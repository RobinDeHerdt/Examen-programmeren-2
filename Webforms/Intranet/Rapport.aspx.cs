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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["student_id"] != null)
            {
                string voornaam     = "";
                string achternaam   = "";
               
                try
                {
                    int studentId = int.Parse(Request.QueryString["student_id"]);
                    
                    int counter = 0;
                    string[] punten = new string[5];

                    foreach (DbDataRecord item in leerling.GetRapportById(studentId))
                    {
                        voornaam =      item.GetValue(0).ToString();
                        achternaam =    item.GetValue(1).ToString();

                        for (int i = 2; i < 7; i++)
                        {
                            punten[counter] = item.GetValue(i).ToString();
                            counter++;
                        }
                    }

                    if (voornaam != "" && achternaam != "")
                    {
                        lblNaam.Text = "Rapport van " + voornaam + " " + achternaam;

                        txtWiskunde.Text    = punten[0];
                        txtFrans.Text       = punten[1];
                        txtEngels.Text      = punten[2];
                        txtSport.Text       = punten[3];
                        txtBiologie.Text    = punten[4];

                        lblWiskunde.Text    = punten[0];
                        lblFrans.Text       = punten[1];
                        lblEngels.Text      = punten[2];
                        lblSport.Text       = punten[3];
                        lblBiologie.Text    = punten[4]; 
                    }
                    else
                    {
                        lblError.Text = "Er ging iets mis. Deze student werd niet teruggevonden in de database.";
                    }
                }
                catch (Exception error)
                {
                    lblError.Text = "ERROR: " + error;
                }
            }
        }
    }

    protected void updateRapport_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            float vak1 = float.Parse(txtWiskunde.Text);
            float vak2 = float.Parse(txtFrans.Text);
            float vak3 = float.Parse(txtEngels.Text);
            float vak4 = float.Parse(txtSport.Text);
            float vak5 = float.Parse(txtBiologie.Text);

            try
            {
                int studentId = int.Parse(Request.QueryString["student_id"]);

                leerling.UpdateRapport(vak1, vak2, vak3, vak4, vak5, studentId);

                lblWiskunde.Text    = txtWiskunde.Text;
                lblFrans.Text       = txtFrans.Text;
                lblEngels.Text      = txtEngels.Text;
                lblSport.Text       = txtSport.Text;
                lblBiologie.Text    = txtBiologie.Text;
            }
            catch (Exception error)
            {
                lblError.Text = "Oops! Er ging iets fout. Error: " + error;
            }
        } 
    }
}