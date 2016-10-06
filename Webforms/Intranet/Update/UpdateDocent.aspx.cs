using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Intranet_Update_UpdateDocent : System.Web.UI.Page
{
    Docent docent = new Docent();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["idToEdit"] != null)
            {
                string voornaam = "";
                string achternaam = "";
                string email = "";

                try
                {
                    int docentId = int.Parse(Request.QueryString["idToEdit"]);

                    foreach (DbDataRecord item in docent.GetDocentById(docentId))
                    {
                        voornaam = item.GetValue(1).ToString();
                        achternaam = item.GetValue(2).ToString();
                        email = item.GetValue(3).ToString();
                    }
                    lblStudentNaam.Text = "Update docent: " + voornaam + " " + achternaam;

                    txtVoornaam.Text = voornaam;
                    txtAchternaam.Text = achternaam;
                    txtEmail.Text = email;
                }
                catch
                {
                    lblError.Text = "Er ging iets mis. Deze student werd niet teruggevonden in de database.";
                }
            }
        }
    }

    protected void updateDocent_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            string voornaam     = txtVoornaam.Text;
            string achternaam   = txtAchternaam.Text;
            string email        = txtEmail.Text;

            try
            {
                int docentId = int.Parse(Request.QueryString["idToEdit"]);

                docent.UpdateDocent(voornaam, achternaam, email, docentId);

                Server.Transfer("~/Intranet/IntranetDocenten.aspx");
            }
            catch (Exception error)
            {
                lblError.Text = "Oops! Er ging iets fout. Error: " + error;
            }

        }
    }
}