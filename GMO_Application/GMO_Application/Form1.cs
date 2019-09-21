using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMO_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContactForm form1 = new ContactForm();
            form1.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Master_DetailForm form2 = new Master_DetailForm();
            form2.Show();
        }
    }
}
