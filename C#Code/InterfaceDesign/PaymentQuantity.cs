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
    public partial class PaymentQuantity : Form
    {
        const int price = 5;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;");
        OleDbCommand cmd;
        private MainMenu m = new MainMenu();
        public PaymentQuantity()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                int totalPrice = (Int32.Parse(textBox1.Text) * price);
                string s = totalPrice.ToString();
                textBox4.Text = s;
            }


            try
            {
                if(textBox2.Text != "")
                {
                    cmd = new OleDbCommand("insert into SalesReport(SAReportID, SADate, Quantity, Price,SalesID ) values (" + textBox5.Text + ",'" + textBox2.Text + "'," + textBox1.Text + "," + textBox4.Text + "," + textBox3.Text + ")", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payment Successful");
                }
                else
                {
                    MessageBox.Show("Payment Unsuccessful ");
                }


            }catch(OleDbException xx)
            {
                MessageBox.Show("Payment Unsuccessful " + xx.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void PaymentQuantity_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SalesAgent myForm = new SalesAgent();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu myForm = new MainMenu();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }
    }
}
