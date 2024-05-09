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
    public partial class AddHealthInfo : Form
    {
        private MySqlConnection conn;
        private string patientId;
        public AddHealthInfo(string patient_id)
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
            patientId = patient_id;
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

            string query = @"INSERT INTO healthcare_db.health_records 
                    (hospital_num, room_num, diagnosis, treatment, allergy, medication, last_visit_date, medical_hist, fam_hist, patient_id)
                    VALUES
                    (@hospital_num, @room_num, @diagnosis, @treatment, @allergyTxt, @medicationTxt, @last_visit_date, @medical_hist, @fam_hist, @patient_id)";

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

            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Insertion successful. " + rowsAffected + " rows inserted.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting into database: " + ex.Message);
            }
            finally
            {
                health_info info = new health_info();
                info.LoadData();
                conn.Close();
            }

            
        }


    }

}
