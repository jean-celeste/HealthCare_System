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
    public partial class Customer : UserControl
    {
        private MySqlConnection conn;
        public DataGridView DataGridViewControl => dataGridView1;

        public Customer()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
        }

        private void Sales_Load(object sender, EventArgs e)
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
                    SELECT c.customer_name, c.email, c.phone, c.address, b.title AS borrowed_book_title, c.date_borrowed, c.paid, c.returned
                    FROM books_db.customers AS c
                    JOIN books_db.books AS b ON c.borrowed_books = b.book_id";


                MySqlCommand command = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        dataTable.Load(reader);

                        dataGridView1.Rows.Clear();

                        foreach (DataRow row in dataTable.Rows)
                        {
                            dataGridView1.Rows.Add(
                                
                                row["customer_name"].ToString(),
                                row["email"].ToString(),
                                row["phone"].ToString(),
                                row["address"].ToString(),
                                row["borrowed_book_title"].ToString(),
                                row["date_borrowed"].ToString(),
                                row["paid"].ToString(),
                                row["returned"].ToString()

                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading sales data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }

}
