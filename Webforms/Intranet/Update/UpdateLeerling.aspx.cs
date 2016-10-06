using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rapport : System.Web.UI.Page
{
    Leerling leerling = new Leerling();
    Klasgroep klasgroep = new Klasgroep();

    protected void Page_Load(object sender, EventArgs e)
    { 
        if(!IsPostBack)
        { 
        if (Request.QueryString["idToEdit"] != null)
        {
            string voornaam     = "";
            string achternaam   = "";
            string email_ouder  = "";
            string klascode     = "";

            try
            {
                int studentId = int.Parse(Request.QueryString["idToEdit"]);

                foreach (DbDataRecord item in leerling.GetAllStudentInfoById(studentId)) 
                {
                    voornaam    = item.GetValue(1).ToString();
                    achternaam  = item.GetValue(2).ToString();
                    email_ouder = item.GetValue(3).ToString();
                    klascode    = item.GetValue(11).ToString();
                }

                // Vul dropdownmenu
                foreach (DbDataRecord item in klasgroep.GetAllKlassenGesorteerdByKlascode())
                {
                    dropDownKlasgroepen.Items.Add(item.GetValue(1).ToString()); // 1 voor volledige klasnaam; 2 voor klascode
                }

                if (voornaam != "" && achternaam != "")
                {
                    lblStudentNaam.Text = "Update student: " + voornaam + " " + achternaam;

                    txtVoornaam.Text = voornaam;
                    txtAchternaam.Text = achternaam;
                    txtEmail.Text = email_ouder;
                    dropDownKlasgroepen.SelectedValue = klascode;
                }
                else
                {
                    lblError.Text = "Er ging iets mis. Deze student werd niet teruggevonden in de database.";
                }
            }
            catch
            {
                lblError.Text = "Er ging iets mis. Deze student werd niet teruggevonden in de database.";
            }
        }
        }
    }

    protected void insertLeerling_Click(object sender, EventArgs e) // Update student
    {
        if (IsValid)
        {
            string voornaam = txtVoornaam.Text;
            string achternaam = txtAchternaam.Text;
            string emailouder = txtEmail.Text;
            string klascode = dropDownKlasgroepen.SelectedValue;

            try
            {
                int klasgroep_id = klasgroep.GetKlasGroepId(klascode);
                int studentId = int.Parse(Request.QueryString["idToEdit"]);

                leerling.UpdateStudent(voornaam, achternaam, emailouder, klasgroep_id, studentId);

                Server.Transfer("~/Intranet/IntranetLeerlingen.aspx");
            }
            catch (Exception error)
            {
                lblError.Text = "Oops! Er ging iets fout. Error: " + error;
            }
           
        }
    }
}