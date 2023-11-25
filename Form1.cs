using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HamburgerOrder
{
    public partial class HamburgerOrder : Form
    {

        SqlConnection connection = new SqlConnection("Data Source");  //enter your own data source

        public HamburgerOrder()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            show();

        }

        private void Add_Click(object sender, EventArgs e)
        {
            String menuName = menuNameText.Text;
            String beverageName = beverageNameText.Text;
            String beverageType = beverageTypeText.Text;
            String potatoType = potatoTypeText.Text;
            String sause = sauseText.Text;
            String price = priceText.Text;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ORDERS(MenuName,BeverageName,BeverageType,PotatoType,Extrasauce,Price) " +
                    "VALUES('" + menuName + "','" + beverageName + "','" + beverageType + "','" + potatoType + "','" + sause + "','" + price + "'  )", connection);
                command.ExecuteNonQuery();
                connection.Close();
                show();
            }
            catch (Exception)
            {
                
                throw;
            }

            

        }

        private void show()
        {
            connection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from ORDERS",connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            connection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            menuNameText.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            beverageNameText.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            beverageTypeText.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            potatoTypeText.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            sauseText.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            priceText.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {//delete

            try
            {
                connection.Open();
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                SqlCommand command = new SqlCommand("DELETE FROM ORDERS WHERE ID=('" + id + "')", connection);
                command.ExecuteNonQuery();
                connection.Close();
                show();
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {// update

            try
            {

                String menuName = menuNameText.Text;
                String beverageName = beverageNameText.Text;
                String beverageType = beverageTypeText.Text;
                String potatoType = potatoTypeText.Text;
                String sause = sauseText.Text;
                String price = priceText.Text;
                String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE ORDERS SET MenuName='" + menuName+ "',BeverageName='" + beverageName + "',BeverageType='" + beverageType +
                  "',PotatoType='" + potatoType + "',Extrasauce='" + sause+ "',Price='" + price+"' WHERE ID='"+id+"' " , connection);
                command.ExecuteNonQuery();
                connection.Close();
                show();
            }
            catch (Exception)
            {

                throw;
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {//clear
            menuNameText.Text = "";
            beverageNameText.Text = "";
            beverageTypeText.Text = "";
            potatoTypeText.Text = "";
            sauseText.Text = "";
            priceText.Text = "";
        }
    }
}
