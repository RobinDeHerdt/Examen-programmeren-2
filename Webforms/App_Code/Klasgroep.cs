using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Klasgroep
{
    private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDbSchool"].ConnectionString);

    public Klasgroep()
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

    public SqlDataReader GetAllKlassenGesorteerdByNaam()
    {
        string query = "SELECT tblKlasgroep.klasgroep_id, tblKlasgroep.naam, tblKlasgroep.klascode, tblRichting.naam AS richtingnaam FROM tblKlasgroep JOIN tblRichting ON tblKlasgroep.richting_id=tblRichting.richting_id ORDER BY tblKlasgroep.naam;";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllKlassenGesorteerdByKlascode()
    {
        string query = "SELECT tblKlasgroep.klasgroep_id, tblKlasgroep.naam, tblKlasgroep.klascode, tblRichting.naam AS richtingnaam FROM tblKlasgroep JOIN tblRichting ON tblKlasgroep.richting_id=tblRichting.richting_id ORDER BY tblKlasgroep.klascode;";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllKlasgroepenWithRichting()
    {
        string query = "SELECT tblKlasgroep.klasgroep_id, tblKlasgroep.naam, tblKlasgroep.klascode, tblRichting.naam AS richtingnaam FROM tblKlasgroep JOIN tblRichting ON tblKlasgroep.richting_id=tblRichting.richting_id;";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllKlassenGesorteerdByRichting()
    {
        string query = "SELECT tblKlasgroep.klasgroep_id, tblKlasgroep.naam, tblKlasgroep.klascode, tblRichting.naam AS richtingnaam FROM tblKlasgroep JOIN tblRichting ON tblKlasgroep.richting_id = tblRichting.richting_id ORDER BY richtingnaam";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllKlassenInfoById(int id)
    {
        string query = "SELECT tblKlasgroep.naam AS klasnaam, tblRichting.naam AS richtingnaam, tblKlasgroep.klascode, tblDocent.docent_id, tblRichting.richting_id, klasgroep_id FROM tblKlasgroep JOIn tblRichting ON tblKlasgroep.richting_id=tblRichting.richting_id JOIN tblDocent ON tblKlasgroep.docent_id=tblDocent.docent_id WHERE tblKlasgroep.klasgroep_id=@id;";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;

        return cmd.ExecuteReader();
    }

    public int GetKlasGroepId(string klasgroep)
    {
        int klasgroep_id = 0;
       
        string query = "SELECT klasgroep_id FROM tblKlasgroep WHERE naam = @klasgroep";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@klasgroep", SqlDbType.NVarChar);
        cmd.Parameters["@klasgroep"].Value = klasgroep;
        klasgroep_id = (int)cmd.ExecuteScalar();

        return klasgroep_id;
    }
    
    public bool InsertKlas(string klasnaam, string klascode,int docent_id, int richting_id)
    {
        string query = "INSERT INTO tblKlasgroep(naam, klascode, richting_id, docent_id) values(@klasnaam, @klascode, @richting_id, @docent_id)";

        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@klasnaam", SqlDbType.NVarChar);
        cmd.Parameters["@klasnaam"].Value = klasnaam;
        cmd.Parameters.Add("@klascode", SqlDbType.NVarChar);
        cmd.Parameters["@klascode"].Value = klascode;
        cmd.Parameters.Add("@richting_id", SqlDbType.Int);
        cmd.Parameters["@richting_id"].Value = richting_id;
        cmd.Parameters.Add("@docent_id", SqlDbType.Int);
        cmd.Parameters["@docent_id"].Value = docent_id;

        cmd.ExecuteNonQuery();

        return true;
    }

    public bool DeleteKlasgroep(int id)
    {
        string query = "DELETE FROM tblKlasgroep WHERE klasgroep_id = @id";

        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;
        cmd.ExecuteNonQuery();

        return true;
    }

    public bool UpdateKlasgroep(string klascode, string klasnaam, int richting_id, int docent_id, int klasgroep_id)
    {
        string query = "UPDATE tblKlasgroep SET klascode=@klascode, naam=@klasnaam, richting_id=@richting_id, docent_id=@docent_id WHERE klasgroep_id=@klasgroep_id;";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@klascode", SqlDbType.NVarChar);
        cmd.Parameters["@klascode"].Value = klascode;
        cmd.Parameters.Add("@klasnaam", SqlDbType.NVarChar);
        cmd.Parameters["@klasnaam"].Value = klasnaam;
        cmd.Parameters.Add("@richting_id", SqlDbType.Int);
        cmd.Parameters["@richting_id"].Value = richting_id;
        cmd.Parameters.Add("@docent_id", SqlDbType.Int);
        cmd.Parameters["@docent_id"].Value = docent_id;
        cmd.Parameters.Add("@klasgroep_id", SqlDbType.Int);
        cmd.Parameters["@klasgroep_id"].Value = klasgroep_id;

        cmd.ExecuteNonQuery();

        return true;
    }
}