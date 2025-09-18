using MySqlConnector;
using System.Data;
using GrAndEddie;

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
           
               
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.BackColor = System.Drawing.Color.FromArgb(255, 000, 000);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sql_connect();

            int yOffset = 10;
            Dictionary<string, string> buttonData = new Dictionary<string, string>
            {
                { "Button1", "Action1" },
                { "Button2", "Action2" },
                { "Button3", "Action3" }
            };


/*
            foreach (var entry in buttonData)
            {
                Button btn = new Button();
                btn.Text = entry.Key;
                btn.Tag = entry.Value; // Store associated data
                btn.Location = new Point(10, yOffset);
                btn.Size = new Size(100, 30);
                //btn.Click += Button_Click;

                this.Controls.Add(btn);
                yOffset += 40;
            }
*/

            // Example usage:
            DataTable categoryTable = LoadTableData("category");
            if (categoryTable != null)
            {
                // Create an array of DataRow items
                DataRow[] rowsArray = categoryTable.Select();

                foreach (DataRow row in rowsArray)
                {
                    try
                    {
                        // Access column values, e.g. row["ColumnName"]
                        // Example: Console.WriteLine(row["id"]);
                        Button btn = new Button();
                        btn.Text = row["categoryname"].ToString();
                        btn.Tag =  row["categoryid"].ToString();
                        //btn.Tag = entry.Value; // Store associated data
                        btn.Location = new Point(10, yOffset);
                        btn.Size = new Size(200, 40);
                        btn.Click += (sender, e) => { ItemForm Item = new(btn.Tag.ToString()); Item.ShowDialog(); };

                        this.Controls.Add(btn);
                        yOffset += 40;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error processing row: " + ex.Message);

                    }
                }
            }

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

        private DataTable LoadTableData(string tableName)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            DataTable dataTable = new();

            try
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}"; // Use brackets to handle special characters

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            return dataTable;
            
        }
        }
    }

