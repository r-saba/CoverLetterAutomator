using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoverLetterGenerator;

namespace CoverLetterAutomator
{
    public partial class CoverLetterAutomator : Form
    {
        string sexSelected;
        string firstName;
        string lastName;
        string company;
        string address;
        string city;
        string province;
        string postalCode;
        string subject;
        ClHelper LetterGenerator = new ClHelper();

        public CoverLetterAutomator()
        {
            InitializeComponent();
            ArrayList s = new ArrayList();
            s.Add("Mr"); s.Add("Mrs");
            sex.DataSource = s;
            folderLocation();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contactNameFull_TextChanged(object sender, EventArgs e)
        {

        }

        private void companyInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void addressInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void cityInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void provinceInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void postalCodeInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void subjectInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            getInfo();
            LetterGenerator.Run(firstName, lastName, company, address, city, province, postalCode,subject, sexSelected);
            clearFields();
        }

        private void getInfo()
        {
            splitName();
            company = companyInput.Text;
            address = addressInput.Text;
            city = cityInput.Text;
            province = provinceInput.Text;
            postalCode = postalCodeInput.Text;
            sexSelected = sex.Text;
            subject = subjectInput.Text;
        }

        private void splitName()
        {
            lastName = contactNameFull.Text.Split(' ').Last();
            string[] nameToSplit = contactNameFull.Text.Split(' ');
            for(int i = 0; i < nameToSplit.Length-1; i++)
            {
                firstName += nameToSplit[i];
            }
        }
        
        private void clearFields()
        {
            contactNameFull.Text = String.Empty;
            companyInput.Text = String.Empty;
            addressInput.Text = String.Empty;
            cityInput.Text = String.Empty;
            provinceInput.Text = String.Empty;
            postalCodeInput.Text = String.Empty;
            sex.Text = String.Empty;
            subjectInput.Text = String.Empty;
            firstName = "";
            lastName = "";
        }

        private void folderLocation()
        {
            folderBrowserDialog1.Description = "Select the folder with the template file";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                LetterGenerator.folderPath = folderBrowserDialog1.SelectedPath.ToString();
            }
            while(LetterGenerator.folderPath == null)
            {
                folderBrowserDialog1.Description = "Please SELECT the folder with the TEMPLATE file to continue";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    LetterGenerator.folderPath = folderBrowserDialog1.SelectedPath.ToString();
                }
            }
        }
    }
}
