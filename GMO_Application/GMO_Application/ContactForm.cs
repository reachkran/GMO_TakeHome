using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMO_Application
{
    public partial class ContactForm : Form
    {
        private string filepath = @"C:\Data";
        private string filename = "Contacts.txt";

        public ContactForm()
        {
            InitializeComponent();
            this.Load += new EventHandler(ContactForm_Load);
        }

        public void ContactForm_Load(object sender, EventArgs e)
        {
            //Set properties
            textBoxName.MaxLength = 20;
            textBoxAddress.MaxLength = 40;
            textBoxPhone.KeyPress += new KeyPressEventHandler(textBoxPhone_KeyPress);
            textBoxPhone.MaxLength = 10;
        }
        //Event to handle phone number value - Numeric
        private void textBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= '0' && e.KeyChar <='9' || e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        
        private void buttonSubmit_Click(object sender, EventArgs e)
        {

            try
            {
                var regItem = new Regex("^[a-zA-Z ]*$");
                var regItemAdd = new Regex("^[a-zA-Z0-9 ]*$");
                //Validation
                if (string.IsNullOrEmpty(textBoxName.Text.ToString()))
                {
                    MessageBox.Show("Name is missing. Please enter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxName.Focus();
                    return;
                }
                if (!regItem.IsMatch(textBoxName.Text.ToString()))
                {
                    MessageBox.Show("Special and numeric characters not allowed. Please verify name", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBoxAddress.Text.ToString()))
                {
                    MessageBox.Show("Address is missing. Please enter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxAddress.Focus();
                    return;
                }
                if (!regItemAdd.IsMatch(textBoxAddress.Text.ToString()))
                {
                    MessageBox.Show("Special characters not allowed. Please verify address", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxAddress.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(textBoxPhone.Text.ToString()))
                {
                    MessageBox.Show("Phone Number is missing. Please enter", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPhone.Focus();
                    return;
                }
                //Check if the folder exists in local
                bool exists = Directory.Exists(filepath);
                if (!exists)
                    Directory.CreateDirectory(filepath);

                //Combine path
                string fileLocation = Path.Combine(filepath, filename);

                //Write to text file
                using (StreamWriter write = File.AppendText(fileLocation))
                {
                    write.WriteLine(string.Format("{0},{1},{2} ;", textBoxName.Text.ToString().Trim(), textBoxAddress.Text.ToString().Trim(), textBoxPhone.Text.ToString().Trim()));
                    write.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured -" + ex.Message, "UserEx", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
            

        }

        public void ContactForm_Closed(object sender, FormClosedEventArgs e)
        {

        }

    }
}
