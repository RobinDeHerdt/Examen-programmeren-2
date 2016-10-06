using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Richting
{
    private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDbSchool"].ConnectionString);

    public Richting()
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

    public SqlDataReader GetAllRichtingen()
    {
        string query = "SELECT * FROM tblRichting";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllRichtingenGesorteerdByNaam()
    {
        string query = "SELECT * FROM tblRichting ORDER BY naam";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetRichtingById(int id)
    {
        string query = "SELECT * FROM tblRichting WHERE richting_id=@id;";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;

        return cmd.ExecuteReader();
    }


    public int GetRichtingId(string richtingnaam)
    {
        int richting_id = 0;

        string query = "SELECT richting_id FROM tblRichting WHERE naam = @richting_naam";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@richting_naam", SqlDbType.NVarChar);
        cmd.Parameters["@richting_naam"].Value = richtingnaam;
        richting_id = (int)cmd.ExecuteScalar();

        return richting_id;
    }

    public bool InsertRichting(string naam, string omschrijving)
    {
        string query = "INSERT INTO tblRichting(naam, omschrijving) values(@naam, @omschrijving)";

        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.Add("@naam", SqlDbType.NVarChar);
        cmd.Parameters["@naam"].Value = naam;
        cmd.Parameters.Add("@omschrijving", SqlDbType.Text);
        cmd.Parameters["@omschrijving"].Value = omschrijving;
        cmd.ExecuteNonQuery();

        return true;
    }

    public bool DeleteRichting(int id)
    {
        string query = "DELETE FROM tblRichting WHERE richting_id = @id";
      
        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;
        cmd.ExecuteNonQuery();

        return true;
    }

    public bool UpdateRichting(string richtingnaam, string omschrijving, int richting_id)
    {
        string query = "UPDATE tblRichting SET naam=@naam, omschrijving=@omschrijving WHERE richting_id=@richting_id;";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@naam", SqlDbType.NVarChar);
        cmd.Parameters["@naam"].Value = richtingnaam;
        cmd.Parameters.Add("@omschrijving", SqlDbType.NVarChar);
        cmd.Parameters["@omschrijving"].Value = omschrijving;
        cmd.Parameters.Add("@richting_id", SqlDbType.Int);
        cmd.Parameters["@richting_id"].Value = richting_id;

        cmd.ExecuteNonQuery();

        return true;
    }
}