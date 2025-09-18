using MySqlConnector;
using System;
using System.Collections;
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
    public partial class Form2 : Form
    {
        int id = 0;
        public Form2(int ID)
        {
            id = ID;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var address = "35.208.249.77";
            var port = "3306";
            address ??= "localhost";

            port ??= "3306";

            string connectionString = "server=" + address + ";database= dbgeqekvf3nwoj;uid=udeyu0hvrtewj;password=c`hfhe^1o51b;port=" + port + "; Connection Timeout=10;allowUserVariables = true;";

            string query = $"SELECT subcategory.subcategoryname, modifier.modifierid, modifiername, modifierprice FROM `modifier` JOIN itemtemplate on itemtemplate.itemtemplatemodifier = modifierid JOIN subcategory on subcategory.subcategoryid = modifier.modifiersubcategory WHERE itemtemplate.itemtemplateitem={id};\r\n";

            List<string> names = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                DataTable dataTable = new DataTable();
                dataTable.Load(reader); // Load data from reader into DataTable

                dataGridView1.DataSource = dataTable; // Bind to DataGridView



            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
