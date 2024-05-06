using HealthCare_System;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HealthCare_System
{
    public partial class Rental : UserControl
    {
        private MySqlConnection conn;
        public Rental()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void Rental_Load(object sender, EventArgs e)
        {
            LoadData();
            clear();
        }
        private void Rental_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            clear();
        }

        public void LoadData()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Create a DataTable to hold the data
            DataTable dataTable = new DataTable();

            string query = @"
                    SELECT p.patient_id, p.patient_name, p.age, p.gender, p.address, p.phone, p.email
                    FROM healthcare_db.patient AS p";

            MySqlCommand command = new MySqlCommand(query, conn);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                // Load data into the DataTable
                dataTable.Load(reader);
                
            }

            // Clear the DataGridView
            dataGridView1.Rows.Clear();

            // Populate the DataGridView with data from the DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView1.Rows.Add(
                    row["patient_id"].ToString(),
                    row["patient_name"].ToString(),
                    row["age"].ToString(),
                    row["gender"].ToString(),
                    row["address"].ToString(),
                    row["phone"].ToString(),
                    row["email"].ToString()
                   
                );
            }

            // Close the connection after loading data
            conn.Close();
        }




        public void clear()
        {
            dataGridView1.ClearSelection();
            cust_name.Clear();
            cust_email.Clear();
            cust_phone.Clear();
            cust_address.Clear();
            book.Clear();
            date.Value = DateTime.Now;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton6.Checked = false;
            radioButton5.Checked = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            /*
                if (string.IsNullOrEmpty(cust_name.Text) || string.IsNullOrEmpty(cust_email.Text) || string.IsNullOrEmpty(cust_phone.Text) ||
                    string.IsNullOrEmpty(cust_address.Text) || string.IsNullOrEmpty(book.Text) || string.IsNullOrEmpty(date.Text))
                {
                    MessageBox.Show("Warning: All fields are Required!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    try
                    {
                        if (conn.State != ConnectionState.Open)
                        {
                            conn.Open();
                        }

                    string query = "INSERT INTO `books_db`.`customers` " +
                                       "(`customer_name`, `email`, `phone`, `address`, `borrowed_books`, `date_borrowed`, `paid`, `returned`) " +
                                       "VALUES (@name, @email, @phone, @address, @borrowed_book, @date_borrowed, @paid, @returned)";

                        MySqlCommand command = new MySqlCommand(query, conn);
                        command.Parameters.AddWithValue("@name", cust_name.Text);
                        command.Parameters.AddWithValue("@email", cust_email.Text);
                        command.Parameters.AddWithValue("@phone", cust_phone.Text);
                        command.Parameters.AddWithValue("@address", cust_address.Text);
                        command.Parameters.AddWithValue("@borrowed_book", book.Text);
                        command.Parameters.AddWithValue("@date_borrowed", date.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                        command.Parameters.AddWithValue("@paid", radioButton1.Checked ? "Yes" : "No");
                        command.Parameters.AddWithValue("@returned", radioButton6.Checked ? "Yes" : "No");

                    int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Successfully Recorded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("There is an Error Saving!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        LoadData(); // Load data after the operation
                        conn.Close(); // Close the connection
                        clear();
                    }
                }
            
            */
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
            // Check if there is at least one row selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                saveBtn.Enabled = false;
                updateBtn.Enabled = true;
                deleteBtn.Enabled = true;
                // Get the selected row
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Populate textboxes with data from the selected row
                cust_name.Text = selectedRow.Cells["Column1"].Value.ToString();
                cust_email.Text = selectedRow.Cells["Column2"].Value.ToString();
                cust_phone.Text = selectedRow.Cells["Column3"].Value.ToString();
                cust_address.Text = selectedRow.Cells["Column4"].Value.ToString();
                //book.Text = selectedRow.Cells["Column6"].Value.ToString();

                /*// Fetch the date from column 7 (index-based, so 6 for column 7)
                string dateString = selectedRow.Cells[6].Value.ToString(); // Assuming column index 6 for column 7

                // Parse the string to obtain a DateTime object
                DateTime selectedDate;
                if (DateTime.TryParse(dateString, out selectedDate))
                {
                    // Set the value of your DateTimePicker control to the retrieved date
                    date.Text = selectedDate.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    // Handle invalid date format
                    MessageBox.Show("Invalid date format in column 7.");
                }

                // Check the paid radio button based on the value in the DataGridView
                string paidValue = selectedRow.Cells["Column7"].Value.ToString();
                radioButton1.Checked = paidValue.Equals("Yes", StringComparison.OrdinalIgnoreCase);
                radioButton2.Checked = paidValue.Equals("No", StringComparison.OrdinalIgnoreCase);

                // Check the returned radio button based on the value in the DataGridView
                string returnedValue = selectedRow.Cells["Column8"].Value.ToString();
                radioButton6.Checked = returnedValue.Equals("Yes", StringComparison.OrdinalIgnoreCase);
                radioButton5.Checked = returnedValue.Equals("No", StringComparison.OrdinalIgnoreCase);



                string customer_id = selectedRow.Cells["Column0"].Value.ToString();

                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }

                    // Construct the query to fetch the borrowed books for the selected customer
                    string query = "SELECT borrowed_books FROM books_db.customers WHERE customer_id = @customer_id";
                    MySqlCommand command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@customer_id", customer_id);

                    // Execute the query and read the borrowed_books value
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Fetch the value of the 'borrowed_books' column
                            string borrowedBooks = reader["borrowed_books"].ToString();
                            // Display the borrowed books in the textbox
                            book.Text = borrowedBooks;

                        }
                        //reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close(); // Close the connection after using it
                }
*/

            }
            else
            {
                saveBtn.Enabled = true;
                updateBtn.Enabled = false;
                deleteBtn.Enabled = false;
            }
        }

        private void udpateBtn_Click(object sender, EventArgs e)
        {
            // Get the selected customer_id from the DataGridView
            string customer_id = dataGridView1.CurrentRow.Cells["Column0"].Value.ToString();


            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string query = "UPDATE `books_db`.`customers`" +
                               " SET `customer_name` = @name," +
                               " `email` = @email," +
                               " `phone` = @phone," +
                               " `address` = @address," +
                               " `borrowed_books` = @borrowed_book," +
                               " `date_borrowed` = @date_borrowed," +
                               " `paid` = @paid," +
                               " `returned` = @returned" +
                               " WHERE `customer_id` = @customer_id"; // Use parameter for customer_id

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@customer_id", customer_id); // Add parameter for customer_id
                command.Parameters.AddWithValue("@name", cust_name.Text);
                command.Parameters.AddWithValue("@email", cust_email.Text);
                command.Parameters.AddWithValue("@phone", cust_phone.Text);
                command.Parameters.AddWithValue("@address", cust_address.Text);
                command.Parameters.AddWithValue("@borrowed_book", book.Text);
                command.Parameters.AddWithValue("@date_borrowed", date.Value.ToString("yyyy-MM-dd HH:mm:ss")); ;
                command.Parameters.AddWithValue("@paid", radioButton1.Checked ? "Yes" : "No");
                command.Parameters.AddWithValue("@returned", radioButton6.Checked ? "Yes" : "No");

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record successfully updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records were updated!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData(); // Reload data after the operation
                conn.Close(); // Close the connection
                clear(); // Clear the form fields
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
/*            string customer_id = dataGridView1.CurrentRow.Cells["Column0"].Value.ToString();
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string query = "DELETE FROM `books_db`.`customers`" +
                               " WHERE `customer_id` = @customer_id"; // Use parameter for customer_id

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@customer_id", customer_id); // Add parameter value



                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Record successfully deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No records were deleted!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                LoadData(); // Reload data after the operation
                conn.Close(); // Close the connection
                clear(); // Clear the form fields
            }*/
        }

        private void cust_search_TextChanged(object sender, EventArgs e)
        {
            /*// Clear the DataGridView before adding new rows
            dataGridView1.Rows.Clear();

            // Check if the connection is not open, then open it
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Get the search pattern from the TextBox
            string searchPattern = cust_search.Text;

            // Construct the SQL query with parameterized search pattern
            string query = "SELECT * FROM books_db.customers " +
                            "WHERE customer_id LIKE @searchPattern OR " +
                            "customer_name LIKE @searchPattern OR " +
                            "email LIKE @searchPattern OR " +
                            "phone LIKE @searchPattern OR " +
                            "address LIKE @searchPattern";
            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@searchPattern", "%" + searchPattern + "%");

            // Create a DataTable to hold the results
            DataTable dataTable = new DataTable();

            // Create a DataAdapter to fill the DataTable
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            // Fill the DataTable with results from the query
            adapter.Fill(dataTable);

            // Populate the DataGridView with data from the DataTable
            foreach (DataRow row in dataTable.Rows)
            {
                dataGridView1.Rows.Add(
                    row["customer_id"].ToString(),
                    row["customer_name"].ToString(),
                    row["email"].ToString(),
                    row["phone"].ToString(),
                    row["address"].ToString(),
                    row["borrowed_books"].ToString(),
                    row["date_borrowed"].ToString(),
                    row["paid"].ToString(),
                    row["returned"].ToString()
                );
            }

            // Clear form fields after populating DataGridView
            clear();

            // Close the connection
            conn.Close()*/;
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void book_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
