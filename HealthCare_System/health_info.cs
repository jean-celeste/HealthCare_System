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
    public partial class health_info : UserControl
    {
        private MySqlConnection conn;
        private string patientId;
        public health_info()
        {
            InitializeComponent();
            conn = DatabaseConnection.GetConnection();
        }
        private void health_info_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Create a DataTable to hold the data
            DataTable dataTable = new DataTable();

            string query = @"SELECT * FROM patients WHERE patient_id = @patient_id";

            MySqlCommand command = new MySqlCommand(query, conn);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    name.Text = reader["patient_name"].ToString();
                    patientIDtxt.Text = reader["patient_id"].ToString();
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
        public void LoadData(string patient_id)
        {
            patientId = patient_id;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            // Create a DataTable to hold the data
            DataTable dataTable = new DataTable();

            string query = @"
                            SELECT hr.record_id, hr.patient_id, p.patient_name, hr.hospital_num, hr.room_num, hr.diagnosis, hr.treatment, 
                            hr.allergy, hr.medication, hr.last_visit_date, hr.medical_hist, hr.fam_hist
                            FROM healthcare_db.health_records hr
                            JOIN healthcare_db.patient p ON hr.patient_id = p.patient_id
                            WHERE hr.patient_id = @patient_id";

            MySqlCommand command = new MySqlCommand(query, conn);
            command.Parameters.AddWithValue("@patient_id", patient_id);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    name.Text = reader["patient_name"].ToString();
                    patientIDtxt.Text = reader["patient_id"].ToString();
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string patient_id = patientId;

            UpdateHealthInfo info = new UpdateHealthInfo();
            info.LoadData(patient_id);
            info.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string patient_id = patientId;

            AddHealthInfo info = new AddHealthInfo(patient_id);
            
            info.ShowDialog();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
