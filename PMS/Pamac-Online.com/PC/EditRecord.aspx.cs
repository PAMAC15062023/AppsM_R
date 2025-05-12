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

public partial class PC_EditRecord : System.Web.UI.Page
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

        SqlCommand sqlcom = new SqlCommand("spGetalldata",sqlcon);
        
        sqlcom.CommandType = CommandType.StoredProcedure;
        //sqlcom.CommandText = "spGetalldata";  //GetEmpData51//GetEmpData49//GetEmpData46//GetEmpData45 //"GetEmpData85"; //GetEmpData88

        sqlcom.CommandTimeout = 0;

        sqlcom.Parameters.AddWithValue("@Machine_Name", hdnmachinename.Value);

        SqlDataAdapter sqlDA = new SqlDataAdapter();
        sqlDA.SelectCommand = sqlcom;

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

        Object SaveUSERInfo = (Object)Session["UserInfo"];
        CCommon objConn = new CCommon();
        SqlConnection sqlcon = new SqlConnection(objConn.AppConnectionString);
        try
        {
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand("SPUpdateRecord", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Machine_Name", txtmachine.Text);
            cmd.Parameters.AddWithValue("@User_Full_Name", txtfullname.Text);
            cmd.Parameters.AddWithValue("@Department", txtdepartment.Text);
            cmd.Parameters.AddWithValue("@Emp_Id", txtempid.Text);
            cmd.Parameters.AddWithValue("@CPU_PAMAC_ID", txtcpupamacid.Text);
            cmd.Parameters.AddWithValue("@Machine_Name_System_Name", txtmachinename.Text);
            cmd.Parameters.AddWithValue("@Monitor_Pamac_Id", txtMonitorpamacid.Text);
            cmd.Parameters.AddWithValue("@Machine_on_DHCP", txtmachineDhcp.Text);
            cmd.Parameters.AddWithValue("@Monitor_Make_Brand", txtmonitormake.Text);
            cmd.Parameters.AddWithValue("@Monitor_Model", txtmonitormodel.Text);
            cmd.Parameters.AddWithValue("@Monitor_Inch", txtmonitorinch.Text);
            cmd.Parameters.AddWithValue("@Monitor_SerialNo", txtmonitorserial.Text);
            cmd.Parameters.AddWithValue("@Machine_IP", txtmachineip.Text);
            cmd.Parameters.AddWithValue("@Desk_IP", txtdeskip.Text);
            cmd.Parameters.AddWithValue("@MAC_Address", txtmacaddress.Text);
            cmd.Parameters.AddWithValue("@Gateways", txtgateway.Text);
            cmd.Parameters.AddWithValue("@Admin_Rights", txtadminrights.Text);
            cmd.Parameters.AddWithValue("@Screen_Saver", txtscreen.Text);
            cmd.Parameters.AddWithValue("@Wallpaper", txtwallpaper.Text);
            cmd.Parameters.AddWithValue("@OS", txtos.Text);
            cmd.Parameters.AddWithValue("@Office_Version", txtOffice.Text);
            cmd.Parameters.AddWithValue("@AV_Name", txtAVname.Text);
            cmd.Parameters.AddWithValue("@Antivirus_Status", txtAVstatus.Text);
            cmd.Parameters.AddWithValue("@AV_Policy", txtAVpolicy.Text);
            cmd.Parameters.AddWithValue("@AV_Updation_Date", txtavupdation.Text);
            cmd.Parameters.AddWithValue("@Bios_Password", txtbios.Text);
            cmd.Parameters.AddWithValue("@Windows_Patch_Date", txtwindowspatch.Text);
            cmd.Parameters.AddWithValue("@System_Date_and_Time", txtsystemdate.Text);
            cmd.Parameters.AddWithValue("@ZIP_CLient", txtzipclient.Text);
            cmd.Parameters.AddWithValue("@Adobe_Version", txtadobeversion.Text);
            cmd.Parameters.AddWithValue("@Machine_Owned", txtmachineowned.Text);
            cmd.Parameters.AddWithValue("@Rentail_Cpu_Number", txtrentalcpuno.Text);
            cmd.Parameters.AddWithValue("@Rentail_Monitor_NO", txtrentalmonitorno.Text);
            cmd.Parameters.AddWithValue("@CPU_MAKE_Model", txtcpumakemodel.Text);
            cmd.Parameters.AddWithValue("@CPU_Serial_NO", txtcpuserialno.Text);
            cmd.Parameters.AddWithValue("@CPU_SPEED", txtcpuspeed.Text);
            cmd.Parameters.AddWithValue("@HDD", txthdd.Text);
            cmd.Parameters.AddWithValue("@RAM", txtram.Text);
            cmd.Parameters.AddWithValue("@CPU", txtcpu.Text);
            cmd.Parameters.AddWithValue("@USB_BLOCK", txtusbblock.Text);
            cmd.Parameters.AddWithValue("@MY_DOCK_PICTURE", txtmydockpicture.Text);
            cmd.Parameters.AddWithValue("@Email_ID", txtemailid.Text);
            cmd.Parameters.AddWithValue("@Type_OF_ID", txttypeofid.Text);
            cmd.Parameters.AddWithValue("@PDF_Writer", txtpdfwriter.Text);
            cmd.Parameters.AddWithValue("@Skype", txtskype.Text);
            cmd.Parameters.AddWithValue("@Time_Synk", txttimesynk.Text);
            cmd.Parameters.AddWithValue("@MY_DOCk_Picture_Remove", txtmudoclpicture.Text);
            cmd.Parameters.AddWithValue("@Maximum_Password_age30", txtmaxmimumpass.Text);
            cmd.Parameters.AddWithValue("@password_Length8", txtpasswordleng.Text);
            cmd.Parameters.AddWithValue("@password_complexity_Enable", txtpasswordcomplexity.Text);
            cmd.Parameters.AddWithValue("@Account_lockout_threshold", txtaccountlokout.Text);
            cmd.Parameters.AddWithValue("@prevent_changing_Wallpaper_Enable", txtpreventchanging.Text);
            cmd.Parameters.AddWithValue("@Password_Protech_Screen_Saver_Enable", txtpasswordprotech.Text);
            cmd.Parameters.AddWithValue("@Screen_saver_Time", txtscreensavertime.Text);
            cmd.Parameters.AddWithValue("@Prevent_Changing", txtprevent.Text);
            cmd.Parameters.AddWithValue("@Office_Licence", txtOfficelicence.Text);
            cmd.Parameters.AddWithValue("@OS_Licence", txtOSlicence.Text);

            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                lblmessage.Text = "Data Saved Sucessfully";
                lblmessage.ForeColor = System.Drawing.Color.Green;
                lblmessage.Visible = true;
            }
            else
            {
                lblmessage.Text = "Data Already Exists";
                lblmessage.ForeColor = System.Drawing.Color.Red;
                lblmessage.Visible = true;
            }



        }
        catch (Exception)
        {

            throw;
        }
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}