using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

public partial class Administrator_FTP_USER_Master : System.Web.UI.Page
{
    CCommon oCmn = new CCommon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GEtdetails();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Insert();
    }

    public string Insert()
    {

        Int32 i = 0;
        string sMsg1 = "";
        try
        {

            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("ADD_FTPUSER", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FROMID", TextBox1.Text.Trim());
                command.Parameters.AddWithValue("@TOID", TextBox2.Text.Trim());
                command.Parameters.AddWithValue("@ADDBY", Session["userid"].ToString());

                con.Open();
                i = command.ExecuteNonQuery();
                con.Close();
                if (i > 0)
                {
                    StatusLabel.Text = "USER Added Successfully...";
                    StatusLabel.ForeColor = System.Drawing.Color.Green;

                    GEtdetails();

                }
                else
                {
                    StatusLabel.Text = "Please Check Employee Code..";
                    StatusLabel.ForeColor = System.Drawing.Color.Red;

                }
            }

        }
        catch
        {

        }

        return sMsg1;

    }

    protected void GEtdetails()
    {
            using (SqlConnection con = new SqlConnection(oCmn.AppConnectionString))
            {
                SqlCommand command = new SqlCommand("getftpuser", con);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sa = new SqlDataAdapter();
                sa.SelectCommand=command;

                DataTable dt = new DataTable();
                sa.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();
          
                
            }           

    }
}
