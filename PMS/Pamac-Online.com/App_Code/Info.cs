using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;
using System.Text;


/// <summary>
/// Summary description for Info
/// </summary>
namespace myInfo
{
    
    public class Info
    {


      
       
        //(akanksha)

        private string grsal_txt;
        public string current_gross_salary
        {
            get { return grsal_txt; }
            set { grsal_txt = value; }
        }

        private string reliving_date_txt;
        public string reliving_date
        {
            get { return reliving_date_txt; }
            set { reliving_date_txt = value; }
        }

        private string approver_name_txt;
        public string approver_name
        {
            get { return approver_name_txt; }
            set { approver_name_txt = value; }
        }
        private string reason_for_separation;
        public string separation_reason
        {
            get { return reason_for_separation; }
            set { reason_for_separation = value; }
        }
        private string approver_email_id_txt;
        public string approver_email_id
        {
            get { return approver_email_id_txt; }
            set { approver_email_id_txt = value; }
        }

        private string present_add_txt;
        public string present_address
        {
            get { return present_add_txt; }
            set { present_add_txt = value; }
        }
        

        private string country_txt;
        public string present_country
        {
            get { return country_txt; }
            set { country_txt = value; }
        }


        private string area_txt;
        public string present_area
        {
            get { return area_txt; }
            set { area_txt = value; }
        }

        
         private string state_txt;
        public string present_state
        {
            get { return state_txt; }
            set { state_txt = value; }
        }


        private string city_txt;
        public string present_city
        {
            get { return city_txt; }
            set { city_txt = value; }
        }

        private string zip_code_txt;
        public string present_postal_code
        {
            get { return zip_code_txt; }
            set { zip_code_txt = value; }
        }

        private string contact_no_txt;
        public string contact_no
        {
            get { return contact_no_txt; }
            set { contact_no_txt = value; }
        }
        private string permanant_add_txt;
        public string permanant_address
        {
            get { return permanant_add_txt; }
            set { permanant_add_txt = value; }
        }
        private string p_country_txt;
        public string permanant_country
        {
            get { return p_country_txt; }
            set { p_country_txt = value; }
        }

        private string p_area_txt;
        public string permanant_area
        {
            get { return p_area_txt; }
            set { p_area_txt = value; }
        }
        

        private string p_state_txt;
        public string permanant_state
        {
            get { return p_state_txt; }
            set { p_state_txt = value; }
        }


        private string p_city_txt;
        public string permanant_city
        {
            get { return p_city_txt; }
            set { p_city_txt = value; }
        }


        private string p_zip_code;
        public string permanant_postal_code
        {
            get { return p_zip_code; }
            set { p_zip_code = value; }
        }
       
         private string p_emailid_txt;
        public string p_emailid
        {
            get { return p_emailid_txt; }
            set { p_emailid_txt = value; }
        }


        private string p_contact_no_txt;
        public string alternate_contact_no
        {
            get { return p_contact_no_txt; }
            set { p_contact_no_txt = value; }
        }


        private string alternate_emailid_txt;
        public string alternate_emailid
        {
            get { return alternate_emailid_txt; }
            set { alternate_emailid_txt = value; }
        }

        //approver data insert
        private string status_ddl;
        public string status
        {
            get {return status_ddl; }
            set { status_ddl = value; }
        }

        private string relivingdate_txt;
        public string app_reliving_date
        {
            get { return relivingdate_txt; }
            set { relivingdate_txt = value; }
        }
        private string app_remark_txt ;
        public string approver_remark
        {
            get { return app_remark_txt; }
            set { app_remark_txt = value; }
        }

        private string str_Branch_id;
        public string Branch_id
        {
            get { return str_Branch_id; }
            set { str_Branch_id = value; }
        }


       // leave page
        //new
        private string ddlauthority;
            public string Auhoity
        {
            get { return ddlauthority; }
            set { ddlauthority = value; }
        }


        private string ticketno_txt;
        public string ticketno
        {
            get { return ticketno_txt; }
            set { ticketno_txt = value; }
        }


        private string startdate_txt;
        public string leave_start_date
        {
            get { return startdate_txt ; }
            set { startdate_txt = value; }
        }

        private string lastdate_txt;
        public string leave_end_date
        {
            get { return lastdate_txt ; }
            set { lastdate_txt = value; }
        }

        private string taotaldy_txt;
        public string total_days
        {
            get { return taotaldy_txt; }
            set { taotaldy_txt = value; }
        }

        private string leavety_dp;
        public string leave_type
        {
            get { return leavety_dp; }
            set { leavety_dp = value; }
        }

        private string reason_txt;
        public string reason
        {
            get { return reason_txt; }
            set { reason_txt = value; }
        }

  
        //update leave authorization element

        private string txt_app_date;
        public string leave_app_date
        {
            get { return txt_app_date; }
            set { txt_app_date = value; }
        }
        private string txt_app_end_date;
        public string leave_app_end_date
        {
            get { return txt_app_end_date; }
            set { txt_app_end_date = value; }
        }

        private string dpsatus;
        public string status_leave
        {
            get { return dpsatus; }
            set { dpsatus = value; }
        }
       
            private string txt_remark;
        public string Remark
        {
            get { return txt_remark; }
            set { txt_remark = value; }
        }

        //leave authorization search(akanksha)

        private string txt_startdate;
        public string leave_start_date1
        {
            get { return txt_startdate; }
            set { txt_startdate = value; }
        }

        private string txt_lastdate;
        public string leave_end_date1
        {
            get { return txt_lastdate; }
            set { txt_lastdate = value; }
        }

        private string dpstatus;
        public string status_leave1
        {
            get { return dpstatus; }
            set { dpstatus = value; }
        }

        //private string authoritytxt;
        //public string Auhoity
        //{
        //    get { return authoritytxt; }
        //    set { authoritytxt = value; }
        //}



        //leave datedifference

        private string startdate_txt1;
        public string leave_start_date2
        {
            get { return startdate_txt1; }
            set { startdate_txt1 = value; }
        }

        private string lastdate_txt1;
        public string leave_end_date2
        {
            get { return lastdate_txt1; }
            set { lastdate_txt1 = value; }
        }

        //private string totaldy_txt1;
        //public string total_days2
        //{
        //    get { return totaldy_txt; }
        //    set { totaldy_txt = value; }
        //}


        CCommon objConn = new CCommon();
        SqlConnection con;

        public Info()
        {
            //

            // TODO: Add constructor logic here
            //
        }

        //(kanchan)

        public DataSet Getdata(string varUserId)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter My_SQLDataAdapter = new SqlDataAdapter();
            //My_SQLDataAdapter.SelectCommand = new SqlCommand();


            con = new SqlConnection(objConn.AppConnectionString);

            SqlCommand command = new SqlCommand("sp_DisplayInfo", con);

            command.CommandType = CommandType.StoredProcedure;
            My_SQLDataAdapter.SelectCommand = command;

            command.Parameters.AddWithValue("@Emp_id", varUserId);
            
            My_SQLDataAdapter.Fill(MyDataSet);

            return MyDataSet;
        }

        //(kanchan)
        public DataSet DisplayInfo(string varUserId)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter My_SQLDataAdapter = new SqlDataAdapter();
            con = new SqlConnection(objConn.AppConnectionString);
            SqlCommand command = new SqlCommand("sp_GridInfo", con);
            command.CommandType = CommandType.StoredProcedure;
            My_SQLDataAdapter.SelectCommand = command;
            command.Parameters.AddWithValue("@emp_id", varUserId);
            My_SQLDataAdapter.Fill(MyDataSet);
            return MyDataSet;

        }
        


        //image show Email(akanksha)

        public DataSet imagesshow()
        {
            DataSet imagdst = new DataSet();

            SqlDataAdapter  Adapter1 = new SqlDataAdapter();
            
            con = new SqlConnection(objConn.AppConnectionString);
            

            SqlCommand command = new SqlCommand("image_show",con);
            command.CommandType = CommandType.StoredProcedure;

          Adapter1.SelectCommand = command;
           Adapter1.Fill(imagdst);

            return imagdst;
        }
        

        //code for Authorize page(kanchan)

        public DataSet RetriveData(string varResigId, string varEmpId)
        {
            DataSet MyDataSet = new DataSet();
            SqlDataAdapter My_SQLDataAdapter = new SqlDataAdapter();
            //My_SQLDataAdapter.SelectCommand = new SqlCommand();


            con = new SqlConnection(objConn.AppConnectionString);

            SqlCommand command = new SqlCommand("sp_GetData", con);

            command.CommandType = CommandType.StoredProcedure;
            My_SQLDataAdapter.SelectCommand = command;

            command.Parameters.AddWithValue("@TicketNo", varResigId);
            command.Parameters.AddWithValue("@emp_id", varEmpId);

            My_SQLDataAdapter.Fill(MyDataSet);

            return MyDataSet;
        }

        //code for Authorize page(kanchan)
        public void UpdateData(string varTicketNo, string varUserId)
        {
           DataSet dt=new DataSet();
           con=new SqlConnection(objConn.AppConnectionString);
           SqlCommand command = new SqlCommand("sp_UpdateData", con);
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.AddWithValue("@TicketNo", varTicketNo);
           command.Parameters.AddWithValue("@status", status_ddl);
           command.Parameters.AddWithValue("@app_reliving_date", app_reliving_date);
           command.Parameters.AddWithValue("@approver_remark", app_remark_txt);
           command.Parameters.AddWithValue("@approved_by", varUserId);
           con.Open();
           command.ExecuteNonQuery();
           con.Close();
        }

        
        // resignation page(akanksha)




////added by abhijeet//
//        public void InsertTokenDetail()
//        {
//            try
//            {
//                string UserId = HttpContext.Current.Session["UserId"].ToString();
//                string LoginId = HttpContext.Current.Session["LogID"].ToString();

//                string Token = HttpContext.Current.Session["Token"].ToString();

//                using (SqlConnection con = new SqlConnection(objConn.AppConnectionString))
//                {
//                    SqlCommand command = new SqlCommand("sp_InsertToken", con);
//                    command.CommandType = CommandType.StoredProcedure;

//                    command.Parameters.AddWithValue("@userid", UserId);
//                    command.Parameters.AddWithValue("@login_id", LoginId);
//                    command.Parameters.AddWithValue("@Token", Token);

//                    con.Open();
//                    int i = command.ExecuteNonQuery();
//                    con.Close();
//                }

//            }
//            catch
//            {

//            }
//        }



    

//        public void UpdateTokenDetail()
//        {
//            SqlConnection con = new SqlConnection(objConn.AppConnectionString);

//            string UserId = HttpContext.Current.Session["UserId"].ToString();
//           // string LoginId = HttpContext.Current.Session["LogID"].ToString();
//            //string Token = HttpContext.Current.Session["Token"].ToString();

//            SqlCommand command = new SqlCommand("sp_Tokendelete", con);
//            command.CommandType = CommandType.StoredProcedure;

//            command.Parameters.AddWithValue("@userid", UserId);
//            //command.Parameters.AddWithValue("@login_id", LoginId);
//            ////command.Parameters.AddWithValue("@token", Token);
//            //command.Parameters.AddWithValue("@token2", tokenupdate);

//            con.Open();
//            int i = command.ExecuteNonQuery();
//            con.Close();
//        }

//        public DataSet Get_TokenUpdate()
//        {

//            string UserId = HttpContext.Current.Session["UserId"].ToString();
//            string LoginId = HttpContext.Current.Session["LogID"].ToString();
//            //string Token = HttpContext.Current.Session["Token"].ToString();

//            SqlConnection con = new SqlConnection(objConn.AppConnectionString);

//            SqlCommand command1 = new SqlCommand("Get_TokenUpdate", con);
//            command1.CommandType = CommandType.StoredProcedure;

//            command1.Parameters.AddWithValue("@userid", UserId);
//            command1.Parameters.AddWithValue("@login_id", LoginId);
//            //command1.Parameters.AddWithValue("@token2", tokenupdate);

//            SqlDataAdapter sda = new SqlDataAdapter();
//            sda.SelectCommand = command1;

//            DataSet ds = new DataSet();
//            sda.Fill(ds);


//            return ds;

//        }



//        //ended by abhijeet//
        
        public void Insert(string varUserId)
        {
            try
            {
                DataSet MyDataSet = new DataSet();

                con = new SqlConnection(objConn.AppConnectionString);

                SqlCommand command = new SqlCommand("insert_resignation_empdetails", con);

                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@Emp_id", varUserId);
                command.Parameters.AddWithValue("@current_gross_salary", grsal_txt);
                command.Parameters.AddWithValue("@reliving_date", reliving_date_txt);
                command.Parameters.AddWithValue("@approver_name", approver_name_txt);
                command.Parameters.AddWithValue("@separation_reason", reason_for_separation);
                command.Parameters.AddWithValue("@approver_email_id", approver_email_id_txt);
                command.Parameters.AddWithValue("@present_address", present_add_txt);
                command.Parameters.AddWithValue("@present_country", country_txt);
                command.Parameters.AddWithValue("@present_area", area_txt);
                command.Parameters.AddWithValue("@present_state", state_txt);
                command.Parameters.AddWithValue("@present_city", city_txt);
                command.Parameters.AddWithValue("@present_postal_code", zip_code_txt);
                command.Parameters.AddWithValue("@contact_no", contact_no_txt);
                command.Parameters.AddWithValue("@permanant_address", permanant_add_txt);
                command.Parameters.AddWithValue("@permanant_area", p_area_txt);
                command.Parameters.AddWithValue("@permanant_state", p_state_txt);
                command.Parameters.AddWithValue("@permanant_city", city_txt);
                command.Parameters.AddWithValue("@permanant_postal_code", p_zip_code);
                command.Parameters.AddWithValue("@alternate_contact_no", p_contact_no_txt);
                command.Parameters.AddWithValue("@p_emailid", p_emailid_txt);
                command.Parameters.AddWithValue("@alternate_emailid", alternate_emailid_txt);
                command.Parameters.AddWithValue("@permanant_country", p_country_txt);
                command.Parameters.AddWithValue("@BranchID", str_Branch_id);
                command.Parameters.AddWithValue("@TicketNo", "");


                SqlParameter VarResult = new SqlParameter();
                VarResult.SqlDbType = SqlDbType.NVarChar;
                VarResult.ParameterName = "@VarResult";
                VarResult.Size = 200;
                VarResult.Direction = ParameterDirection.Output;
                command.Parameters.Add(VarResult);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();


                string RowEffected = Convert.ToString(command.Parameters["@VarResult"].Value);
            }
            catch
            {
                
            }
           
        }

        // update resignation (made by kanachan)

        public void UpdateInfo(string varUserId)
        {
            DataSet MyDataSet = new DataSet();




            con = new SqlConnection(objConn.AppConnectionString);

            SqlCommand command = new SqlCommand("insert_resignation_empdetails", con);

            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@TicketNo", varUserId);
            command.Parameters.AddWithValue("@emp_id", "");
            command.Parameters.AddWithValue("@current_gross_salary", grsal_txt);
            command.Parameters.AddWithValue("@reliving_date", reliving_date_txt);
            command.Parameters.AddWithValue("@approver_name", approver_name_txt);
            command.Parameters.AddWithValue("@separation_reason", reason_for_separation);
            command.Parameters.AddWithValue("@approver_email_id", approver_email_id_txt);
            command.Parameters.AddWithValue("@present_address", present_add_txt);
            command.Parameters.AddWithValue("@present_country", country_txt);
            command.Parameters.AddWithValue("@present_area", area_txt);
            command.Parameters.AddWithValue("@present_state", state_txt);
            command.Parameters.AddWithValue("@present_city", city_txt);
            command.Parameters.AddWithValue("@present_postal_code", zip_code_txt);
            command.Parameters.AddWithValue("@contact_no", contact_no_txt);
            command.Parameters.AddWithValue("@permanant_address", permanant_add_txt);
            command.Parameters.AddWithValue("@permanant_area", p_area_txt);
            command.Parameters.AddWithValue("@permanant_state", p_state_txt);
            command.Parameters.AddWithValue("@permanant_city", city_txt);
            command.Parameters.AddWithValue("@permanant_postal_code", p_zip_code);
            command.Parameters.AddWithValue("@alternate_contact_no", p_contact_no_txt);
            command.Parameters.AddWithValue("@p_emailid", p_emailid_txt);
            command.Parameters.AddWithValue("@alternate_emailid", alternate_emailid_txt);
            command.Parameters.AddWithValue("@permanant_country", p_country_txt);
            command.Parameters.AddWithValue("@BranchID", str_Branch_id);
            //command.Parameters.AddWithValue("@TicketNo", "");


            SqlParameter VarResult = new SqlParameter();
            VarResult.SqlDbType = SqlDbType.NVarChar;
            VarResult.ParameterName = "@VarResult";
            VarResult.Size = 200;
            VarResult.Direction = ParameterDirection.Output;
            command.Parameters.Add(VarResult);

            con.Open();
            command.ExecuteNonQuery();
            con.Close();


            string RowEffected = Convert.ToString(command.Parameters["@VarResult"].Value);


        }


        //leave page insert data (Akanksha)



        public void leave_Insert(string varUserId1)
        {
            DataSet MyDataSet1 = new DataSet();

            con = new SqlConnection(objConn.AppConnectionString);

            //SqlCommand command = new SqlCommand("sp_leave_insert", con);
            SqlCommand command = new SqlCommand("sp_updateleave_insertleave", con);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Auhoity", ddlauthority);
            command.Parameters.AddWithValue("@emp_id", varUserId1);
            command.Parameters.AddWithValue("@BranchID", str_Branch_id);
            command.Parameters.AddWithValue("@leave_start_date",startdate_txt);
            command.Parameters.AddWithValue("@leave_end_date",lastdate_txt );
            command.Parameters.AddWithValue("@total_days",taotaldy_txt );
            command.Parameters.AddWithValue("@leave_type",leavety_dp );
            command.Parameters.AddWithValue("@reason",reason_txt);
           


            command.Parameters.AddWithValue("@TicketNo", "");

            SqlParameter VarResult1 = new SqlParameter();
            VarResult1.SqlDbType = SqlDbType.NVarChar;
            VarResult1.ParameterName = "@VarResult1";
            VarResult1.Size = 200;
            VarResult1.Direction = ParameterDirection.Output;
            command.Parameters.Add(VarResult1);


            con.Open();
            command.ExecuteNonQuery();
            con.Close();


            string RowEffected1 = Convert.ToString(command.Parameters["@VarResult1"].Value);

 }



        //upadte leave page data(akanksha)

        public void leave_update(string varticketno,string varuserid)
        {
            DataSet MyDataSet1 = new DataSet();

            con = new SqlConnection(objConn.AppConnectionString);

            //SqlCommand command = new SqlCommand("sp_leave_insert", con);
            SqlCommand command = new SqlCommand("sp_updateleave_insertleave", con);

            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@emp_id",varuserid);
            command.Parameters.AddWithValue("@leave_start_date", startdate_txt);
            command.Parameters.AddWithValue("@leave_end_date", lastdate_txt);
            command.Parameters.AddWithValue("@total_days", taotaldy_txt);
            command.Parameters.AddWithValue("@leave_type", leavety_dp);
            command.Parameters.AddWithValue("@reason", reason_txt);
            command.Parameters.AddWithValue("@BranchID", "");

            SqlParameter VarResult1 = new SqlParameter();
            VarResult1.SqlDbType = SqlDbType.NVarChar;
            VarResult1.ParameterName = "@VarResult1";
            VarResult1.Size = 200;
            VarResult1.Direction = ParameterDirection.Output;
            command.Parameters.Add(VarResult1);

           

            command.Parameters.AddWithValue("@TicketNo",varticketno);

           
            con.Open();
            command.ExecuteNonQuery();
            con.Close();

          

        }


        //code for Resignation Authorize page(kanchan)
        // insert records into grid where approved by=null
        public DataSet ClearGrid(string varEmpId)
        {

            //to show only approved by=null records in gridview
            DataSet dm = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            con = new SqlConnection(objConn.AppConnectionString);
            SqlCommand cmd = new SqlCommand("sp_ClearRecord", con);
            cmd.CommandType = CommandType.StoredProcedure;
            adt.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@emp_id", varEmpId);
            adt.Fill(dm);
            return dm;


        }

        //code to Edit Data in textbox(kanchan)
        public DataSet EditGrid(string varEmpId)//resignation form code
        {

            //to show only approved by=null records in gridview
            DataSet dm = new DataSet();
            SqlDataAdapter adt = new SqlDataAdapter();
            con = new SqlConnection(objConn.AppConnectionString);
            SqlCommand cmd = new SqlCommand("sp_EditGridInfo", con);
            cmd.CommandType = CommandType.StoredProcedure;
            adt.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@emp_id", varEmpId);
            adt.Fill(dm);
            return dm;
        }




        //leave_page display grid data(akanksha)
        

        public DataSet griddisplaydata1(string varticketno)
        {

            //to show only approved by=null records in gridview
            DataSet ds2 = new DataSet();
            SqlDataAdapter adpt2 = new SqlDataAdapter();
            con = new SqlConnection(objConn.AppConnectionString);
            SqlCommand cmd = new SqlCommand("sp_displygridview", con);
            cmd.CommandType = CommandType.StoredProcedure;
            adpt2.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@emp_id",varticketno);
            adpt2.Fill(ds2);
            return ds2;

        }



        //leave page caculate days difference(akanksha)

          public DataSet getdatediff()
        {

          
            DataSet mds = new DataSet();
            SqlDataAdapter madpt = new SqlDataAdapter();
            con = new SqlConnection(objConn.AppConnectionString);
            SqlCommand scmd = new SqlCommand("DateDiffCal", con);
            scmd.CommandType = CommandType.StoredProcedure;
            madpt.SelectCommand = scmd;
            scmd.Parameters.AddWithValue("@leave_start_date", startdate_txt1);
            scmd.Parameters.AddWithValue("@leave_end_date", lastdate_txt1);
           
            madpt.Fill(mds);
            return mds;

        }


      
        //leave authorization search(akanksha)

        public DataSet searchdata(string varUserId1)
        {

            DataSet dset = new DataSet();
            SqlDataAdapter sqladpt = new SqlDataAdapter();
            con = new SqlConnection(objConn.AppConnectionString);
            SqlCommand sqlcmd = new SqlCommand("searchdate", con);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqladpt.SelectCommand = sqlcmd;
            sqlcmd.Parameters.AddWithValue("@Auhoity", varUserId1);
            sqlcmd.Parameters.AddWithValue("@leave_start_date",txt_startdate);
            sqlcmd.Parameters.AddWithValue("@leave_end_date",txt_lastdate);
            sqlcmd.Parameters.AddWithValue("@status_leave",dpstatus);
            sqladpt.Fill(dset);
            return dset;

        }   
          


        //leave authorization edit data (akanksha)

        public void EditData(string varid,string UserId)
        {
            DataSet dst = new DataSet();
            con = new SqlConnection(objConn.AppConnectionString);
            SqlCommand command = new SqlCommand("sp_editData", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@TicketNo", varid);
            command.Parameters.AddWithValue("@leave_app_date", txt_app_date);
            command.Parameters.AddWithValue("@leave_app_end_date", txt_app_end_date);
            command.Parameters.AddWithValue("@status_leave",dpsatus);
            command.Parameters.AddWithValue("@Remark",txt_remark);
            command.Parameters.AddWithValue("@approved_by",UserId);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
        }


        //leave count display

        public DataSet leavecountdisply()
        {

          
            DataSet lds = new DataSet();
            SqlDataAdapter sadpt2 = new SqlDataAdapter();
            con = new SqlConnection(objConn.AppConnectionString);
            SqlCommand scmd = new SqlCommand("leave_type_display", con);
            scmd.CommandType = CommandType.StoredProcedure;
            sadpt2.SelectCommand = scmd;
            sadpt2.Fill(lds);
            return lds;

        }

     
        // calender(Rupesh sir)
        public string strDate(string strInDate)
        {
            string strDD = strInDate.Substring(0, 2);

            string strMM = strInDate.Substring(3, 2);

            string strYYYY = strInDate.Substring(6, 4);

           // string strMMDDYYYY = strMM + "/" + strDD + "/" + strYYYY;

            string strMMDDYYYY = strDD + "/" + strMM + "/" + strYYYY;

            DateTime dtConvertDate = Convert.ToDateTime(strMMDDYYYY);

            string strOutDate = dtConvertDate.ToString("dd-MMM-yyyy");

            return strOutDate;
        }

    }
}