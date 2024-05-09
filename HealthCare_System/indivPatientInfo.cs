using MySql.Data.MySqlClient;
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

namespace HealthCare_System
{
    public partial class indivPatientInfo : UserControl
    {
        
        private MySqlConnection conn;

        public indivPatientInfo()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
        }
        public void UpdateLabel(string name)
        {
            
            header.Text = name +"'s Health Information";
        }
        public void RetrieveHealthRecords(string userName)
        {
            Console.WriteLine(userName);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            try
            {
                string query = "SELECT patient_id FROM patient WHERE patient_name = @userName";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@userName", userName);
                string patientId = command.ExecuteScalar()?.ToString();
                


                if (!string.IsNullOrEmpty(patientId))
                {
                    // Retrieve health records based on patient_id
                    query = "SELECT * FROM health_records WHERE patient_id = @patientId";
                    command = new MySqlCommand(query, conn);
                    command.Parameters.AddWithValue("@patientId", patientId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            patientIDTxt.Text = "Patient ID: " + patientId;
                            recordIDtxt.Text = reader["record_id"].ToString();
                            hospNumTxt.Text = reader["hospital_num"].ToString();
                            roomNumTxt.Text = reader["room_num"].ToString();
                            diagTxt.Text = reader["diagnosis"].ToString();
                            treatmentTxt.Text = reader["treatment"].ToString();
                            allergyTxt.Text = reader["allergy"].ToString();
                            medTxt.Text = reader["medication"].ToString();
                            dateTxt.Text = reader["last_visit_date"].ToString();
                            medHist.Text = reader["medical_hist"].ToString();
                            famHist.Text = reader["fam_hist"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
