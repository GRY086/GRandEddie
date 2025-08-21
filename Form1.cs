using MySqlConnector;
using System.Data;
using System.Diagnostics;

namespace GRandEddie
{
    public partial class Form1 : Form
    {
        string x = "";
        private string connectionString;
        public Form1(string x)
        {
            InitializeComponent();
            this.x = x;
            Debug.Write(this.x);
               
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = System.Drawing.Color.FromArgb(255, 000, 000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sql_connect();
            button1.Text = this.x;
        }

        internal void sql_connect() {

            var address = "35.208.249.77";
            var port = "3306";
            address ??= "localhost";

            port ??= "3306";

            connectionString = "server=" + address + ";database= dbgeqekvf3nwoj;uid=udeyu0hvrtewj;password=c`hfhe^1o51b;port=" + port + "; Connection Timeout=10;";

            MySqlConnection conn = new MySqlConnection();
            conn.ConnectionString = connectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DataTable tables = connection.GetSchema("Tables");

                    foreach (DataRow row in tables.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();
                        comboBox1.Items.Add(tableName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = comboBox1.SelectedItem.ToString();
            LoadTableData(selectedTable);
        }

        private void LoadTableData(string tableName)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);


            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}"; // Use brackets to handle special characters

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        }
    }

