using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrAndEddie
{
    public partial class ItemForm : Form
    {
        string id = string.Empty;
        string connectionString = string.Empty;
        public ItemForm(string Catagory)
        {
            InitializeComponent();
            id = Catagory;
            this.Text = Catagory;
        }

        internal void sql_connect()
        {

            var address = "35.208.249.77";
            var port = "3306";
            address ??= "localhost";

            port ??= "3306";

            connectionString = "server=" + address + ";database= dbgeqekvf3nwoj;uid=udeyu0hvrtewj;password=c`hfhe^1o51b;port=" + port + "; Connection Timeout=10;allowUserVariables = true;";




            try
            {

                string query = $"SELECT * FROM item WHERE itemcategory = '{id}'";
                 
                List<string> names = new List<string>();

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    int yOffset = 20;
                    while (reader.Read())
                    {
                        Button btn = new Button();
                        btn.Text = reader.GetString("itemname");
                        btn.Tag = reader.GetInt32("itemid");
                      
                        btn.Location = new Point(10, yOffset);
                        btn.Size = new Size(200, 40);
                        btn.Click += (sender, e) => { Form2 Item = new((int)btn.Tag); Item.ShowDialog(); };

                        this.Controls.Add(btn);
                        yOffset += 40;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            sql_connect();
        }
    }
}