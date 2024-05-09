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
    public partial class UpdateHealthInfo : Form
    {
        private MySqlConnection conn;
        private string patientId;
        public UpdateHealthInfo()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
        }
        public void LoadData(string patient_id)
        {
            patientId = patient_id;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            

            string query = @"SELECT hospital_num, room_num, diagnosis, treatment, allergy, medication, last_visit_date, medical_hist, fam_hist
                             FROM healthcare_db.health_records
                             WHERE patient_id = @patient_id";

            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@patient_id", patient_id);
            Console.Write(patient_id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    hn.Text = reader["hospital_num"].ToString();
                    rn.Text = reader["room_num"].ToString();
                    diag.Text = reader["diagnosis"].ToString();
                    treat.Text = reader["treatment"].ToString();
                    allergy.Text = reader["allergy"].ToString();
                    medication.Text = reader["medication"].ToString();
                    date.Text = reader["last_visit_date"].ToString();
                    med.Text = reader["medical_hist"].ToString();
                    fam.Text = reader["fam_hist"].ToString();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hospital_num = hn.Text;
            string room_num = rn.Text;
            string diagnosis = diag.Text;
            string treatment = treat.Text;
            string allergyTxt = allergy.Text;
            string medicationTxt = medication.Text;
            DateTime last_visit_date = date.Value; 
            string medical_hist = med.Text;
            string fam_hist = fam.Text;

            
            string formattedVisitDate = last_visit_date.ToString("yyyy-MM-dd");

            string query = @"UPDATE healthcare_db.health_records 
            SET hospital_num = @hospital_num, 
                room_num = @room_num, 
                diagnosis = @diagnosis, 
                treatment = @treatment, 
                allergy = @allergyTxt, 
                medication = @medicationTxt, 
                last_visit_date = @last_visit_date, 
                medical_hist = @medical_hist, 
                fam_hist = @fam_hist
            WHERE patient_id = @patient_id";

            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@hospital_num", hospital_num);
            command.Parameters.AddWithValue("@room_num", room_num);
            command.Parameters.AddWithValue("@diagnosis", diagnosis);
            command.Parameters.AddWithValue("@treatment", treatment);
            command.Parameters.AddWithValue("@allergyTxt", allergyTxt); 
            command.Parameters.AddWithValue("@medicationTxt", medicationTxt); 
            command.Parameters.AddWithValue("@last_visit_date", formattedVisitDate); 
            command.Parameters.AddWithValue("@medical_hist", medical_hist);
            command.Parameters.AddWithValue("@fam_hist", fam_hist);
            command.Parameters.AddWithValue("@patient_id", patientId);

            // Execute the update query
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Update successful. " + rowsAffected + " rows updated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating database: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }

}
