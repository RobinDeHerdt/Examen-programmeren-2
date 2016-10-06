using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IntranetDocenten : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        Docent docent = new Docent();
        Klasgroep klasgroep = new Klasgroep();

        if (Request.QueryString["idToDelete"] != null)
        {
            try
            {
                int idToDelete = int.Parse(Request.QueryString["idToDelete"]);
                docent.DeleteDocent(idToDelete);
            }
            catch
            {
                lblError.Text = "Oops! Er ging iets mis. De kans is groot dat deze docent nog titularis is van een klas. Gelieve eerst een andere titularis te verbinden aan deze klas.";
                lblError.Visible = true;
            }

            try
            {
                docentRepeater.DataSource = docent.GetAllDocentenZonderKlasGesorteerdByAchternaam();
                docentRepeater.DataBind();
            }
            catch
            {
                lblError.Text = "Er ging iets mis met het ophalen van de data.";
                lblError.Visible = true;
            }
        }     
            else
            {
                if (Request.QueryString["sort"] != null)
                {

                    string sortBy = Request.QueryString["sort"];

                    switch (sortBy)
                    {
                        case "achternaam":
                            docentRepeater.DataSource = docent.GetAllDocentenZonderKlasGesorteerdByAchternaam();
                            break;
                        case "voornaam":
                            docentRepeater.DataSource = docent.GetAllDocentenZonderKlasGesorteerdByVoornaam();
                            break;
                        case "email":
                        docentRepeater.DataSource = docent.GetAllDocentenZonderKlasGesorteerdByEmail();
                            break;
                        default:
                            docentRepeater.DataSource = docent.GetAllDocentenGesorteerdByAchternaam();
                            break;
                    }
                    docentRepeater.DataBind();
                }
                else
                {
                    docentRepeater.DataSource = docent.GetAllDocentenZonderKlasGesorteerdByAchternaam();
                    docentRepeater.DataBind();
                }
            }
    }

    protected void insertLeerling_Click(object sender, EventArgs e)
    {
        if (IsValid)
        { 
            string achterNaam   = txtAchternaam.Text;
            string voorNaam     = txtVoornaam.Text;
            string email        = txtEmail.Text;

            try
            {
                Docent docent = new Docent();
                docent.InsertDocent(voorNaam, achterNaam, email);

                docentRepeater.DataSource = docent.GetAllDocentenZonderKlasGesorteerdByAchternaam();
                docentRepeater.DataBind();
            }
            catch(Exception error)
            {
                lblError.Text = "Er ging iets mis met de insert." + error;
            }
            
        }
    }
}