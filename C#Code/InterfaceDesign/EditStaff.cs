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
    public partial class EditStaff : Form
    {
        private OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;");
        private OleDbCommand cmd;
        OleDbDataReader dr;
        public EditStaff()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    cmd = new OleDbCommand("select * from StaffManager where SMID='" + textBox7.Text + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    textBox3.Text = dr["SMID"].ToString();
                    textBox1.Text = dr["STName"].ToString();
                    textBox2.Text = dr["DateofBirth"].ToString();
                    textBox6.Text = dr["Salary"].ToString();
                    dr.Close();
                    MessageBox.Show("If the displayed information is correct please click the delete button");
                }
                else if (checkBox2.Checked == true)
                {
                    cmd = new OleDbCommand("select * from SalesAgent where SalesID='" + textBox7.Text + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    textBox3.Text = dr["SalesID"].ToString();
                    textBox1.Text = dr["SName"].ToString();
                    textBox2.Text = dr["DateofBirth"].ToString();
                    textBox6.Text = dr["Salary"].ToString();
                    dr.Close();
                    MessageBox.Show("If the displayed information is correct please click the delete button");
                }
                else if (checkBox3.Checked == true)
                {
                    cmd = new OleDbCommand("select * from TourGuide where TGID='" + textBox7.Text + "'", con);
                    con.Open();
                    dr = cmd.ExecuteReader();
                    dr.Read();
                    textBox3.Text = dr["TGID"].ToString();
                    textBox1.Text = dr["TGName"].ToString();
                    textBox2.Text = dr["DateofBirth"].ToString();
                    textBox6.Text = dr["Salary"].ToString();
                    dr.Close();
                    MessageBox.Show("If the displayed information is correct please edit and click the Submit button");
                }
            }
            catch (OleDbException xx)
            {
                MessageBox.Show("There is a problem" + xx.Message);
            }
            catch
            {
                MessageBox.Show("Invalid ID");
            }
            finally
            {
                con.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(checkBox1.Checked == true)
                {
                    cmd = new OleDbCommand("update StaffManager set SMID = '" + textBox3.Text + "', STName='" + textBox1.Text + "',DateofBirth = '" + textBox2.Text + "', Salary = " + textBox6.Text + " where SMID = '" + textBox7.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("done");
                }else if(checkBox2.Checked == true)
                {
                    cmd = new OleDbCommand("update SalesAgent set SalesID = '" + textBox3.Text + "', SName='" + textBox1.Text + "',DateofBirth = '" + textBox2.Text + "', Salary = " + textBox6.Text + " where SalesID = '" + textBox7.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("done");
                }else if(checkBox3.Checked == true)
                {
                    cmd = new OleDbCommand("update TourGuide set TGID = '" + textBox3.Text + "', TGName='" + textBox1.Text + "',DateofBirth = '" + textBox2.Text + "', Salary = " + textBox6.Text + " where TGID = '" + textBox7.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("done");
                }


            }
            catch (OleDbException ff)
            {
                MessageBox.Show("somthing Wrong" + ff.Message);

            }
            finally
            {
                con.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StaffManager myForm = new StaffManager();
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
