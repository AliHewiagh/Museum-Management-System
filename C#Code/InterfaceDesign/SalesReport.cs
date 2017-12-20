using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterfaceDesign
{
    public partial class SalesReport : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;");
        //OleDbCommand cmd;
        OleDbDataReader dr;
        DataSet ds;
        OleDbDataAdapter cmd;
        public SalesReport()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new OleDbDataAdapter("select Quantity,Price,SADate as 'Date' from SalesReport where SADate='" + textBox1.Text+"'",con );
                con.Open();
                //dr = cmd.ExecuteReader();
                //dr.Read();
                ds = new System.Data.DataSet();
                cmd.Fill(ds, "SalesReport");
                dataGridView1.DataSource = ds.Tables[0];

            }
            catch(OleDbException xx)
            {
                MessageBox.Show("Mistake"+xx.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registrar myForm = new Registrar();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainMenu myForm = new MainMenu();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}
