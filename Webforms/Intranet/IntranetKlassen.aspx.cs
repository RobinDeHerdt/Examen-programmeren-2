using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IntranetKlassen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Klasgroep klasgroep = new Klasgroep();
        Richting richting = new Richting();
        Docent docent = new Docent();

        if (!IsPostBack)
        {
            foreach (DbDataRecord item in richting.GetAllRichtingen()) 
            {
                dropDownRichtingen.Items.Add(item.GetValue(1).ToString());
            }

            foreach (DbDataRecord item in docent.GetAllDocentenZonderKlasGesorteerdByAchternaam())
            {
                dropDownDocenten.Items.Add(item.GetValue(2).ToString() + "," + item.GetValue(1).ToString());
            }
        }

        if (Request.QueryString["idToDelete"] != null)
        {
            try
            {
                int idToDelete = int.Parse(Request.QueryString["idToDelete"]);
                klasgroep.DeleteKlasgroep(idToDelete);
            }
            catch
            {
                lblError.Text = "Oops! Er ging iets mis. De kans is groot dat je deze klas niet kan verwijderen omdat er nog studenten in zitten. Gelieve eerst de studenten naar een andere klas te verplaatsen. Probeer dan nog een keer.";
                lblError.Visible = true;
            }
        }

        if (Request.QueryString["sort"] != null)
        {

            string sortBy = Request.QueryString["sort"];

            switch (sortBy)
            {
                case "klascode":
                    klasgroepgRepeater.DataSource = klasgroep.GetAllKlassenGesorteerdByKlascode();
                    break;
                case "naam":
                    klasgroepgRepeater.DataSource = klasgroep.GetAllKlassenGesorteerdByNaam();
                    break;
                case "richting":
                    klasgroepgRepeater.DataSource = klasgroep.GetAllKlassenGesorteerdByRichting();
                    break;
                default:
                    klasgroepgRepeater.DataSource = klasgroep.GetAllKlassenGesorteerdByNaam();
                    break;
            }
            klasgroepgRepeater.DataBind();
        }
        else
        {
            klasgroepgRepeater.DataSource = klasgroep.GetAllKlasgroepenWithRichting();
            klasgroepgRepeater.DataBind();
        }
    }

    protected void insertKlas_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Richting richting = new Richting();
            Klasgroep klasgroep = new Klasgroep();
            Docent docent = new Docent();

            string naam = txtVolledigeKlasNaam.Text;
            string klascode = txtKlascode.Text;
            string richtingnaam = dropDownRichtingen.SelectedValue;
            string volledigenaam = dropDownDocenten.SelectedValue;

            int id = 0;
            int docent_id = 0;

            string[] splitnaam = volledigenaam.Split(',');

            
            // Response.Write("INDEX 0 " + splitnaam[0] + " - INDEX 1: " + splitnaam[1]);
            // Achternaam: index 0 ; Voornaam: index 1

            id = richting.GetRichtingId(richtingnaam);
            docent_id = docent.GetDocentId(splitnaam[1], splitnaam[0]);

            klasgroep.InsertKlas(naam, klascode, docent_id ,id);

            klasgroepgRepeater.DataSource = klasgroep.GetAllKlasgroepenWithRichting();
            klasgroepgRepeater.DataBind();
        }
    }
}