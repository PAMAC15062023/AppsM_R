using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


using System.Globalization;
using Rectangle = iTextSharp.text.Rectangle;

namespace Pamac_Projects
{
    public partial class generate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //  string templateFilePath = Server.MapPath("/ImageTemplates/");


            //string templateFilePath = Server.MapPath("/ImageTemplates/");
            //int fileCount = Directory.GetFiles(@templateFilePath).Length;

            //int count = Directory.GetFiles(templateFilePath, "ENAM*.*").Length;

            if (!IsPostBack)
            {

                lblmsg.Text = "Please select an item from the grid to generate PDF";
                Get_DataForPDF(0);
                //   texttopdf();
            }

            lblmsg.Text = "";
        }

        private void Get_DataForPDF(int sid)
        {
            SqlConnection Sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Sqlcon;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ENAM_getCasesforPDF";
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@SID", sid);
            //cmd.Parameters.AddWithValue("@ToDate", strDate(txtToDate.Text.Trim()));
            //cmd.Parameters.AddWithValue("@Role", ddlStagge.SelectedItem.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);


            if (dt.Rows.Count > 0)
            {
                grdcases.DataSource = dt;
                grdcases.DataBind();
                //   grdtransaction.na name.Columns[10].Visible = false
                //for (int i = 0; i < grdcases.Rows.Count; i++)
                //{
                //    HyperLink hlContro = new HyperLink();
                //    hlContro.NavigateUrl = "./newPage.aspx?ID=" + grdcases.Rows[i].Cells[3].Text;
                //  //  hlContro.ImageUrl = "./sample.jpg";
                //    hlContro.Text = grdcases.Rows[i].Cells[3].Text;
                //    grdcases.Rows[i].Cells[3].Controls.Add(hlContro);
                //}
               

            }
            else
            {
                grdcases.DataSource = null;
                grdcases.DataBind();
            }
        }

        protected void lnkWIP_Click(object sender, EventArgs e)
        {

            //    return;

            //lblmsg.Text = "in wip";
            //lblmsg.Text = "";
            //try
            //{
            for (int i = 0; i <= grdcases.Rows.Count - 1; i++)
            {
                CheckBox chkSelect = (CheckBox)grdcases.Rows[i].FindControl("chkSelect");
                LinkButton IP = (LinkButton)grdcases.Rows[i].FindControl("lnIP");

                if (chkSelect.Checked == true)
                {
                   // lblmsg.Text = "Selected ID = " + grdcases.Rows[i].Cells[2].Text;

                    //String pmscode = Session["PMSCODE"].ToString();
                    texttopdf(i);
                    mutiplepdftoSinglepdf(i);
                    lblmsg.Text = "Case No "+ grdcases.Rows[i].Cells[4].Text + " Completed";
                }
            }
        }
        protected void texttopdf(int i)
        {
          
            string clientname = grdcases.Rows[i].Cells[3].Text;
            string pmscode = grdcases.Rows[i].Cells[4].Text;
            Session["PMSCODE"] = pmscode;
            string documentname = "AOF";

            // number of pages is equal to the number page template for the specific client
            // currently assuming one client one document

            string templateFilePath = Server.MapPath("/PDFTemplates/");
     

            int fileCount = Directory.GetFiles(templateFilePath, clientname + "*.pdf").Length;
            //fileCount = 1;
       


            for ( int p = 1; p <= fileCount; p++)
            {
                
                string p1 = "";
                if (p < 10 )
                {
                     p1 = '0' + (p).ToString();
                }
                else
                {
                    p1 = (p).ToString();
                }

                string oldFile = Server.MapPath("/PDFTemplates/ENAM_tempLate_" + (p).ToString() + ".pdf");
                //string tod = DateTime.Now.ToString("yyyyMMddHHmmss");

                string newFile = Server.MapPath("/PDFgenerated/" + clientname + "_"+ documentname +"_"+  p1 + "_" + pmscode + ".pdf");
                //     string newFile = Server.MapPath("/PDF/newFile" + ".pdf");
                // open the reader
                PdfReader reader = new PdfReader(oldFile);

                Rectangle size = reader.GetPageSizeWithRotation(1);

                Document document = new Document(size);


                // open the writer
                FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
          
                // the pdf content
                PdfContentByte cb = writer.DirectContent;
                PdfImportedPage page = writer.GetImportedPage(reader, 1);
                cb.AddTemplate(page, 0, 0);
                // select the font properties
                // BaseFont bf = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                BaseFont bf = BaseFont.CreateFont(BaseFont.COURIER_BOLD, BaseFont.CP1252,BaseFont.NOT_EMBEDDED);
                cb.SetColorFill(BaseColor.BLACK);
                cb.SetFontAndSize(bf, 10);

                // get data for each page
                // get data from datamaster for page 1
                SqlConnection Sqlcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Sqlcon;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ENAM_getFieldMaster";
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@pageno", p);
                cmd.Parameters.AddWithValue("@pmscode", pmscode);
                cmd.Parameters.AddWithValue("@clientname", clientname);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                int rowcount = dt.Rows.Count;

                int x = 0; int y = 0;

                for (int fld = 0; fld <= rowcount - 1; fld++)
                {
                    x = (int)dt.Rows[fld]["x_point"];
                    y = (int)dt.Rows[fld]["y_point"];
                    string fieldname = (string)dt.Rows[fld]["FieldName"];
                    string fieldtype = (string)dt.Rows[fld]["Fieldtype"];
                    string fieldvalue = "";
                    fieldvalue = dt.Rows[fld][fieldname].ToString();
                    char[] cArray = fieldvalue.ToCharArray();
                    string text = String.Join(" ", cArray);
                    if (fieldvalue != "")
                        //        { 
                        if (fieldtype == "datetime")
                        {
                            // fieldvalue = dt.Rows[fld][fieldname].ToString();
                            DateTime dated = Convert.ToDateTime(dt.Rows[fld][fieldname]);

                            fieldvalue = dated.ToString("dd MMyyyy"); // dt.Rows[fld][fieldname].ToString();  // (FormatException dd mm yyyy)
                           cArray = fieldvalue.ToCharArray();
                             text = String.Join(" ", cArray);
                           // text = fieldvalue;
                        }
                    if (fieldtype == "checkbox")
                        {
                            fieldvalue = dt.Rows[fld][fieldname].ToString();
                            if (fieldvalue == "")
                            {
                                fieldvalue = "0";
                            }
                            int fval = int.Parse(fieldvalue);
                            //            // for check box separate table - get the values of x and y based on 
                            //            // the field value
                            SqlConnection Sqlcon1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            SqlCommand cmd1 = new SqlCommand();
                            cmd1.Connection = Sqlcon1;

                            cmd1.CommandType = CommandType.StoredProcedure;
                            cmd1.CommandText = "ENAM_getCheckboxMaster";
                            cmd1.CommandTimeout = 0;
                            cmd1.Parameters.AddWithValue("@fldname", fieldname);
                            cmd1.Parameters.AddWithValue("@fval", fval);
                            // cmd1.Parameters.AddWithValue("@clientname", clientname);
                            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                            DataTable dt1 = new DataTable();
                            da1.Fill(dt1);
                        if (dt1.Rows.Count > 0)
                        {
                            x = (int)dt1.Rows[0]["x_point"];
                            y = (int)dt1.Rows[0]["y_point"];
                            //x = x + (int.Parse(fieldvalue)*10);
                            fieldvalue = "x";
                            text = fieldvalue;
                            if (fval == 99)
                            {
                                string newfield = fieldname + "_Others";
                                fieldvalue = dt.Rows[fld][newfield].ToString();
                                cArray = fieldvalue.ToCharArray();
                                text = String.Join(" ", cArray);
                                //?? how to get the next field name
                            }
                        }
                        else
                        {
                            text = "";
                        }
                        } 
                            cb.BeginText();
                    // put the alignment and coordinates here
         
                        cb.ShowTextAligned(Element.ALIGN_LEFT, text, x, y, 0);
                    cb.EndText();
              
            }
              // create the new page and add it to the pdf
                //PdfImportedPage page = writer.GetImportedPage(reader, 1);
                //cb.AddTemplate(page, 0, 0);
    
                // close the streams and voilá the file should be changed :)
                document.Close();
                fs.Close();
                writer.Close();
                reader.Close();
                
            }

        }
        protected void mutiplepdftoSinglepdf(int i)
        {
            string PDFgeneratedFilePath = Server.MapPath("/PDFGenerated/");
            string clientname = grdcases.Rows[i].Cells[3].Text;
            string pmscode = Session["PMSCODE"].ToString();
            string documentname = "AOF";
            int fileCount = Directory.GetFiles(PDFgeneratedFilePath,clientname + "*.pdf").Length;
            // merge the files here
            using (MemoryStream stream = new MemoryStream())
            {
                using (Document doc = new Document())
                {
                    PdfCopy pdf = new PdfCopy(doc, stream);
                    pdf.CloseStream = false;
                    doc.Open();

                    PdfReader reader = null;
                    PdfImportedPage page = null;

                    foreach (var file in Directory.GetFiles(Server.MapPath("/PDFGenerated/")))
                       
                    {
                        reader = new PdfReader(file);
                        for ( i = 0; i < reader.NumberOfPages; i++)
                        {
                            page = pdf.GetImportedPage(reader, i + 1);
                            pdf.AddPage(page);
                        }

                        pdf.FreeReader(reader);
                        reader.Close();
                    }
                }

                using (FileStream streamX = new FileStream(Server.MapPath("/PDFFinal/"+ clientname+ "_"+documentname +"_"+ pmscode+ ".pdf"), FileMode.Create))
                {
                    stream.WriteTo(streamX);
                }
            }
            // post merging into one PDF delete all individual generated pdfs
            for (int p = 1; p <= fileCount; p++)
            {
               //  pmscode = Session["PMSCODE"].ToString();
                string PDFfilepath = Server.MapPath("/PDFGenerated");
                string p1 = "";
                if (p < 10)
                {
                    p1 = '0' + (p).ToString();
                }
                else
                {
                    p1 = (p).ToString();
                }
                string pdffilename = "/" + clientname  +"_"+documentname +"_"+ p1 + "_" + pmscode + ".pdf";
               File.Delete(PDFfilepath + pdffilename);
            }

        }
    }
        

    }
        
    
        
    
