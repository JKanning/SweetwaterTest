using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

namespace SweetwaterTest
{
    public partial class SweetwaterComments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayComments();
            UpdateShipDate();
        }

        private void DisplayComments()
        {
            MySql.Data.MySqlClient.MySqlConnection cn;
            cn = new MySql.Data.MySqlClient.MySqlConnection();

            string strComments;

            try
            {
                cn.ConnectionString = WebConfigurationManager.ConnectionStrings["strConnectionString"].ConnectionString;
                cn.Open();
            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                txtCandy.Text = "Connection Error. Please contact the web admin.";
            }

            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = "sweetwater_test";
            cm.Connection = cn;
            cm.CommandType = CommandType.TableDirect;
            MySqlDataReader dr = cm.ExecuteReader();

            while(dr.Read())
            {
                //-- Search comments for the following categories (assuming each comment only goes into one category):
                //-- improvement: make searches case insensitive
                strComments = dr[1].ToString();

                if (strComments.Contains("candy") || strComments.Contains("CANDY") || strComments.Contains("smarties") || strComments.Contains("Taffy"))
                    txtCandy.Text = txtCandy.Text + dr[0].ToString() + ": " + strComments + "\r\n";

                else if (strComments.Contains("call") || strComments.Contains("CALL") || strComments.Contains("contact"))
                    txtCallMe.Text = txtCallMe.Text + dr[0].ToString() + ": " + strComments + "\r\n";

                else if (strComments.Contains("referred") || strComments.Contains("REFERRED") || strComments.Contains("refer"))
                    txtReferred.Text = txtReferred.Text + dr[0].ToString() + ": " + strComments + "\r\n";

                else if (strComments.Contains("signature") || strComments.Contains("SIGNATURE"))
                    txtSignature.Text = txtSignature.Text + dr[0].ToString() + ": " + strComments + "\r\n";

                else
                    txtDisplay.Text = txtDisplay.Text + dr[0].ToString() + ": " + strComments + "\r\n";

            }
            cn.Close();
        }

        private void UpdateShipDate()
        {
            MySql.Data.MySqlClient.MySqlConnection cn;
            MySql.Data.MySqlClient.MySqlConnection cnUpdate;

            cn = new MySql.Data.MySqlClient.MySqlConnection();
            cnUpdate = new MySql.Data.MySqlClient.MySqlConnection();

            string strComments;
            string strUpdate;
            int loc;
            string strDate;

            try
            {
                cn.ConnectionString = WebConfigurationManager.ConnectionStrings["strConnectionString"].ConnectionString;
                cn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                txtCandy.Text = "Connection Error. Please contact the web admin.";
            }

            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = "sweetwater_test";
            cm.Connection = cn;
            cm.CommandType = CommandType.TableDirect;
            MySqlDataReader dr = cm.ExecuteReader();


            //-- update info
            cnUpdate.ConnectionString = WebConfigurationManager.ConnectionStrings["strConnectionString"].ConnectionString;
            MySqlCommand cmUpdate = new MySqlCommand();
            cmUpdate.CommandText = "sweetwater_test";
            cmUpdate.Connection = cnUpdate;


            while (dr.Read())
            {
                strComments = dr[1].ToString();

                loc = strComments.IndexOf("Expected Ship Date");

                if (loc > 0)
                {
                    //txtTest.Text = txtTest.Text + dr[0].ToString() + ": " + loc.ToString() + "\r\n";
                    //txtTest.Text = txtTest.Text + strComments.Substring(loc + 20);
                    
                    //-- assuming 8 characters for the date
                    strDate = strComments.Substring(loc + 20, 8);

                    strUpdate = "UPDATE sweetwater_test SET shipdate_expected = '" + strDate + "' WHERE orderid = " + dr[0];
                    //txtTest.Text = txtTest.Text + strUpdate + "\r\n";

                    //-- update table
                    cmUpdate.CommandText = strUpdate;
                    cnUpdate.Open();
                    cmUpdate.ExecuteNonQuery();
                    cnUpdate.Close();
                    
                    //txtTest.Text = txtTest.Text + "\r\n";
                }

            }
            cn.Close();
        }

    }
}