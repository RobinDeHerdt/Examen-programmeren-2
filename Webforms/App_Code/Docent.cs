using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Docent
{
    private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDbSchool"].ConnectionString);

    public Docent()
    {
        try
        {
            cn.Open();
        }
        catch
        {
            HttpContext.Current.Server.Transfer("~/error/dberror.aspx");
        }
    }

    public SqlDataReader GetAllDocentenGesorteerdByEmail()
    {
        string query = "SELECT * FROM tblDocent JOIN tblKlasgroep ON tblDocent.docent_id=tblKlasgroep.docent_id ORDER BY tblDocent.email";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllDocentenGesorteerdByVoornaam()
    {
        string query = "SELECT * FROM tblDocent JOIN tblKlasgroep ON tblDocent.docent_id=tblKlasgroep.docent_id ORDER BY tblDocent.voornaam";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllDocentenGesorteerdByAchternaam()
    {
        string query = "SELECT * FROM tblDocent JOIN tblKlasgroep ON tblDocent.docent_id=tblKlasgroep.docent_id ORDER BY tblDocent.achternaam";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }


    public SqlDataReader GetAllDocentenGesorteerdByKlas()
    {
        string query = "SELECT * FROM tblDocent JOIN tblKlasgroep ON tblDocent.docent_id=tblKlasgroep.docent_id ORDER BY tblKlasgroep.klascode";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllDocentenZonderKlasGesorteerdByAchternaam()
    {
        string query = "SELECT * FROM tblDocent ORDER BY achternaam";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }
    public SqlDataReader GetAllDocentenZonderKlasGesorteerdByVoornaam()
    {
        string query = "SELECT * FROM tblDocent ORDER BY voornaam";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }
    public SqlDataReader GetAllDocentenZonderKlasGesorteerdByEmail()
    {
        string query = "SELECT * FROM tblDocent ORDER BY email";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetDocentById(int id)
    {
        string query = "SELECT * FROM tblDocent WHERE docent_id=@id;";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;

        return cmd.ExecuteReader();
    }

    public int GetDocentId(string voornaam, string achternaam)
    {
        int docent_id = 0;

        string query = "SELECT docent_id FROM tblDocent WHERE voornaam=@voornaam AND achternaam=@achternaam;";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@voornaam", SqlDbType.NVarChar);
        cmd.Parameters["@voornaam"].Value = voornaam;
        cmd.Parameters.Add("@achternaam", SqlDbType.NVarChar);
        cmd.Parameters["@achternaam"].Value = achternaam;
        docent_id = (int)cmd.ExecuteScalar();

        return docent_id;
    }

    public bool InsertDocent(string voornaam, string achternaam, string email)
    {
        string query = "INSERT INTO tblDocent(voornaam, achternaam, email) values(@voornaam, @achternaam, @email);";

        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@voornaam", SqlDbType.NVarChar);
        cmd.Parameters["@voornaam"].Value = voornaam;
        cmd.Parameters.Add("@achternaam", SqlDbType.NVarChar);
        cmd.Parameters["@achternaam"].Value = achternaam;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar);
        cmd.Parameters["@email"].Value = email;

        cmd.ExecuteNonQuery();

        return true;
    }

    public bool UpdateDocent(string voornaam, string achternaam, string email, int docent_id)
    {
        string query = "UPDATE tblDocent SET voornaam=@voornaam, achternaam=@achternaam, email=@email WHERE docent_id=@docent_id;";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@voornaam", SqlDbType.NVarChar);
        cmd.Parameters["@voornaam"].Value = voornaam;
        cmd.Parameters.Add("@achternaam", SqlDbType.NVarChar);
        cmd.Parameters["@achternaam"].Value = achternaam;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar);
        cmd.Parameters["@email"].Value = email;
        cmd.Parameters.Add("@docent_id", SqlDbType.Int);
        cmd.Parameters["@docent_id"].Value = docent_id;

        cmd.ExecuteNonQuery();

        return true;
    }

    public bool DeleteDocent(int id)
    {
        string query = "DELETE FROM tblDocent WHERE docent_id = @id";

        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;
        cmd.ExecuteNonQuery();

        return true;
    }
}