using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace CoverLetterGenerator
{
    public class ClHelper
    {
        private string Date { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Position { get; set; }
        private string CompanyName { get; set; }
        private string StreetAddress { get; set; }
        private string City { get; set; }
        private string Province { get; set; }
        private string PostalCode { get; set; }
        private string Subject { get; set; }
        private string Sex { get; set; }
        private string desktopPath;
        public string folderPath;
        string readFilePath;
        string writeFilePath;
        //Gets Cover Letter Info
        private void _getInfo(string firstName, string lastName, string companyName, string streetAdress,
            string city, string province, string postalCode, string subject, string sex)
        {
            Date = DateTime.Now.ToString("M/d/yyyy");
            FirstName = firstName;
            LastName = lastName;
            CompanyName = companyName;
            StreetAddress = streetAdress;
            City = city;
            Province = province;
            PostalCode = postalCode;
            Subject = subject;
            Sex = sex;
        }
        //Set up document paths
        private void _documentPrep()
        {
            desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //folderPath = System.IO.Path.Combine(desktopPath, "RagTestFolder");
            readFilePath = System.IO.Path.Combine(folderPath, "Template.docx");
            writeFilePath = System.IO.Path.Combine(folderPath, (CompanyName + " - Cover Letter 2018 - " + Subject + ".docx"));

        }

        private void _findAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
        {
            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.ClearFormatting();
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }

        private void _replaceText()
        {
            //PrepareDocument
            Application application = new Application();
            Document document = application.Documents.Open(readFilePath, ReadOnly: false);
            application.Selection.ClearFormatting();

            _findAndReplace(application, "%Date%", DateTime.Now.ToString("M/d/yyyy"));
            _findAndReplace(application, "%HRName%", (FirstName+ " " +LastName));
            _findAndReplace(application, "%LastName%", (LastName));
            _findAndReplace(application, "%CompanyName%", CompanyName);
            _findAndReplace(application, "%StreetAddress%", StreetAddress);
            _findAndReplace(application, "%City%", City);
            _findAndReplace(application, "%Province%", Province);
            _findAndReplace(application, "%PostalCode%", PostalCode);
            _findAndReplace(application, "%Subject%", Subject);
            _findAndReplace(application, "%Sex%", Sex);

            document.Paragraphs[1].Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            document.SaveAs2(writeFilePath);
            object doNotSaveChanges = WdSaveOptions.wdDoNotSaveChanges;
            document.Close(ref doNotSaveChanges);
            application.Quit();
        }

        public void Run(string firstName, string lastName, string companyName, string streetAdress,
            string city, string province, string postalCode, string subject, string sex)
        {
            this._getInfo(firstName, lastName, companyName, streetAdress, city, province, postalCode, subject, sex);
            this._documentPrep();
            this._replaceText();
        }

    }
}
