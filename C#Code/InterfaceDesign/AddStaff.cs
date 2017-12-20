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
    public partial class AddStaff : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;");
        OleDbCommand cmd;
        public AddStaff()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StaffManager myForm = new StaffManager();
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(checkBox1.Checked == true)
                {
                    cmd = new OleDbCommand("insert into StaffManager(SMID,DateofBirth,Salary,STName)values(" + textBox3.Text + ",'" + textBox2.Text + "'," + textBox6.Text + ",'" + textBox1.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully StaffManager");
                }else if(checkBox2.Checked == true)
                {
                    cmd = new OleDbCommand("insert into SalesAgent(SalesID,SName,DateofBirth,Salary)values(" + textBox3.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "'," + textBox6.Text + ")", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully SalesAgent");
                }
                else if (checkBox3.Checked == true)
                {
                    cmd = new OleDbCommand("insert into TourGuide(TGID,TGName,DateofBirth,Salary)values(" + textBox3.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "'," + textBox6.Text + ")", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Added Successfully Tour Guide");
                }

            }
            catch (OleDbException xx)
            {
                MessageBox.Show("Wrong " + xx.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox1.Checked = false;
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
