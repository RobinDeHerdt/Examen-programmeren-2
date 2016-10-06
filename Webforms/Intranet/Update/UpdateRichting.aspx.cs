using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Intranet_Update_UpdateRichting : System.Web.UI.Page
{
    Richting richting = new Richting();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["idToEdit"] != null)
            {
                string richtingnaam = "";
                string omschrijving = "";

                try
                {
                    int richtingId = int.Parse(Request.QueryString["idToEdit"]);

                    foreach (DbDataRecord item in richting.GetRichtingById(richtingId))
                    {
                        richtingnaam = item.GetValue(1).ToString();
                        omschrijving = item.GetValue(2).ToString();
                    }
                    lblStudentNaam.Text = "Update richting: " + richtingnaam;

                    txtRichting.Text = richtingnaam;
                    txtOmschrijving.Text = omschrijving;
                }
                catch
                {
                    lblError.Text = "Er ging iets mis. Deze student werd niet teruggevonden in de database.";
                }
            }
        }
    }

    protected void updateRichting_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            string richtingnaam     = txtRichting.Text;
            string omschrijving   = txtOmschrijving.Text;

            try
            {
                int richtingId = int.Parse(Request.QueryString["idToEdit"]);

                richting.UpdateRichting(richtingnaam, omschrijving, richtingId);

                Server.Transfer("~/Intranet/IntranetRichtingen.aspx");
            }
            catch (Exception error)
            {
                lblError.Text = "Oops! Er ging iets fout. Error: " + error;
            }

        }
    }
}