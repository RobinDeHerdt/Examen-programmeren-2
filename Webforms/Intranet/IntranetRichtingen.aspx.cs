using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IntranetRichtingen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Richting richting = new Richting();

        try
        {
            if (Request.QueryString["idToDelete"] != null)
            {

                richting.GetAllRichtingenGesorteerdByNaam().Close();
                int idToDelete = int.Parse(Request.QueryString["idToDelete"]);
                richting.DeleteRichting(idToDelete);
            }
        }
        catch 
        {
            lblError.Text = "Oops! Er ging iets mis. De kans is groot dat je de richting niet kan verwijderen omdat er nog klasgroepen aan verbonden zijn. Gelieve de klasgroepen eerst te verwijderen.";
            lblError.Visible = true;
        }
        richtingRepeater.DataSource = richting.GetAllRichtingenGesorteerdByNaam();
        richtingRepeater.DataBind();
    }

    protected void insertRichtingen_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Richting richting = new Richting();
            string naam = txtRichtingNaam.Text;
            string omschrijving = txtRichtingOmschrijving.Text;
            richting.InsertRichting(naam, omschrijving);

            richtingRepeater.DataSource = richting.GetAllRichtingenGesorteerdByNaam();
            richtingRepeater.DataBind();
        }
    }
}