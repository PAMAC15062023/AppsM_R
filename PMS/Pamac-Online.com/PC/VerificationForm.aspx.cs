using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class PC_VerificationForm : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["Machine_Name"] != null)
            {
                hdnmachinename.Value = Request.QueryString["Machine_Name"].ToString();
                GetallDetails();
            }
        }

    }

    public void GetallDetails()
    {

        Object SaveUSERInfo = (Object)Session["UserInfo"];

       
 CCommon objConn = new CCommon();
 SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);

 SqlCommand sqlCom = new SqlCommand("spGetalldata", sqlcon);
       
        sqlCom.CommandType = CommandType.StoredProcedure;
        //sqlCom.CommandText = "spGetalldata";  //GetEmpData51//GetEmpData49//GetEmpData46//GetEmpData45 //"GetEmpData85"; //GetEmpData88

        sqlCom.CommandTimeout = 0;

        sqlCom.Parameters.AddWithValue("@Machine_Name", hdnmachinename.Value);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlCom;

        DataTable dt = new DataTable();
        sqlDA.Fill(dt);
        if (dt.Rows.Count > 0)
        {
            txtmachine.Text = dt.Rows[0]["Machine_Name"].ToString();
            txtfullname.Text = dt.Rows[0]["User_Full_Name"].ToString();
            txtdepartment.Text = dt.Rows[0]["Department"].ToString();
            txtempid.Text = dt.Rows[0]["Emp_Id"].ToString();
            txtcpupamacid.Text = dt.Rows[0]["CPU_PAMAC_ID"].ToString();
            txtmachinename.Text = dt.Rows[0]["Machine_Name_System_Name"].ToString();
            txtMonitorpamacid.Text = dt.Rows[0]["Monitor_Pamac_Id"].ToString();
            txtmachineDhcp.Text = dt.Rows[0]["Machine_on_DHCP"].ToString();
            txtmonitormake.Text = dt.Rows[0]["Monitor_Make_Brand"].ToString();
            txtmonitormodel.Text = dt.Rows[0]["Monitor_Model"].ToString();
            txtmonitorinch.Text = dt.Rows[0]["Monitor_Inch"].ToString();
            txtmonitorserial.Text = dt.Rows[0]["Monitor_SerialNo"].ToString();
            txtmachineip.Text = dt.Rows[0]["Machine_IP"].ToString();
            txtdeskip.Text = dt.Rows[0]["Desk_IP"].ToString();
            txtmacaddress.Text = dt.Rows[0]["MAC_Address"].ToString();
            txtgateway.Text = dt.Rows[0]["Gateways"].ToString();
            txtadminrights.Text = dt.Rows[0]["Admin_Rights"].ToString();
            txtscreen.Text = dt.Rows[0]["Screen_Saver"].ToString();
            txtwallpaper.Text = dt.Rows[0]["Wallpaper"].ToString();
            txtos.Text = dt.Rows[0]["OS"].ToString();
            txtOffice.Text = dt.Rows[0]["Office_Version"].ToString();
            txtAVname.Text = dt.Rows[0]["AV_Name"].ToString();
            txtAVstatus.Text = dt.Rows[0]["Antivirus_Status"].ToString();
            txtAVpolicy.Text = dt.Rows[0]["AV_Policy"].ToString();
            txtavupdation.Text = dt.Rows[0]["AV_Updation_Date"].ToString();
            txtbios.Text = dt.Rows[0]["Bios_Password"].ToString();
            txtwindowspatch.Text = dt.Rows[0]["Windows_Patch_Date"].ToString();
            txtsystemdate.Text = dt.Rows[0]["System_Date_and_Time"].ToString();
            txtzipclient.Text = dt.Rows[0]["ZIP_CLient"].ToString();
            txtadobeversion.Text = dt.Rows[0]["Adobe_Version"].ToString();
            txtmachineowned.Text = dt.Rows[0]["Machine_Owned"].ToString();
            txtrentalcpuno.Text = dt.Rows[0]["Rentail_Cpu_Number"].ToString();
            txtrentalmonitorno.Text = dt.Rows[0]["Rentail_Monitor_NO"].ToString();

            txtcpumakemodel.Text = dt.Rows[0]["CPU_MAKE_Model"].ToString();

            txtcpuserialno.Text = dt.Rows[0]["CPU_Serial_NO"].ToString();
            txtcpuspeed.Text = dt.Rows[0]["CPU_SPEED"].ToString();
            txthdd.Text = dt.Rows[0]["HDD"].ToString();
            txtram.Text = dt.Rows[0]["RAM"].ToString();

            txtcpu.Text = dt.Rows[0]["CPU"].ToString();
            txtusbblock.Text = dt.Rows[0]["USB_BLOCK"].ToString();

            txtmydockpicture.Text = dt.Rows[0]["MY_DOCK_PICTURE"].ToString();
            txtemailid.Text = dt.Rows[0]["Email_ID"].ToString();

            txttypeofid.Text = dt.Rows[0]["Type_OF_ID"].ToString();
            txtpdfwriter.Text = dt.Rows[0]["PDF_Writer"].ToString();

            txtskype.Text = dt.Rows[0]["Skype"].ToString();
            txttimesynk.Text = dt.Rows[0]["Time_Synk"].ToString();

            txtmudoclpicture.Text = dt.Rows[0]["MY_DOCk_Picture_Remove"].ToString();

            txtmaxmimumpass.Text = dt.Rows[0]["Maximum_Password_age30"].ToString();
            txtpasswordleng.Text = dt.Rows[0]["password_Length8"].ToString();

            txtpasswordcomplexity.Text = dt.Rows[0]["password_complexity_Enable"].ToString();
            txtaccountlokout.Text = dt.Rows[0]["Account_lockout_threshold"].ToString();
            txtpreventchanging.Text = dt.Rows[0]["prevent_changing_Wallpaper_Enable"].ToString();

            txtpasswordprotech.Text = dt.Rows[0]["Password_Protech_Screen_Saver_Enable"].ToString();
            txtscreensavertime.Text = dt.Rows[0]["Screen_saver_Time"].ToString();

            txtprevent.Text = dt.Rows[0]["Prevent_Changing"].ToString();
            txtOfficelicence.Text = dt.Rows[0]["Office_Licence"].ToString();
            txtOSlicence.Text = dt.Rows[0]["OS_Licence"].ToString();
        }

    }

    protected void btnapprove_Click(object sender, EventArgs e)
    {
        CLogin objLogin = new CLogin();

        Object SaveUSERInfo = (Object)Session["UserInfo"];

        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["Westconstring"]);

        sqlCon.Open();
        SqlCommand sqlCom = new SqlCommand();
        sqlCom.Connection = sqlCon;
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.CommandText = "spGetverfiydetails";  //GetEmpData51//GetEmpData49//GetEmpData46//GetEmpData45 //"GetEmpData85"; //GetEmpData88




        SqlParameter UserId = new SqlParameter();
        UserId.SqlDbType = SqlDbType.VarChar;
        UserId.Value = Session["UserId"].ToString();
        UserId.ParameterName = "@EmpID_Verify";
        sqlCom.Parameters.Add(UserId);


        
        sqlCom.Parameters.AddWithValue("@Machine_Name", txtmachine.Text);

        sqlCom.Parameters.AddWithValue("@Monitor_Pamac_Id", txtMonitorpamacid.Text);

        int i = sqlCom.ExecuteNonQuery();
        if (i > 0)
        {
            lblmessage.Text = "Verified Sucessfully";
            lblmessage.ForeColor = System.Drawing.Color.Green;

            lblmessage.Visible = true;
        }
        else
        {

        }

        sqlCon.Close();
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("SystemInfo.aspx");
    }
}