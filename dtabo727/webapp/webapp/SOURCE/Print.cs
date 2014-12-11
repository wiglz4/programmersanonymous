using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Forms;

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace webapp.SOURCE
{

    public class Print
    {
        
        static String connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        
        
        //modify to do a specific query
        public static bool genLetter(string checkNo, int letterNo)
        {
            DataSet ds = new DataSet();
            DateTime now = DateTime.Now;
            string letterDate = now.ToString();
            

            OleDbConnection connection = new OleDbConnection(connectionString);
            OleDbCommand cmdCheck = new OleDbCommand(@"Select * FROM [Check] WHERE ([Check Number] = @checkNo)", connection);
            cmdCheck.Parameters.AddWithValue("@checkNo", checkNo);

            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdCheck);
            adapter.Fill(ds);
            int amtDue = 0;
            string checkDate = "";
            

            try
            {
                amtDue = int.Parse(ds.Tables[0].Rows[0][2].ToString());
            }
            catch 
            {
                return false;
            }

            try
            {
                checkDate = ds.Tables[0].Rows[0][5].ToString();
            }
            catch
            {
                return false;
            }

            int bankFee = 30;
            int stateFee = 30;
            int fullTotal = amtDue + bankFee + stateFee;
            
            
            string signature = "David Tabor - Bounce House Check Collection";

            switch (letterNo)
            {
                case 1:
                    {
                        string letterHeading = "Your check number " + checkNo + " in the amount of $" + amtDue + ", dated " + checkDate + ",  has been returned by the bank. We have verified with your bank that there are insufficient funds to pay the check.";
                        string letterBody = "Please replace this check with cash or a money order and pay the required state fee of $30 for a total of $" + (amtDue + stateFee) + " within 14 days per South Carolina Law to avoid further collection action. Since this is your first notice, the bank fee will be waived if payment is recieved within 14 days.";
                        string letterClose = "If you have questions about this, please contact the Bounce House Check Collection office at 864-555-5555 between the hours of 9 and 5."; 
                        

                        HttpContext.Current.Session["letterHeading"] = letterHeading;
                        HttpContext.Current.Session["letterBody"] = letterBody;
                        HttpContext.Current.Session["letterClose"] = letterClose;
                        HttpContext.Current.Session["letterSig"] = signature;
                    }
                    return true;

                case 2:
                    {
                        string letterHeading = "Your check number " + checkNo + " in the amount of $" + amtDue + ", dated " + checkDate + ",  has been returned by the bank. We have verified with your bank that there are insufficient funds to pay the check.";
                        string letterBody = "This is your second notice. Please replace this check with cash or a money order, pay the bank charge of $30, and pay the state fee of $30 for a total of " + fullTotal + " within 10 days per South Carolina Law to avoid further collection action.";
                        string letterClose = "If you have questions about this, please contact the Bounce House Check Collection office at 864-555-5555 between the hours of 9 and 5.";

                        HttpContext.Current.Session["letterHeading"] = letterHeading;
                        HttpContext.Current.Session["letterBody"] = letterBody;
                        HttpContext.Current.Session["letterClose"] = letterClose;
                        HttpContext.Current.Session["letterSig"] = signature;
                    }
                    return true;

                case 3:
                    {
                        string letterHeading = "Your check number " + checkNo + " in the amount of $" + amtDue + ", dated " + checkDate + ",  has been returned by the bank. We have verified with your bank that there are insufficient funds to pay the check.";
                        string letterBody = "This is your third notice. Please replace this check with cash or a money order, pay the bank charge of $30, and pay the state fee of $30 for a total of " + fullTotal + " within 14 days per South Carolina Law to avoid further collection action. This is your third notice.If payment is not recieved within 14 days legal action will be taken to the full measure of the law.";
                        string letterClose = "If you have questions about this, please contact the Bounce House Check Collection office at 864-555-5555 between the hours of 9 and 5.";

                        HttpContext.Current.Session["letterHeading"] = letterHeading;
                        HttpContext.Current.Session["letterBody"] = letterBody;
                        HttpContext.Current.Session["letterClose"] = letterClose;
                        HttpContext.Current.Session["letterSig"] = signature;

                    }
                    return true;
                
            }

            //may need to either move StoreID into Check table or write a second Dataset call into the Account table and link the check to the appropriate 
            connection.Close();
            return false;
            
        }

        //accept parameters and instert into paragraph template
        //build paragraph into PDF using iTextSharp
        //returns true if successful
        public static bool singlePDFs(string acctID,string amtDue,string checkNo,string checkDate,int letterNo, int fileNumber)
        {
            string filepath = HttpContext.Current.Server.MapPath("~/App_Data/singlePDFs/" + fileNumber + ".pdf");

            decimal amtDueDec = Decimal.Parse(amtDue);
            Paragraph paragraph = new Paragraph("");
            int bankFee = 30;
            int stateFee = 30;
            int fullTotal = ((int)amtDueDec) + bankFee + stateFee;
            
            switch (letterNo)
            {
                case 0:
                {
                    paragraph = new Paragraph("Dear Sir or Madam, \n \n Your check number '" + checkNo + "' from account '"+ acctID +"' in the amount of $" + amtDueDec + ", dated " + checkDate + ",  has been returned by the bank. \n \n We have verified with your bank that there are insufficient funds to pay the check. \n Please replace this check with cash or a money order and pay the required state fee of $30 for a \n total of $" + (amtDueDec + stateFee) + " within 14 days per South Carolina Law to avoid further collection action. \n \n Since this is your first notice, the bank fee will be waived if payment is recieved within 14 days. \n If you have questions about this, please contact the Bounce House Check Collection office at 864-555-5555 between the hours of 9 and 5. \n Sincerely, \n \n David Tabor - Bounce House Collection Agency");
                    Document doc = new Document(iTextSharp.text.PageSize.LETTER);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                    doc.Open();
                    doc.Add(paragraph);
                    doc.Close();
                    return true;
                }
                case 1:
                {
                    paragraph = new Paragraph("Dear Sir or Madam, \n \n Your check number '" + checkNo + "' from account '" + acctID + "' in the amount of $" + amtDueDec + ", dated " + checkDate + ",  has been returned by the bank. \n We have verified with your bank that there are insufficient funds to pay the check. \n This is your second notice. Please replace this check with cash or a money order, pay the bank charge of $30, and pay the state fee of $30 for a total of " + fullTotal + " within 10 days per South Carolina Law to avoid further collection action. \n \n If you have questions about this, please contact the Bounce House Check Collection office at 864-555-5555 between the hours of 9 and 5. \n Sincerely, \n \n David Tabor - Bounce House Collection Agency");
                    Document doc = new Document(iTextSharp.text.PageSize.LETTER);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                    doc.Open();
                    doc.Add(paragraph);
                    doc.Close();
                    return true;
                }
                case 2:
                {
                    paragraph = new Paragraph("Dear Sir or Madam, \n \n Your check number '" + checkNo + "' from account '" + acctID + "' in the amount of $" + amtDueDec + ", dated " + checkDate + ",  has been returned by the bank. \n We have verified with your bank that there are insufficient funds to pay the check. \n This is your third notice. Please replace this check with cash or a money order, pay the bank charge of $30, and pay the state fee of $30 for a total of " + fullTotal + " within 10 days per South Carolina Law to avoid further collection action. \n \n If payment is not recieved within 14 days legal action will be taken to the full measure of the law. \n If you have questions about this, please contact the Bounce House Check Collection office at 864-555-5555 between the hours of 9 and 5. \n Sincerely, \n \n David Tabor - Bounce House Collection Agency");
                    Document doc = new Document(iTextSharp.text.PageSize.LETTER);
                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(filepath, FileMode.Create));
                    doc.Open();
                    doc.Add(paragraph);
                    doc.Close();
                    return true;
                }
            }
            
            return true;
        }

        public static bool prepDirForPrint()
        {
            string sourceDir = HttpContext.Current.Server.MapPath("~/App_Data/singlePDFs");
            var files = Directory.GetFiles(sourceDir);
            try
            {
                foreach (string pdfFile in files)
                {
                    File.Delete(pdfFile);
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public static bool CreateMergedPDF()
        {
            string filePath = @"c:\tempMerge\";
            string fileName = "mergePDF.pdf";
            string fileCombo = filePath + fileName;
            

            if(!File.Exists(filePath)) 
            {
                 //This path is a file
                System.IO.Directory.CreateDirectory(filePath);
            }             

            string sourceDir = HttpContext.Current.Server.MapPath("~/App_Data/singlePDFs");
            try
            {
                using (FileStream stream = new FileStream(fileCombo, FileMode.Create))
                {
                    Document pdfDoc = new Document(PageSize.LETTER);
                    PdfCopy pdf = new PdfCopy(pdfDoc, stream);
                    pdfDoc.Open();
                    var files = Directory.GetFiles(sourceDir);

                    int i = 1;
                    foreach (string file in files)
                    {

                        pdf.AddDocument(new PdfReader(file));
                        i++;
                    }

                    if (pdfDoc != null)
                    {
                        pdfDoc.Close();
                     }
                    return true;
                }
            }
            catch (Exception e)
            {
                if (e.Message == @"The process cannot access the file 'c:\tempMerge\mergePDF.pdf' because it is being used by another process")
                {
                    return false;
                }
               
            }
            return false;
        }
    }
}