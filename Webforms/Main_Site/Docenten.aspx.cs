using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Docenten : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Docent docent = new Docent();

        if (Request.QueryString["sort"] != null)
        {
            string sortBy = Request.QueryString["sort"];

            switch (sortBy)
            {
                case "voornaam":
                    docentRepeater.DataSource = docent.GetAllDocentenGesorteerdByVoornaam();
                    break;
                case "achternaam":
                    docentRepeater.DataSource = docent.GetAllDocentenGesorteerdByAchternaam();
                    break;
                case "klascode":
                    docentRepeater.DataSource = docent.GetAllDocentenGesorteerdByKlas();
                    break;
                case "email":
                    docentRepeater.DataSource = docent.GetAllDocentenGesorteerdByEmail();
                    break;
                default:
                    docentRepeater.DataSource = docent.GetAllDocentenGesorteerdByKlas();
                    break;
            }
            docentRepeater.DataBind();
        }
        else 
        {
            docentRepeater.DataSource = docent.GetAllDocentenGesorteerdByVoornaam();
            docentRepeater.DataBind();
        }
        
            
    
    }
}