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
    public partial class MainMenu : Form
    {
        private OleDbConnection _dbConnection;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                _dbConnection = new OleDbConnection { ConnectionString = "Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\\Users\\Malik\\Desktop\\SEF31.accdb;Persist Security Info=False;" };
                DataSet myDataSet = new DataSet();
                DataTable myDataTable = new DataTable();
                var myAdaptor = new OleDbDataAdapter();
                string sSelect = "SELECT * FROM [login] WHERE user_id='" + textBox2.Text + "' AND password=" + textBox1.Text + "";
                OleDbCommand command = new OleDbCommand(sSelect, _dbConnection);
                myAdaptor.SelectCommand = command;
                myAdaptor.Fill(myDataSet, "login");
                myDataTable = myDataSet.Tables["login"];
                _dbConnection.Close();
                string s = textBox2.Text;
                int icount = myDataSet.Tables[0].Rows.Count;
                //MessageBox.Show("Row Count = " + icount);
                // int icount = myDataSet.Tables[0].Rows.Count;
                if (icount > 0)
                {
                    // found
                    foreach (DataRow datarow in myDataTable.Rows)
                    {
                        //MessageBox.Show(datarow["user_role"].ToString());
                        if (datarow["user_role"].ToString() == "admin" && datarow["password"].ToString() == "222")
                        {
                            Registrar myForm = new Registrar();
                            this.Hide();
                            myForm.ShowDialog();
                            this.Close();

                        }else if (datarow["user_role"].ToString() == "staffmanager" && datarow["password"].ToString() == "333")
                        {
                            StaffManager myForm = new StaffManager();
                            this.Hide();
                            myForm.ShowDialog();
                            this.Close();

                        }else if (datarow["user_role"].ToString() == "salesagent" && datarow["password"].ToString() == "444")
                        {
                            SalesAgent myForm = new SalesAgent();
                            this.Hide();
                            myForm.ShowDialog();
                            this.Close();

                        }else if (datarow["user_role"].ToString() == "tourguide" && datarow["password"].ToString() == "555")
                        {
                            TourGuide myForm = new TourGuide();
                            this.Hide();
                            myForm.ShowDialog();
                            this.Close();

                        }
                    }
                    // }

                }
              
            }

        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}