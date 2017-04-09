using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database4
{
    public partial class Form1 : Form
    {

        DataTable mTable;
       
        MySqlConnection mConn;
        MySqlCommand mComm;
        MySqlDataAdapter mAdapter;

        String tableName = "qlnv2";

        public Form1()
        {
            InitializeComponent();
        }

        public void queryTable(String cmd)
        {
            //this.Validate();

            //createTable();
            
            mComm = new MySqlCommand(cmd, mConn);

            //mAdapter = new MySqlDataAdapter();
            //mAdapter.SelectCommand = mComm;

            mTable = new DataTable();

            mTable.Load(mComm.ExecuteReader());

            //MySqlCommandBuilder builder = new MySqlCommandBuilder(mAdapter);

            //mAdapter.Update(mTable);
            //builder.GetUpdateCommand();
            //dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.DataSource = mTable;

            //mConn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mConn = new MySqlConnection("datasource = 127.0.0.1; username = root; "
                      + "password=;database=mydatabase;");

            mConn.Open();

            mComm = new MySqlCommand("select * from qlnv2", mConn);

            //mAdapter = new MySqlDataAdapter();
            //mAdapter.SelectCommand = mComm;

            mTable = new DataTable();

            mTable.Load(mComm.ExecuteReader());

            //MySqlCommandBuilder builder = new MySqlCommandBuilder(mAdapter);

            //mAdapter.Update(mTable);
            //builder.GetUpdateCommand();

           // mConn.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            queryTable("insert into qlnv2(ID, NAME) values(" + textBox1.Text 
                + ", \"" + textBox2.Text +"\");");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            queryTable("delete from qlnv2 where ID = " + textBox1.Text + ";");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            mConn.Close();
            this.Close();
        }
    }
}
