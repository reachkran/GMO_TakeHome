using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMO_Application
{
    public partial class Master_DetailForm : Form
    {
        private string filepath = @"C:\Data\ProductsDescriptions.csv";
        private DataTable dtProducts = new DataTable();
        private DataRow row;
        private bool bLoad = false;

        public Master_DetailForm()
        {
            InitializeComponent();
            textBoxProd.ReadOnly = true;
            this.Load += new EventHandler(Master_DetailForm_Load);
        }
        public void Master_DetailForm_Load(object sender, EventArgs e)
        {
            try
            {
                //Check if the file exists in local
                bool exists = File.Exists(filepath);
                if (!exists)
                {
                    MessageBox.Show("CSV source file is missing- C:\\Data\\ProductsDescriptions.csv ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    //load csv file to dataset
                    var rows = File.ReadAllLines(filepath).Select(x => x.Split(';')).Skip(1).ToList();                    

                    //var contents = File.ReadAllText(filepath).Split('\n').Skip(1);
                    //var results = from line in contents
                    //              select line.Split(',').ToList();

                    dtProducts.Columns.Add("ID");
                    dtProducts.Columns.Add("Name");
                    dtProducts.Columns.Add("Description");

                    foreach (var item in rows)
                    {
                        row = dtProducts.NewRow();
                        if (item.Count() == 1)
                        {
                            //List<string[]> linerow = item.Select(x => x.Split(',')).ToList();
                            string[] linerow = item[0].Split(',');
                            row["ID"] = linerow[0];
                            row["Name"] = linerow[1];
                            row["Description"] = linerow[2];
                        }
                        else if (item.Count() == 2)
                        {
                            //List<string[]> linerow = item.Select(x => x.Split(',')).ToList();
                            string[] linerow = item[0].Split(',');
                            row["ID"] = linerow[0];
                            row["Name"] = linerow[1];
                            row["Description"] = string.Format("{0} {1}", linerow[2], item[1]) ;
                        }
                        dtProducts.Rows.Add(row);
                    }             

                    //Bind combolist
                    comboBoxProduct.DataSource = dtProducts;
                    comboBoxProduct.DisplayMember = "Name";
                    comboBoxProduct.ValueMember = "Name";


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("CSV load file exception " + ex.Message, "Constructor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
               
        }

        //private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (!string.IsNullOrEmpty(comboBoxProduct.SelectedItem.ToString()))
        //    //    {
        //    //        var results = dtProducts.AsEnumerable().Select(x => x["Name"]).ToList();
        //    //        //Where(dr => dr["Name"] == comboBoxProduct.SelectedItem.ToString())
        //    //        var productResults = (from dt in dtProducts.AsEnumerable()
        //    //                              where dt.Field<string>("Name").Trim() == comboBoxProduct.SelectedItem.ToString()
        //    //                              select dt).ToList();
        //    //        if (productResults != null)
        //    //        {
        //    //            foreach (var product in productResults)
        //    //            {
        //    //                textBoxDescription.Text = product.Field<string>("Description");
        //    //                textBoxProd.Text = product.Field<string>("Name");
        //    //            }
        //    //        }
        //    //        else
        //    //        {
        //    //            textBoxProd.Clear();
        //    //            textBoxDescription.Clear();
        //    //        }
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show("Exception while reading data.. " + ex.Message, "ProductList", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //}
           
        //}

        public void Master_DetailForm_Closed(object sender, FormClosedEventArgs e)
        {

        }

        private void comboBoxProduct_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(comboBoxProduct.SelectedValue.ToString()))
                {
                    var productResults = dtProducts.AsEnumerable().Where(dr => dr["Name"] == comboBoxProduct.SelectedValue.ToString()).ToList();
                    if (productResults != null)
                    {
                        foreach (var product in productResults)
                        {
                            textBoxProd.Text = product[1].ToString(); //product.Field<string>("Name");
                            textBoxDescription.Text = product[2].ToString(); //product.Field<string>("Description");
                        }
                    }
                    else
                    {
                        textBoxProd.Clear();
                        textBoxDescription.Clear();
                    }
                }
                else
                {
                    textBoxProd.Clear();
                    textBoxDescription.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception while reading data.. " + ex.Message, "ProductList", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
