using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using myInfo;

public partial class OrganizationTree : System.Web.UI.Page
{
    Info obj = new Info();
    OleDbConnection connection;
    SqlConnection sqlcon;
    string connString;

    void Page_Init(object sender, EventArgs e)
    {
        //ViewStateUserKey = Session.SessionID;

        //Session.Timeout = 240;

        //if (Session.Count == 0)
        //{
        //    Session.Abandon();
        //    Response.Redirect("~/InvalidRequest.aspx");
        //}    

    }

    protected void Page_Load(object sender, EventArgs e)
    {        
        try
        {
            //token();
            HideInductionLink();
      

            if (Session["UserID"].ToString() == "101103918" || Session["UserID"].ToString() == "101103919")
            {
                lnkAdmin.Visible = false;
                lnkChangePassword.Visible = false;
                lnkFETracking.Visible = false;
                LnkbtnQueryBuilder.Visible = false;
                lnkDedupSearch.Visible = false;
                lnkSalaryView.Visible = false;
                LinkButton1.Visible = false;
                LinkButton2.Visible = false;
                lnkSoftware.Visible = false;
            }

            if (Session.Count == 0)
                Response.Redirect("Default.aspx?zone=" + HttpContext.Current.Session["Zone"]);

            string[] strRole = Session["RoleId"].ToString().Split(',');
            bool isAdmin = false;
            foreach (string str in strRole)
            {
                if (str == "1")
                    isAdmin = true;
            }
            if (isAdmin)
                lnkAdmin.Visible = true;
            else
                lnkAdmin.Visible = false;

            CCommon objConn = new CCommon();
            sqlcon = new SqlConnection(objConn.AppConnectionString);

            connString = objConn.ConnectionString;  //Sir
            connection = new OleDbConnection(connString);
            if (!IsPostBack)
            {

                logedindetails();

                Session["ActivityId"] = "";
                Session["ProductId"] = "";
                Session["ClientId"] = "";


                string CenterId1 = HttpContext.Current.Session["CentreId"].ToString();
                string UserId2 = HttpContext.Current.Session["UserId"].ToString();

                OleDbParameter[] stCenter = new OleDbParameter[2];

                stCenter[0] = new OleDbParameter("@centre_ID", OleDbType.VarChar);
                stCenter[0].Value = CenterId1;
                stCenter[1] = new OleDbParameter("@user_Id", OleDbType.VarChar);
                stCenter[1].Value = UserId2;
                OleDbDataReader drCentre = OleDbHelper.ExecuteReader(connString, CommandType.StoredProcedure, "sp_strCentre", stCenter);

                TreeNode tnClient, tnProduct, tnActivity, tnCentre;

                while (drCentre.Read())
                {
                    tnCentre = new TreeNode(drCentre["Centre_Name"].ToString());
                    tnCentre.SelectAction = TreeNodeSelectAction.Expand;

                   tvOrganization.Nodes.Add(tnCentre);

                    string UserIdActivity = HttpContext.Current.Session["UserId"].ToString();
                    OleDbParameter[] stActivity = new OleDbParameter[2];
                    stActivity[0] = new OleDbParameter("@Centre_Id", OleDbType.VarChar);
                    stActivity[0].Value = drCentre["Centre_Id"].ToString();
                    stActivity[1] = new OleDbParameter("@user_Id", OleDbType.VarChar);
                    stActivity[1].Value = UserIdActivity;
                    OleDbDataReader drActivity = OleDbHelper.ExecuteReader(connection, CommandType.StoredProcedure, "sp_strActivity", stActivity);

                    while (drActivity.Read())
                    {

                        tnActivity = new TreeNode(drActivity["Activity_Name"].ToString());
                        tnActivity.SelectAction = TreeNodeSelectAction.Expand;
                        tnCentre.ChildNodes.Add(tnActivity);

                        string UserProduct = HttpContext.Current.Session["UserId"].ToString();
                        OleDbParameter[] paramProduct = new OleDbParameter[3];
                        paramProduct[0] = new OleDbParameter("@Centre_Id", OleDbType.VarChar);
                        paramProduct[0].Value = drCentre["Centre_Id"].ToString();
                        paramProduct[1] = new OleDbParameter("@Activity_Id", OleDbType.VarChar);
                        paramProduct[1].Value = drActivity["Activity_Id"].ToString();
                        paramProduct[2] = new OleDbParameter("@user_Id", OleDbType.VarChar);
                        paramProduct[2].Value = UserProduct;
                        string strY = "";
                        OleDbDataReader drProduct = OleDbHelper.ExecuteReader(connection, CommandType.StoredProcedure, "sp_strProduct", paramProduct);


                        while (drProduct.Read())
                        {

                            tnProduct = new TreeNode(drProduct["Product_Name"].ToString());

                            tnActivity.ChildNodes.Add(tnProduct);

                            string UserCenter = HttpContext.Current.Session["UserId"].ToString();
                            OleDbParameter[] strClient1 = new OleDbParameter[4];
                            strClient1[0] = new OleDbParameter("@Centre_Id", OleDbType.VarChar);
                            strClient1[0].Value = drCentre["Centre_Id"].ToString();
                            strClient1[1] = new OleDbParameter("@Activity_Id", OleDbType.VarChar);
                            strClient1[1].Value = drActivity["Activity_Id"].ToString();
                            strClient1[2] = new OleDbParameter("@user_Id", OleDbType.VarChar);
                            strClient1[2].Value = UserCenter;
                            strClient1[3] = new OleDbParameter("@Product_Id", OleDbType.VarChar);
                            strClient1[3].Value = drProduct["Product_Id"].ToString();
                            OleDbDataReader drClient = OleDbHelper.ExecuteReader(connection, CommandType.StoredProcedure, "sp_strClient", strClient1);

                            while (drClient.Read())
                            {
                                if (drClient["Client_Name"].ToString().Trim() != "")
                                {
                                    tnClient = new TreeNode(drClient["Client_Name"].ToString());

                                    tnClient.Value = drActivity["Activity_Id"].ToString() + "," +
                                                     drProduct["Product_Id"].ToString() + "," +
                                                     drClient["Client_Id"].ToString() + "," +
                                                     drActivity["Activity_Name"].ToString() + "/" +
                                                     drProduct["Product_Name"].ToString();
                                    tnProduct.ChildNodes.Add(tnClient);
                                    strY = "";


                                }
                                else
                                {

                                    strY = "Y";
                                }
                            }
                            drClient.Close();
                            if (strY != "Y")
                            {
                                tnProduct.SelectAction = TreeNodeSelectAction.Expand;

                            }
                            else
                            {
                                tnProduct.SelectAction = TreeNodeSelectAction.Select;
                                tnProduct.Value = drActivity["Activity_Id"].ToString() + "," +
                                                drProduct["Product_Id"].ToString() + ", ," +
                                                drActivity["Activity_Name"].ToString() + "/" +
                                                drProduct["Product_Name"].ToString();
                                strY = "";
                            }

                        }
                        drProduct.Close();
                    }
                    drActivity.Close();
                }
                drCentre.Close();

                string[] sRoleId = Session["RoleId"].ToString().Split(',');
                foreach (string str in sRoleId)
                {

                    if (str == "20" || str == "1")
                    {
                        lnkDedupSearch.Visible = true;
                    }

                    if (str == "21" || str == "1")
                    {
                        lnkFETracking.Visible = true;
                    }
                    else
                    {
                        lnkFETracking.Visible = false;
                    }
                }

            }

            Label1.Text = Request.UserHostName.ToString();

            string strIpAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (strIpAddress == null)
            {
                Label1.Text = Request.ServerVariables["REMOTE_ADDR"];
            }

            Get_EmployeeDetails();
          

        }

        catch (Exception ex)
        {
            Response.Redirect("~/Error20.aspx");
        }
    }



    //public void token()
    //{
    //    //string getToken = obj.GetRandomString(10);

    //    DataSet ds = new DataSet();
    //   // ds = obj.Get_TokenUpdate();

    //    if (Session["Token"].ToString() == ds.Tables[0].Rows[0]["Token"].ToString())
    //    {

    //        //Session.Remove("Token");

    //        //Random objrnd = new Random();
    //        //int tokenstring = objrnd.Next();
    //        //obj.UpdateTokenDetail(tokenstring);

    //        //Session["Token"] = tokenstring;
    //    }
    //    else
    //    {
    //        //if (Session["CookiesToken"].ToString() == ds.Tables[0].Rows[0]["Token"].ToString())
    //        //{
    //        //    //Response.Redirect("~/Error20.aspx");
    //        //}
    //        //else
    //        //{
    //            Response.Redirect("~/Error20.aspx");
    //        //}
    //    }
    //}
    public void HideInductionLink()
    {

        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
 

        //SqlCommand sqlcmd = new SqlCommand();
        //sqlcmd.Connection = sqlcon;
        //sqlcmd.CommandType = CommandType.StoredProcedure;
        //sqlcmd.CommandText = "sp_GetDojNEW";
        //sqlcmd.CommandTimeout = 0;

        //SqlParameter Emp_id = new SqlParameter();
        //Emp_id.SqlDbType = SqlDbType.VarChar;
        //Emp_id.Value = Session["UserId"].ToString(); 
        //Emp_id.ParameterName = "@Emp_id";
        //sqlcmd.Parameters.Add(Emp_id);

        //SqlDataAdapter sqlda2 = new SqlDataAdapter();
        //sqlda2.SelectCommand = sqlcmd;

        //DataTable dt = new DataTable();
        //sqlda2.Fill(dt);

        //int datediff = 0;
        //string training = null;
        //string engage30 = null;
        //string engage90 = null;
        //foreach (DataRow dr in dt.Rows)
        //{
        //    datediff = Convert.ToInt32(dr["Diff"]);
        //    training = Convert.ToString(dr["training"]);
        //    engage30 = Convert.ToString(dr["Engage30"]);
        //    engage90 = Convert.ToString(dr["Engage90"]);

        //}
        ////sqlcon.Open();

        ////object obj = sqlcmd.ExecuteScalar();

        ////int datediff = obj != null ? Convert.ToInt32(obj) : 0;


        ////sqlcon.Close();
        //////////if (training=="No")
        //////////{
        //////////    LinkButton5.Visible = true;
        //////////    LinkButton4.Visible = false;
        //////////}
        //////////else if (datediff > 30 && training == "Yes" && engage30 == null)
        //////////{
        //////////    LinkButton5.Visible = false;
        //////////    LinkButton4.Text = "Engage 30";
        //////////}
        //////////else if (datediff > 90 && training == "Yes" && engage30 != null && engage90 ==null)
        //////////{
        //////////    LinkButton5.Visible = false;
        //////////    LinkButton4.Text = "Engage 90";

        //////////}
        //////////else
        //////////{
        //////////    LinkButton5.Visible = false;
        //////////    LinkButton4.Visible = false;
        //////////}
        //if (training == "No")
        //{
        //    LinkButton5.Visible = true;
        //    LinkButton4.Visible = false;
        //}
        //else if (datediff > 30 && training == "Yes" && engage30 == "")
        //{
        //    LinkButton5.Visible = false;
        //    LinkButton4.Text = "Engage 30";
        //}
        //else if (datediff > 90 && training == "Yes" && engage30 != "" && engage90 == "")
        //{
        //    LinkButton5.Visible = false;
        //    LinkButton4.Text = "Engage 90";

        //}
        //else
        //{
        //    LinkButton5.Visible = false;
        //    LinkButton4.Visible = false;
        //}
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "sp_GetDojNEW12";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Emp_id = new SqlParameter();
        Emp_id.SqlDbType = SqlDbType.VarChar;
        Emp_id.Value = Session["UserId"].ToString();
        Emp_id.ParameterName = "@Emp_id";
        sqlcmd.Parameters.Add(Emp_id);

        SqlDataAdapter sqlda2 = new SqlDataAdapter();
        sqlda2.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda2.Fill(dt);

        int datediff = 0;
        string training = null;
        string engage30 = null;
        string engage301 = null;
        string engage90 = null;
        string Training_date = null;
        foreach (DataRow dr in dt.Rows)
        {
            datediff = Convert.ToInt32(dr["Diff"]);
            training = Convert.ToString(dr["training"]);
            engage30 = Convert.ToString(dr["Engage30"]);
            engage301 = Convert.ToString(dr["engage301"]);
            engage90 = Convert.ToString(dr["Engage90"]);
            Training_date = Convert.ToString(dr["Training_date"]);

        }


        if (dt.Rows.Count > 0)
        {
            if ((Training_date == "" || Training_date == null))// //  if ((training == "No" || training == "" || training == null) && (Training_date == "" || Training_date == null))
            {

                LinkButton5.Visible = true;
                LinkButton4.Visible = false;
            }
            else if (datediff >= 30 && engage30 == "" && Training_date != "" && engage301 == "")// else if (datediff >= 30 && training == "Yes" && engage30 == "" && Training_date != "")
            {
                LinkButton5.Visible = false;
                LinkButton4.Text = "Engage 90(1st Employee Survey(30 Days))";
            }
            else if (datediff > 90 && engage301 != "" && engage90 == "" && Training_date != "")////   else if (datediff >= 90 && training == "Yes" && engage30 != "" && engage90 == "" && Training_date != "")
            {
                LinkButton5.Visible = false;
                LinkButton4.Text = "Engage 90(2nd Employee Survey(90 Days))";

            }
            else
            {
                LinkButton5.Visible = false;
                LinkButton4.Visible = false;
            }
        }
        else
        {
            LinkButton5.Visible = false;
            LinkButton4.Visible = false;
        }
      
    }


    protected void logedindetails()
    {
        try
        {
            sqlcon.Open();

            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = sqlcon;
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.CommandText = "Sp_Login_Details_2";
            cmd3.CommandTimeout = 0;

            SqlParameter LoginName = new SqlParameter();
            LoginName.SqlDbType = SqlDbType.VarChar;
            LoginName.Value =Session["userid"].ToString().Trim();
            LoginName.ParameterName = "@LoginName";
            cmd3.Parameters.Add(LoginName);
            
            SqlDataAdapter sqlda2 = new SqlDataAdapter();
            sqlda2.SelectCommand = cmd3;

            DataTable dt = new DataTable();
            sqlda2.Fill(dt);

            sqlcon.Close();

                    

            if(dt.Rows.Count>0)
            {
                Session["Old"] = dt.Rows[0]["log_det_id"].ToString();

                lbldate.Text = "Last logged on: " + dt.Rows[1]["login_date"].ToString() + " at :" + dt.Rows[1]["login_time"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
        }

    }

    protected void tvOrganization_SelectedNodeChanged(object sender, EventArgs e)
    {
        string[] strParameter = ((TreeView)sender).SelectedValue.Split(',');
        Session["ActivityId"]=strParameter[0];
        Session["ProductId"]=strParameter[1];
        Session["ClientId"]=strParameter[2];
        Response.Redirect(strParameter[3]);
    }

    private void Get_EmployeeDetails()
    {
        CCommon objConn = new CCommon(); SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        sqlcon.Open();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = "Get_EmployeeDetails_CSAT";
        sqlcmd.CommandTimeout = 0;

        SqlParameter Emp_id = new SqlParameter();
        Emp_id.SqlDbType = SqlDbType.VarChar;
        Emp_id.Value = Session["userid"].ToString();
        Emp_id.ParameterName = "@Emp_id";
        sqlcmd.Parameters.Add(Emp_id);

        SqlDataAdapter sqlda = new SqlDataAdapter();
        sqlda.SelectCommand = sqlcmd;

        DataTable dt = new DataTable();
        sqlda.Fill(dt);

        sqlcon.Close();

        if (dt.Rows.Count > 0)
        {
            //if (Label1.Text == "61.12.20.178" ||  Label1.Text == "175.100.162.154" || Label1.Text == "103.8.127.11" || Label1.Text == "49.248.0.82" || Label1.Text == "175.100.160.70" || Label1.Text == "175.100.160.57" || Label1.Text == "175.100.160.59" || Label1.Text == "175.100.162.155" || Label1.Text == "175.100.160.58" || Label1.Text == "175.100.160.61")
            //{

            //if (Label1.Text == dt.Rows[0]["IPAddress"].ToString())
            //{
            //LnkbtnQueryBuilder.Visible = false;
            //lnkSalaryView.Visible = false;
            //LinkButton1.Visible = false;
            //lnkDedupSearch.Visible = false;
            //lnkFETracking.Visible = false;
            //lnkQms.Visible = false;
            //LinkButton2.Visible = true;  // HDFC Manual link
            //lnkSoftware.Visible = false;

            LinkButton3.Visible = true;
            //}


        }
        else
        {
            LinkButton3.Visible = false;
        }

    }
    
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string strFileName = Server.MapPath("~/ProcessFlow/HDFC Bank  Liab _Software Manual_Version 1.1 [Compatibility Mode].pdf");
        String attachment = "attachment; filename=HDFC Bank  Liab _Software Manual_Version 1.1 [Compatibility Mode].pdf";

        Response.ClearContent();
        Response.ClearHeaders();
        Response.Clear();

        Context.Response.AddHeader("content-disposition", attachment);
        Context.Response.ContentType = "application/PDF";

        Response.WriteFile(strFileName);

        Response.End();
           
    }

}
