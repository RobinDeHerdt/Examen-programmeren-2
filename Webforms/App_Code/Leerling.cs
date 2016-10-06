using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class Leerling
{
    private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionDbSchool"].ConnectionString);

    public Leerling()
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

    public SqlDataReader GetAllStudentenGesorteerdByEmail()
    {
        string query = "SELECT * FROM tblStudent JOIN tblKlasgroep ON tblStudent.klasgroep_id=tblKlasgroep.klasgroep_id ORDER BY tblStudent.email_ouder";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllStudentenGesorteerdByVoornaam()
    {
        string query = "SELECT * FROM tblStudent JOIN tblKlasgroep ON tblStudent.klasgroep_id=tblKlasgroep.klasgroep_id ORDER BY tblStudent.voornaam";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllStudentenGesorteerdByAchternaam()
    {
        string query = "SELECT * FROM tblStudent JOIN tblKlasgroep ON tblStudent.klasgroep_id=tblKlasgroep.klasgroep_id ORDER BY tblStudent.achternaam";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }


    public SqlDataReader GetAllStudentGesorteerdByKlas()
    {
        string query = "SELECT * FROM tblStudent JOIN tblKlasgroep ON tblStudent.klasgroep_id=tblKlasgroep.klasgroep_id ORDER BY tblKlasgroep.klascode";
        SqlCommand cmd = new SqlCommand(query, cn);
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetAllStudentInfoById(int id)
    {
        string query = "SELECT * FROM tblStudent JOIN tblKlasgroep ON tblStudent.klasgroep_id=tblKlasgroep.klasgroep_id WHERE student_id = @id";

        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;
        
        return cmd.ExecuteReader();
    }

    public SqlDataReader GetRapportById(int id)
    {
        string query = "SELECT voornaam, achternaam, rapport_wiskunde, rapport_frans, rapport_engels, rapport_sport, rapport_biologie FROM tblStudent WHERE student_id = @id;";

        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;

        return cmd.ExecuteReader();
    }

    public bool InsertStudent(string voornaam, string achternaam, string email, int klasgroep_id)
    {
        string query = "INSERT INTO tblStudent(voornaam, achternaam, email_ouder, klasgroep_id) values(@voornaam, @achternaam, @email, @klasgroep_id)";

        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@voornaam", SqlDbType.NVarChar);
        cmd.Parameters["@voornaam"].Value = voornaam;
        cmd.Parameters.Add("@achternaam", SqlDbType.NVarChar);
        cmd.Parameters["@achternaam"].Value = achternaam;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar);
        cmd.Parameters["@email"].Value = email;
        cmd.Parameters.Add("@klasgroep_id", SqlDbType.Int);
        cmd.Parameters["@klasgroep_id"].Value = klasgroep_id;

        cmd.ExecuteNonQuery();

        return true;
    }

    public bool DeleteStudent(int id)
    {
        string query = "DELETE FROM tblStudent WHERE student_id = @id";

        SqlCommand cmd = new SqlCommand(query, cn);
        cmd.Parameters.Add("@id", SqlDbType.Int);
        cmd.Parameters["@id"].Value = id;
        cmd.ExecuteNonQuery();

        return true;
    }

    public bool UpdateStudent(string voornaam, string achternaam, string email_ouder, int klasgroep_id, int student_id)
    {
        string query = "UPDATE tblStudent SET voornaam=@voornaam, achternaam=@achternaam, email_ouder=@email, klasgroep_id=@klasgroep_id WHERE student_id=@student_id;";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@voornaam", SqlDbType.NVarChar);
        cmd.Parameters["@voornaam"].Value = voornaam;
        cmd.Parameters.Add("@achternaam", SqlDbType.NVarChar);
        cmd.Parameters["@achternaam"].Value = achternaam;
        cmd.Parameters.Add("@email", SqlDbType.NVarChar);
        cmd.Parameters["@email"].Value = email_ouder;
        cmd.Parameters.Add("@klasgroep_id", SqlDbType.Int);
        cmd.Parameters["@klasgroep_id"].Value = klasgroep_id;
        cmd.Parameters.Add("@student_id", SqlDbType.Int);
        cmd.Parameters["@student_id"].Value = student_id;

        cmd.ExecuteNonQuery();

        return true;
    }

    public bool UpdateRapport(float vak1, float vak2, float vak3, float vak4, float vak5, int id)
    {
        string query = "UPDATE tblStudent SET rapport_wiskunde=@vak1, rapport_frans=@vak2, rapport_engels=@vak3, rapport_sport=@vak4, rapport_biologie=@vak5 WHERE student_id=@student_id;";
        SqlCommand cmd = new SqlCommand(query, cn);

        cmd.Parameters.Add("@vak1", SqlDbType.Float);
        cmd.Parameters["@vak1"].Value = vak1;
        cmd.Parameters.Add("@vak2", SqlDbType.Float);
        cmd.Parameters["@vak2"].Value = vak2;
        cmd.Parameters.Add("@vak3", SqlDbType.Float);
        cmd.Parameters["@vak3"].Value = vak3;
        cmd.Parameters.Add("@vak4", SqlDbType.Float);
        cmd.Parameters["@vak4"].Value = vak4;
        cmd.Parameters.Add("@vak5", SqlDbType.Float);
        cmd.Parameters["@vak5"].Value = vak5;
        cmd.Parameters.Add("@student_id", SqlDbType.Int);
        cmd.Parameters["@student_id"].Value = id;

        cmd.ExecuteNonQuery();

        return true;
    }
}