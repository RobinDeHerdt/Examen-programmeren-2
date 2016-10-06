using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Intranet_Update_UpdateKlasgroep : System.Web.UI.Page
{
    Klasgroep klasgroep = new Klasgroep();
    Docent docent       = new Docent();
    Richting richting   = new Richting();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["idToEdit"] != null)
            {
                string  klascode        = "";
                string  klasnaam        = "";
                string  richtingnaam    = "";
                int     docent_id       = 0 ;

                try
                {
                    int klasgroepId = int.Parse(Request.QueryString["idToEdit"]);

                    foreach (DbDataRecord item in richting.GetAllRichtingen())
                    {
                        dropDownRichtingen.Items.Add(item.GetValue(1).ToString());
                    }

                    foreach (DbDataRecord item in docent.GetAllDocentenZonderKlasGesorteerdByAchternaam())
                    {
                        dropDownDocenten.Items.Add(item.GetValue(2).ToString() + "," + item.GetValue(1).ToString());
                    }

                    foreach (DbDataRecord item in klasgroep.GetAllKlassenInfoById(klasgroepId))
                    {
                        klasnaam    = item.GetValue(0).ToString();
                        richtingnaam= item.GetValue(1).ToString();
                        klascode    = item.GetValue(2).ToString();
                        docent_id   = (int)item.GetValue(3);
                    }

                    txtKlascode.Text                    = klascode;
                    txtVolledigeKlasnaam.Text           = klasnaam;
                    dropDownRichtingen.SelectedValue    = richtingnaam;
                    dropDownDocenten.SelectedIndex      = docent_id;
                }
                catch (Exception error)
                {
                    lblError.Text = "Er ging iets mis. Deze klas werd niet teruggevonden in de database." + error;
                }
            }
        }
    }

    protected void updateKlasgroep_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            string klascode             = txtKlascode.Text;
            string volledigeklasnaam    = txtVolledigeKlasnaam.Text;
            string richtingnaam         = dropDownRichtingen.SelectedValue;
            string titularisnaam        = dropDownDocenten.SelectedValue;

            string[] splitnaam = titularisnaam.Split(',');
            int docent_id = docent.GetDocentId(splitnaam[1], splitnaam[0]);

            int richting_id = richting.GetRichtingId(richtingnaam);

            try
            {
                int klasgroepId = int.Parse(Request.QueryString["idToEdit"]);

                klasgroep.UpdateKlasgroep(klascode, volledigeklasnaam, richting_id, docent_id , klasgroepId);

                Server.Transfer("~/Intranet/IntranetKlassen.aspx");
            }
            catch (Exception error)
            {
                lblError.Text = "Oops! Er ging iets fout. Error: " + error;
            }

        }
    }
}