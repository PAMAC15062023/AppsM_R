    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace RESDOT
{
    public partial class RESDOT_Master_M : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            try

            {
                Object SaveUSERInfo = (Object)Session["UserInfo"];
                string username = Session["fullName"].ToString();
                string Rolename = Session["Rolename"].ToString();
                string roleid = Session["Roleid"].ToString();
             //   string activityname = Session["ActivityName"].ToString();

                lblWelcome.Text = "RESDOT";
                lblUserName.Text = "UserName : "+ username  + "- Role Name : "+ Rolename ;
                //if (Session["UserInfo"] == null)
                //{
                //    Response.Redirect("Test_InvalidRequest.aspx", true);
                //}
                //else
                //{
                    if (!IsPostBack)
                {
                    DataTable dt = this.BindMenuData(0);
                    DynamicMenuControlPopulation(dt, 0, null);

                    //add by Rutu on 15/12/23
                    //string elapsed_time = Session["elapsedtime"].ToString();
                    //lblelapsedtime.Text = "Elapsed Time : " + elapsed_time;
                    //add by Rutu on 15/12/23
                }
                //}
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected DataTable BindMenuData(int parentmenuId)
        {
            //declaration of variable used  
            DataSet ds = new DataSet();
            // DataTable dt;
            //DataRow dr;
            //DataColumn menu;
            //DataColumn pMenu;
            //DataColumn title;
            //DataColumn description;
            //DataColumn URL;

            int RoleId = Convert.ToInt32(Session["RoleId"]);


            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlCon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "sp_getMenu";

            sqlcmd.Parameters.AddWithValue("@role", RoleId);
            //sqlcmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter sqlDA = new SqlDataAdapter();

            sqlDA.SelectCommand = sqlcmd;
            DataTable dt = new DataTable();
            sqlDA.Fill(dt);
            sqlCon.Close();
                      

            ds.Tables.Add(dt);




            var dv = ds.Tables[0].DefaultView;
            dv.RowFilter = "ParentId='" + parentmenuId + "'";
            DataSet ds1 = new DataSet();
            var newdt = dv.ToTable();
            return newdt;
        }
        /// <summary>  
        /// This is a recursive function to fetchout the data to create a menu from data table  
        /// </summary>  
        /// <param name="dt">datatable</param>  
        /// <param name="parentMenuId">parent menu Id of integer type</param>  
        /// <param name="parentMenuItem"> Menu Item control</param>  
        protected void DynamicMenuControlPopulation(DataTable dt, int parentMenuId, MenuItem parentMenuItem)
        {
            string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
            foreach (DataRow row in dt.Rows)
            {
                MenuItem menuItem = new MenuItem
                {
                    Value = row["MenuId"].ToString(),
                    Text = row["Title"].ToString(),
                    NavigateUrl = row["URL"].ToString(),
                    Selected = row["URL"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
                };
                if (parentMenuId == 0)
                {
                    Menu1.Items.Add(menuItem);
                    DataTable dtChild = this.BindMenuData(int.Parse(menuItem.Value));
                    DynamicMenuControlPopulation(dtChild, int.Parse(menuItem.Value), menuItem);
                }
                else
                {

                    parentMenuItem.ChildItems.Add(menuItem);
                    DataTable dtChild = this.BindMenuData(int.Parse(menuItem.Value));
                    DynamicMenuControlPopulation(dtChild, int.Parse(menuItem.Value), menuItem);

                }
            }
        }

        //protected void Createmenu()
        //{

        //    // get from session role
        //    int role = 1;
        //    SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        //    sqlCon.Open();
        //    SqlCommand sqlcmd = new SqlCommand();
        //    sqlcmd.Connection = sqlCon;
        //    sqlcmd.CommandType = CommandType.StoredProcedure;
        //    sqlcmd.CommandText = "sp_getMenu";

        //    sqlcmd.Parameters.AddWithValue("@role", role);
        //    //sqlcmd.Parameters.AddWithValue("@id", id);
        //    SqlDataAdapter sqlDA = new SqlDataAdapter();

        //    sqlDA.SelectCommand = sqlcmd;
        //    DataTable dt = new DataTable();
        //    sqlDA.Fill(dt);
        //    sqlCon.Close();

        //    if (dt != null)

        //    {
        //        int menuid = 0;
        //        String isheader = "";
        //        int position = 0;
        //        int parentid = 0;
        //        string pagepath = "";
        //        String displayname = "";
        //        string href1 = "";
        //        string href2 = "";
        //        int totalRows = dt.Rows.Count;
        //        int rowcount = 0;
        //        int hline = 1;

        //        lblUserName.Text = " Welcome ";//+ UserName +"  " + RoleName;

        //        int parentMenuId = 1;
        //         MenuItem parentMenuItem = null;


        //        //pnlmenu.Controls.Add(new LiteralControl("<tr><table><td class='TableTitle' style='width: 150px'>"));
        //        foreach (DataRow dr in dt.Rows)
        //        {

        //            {
        //                string currentPage = Path.GetFileName(Request.Url.AbsolutePath);
        //                foreach (DataRow row in dt.Rows)
        //                {
        //                    MenuItem menuItem = new MenuItem
        //                    {
        //                        Value = row["MenuId"].ToString(),
        //                        Text = row["Title"].ToString(),
        //                        NavigateUrl = row["URL"].ToString(),
        //                        Selected = row["URL"].ToString().EndsWith(currentPage, StringComparison.CurrentCultureIgnoreCase)
        //                    };
        //                    if (parentMenuId == 0)
        //                    {
        //                        Menu1.Items.Add(menuItem);
        //                        DataTable dtChild = this.BindMenuData(int.Parse(menuItem.Value));
        //                        DynamicMenuControlPopulation(dtChild, int.Parse(menuItem.Value), menuItem);
        //                    }
        //                    else
        //                    {

        //                        parentMenuItem.ChildItems.Add(menuItem);
        //                        DataTable dtChild = this.BindMenuData(int.Parse(menuItem.Value));
        //                        DynamicMenuControlPopulation(dtChild, int.Parse(menuItem.Value), menuItem);

        //                    }
        //                }
        //            }
        //        }


        //        {
        //            menuid = Int32.Parse(dr["MenuId"].ToString());
        //            isheader = dr["IsHeader"].ToString();
        //            position = Int32.Parse(dr["Position"].ToString());
        //            parentid = Int32.Parse(dr["ParentId"].ToString());
        //            pagepath = dr["PagePath"].ToString();
        //            displayname = dr["DisplayName"].ToString();

        //            if (isheader == "True")
        //            {
        //                //if (hline == 1)
        //                //{
        //                //    pnlmenu.Controls.Add(new LiteralControl(
        //                //    "< div class='navbar'><div class='dropdown'"
        //                //  + "<button class='dropbtn' id='Menubtn' runat='server' Text='Add New' >"
        //                //    + displayname
        //                //    + " <i class='fa fa - caret - down'></i>  </button>"));
        //                //    //  & nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        //                //    //Menu
        //                //    hline = hline + 1;



        //                //}
        //                //   pnlmenu.Controls.Add(new LiteralControl("<tr><table><td class='TableTitle' style='width: 150px'>"));

        //                //pnlmenu.Controls.Add(new LiteralControl("<b>"+displayname + "</b>"));
        //                //pnlmenu.Controls.Add(new LiteralControl
        //                //    ("</td><td class='TableTitle' style='width: 150px'>"));

        //                //pnlmenu.Controls.Add(new LiteralControl(
        //                //    "<asp:Panel ID='pnlmenu' runat='server'>< div class='navbar'>"
        //                //    +"   <div class='dropdown''><button class='dropbtn' id='Menubtn'  Text='Add New'>"
        //                //    + "<i class='fa fa-caret-down'></i>  </button></div>"));
        //                //Menubtn.InnerText=displayname;              


        //                //ltrInfo.Text = "<ul style='list-style: none;'>";
        //                //       txtMenuName.Text = displayname;

        //                //pnlArea.Controls.Add(new LiteralControl("</div>"));


        //            }
        //            if (isheader == "False")
        //            {
        //                pnlmenu.Controls.Add(new LiteralControl("<tr><td>"));
        //                href1 = pagepath;
        //                href2 = displayname;
        //                if (rowcount % 2 == 0)
        //                {
        //                    pnlmenu.Controls.Add(new LiteralControl("<tr><td>"));
        //                }
        //                else
        //                {
        //                    pnlmenu.Controls.Add(new LiteralControl("</td> <td> "));

        //                }
        //                if (rowcount == 1)
        //                {
        //                     mn1.HRef = pagepath;
        //                     mn1.InnerText = "ImportXXX";
        //                }  

        //                //pnlmenu.Controls.Add(new LiteralControl
        //                //    ("<li><a href=" + href1 + ">" + href2 + " </a></li>"));

        //                rowcount = rowcount + 1;



        //                //pnlmenu.Controls.Add(new LiteralControl
        //                //   ("<tr><td>") ; // class='TableTitle' style='width: 150px'>"));
        //                //pnlmenu.Controls.Add(new LiteralControl
        //                //    ("< ul style = 'list-style: none;' >"));

        //                //pnlmenu.Controls.Add(new LiteralControl
        //                //("</ul>"));
        //                //ltrInfo.Text = "<ul style='list-style: none;'>";
        //                //ltrInfo.Text += "<li><a href=" + href1 + ">" + href2 + "</a></li>";
        //                //        //ltrInfo.Text += "<li><a href='page2.aspx'>Link Two </a></li>";
        //                //        //ltrInfo.Text += "</ul>";
        //            }
        //            //  // 
        //        }



        //            //href1 = "RESDOT_UserMaster.aspx";
        //            //href2 = "User Master";
        //            //menuname.InnerText = "NOT MENU"; // parent
        //            //menuname1.InnerText = "MY MENU"; // parent2
        //            //                                 // Mysample.aspx
        //            //ltrInfo.Text = "<ul style='list-style: none;'>";
        //            //ltrInfo.Text += "<li><a href=" + href1 + ">" + href2 + "</a></li>";
        //            ////ltrInfo.Text += "<li><a href='page2.aspx'>Link Two </a></li>";
        //            //ltrInfo.Text += "</ul>";
        //        }


        //}
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] != null)
                {
                    //CommonMaster commonMaster = new CommonMaster();
                    //int Result = commonMaster.UserLogOut(Convert.ToString(Session["LoginName"]));

                    //if (Result == 1)
                    //{
                        Session.Clear();
                        Response.Redirect("RESDOT_Login.aspx", false);
                    //}
                }
                else
                {
                    Session.Clear();
                    Response.Redirect("RESDOT_Login.aspx", false);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("RESDOT_MenuPage.aspx", false);
        }

     
    }
}
