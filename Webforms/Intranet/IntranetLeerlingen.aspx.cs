using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Common;

public partial class IntranetLeerlingen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Leerling leerling = new Leerling();
        Klasgroep klasgroep = new Klasgroep();

        if (!IsPostBack)
        {
            foreach (DbDataRecord item in klasgroep.GetAllKlasgroepenWithRichting())
            {
                dropDownKlasgroepen.Items.Add(item.GetValue(1).ToString());
            }
        }
        
        if (Request.QueryString["idToDelete"] != null)
        {
            try
            {   
                int idToDelete = int.Parse(Request.QueryString["idToDelete"]);
                leerling.DeleteStudent(idToDelete);
            }
            catch
            {
                lblError.Text = "Oops! Er ging iets mis.";
                lblError.Visible = true;
            }
        }

        if (Request.QueryString["idToEdit"] != null)
        {
            try
            {
                int idToEdit = int.Parse(Request.QueryString["idToEdit"]);
            }
            catch
            {
                lblError.Text = "Oops! Er ging iets mis.";
                lblError.Visible = true;
            }
        }

        if (Request.QueryString["sort"] != null)
        {
            string sortBy = Request.QueryString["sort"];

            switch (sortBy)
            {
                case "voornaam":
                    leerlingenRepeater.DataSource = leerling.GetAllStudentenGesorteerdByVoornaam();
                    break;
                case "achternaam":
                    leerlingenRepeater.DataSource = leerling.GetAllStudentenGesorteerdByAchternaam();
                    break;
                case "klasgroep":
                    leerlingenRepeater.DataSource = leerling.GetAllStudentGesorteerdByKlas();
                    break;
                case "email":
                    leerlingenRepeater.DataSource = leerling.GetAllStudentenGesorteerdByEmail();
                    break;
                default:
                    leerlingenRepeater.DataSource = leerling.GetAllStudentenGesorteerdByAchternaam();
                    break;
            }
            leerlingenRepeater.DataBind();
        }
        else
        {
            leerlingenRepeater.DataSource = leerling.GetAllStudentenGesorteerdByVoornaam();
            leerlingenRepeater.DataBind();
        }
    }

    protected void insertLeerling_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Leerling leerling   = new Leerling();
            Klasgroep klasgroep = new Klasgroep();

            string achterNaam   = txtAchternaam.Text;
            string voorNaam     = txtVoornaam.Text;
            string emailOuder   = txtEmail.Text;

            int id = 0;
            string klascode = dropDownKlasgroepen.SelectedValue;
            id = klasgroep.GetKlasGroepId(klascode);
            leerling.InsertStudent(voorNaam, achterNaam, emailOuder, id);

            leerlingenRepeater.DataSource = leerling.GetAllStudentenGesorteerdByAchternaam();
            leerlingenRepeater.DataBind();
        }
    }
}