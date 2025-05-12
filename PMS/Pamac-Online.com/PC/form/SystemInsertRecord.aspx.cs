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

public partial class PC_form_SystemInsertRecord : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }

    }



    protected void btnapprove_Click(object sender, EventArgs e)
    {
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "reset", " resetFields();", true);


        Object SaveUSERInfo = (Object)Session["UserInfo"];
        SqlConnection sqlCon = new SqlConnection(ConfigurationManager.AppSettings["Westconstring"]);
        try
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("spInsertSystemRecord", sqlCon);
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}