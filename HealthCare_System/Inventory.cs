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

namespace HealthCare_System
{
    public partial class Inventory : UserControl
    {
        private MySqlConnection conn;
        public DataGridView DataGridViewControl => dataGridView1;
        public Inventory()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        public void LoadData()
        {
            try
            {
                
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                DataTable dataTable = new DataTable();

                string query = @"
                    SELECT b.book_id, b.title, a.author_name, p.publisher_name, b.publish_date, 
                            c.category_name, b.price, b.copies
                    FROM books_db.books AS b
                    JOIN books_db.authors AS a ON b.author_id = a.author_id
                    JOIN books_db.publishers AS p ON b.publisher_id = p.publisher_id
                    JOIN books_db.categories AS c ON b.category_id = c.category_id
                    ORDER BY b.book_id";

                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        dataTable.Load(reader);

                        dataGridView1.Rows.Clear();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            // Handle potential null values and data type conversions
                            dataGridView1.Rows.Add(
                                row["book_id"].ToString(),
                                row["title"].ToString(),
                                row["author_name"].ToString(),
                                row["publisher_name"].ToString(),
                                (row["publish_date"] != DBNull.Value) ? Convert.ToDateTime(row["publish_date"]).ToString("yyyy-MM-dd") : "",
                                row["category_name"].ToString(),
                                (row["price"] != DBNull.Value) ? Convert.ToDouble(row["price"]).ToString() : "",
                                (row["copies"] != DBNull.Value) ? row["copies"].ToString() : ""
                            );
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection in all scenarios
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


    }
}
    
