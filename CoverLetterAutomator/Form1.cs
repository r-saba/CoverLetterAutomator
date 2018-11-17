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

namespace CoverLetterAutomator
{
    public partial class CoverLetterAutomator : Form
    {
        public CoverLetterAutomator()
        {
            InitializeComponent();
            ArrayList s = new ArrayList();
            s.Add("Mr"); s.Add("Mrs");
            sex.DataSource = s;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
