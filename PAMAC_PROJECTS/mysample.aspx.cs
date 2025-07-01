using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.IO;

namespace Pamac_Projects
{
    public partial class mysample : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
  
            if (!IsPostBack)
            {
                //  Session["sesfieldlist"] = "1";
                Session["iterations"] = 0;
                Session["sesfieldlist"] = "1";
                            string menuname = Request.QueryString["menuname"];
                            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                       //     int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                //  getgridview_search("1");
           
            }
            int sesit = Convert.ToInt32(Session["iterations"]);
            if (sesit  == 1)
            {

           
                string hr = Session["headrow"].ToString();
                string svl = Session["selval"].ToString();
                topfields_3(3, hr,  svl);
               
            }
            if (sesit == 0)
            {
            topfields(2);
            }
            if (sesit == 2)
            {
                topfields(3);
            }

        }

    
        protected void topfields(int field_show_in) // to be wrpnlitten
        {
            string menuname = Request.QueryString["menuname"];
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
        //    int activityid = 1;// Convert.ToInt32(Request.QueryString["Activityid"]);

            //PlaceholderControls.Controls.Add
            PlaceholderControls.Controls.Add(new LiteralControl("<div>" +  //  class='box'
                    "<div class='box-header with-border'>" + "<h2 class='box-title'>" + menuname + "<br>" +
                    "</div>" + "</div>"));


            DataTable dt = new DataTable();
            FieldData fielddata = new FieldData();

          //  dt = fielddata.GetFieldData(menuid, activityid, field_show_in);
            dt = fielddata.GetFieldData(menuid,  field_show_in);
            string inputtype = "";
            String labelnames = "";
            String fieldids = "";
            int num = 20;

            string tblName = "";
            String fieldName = "";
            String fieldtype = "";
            string validation_req = "";
            int tno = 0;


            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    int reccnt = 0;
                    PlaceholderControls.Controls.Add(new LiteralControl("<tr>"));

                    foreach (DataRow dr in dt.Rows) // do something for each field
                    {
                       
                        if (reccnt % 2 == 0)    //> 1
                        {
                            PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr>"));
                        }
                        reccnt = reccnt + 1;
                        inputtype = dr["input_type"].ToString().ToUpper();
                        labelnames = dr["label_name"].ToString();
                        labelnames = labelnames.Replace(" ", "");
                 
                        fieldids = dr["fields_id"].ToString();

                        string maxlength = dr["input_maxLength"].ToString();
                        num = Int32.Parse(dr["input_maxLength"].ToString());
                        tblName = dr["select_table"].ToString();
                        fieldName = dr["field_Name"].ToString();
                        fieldtype = dr["field_type"].ToString();
                        validation_req = dr["validation_req"].ToString();


                        {
                            if (inputtype == "INPUTBOX")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>" + labelnames ));

                                TextBox fieldidT = new TextBox();
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                fieldidT.ID = "txt" + fieldName;

                                string fldt = fieldidT.ID;

                                PlaceholderControls.Controls.Add(fieldidT);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));


                                tno = tno + 1;
                            }
                            if (inputtype == "SELECT")
                            {
                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                DropDownList ddArea = new DropDownList();
                                ddArea.ID = "ddl" + fieldName;
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(ddArea);

                                Binddata(tblName, ddArea, fieldName, labelnames);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                            }
                            if (inputtype == "LISTBOX")
                            {
                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                ListBox lstArea = new ListBox();
                                lstArea.ID = "lst" + fieldName;
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(lstArea);
                     

                                lstArea.SelectionMode = ListSelectionMode.Multiple;
                                    
                                  
                                Binddata1(tblName, lstArea, fieldName, labelnames);

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                            }



                            if (inputtype == "DATETIME")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox fieldidT = new TextBox();
                                fieldidT.ID = "dat" + fieldName;
                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldidT.Attributes.Add("class", "datepicker");

                                PlaceholderControls.Controls.Add(fieldidT);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "TEXTAREA")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox textArea = new TextBox();
                                textArea.TextMode = TextBoxMode.MultiLine;
                                textArea.ID = "txA" + fieldName;
                                PlaceholderControls.Controls.Add(textArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "CHECKBOX")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                CheckBox cbArea = new CheckBox();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                cbArea.ID = "chk" + fieldName;
                                PlaceholderControls.Controls.Add(cbArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "RADIO")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<tr><td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));

                                string[] values = tblName.Split(',');
                                for (int i = 0; i < values.Length; i++)
                                {
                                    values[i] = values[i].Trim();
                                }

                                for (int i = 1; i <= num; i++)
                                {

                                    RadioButton rbitem = new RadioButton();
                                    rbitem.ID = values[i - 1].Trim(); //"rb" + i + fieldName;
                                                                      //rbitem.ID = "rb"+i + labelnames;
                                    rbitem.Text = rbitem.ID;
                                    PlaceholderControls.Controls.Add(rbitem);

                                }
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "FILE")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px' font_size=10>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                FileUpload fileArea = new FileUpload();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                fileArea.ID = "fil" + labelnames;
                                PlaceholderControls.Controls.Add(fileArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }

                            if (inputtype == "BUTTON")
                            {

                                PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                                Button button = new Button();
                                button.ID = "btn" + fieldName;
                                button.Text = labelnames;
                                button.BackColor = Color.DarkGray;
                                button.Font.Size = 10;
                                button.Font.Underline = true;
                                button.Width = 200;
                                button.Height = 40;
                                button.ForeColor = Color.Black;

                                
                            
                                button.Click += new EventHandler(ButtonClickCommonEvent);
                             

                                PlaceholderControls.Controls.Add(button); // here
                               
                                //PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                //PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                            }

                        }
                    }

                }
                //string fieldlist = Session["sesfieldlist"].ToString();

                //getgridview_search(fieldlist);

            }
        }
        protected void topfields_3(int field_show_in,string headerRowText,string selval) // to bestring headerRowText written
        {
            string menuname = Request.QueryString["menuname"];
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
        //    int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
            Session["headrow"] = headerRowText;
            Session["selval"] = selval;


            PlaceholderControls.Controls.Add(new LiteralControl("<div class='box'>" +
                    "<div class='box-header with-border'>" + "<h2 class='box-title'>" + menuname + "<br>" +
                    "</div>" + "</div>"));


            DataTable dt = new DataTable();
            FieldData fielddata = new FieldData();

            dt = fielddata.GetFieldData(menuid,  field_show_in);

            string inputtype = "";
            String labelnames = "";
            String fieldids = "";
            int num = 20;

            string tblName = "";
            String fieldName = "";
            String fieldtype = "";
            int tno = 0;
            string fieldval = "";
            int validation_req = 0;

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    int reccnt = 1;
                    PlaceholderControls.Controls.Add(new LiteralControl("<tr>"));

                 foreach (DataRow dr in dt.Rows) // do something for each field
                    {
                        reccnt = reccnt + 1;
                        if (reccnt % 2 == 0)    //> 1
                        {
                            PlaceholderControls.Controls.Add(new LiteralControl("</tr><tr>"));
                        }

                        inputtype = dr["input_type"].ToString().ToUpper();
                        labelnames = dr["label_name"].ToString();
                        labelnames = labelnames.Replace(" ", "");

                        fieldids = dr["fields_id"].ToString();

                        string maxlength = dr["input_maxLength"].ToString();
                        num = Int32.Parse(dr["input_maxLength"].ToString());
                        tblName = dr["select_table"].ToString();
                        fieldName = dr["field_Name"].ToString();
                        fieldtype = dr["field_type"].ToString();
                        validation_req = Int32.Parse(dr["validation_req"].ToString());

                        if (inputtype  != "BUTTON" )
                        { 
                                SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

                                SqlCommand sqlCom = new SqlCommand();
                                sqlCom.Connection = sqlCon1;
                                sqlCom.CommandType = CommandType.StoredProcedure;
                                sqlCom.CommandText = "SP_geteditdata";
                                SqlDataAdapter da = new SqlDataAdapter(sqlCom);

                                    SqlParameter menu = new SqlParameter();
                                    menu.SqlDbType = SqlDbType.VarChar;
                                    menu.Value = menuid;
                                    menu.ParameterName = "@menuid";
                                    sqlCom.Parameters.Add(menu);

                                    //SqlParameter activity = new SqlParameter();
                                    //activity.SqlDbType = SqlDbType.VarChar;
                                    //activity.Value = activityid;
                                    //activity.ParameterName = "@activityid";
                                    //sqlCom.Parameters.Add(activity);

                                    SqlParameter fldname = new SqlParameter();
                                    fldname.SqlDbType = SqlDbType.VarChar;
                                    fldname.Value = fieldName;
                                    fldname.ParameterName = "@fldname";
                                    sqlCom.Parameters.Add(fldname);

                                    SqlParameter headertext = new SqlParameter();
                                    headertext.SqlDbType = SqlDbType.VarChar;
                                    headertext.Value = headerRowText;
                                    headertext.ParameterName = "@headerRowText";
                                    sqlCom.Parameters.Add(headertext);

                                    SqlParameter selev = new SqlParameter();
                                    selev.SqlDbType = SqlDbType.VarChar;
                                    selev.Value = selval;
                                    selev.ParameterName = "@selval";
                                    sqlCom.Parameters.Add(selev);

                                    DataSet ds = new DataSet();
                                    da.Fill(ds);

                                    if (ds != null && ds.Tables.Count > 0)
                                    {
                                        fieldval = ds.Tables[0].Rows[0][fieldName].ToString();
                                string str = "field" + reccnt;
                          
                                Session[str] = "txt"+ fieldName +'-'+ fieldval;

                                string fl1 = Session[str].ToString();
                            }
                        }
                        {
                            if (inputtype == "INPUTBOX")
                            {
                                //labelnames = fieldName;
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px' font-size='medium'>" +"<b>"+ labelnames+"</b>"));

                                TextBox fieldidT = new TextBox();
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                fieldidT.ID = "txt" + fieldName;
                                fieldidT.Text = fieldval;
                               
                                string fldt = fieldidT.ID;


                                PlaceholderControls.Controls.Add(fieldidT);
                              
                                if (validation_req == 1 )
                                { 
                                RequiredFieldValidator req = new RequiredFieldValidator();
                                req.ID = "rfvDynamic" + fieldidT.ID;
                                req.Font.Bold = true;
                                req.SetFocusOnError = true;
                                req.ErrorMessage = "Required";
                                req.ControlToValidate = fieldidT.ID;
                                PlaceholderControls.Controls.Add(req);
                                
                                }
                                if (fieldtype=="INT")
                                { 
                                fieldidT.Attributes.Add("onkeypress", "return isNumber(event);");
                                

                                }
                                fieldidT.Attributes.Add("maxlength", maxlength);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));


                                tno = tno + 1;
                            }
                            if (inputtype == "SELECT")
                            {
                                if (fieldName == "fe-id") { fieldName = "empid"; }
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                DropDownList ddArea = new DropDownList();
                                ddArea.ID = "ddl" + fieldName;
                       
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                PlaceholderControls.Controls.Add(ddArea);

                                Binddata(tblName, ddArea, fieldName, labelnames);
                                ddArea.SelectedValue = fieldval;
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));

                            }
                            if (inputtype == "DATETIME")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox fieldidT = new TextBox();
                                fieldidT.ID = "dat" + fieldName;
                               
                                PlaceholderControls.Controls.Add(fieldidT);
                                fieldidT.Attributes.Add("class", "datepicker");

                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "TEXTAREA")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                TextBox textArea = new TextBox();
                                textArea.TextMode = TextBoxMode.MultiLine;
                                textArea.ID = "txA" + fieldName;
                                PlaceholderControls.Controls.Add(textArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "CHECKBOX")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                CheckBox cbArea = new CheckBox();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                cbArea.ID = "chk" + fieldName;
                                PlaceholderControls.Controls.Add(cbArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "RADIO")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<tr><td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));

                                string[] values = tblName.Split(',');
                                for (int i = 0; i < values.Length; i++)
                                {
                                    values[i] = values[i].Trim();
                                }

                                for (int i = 1; i <= num; i++)
                                {

                                    RadioButton rbitem = new RadioButton();
                                    rbitem.ID = values[i - 1].Trim(); //"rb" + i + fieldName;
                                                                      //rbitem.ID = "rb"+i + labelnames;
                                    rbitem.Text = rbitem.ID;
                                    PlaceholderControls.Controls.Add(rbitem);

                                }
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                            if (inputtype == "FILE")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<td class='TableTitle' style='width: 100px'>"));
                                PlaceholderControls.Controls.Add(new LiteralControl(labelnames));
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                                PlaceholderControls.Controls.Add(new LiteralControl("<td style = 'width: 100px' >"));
                                FileUpload fileArea = new FileUpload();
                                //  textArea.TextMode = TextBoxMode.MultiLine;
                                fileArea.ID = "fil" + labelnames;
                                PlaceholderControls.Controls.Add(fileArea);
                                PlaceholderControls.Controls.Add(new LiteralControl("</td>"));
                            }
                             }
                            if (inputtype == "BUTTON")
                            {
                                PlaceholderControls.Controls.Add(new LiteralControl("<tr><td>"));
                                Button button = new Button();
                                button.ID = "btn" + fieldName;
                                button.Text = labelnames;
                                button.BackColor = Color.Blue;
                                //if (button.Text=="save")
                                //{
                                button.Click += new EventHandler(ButtonClickCommonEvent);
                                PlaceholderControls.Controls.Add(button); // here
                                PlaceholderControls.Controls.Add(new LiteralControl("</td></tr>"));

                                PlaceholderControls.Controls.Add(new LiteralControl("<td>"));
                            }

                       
                    }

                }
                //string fieldlist = Session["sesfieldlist"].ToString();

                //getgridview_search(fieldlist);

            }
        }
        void getgridview_search(string fieldlist)
        {
            Session["sesfieldlist"] = fieldlist;
            string fields1 = Session["sesfieldlist"].ToString();

            SqlConnection Sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            if (Sqlcon.State == ConnectionState.Closed)
            {
                string menuname = Request.QueryString["menuname"];
                int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
          //      int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);


                Sqlcon.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Sqlcon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_getgridvalue_search";
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@menuid", menuid);
        //        cmd.Parameters.AddWithValue("@activityID", activityid);
                cmd.Parameters.AddWithValue("@fieldlist", fieldlist);


                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                int SqlRow = 0;
                SqlRow = cmd.ExecuteNonQuery();

                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    //lblMessage.Text = " I am here";

                    grv1.DataSource = dt;
                    grv1.DataBind();
                    if (menuid < 24)
                    {
                     //  grv1.Columns[0].Visible = false;
                        grv1.Columns[1].Visible = false;
                    }
                    }
                else
                {
                    grv1.DataSource = null;
                    grv1.DataBind();
                }
            }
        }

        protected void ButtonClickCommonEvent(object sender, EventArgs e) // general
        {

            string actres = "";

            Button btn = (Button)sender;
            actres = btn.Text;

            switch (actres)
            {
                case "Search":
                    searchevent();
                    break;

                //case "ManualAssign":
                    //checkboxclick();
                //    break;

                case "Save":
                    saveevent();
                    lblMessage.Text = "  Record Saved successfully";
                    Session["iterations"] = 0;
                   PlaceholderControls.Controls.Clear();
                  
                //    Response.Redirect("Mysample.aspx?menuid=" + 3 + "&menuname= " + "Demat_DataEntry", false);
                    //string menuname = Request.QueryString["menuname"];
                    //int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                    //int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                    grv1.Visible = true;
                //    getgridview_search("1");
                    break;
                case "ADD":
                    //   Addevent();
                    Session["iterations"] = 2;
                    PlaceholderControls.Controls.Clear();
                    grv1.Visible = false;
                    topfields(3);
                    lblMessage.Text = actres + "  Please Add new records and save";
                    break;

                case "Back":
                    string menuname = Request.QueryString["menuname"];
                    int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                    int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                    Response.Redirect("ENAM_MenuPage.aspx", false);
                  //  Response.Redirect("Mysample.aspx?menuid=" + menuid + "&menuname= " + menuname + "&Activityid=1", false);
                    break;
                case "GO_TO_FIRST_HOLDER":
                    //string menuname = Request.QueryString["menuname"];
                    //int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                    //int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                    //lblMessage.Text = Session["PMSCode"].ToString();
                    
                    Response.Redirect("Mysample.aspx?menuid=" + 2 + "&menuname= " + "AOF_Dataentry" + "&Activityid=1", false);
                    break;
                case "GO_TO_SECOND_HOLDER":
                    //string menuname = Request.QueryString["menuname"];
                    //int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                    //int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                 //   lblMessage.Text = Session["PMSCode"].ToString();
                    Response.Redirect("Mysample.aspx?menuid=" + 3 + "&menuname= " + "AOF_DataEntry" + "&Activityid=1", false);
                    break;
                case "GO_TO_THIRD_HOLDER":
                    //string menuname = Request.QueryString["menuname"];
                    //int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
                    //int activityid = Convert.ToInt32(Request.QueryString["Activityid"]);
                  //  lblMessage.Text = Session["PMSCode"].ToString();
                    Response.Redirect("Mysample.aspx?menuid=" + 4 + "&menuname= " + "AOF_DataEntry" + "&Activityid=13", false);
                    break;
                default:
                    lblMessage.Text = actres + "  button clicked";
                    break;
            }
            return;



        }
        protected void saveevent() // to be written
        {
            string message = "";
            lblMessage.Text = "";
            string updatevalue = "";
            foreach (TextBox textBox in PlaceholderControls.Controls.OfType<TextBox>())
            {
                lblMessage.Text += textBox.ID.Substring(3) + ",";
                message += "'" + textBox.Text + "'" + ",";
                updatevalue += textBox.ID.Substring(3) + "=" + "'" + textBox.Text + "'" + ",";

            }
            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {
                lblMessage.Text += ddl.ID.Substring(3) + ",";
                message += "'" + ddl.SelectedValue + "'" + ",";
                updatevalue += ddl.ID.Substring(3) + "=" + "'" + ddl.SelectedValue + "'" + ",";
            }
            foreach (CheckBox chk in PlaceholderControls.Controls.OfType<CheckBox>())
            {
                lblMessage.Text += chk.ID.Substring(3) + ",";
                message += "'" + chk.Checked + "'" + ",";
                updatevalue += chk.ID.Substring(3) + "="+ "'" + "'" + chk.Checked + "'" + ",";
            }
            foreach (FileUpload fup in PlaceholderControls.Controls.OfType<FileUpload>())
            {
                lblMessage.Text += fup.ID.Substring(3) + ",";
                message += "'" + fup.FileName + "'" + ",";
                updatevalue += fup.ID.Substring(3) + ","+"'" + fup.FileName + "'" + ",";
            }

          
            int sesit = Convert.ToInt32(Session["iterations"]);

            string hr = "";
            string svl = "";
            string menuname = Request.QueryString["menuname"];
            int menuid = Convert.ToInt32(Request.QueryString["menuid"]);
          //  int activityid = Convert.ToInt32(Request.QueryString["Activityid"]); 
            String valforupdate = "";
            String tosendtosql = "";
            String valtosendtosql = "";
            if (sesit == 1)
            {
                 hr = Session["headrow"].ToString();
                svl = Session["selval"].ToString();
               
                valforupdate = updatevalue.TrimEnd(',');

                string hrv = hr + "='" + svl+ "'" ;

                valforupdate = valforupdate.Replace(hrv, "");
                 
                valforupdate = valforupdate.TrimEnd(',');
                //valforupdate = valforupdate.Substring(valforupdate.IndexOf(',') + 1);
                valforupdate = valforupdate.TrimStart(',');
                valtosendtosql = valforupdate;
                tosendtosql = "x";
            }
            else
            {
                hr = "0";
                svl = "0";
                tosendtosql = lblMessage.Text.TrimEnd(',');
                tosendtosql = tosendtosql.Substring(tosendtosql.IndexOf(',') + 1);
                valtosendtosql = message.TrimEnd(',');
                valtosendtosql = valtosendtosql.Substring(valtosendtosql.IndexOf(',') + 1);
            }

            SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sqlCon;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_save";
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@menuid", menuid);
            //    cmd.Parameters.AddWithValue("@activityID", activityid);
                cmd.Parameters.AddWithValue("@headrow", hr);
                cmd.Parameters.AddWithValue("@selval", svl);
                cmd.Parameters.AddWithValue("@sessit", sesit);
                cmd.Parameters.AddWithValue("@fieldlist", tosendtosql);
                cmd.Parameters.AddWithValue("@fieldvalue", valtosendtosql);


                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;

                int SqlRow = 0;
                SqlRow = cmd.ExecuteNonQuery();
            }
            Session["iterations"] = 0;
                        }
        protected void searchevent()
        {
            lblMessage.Text = "button1 clicked  SEARCH ";
        
            string message = "";
            string forsearch = "";
            foreach (TextBox textBox in PlaceholderControls.Controls.OfType<TextBox>())
            {
                lblMessage.Text += textBox.ID.Substring(3) + ",";
                message += "'" + textBox.Text + "'" + ",";
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    //textBox.Text = "x";
                }
                else
                {
                    forsearch += textBox.ID.Substring(3) + ",";
                    forsearch += "'" + textBox.Text + "'" + ",";
                }
            }
            foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
            {
                lblMessage.Text += ddl.ID.Substring(3) + ",";
                message += "'" + ddl.SelectedValue + "'" + ",";
                if (ddl.SelectedValue == "--Select--")
                {
                    ddl.SelectedValue = null;
                }
                else
                {
                    forsearch += ddl.ID.Substring(3) + ",";
                    forsearch += "'" + ddl.SelectedValue + "'" + ",";
                }
            }

            foreach (ListBox lst in PlaceholderControls.Controls.OfType<ListBox>())
            {
                //lblMessage.Text += lst.ID.Substring(3) + ",";
                //message += "'" + lst.SelectedValue + "'" + ",";
                if (lst.SelectedValue == "--Select--")
                {
                    lst.SelectedValue = null;
                }
                else
                {
                    foreach (ListItem item in lst.Items)
                     {
                        if (item.Selected)
                        {
                            forsearch += lst.ID.Substring(3) + ",";
                            forsearch += "'" + item.Value + "'" + ",";
                        }
                  
                    }

                    //forsearch += lst.ID.Substring(3) + ",";
                    //forsearch += "'" + lst.SelectedValue + "'" + ",";
                }
            }

            foreach (CheckBox chk in PlaceholderControls.Controls.OfType<CheckBox>())
            {
                lblMessage.Text += chk.ID.Substring(3) + ",";
                message += "'" + chk.Checked + "'" + ",";
                forsearch += chk.ID.Substring(3) + ",";
                forsearch += "'" + chk.Checked + "'" + ",";
            }


            string toforsearch = forsearch;
            toforsearch = toforsearch.TrimEnd(',');

            Session["sesfieldlist"] = toforsearch;
            string fields = Session["sesfieldlist"].ToString();
            if (fields == "")
            {
                lblMessage.Text = "Please select atlast one field in filter";
                return;

            }

            getgridview_search(toforsearch);



            // Search griddata from gridview

        }

  
        void Binddata(String tblName1, DropDownList ddl, String fieldname, String labelname)
        {
            try
            {
                SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());

                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_binddata";
                SqlDataAdapter da = new SqlDataAdapter(sqlCom);

                //SqlParameter tbl = new SqlParameter();
                //tbl.SqlDbType = SqlDbType.VarChar;
                //tbl.Value = tblName1;
                //tbl.ParameterName = "@tblname";
                //sqlCom.Parameters.Add(tbl);

                SqlParameter fldname = new SqlParameter();
                fldname.SqlDbType = SqlDbType.VarChar;
                fldname.Value = fieldname;
                fldname.ParameterName = "@fldname";
                sqlCom.Parameters.Add(fldname);

                //SqlParameter lblname = new SqlParameter();
                //lblname.SqlDbType = SqlDbType.VarChar;
                //lblname.Value = labelname;
                //lblname.ParameterName = "@lblname";
                //sqlCom.Parameters.Add(lblname);

                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {

                    ddl.DataTextField = "DTF";
                    ddl.DataValueField = "DTV";
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataBind();
                  //  ddl.Items.Insert(0, "--Select--");
                 //   ddl.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        void Binddata1(String tblName1, ListBox ddl, String fieldname, String labelname)
        {
            try
            {

                SqlConnection sqlCon1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand sqlCom = new SqlCommand();
                sqlCom.Connection = sqlCon1;
                sqlCom.CommandType = CommandType.StoredProcedure;
                sqlCom.CommandText = "SP_binddata";
                SqlDataAdapter da = new SqlDataAdapter(sqlCom);

                SqlParameter tbl = new SqlParameter();
                tbl.SqlDbType = SqlDbType.VarChar;
                tbl.Value = tblName1;
                tbl.ParameterName = "@tblname";
                sqlCom.Parameters.Add(tbl);

                SqlParameter fldname = new SqlParameter();
                fldname.SqlDbType = SqlDbType.VarChar;
                fldname.Value = fieldname;
                fldname.ParameterName = "@fldname";
                sqlCom.Parameters.Add(fldname);

                SqlParameter lblname = new SqlParameter();
                lblname.SqlDbType = SqlDbType.VarChar;
                lblname.Value = labelname;
                lblname.ParameterName = "@lblname";
                sqlCom.Parameters.Add(lblname);

                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0)
                {


                    ddl.DataTextField = "DTF";
                    ddl.DataValueField = "DTV";
                    ddl.DataSource = ds.Tables[0];
                    ddl.DataBind();
                    ddl.Items.Insert(0, "--Select--");
                    ddl.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void grv1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grv1.PageIndex = e.NewPageIndex;

            string fieldlist = Session["sesfieldlist"].ToString();
            getgridview_search(fieldlist);

        }

        //protected void checkboxclick()
        //{
        //    foreach (DropDownList ddl in PlaceholderControls.Controls.OfType<DropDownList>())
        //    {
        //        // lblMessage.Text += ddl.ID + ",";
        //        if (ddl.ID == "ddlempid") 
        //        {

        //            if (ddl.SelectedValue == "--Select--")
        //            {
        //                lblMessage.Text = "Please select an employee";
        //                return;
        //            }
        //            else
        //            {
        //                lblMessage.Text += ddl.ID + ",";
        //                lblMessage.Text += ddl.SelectedValue.ToString();
        //                string emplid = ddl.SelectedValue.ToString();
        //            }
                                     

        //        }
        //    }

        //    Session["iterations"] = 1;
           
        //    lblMessage.Text = "";
        //    int field_show_in = 0;
        //    //     grv1.Visible = false;

        //    //PlaceholderControls.Controls.Clear();
            
        //    string selval = null;
        //    //try
        //    //{
        //    int numboxchecked = 0;
        //    for (int i = 0; i <= grv1.Rows.Count - 1; i++)

        //    {
        //        CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");
        //        // LinkButton IP = (LinkButton)grv1.Rows[i].FindControl("lnkWIP");

        //        if (chkSelect.Checked == true)
        //        {
        //          //  PlaceholderControls.Controls.Clear();
        //            string headerRowText = grv1.HeaderRow.Cells[2].Text;
        //            selval = grv1.Rows[i].Cells[2].Text.Trim();
        //            numboxchecked = 1;

        //            //lblMessage.Text = selval;
        //            field_show_in = 3;

        //            topfields_3(field_show_in, headerRowText, selval);
        //            break;
        //        }
        //    }
        //    if (numboxchecked == 0)
        //    {
        //        lblMessage.Text = "Please select one record from the grid";
        //    }
        //    else
        //    {
        //        grv1.Visible = true;

        //        // update the case id in tbl_cases and others if any
        //        lblMessage.Text = "Case " + selval + "selected";

        //        // uptdate tbl_cases set fe_id = empid?, assign_status='Assign',       where case_id= selval
        //        // insert into fe_assign (not required)  fe_id, caseId, Client_id
        //        /* insert into case_history 
        //         build json and keep it ready in the field details based on the template id provided in tbl_cases
        //          (probably filled during import - to check)
        //          that is to be used for this client
        //         for being picked up by Mobile application when the fe (mobile user)
        //         clicks on menu - Accept - Thena all case details are sent through this detail column
        //         as json file */

        //    }

        //}
        protected void lnkWIP_Click(object sender, EventArgs e)
        {

            Session["iterations"] = 1;

            lblMessage.Text = "";
            int field_show_in = 0;
            //     grv1.Visible = false;

            //PlaceholderControls.Controls.Clear();

            string selval = null;
            //try
            //{
            int numboxchecked = 0;
            for (int i = 0; i <= grv1.Rows.Count - 1; i++)

            {
                CheckBox chkSelect = (CheckBox)grv1.Rows[i].FindControl("chkSelect");
                // LinkButton IP = (LinkButton)grv1.Rows[i].FindControl("lnkWIP");
           
                if (chkSelect.Checked == true)
                {
                    PlaceholderControls.Controls.Clear();
                    string headerRowText = grv1.HeaderRow.Cells[2].Text;
                    selval = grv1.Rows[i].Cells[2].Text.Trim();
                    numboxchecked = 1;

                    //lblMessage.Text = selval;
                    field_show_in = 3;

                    topfields_3(field_show_in, headerRowText,selval);
                    break;
                }
            }
            if (numboxchecked == 0)
            {
                lblMessage.Text = "Please select one record from the grid";
            }
            else
            {
                 grv1.Visible = false;
            }
            
        }

        protected void btnSaveandContinue_Click(object sender, EventArgs e)
        {

        }


        // string headerRowText = grv1.HeaderRow.Cells[2].Text;

        //        //if (headerRowText=="case_id")
        //        //{


        //        //}






        //    }

        //}
        //catch (Exception ex)
        //{
        //    lblMessage.Visible = true;
        //    lblMessage.Text = "Error :" + ex.Message;
        //}

    }
}


        
    

    
    

