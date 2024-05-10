using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace HealthCare_System
{
    public partial class MainForm : Form
    {
        private Form loginForm;
        private UserAdmin_Prompt userAdminPrompt;
        private customControl1 home;
        private customControl2 dashboard;
        private customControl3 report;
        private customControl4 about;

        public MainForm(UserAdmin_Prompt userAdminPrompt, Form loginForm)
        {
            InitializeComponent();
            /*this.userAdminPrompt = userAdminPrompt;*/
            this.loginForm = loginForm;

            //sidePanel.Height = button1.Height;

            //customControl1.BringToFront();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Subscribe to the FormClosing event
            this.FormClosing += MainForm_FormClosing;
        }

        // Event handler for FormClosing event
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Ensure that the user wants to exit
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancel the closing event
            }
            else
            {
                // Unsubscribe from the FormClosing event to prevent multiple dialogs
                this.FormClosing -= MainForm_FormClosing;
                Environment.Exit(0);

                // Break into the debugger (optional)
                Debugger.Break();
                //Application.Exit(); // Close the entire application
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //button6.BackColor = Color.White;
            //button2.BackColor = Color.DarkSlateGray;
            button1.BackColor = Color.DarkSlateGray;
            //button5.BackColor = Color.DarkSlateGray;
            button8.BackColor = Color.DarkSlateGray;

            button8.ForeColor = Color.White;

            //button6.ForeColor = Color.DarkSlateGray;
            ////button2.ForeColor = Color.White;
            //button5.ForeColor = Color.White;
            button1.ForeColor = Color.White;

            report = new customControl3();
            Controls.Add(report);
            report.Location = new Point(221, 40);
            report.BringToFront();

            // Disable other controls
            if (dashboard != null)
                dashboard.Enabled = false;
            if (home != null)
                home.Enabled = false;
            if (about != null)
                about.Enabled = false;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //button5.BackColor = Color.White;
            //button2.BackColor = Color.DarkSlateGray;
            //button6.BackColor = Color.DarkSlateGray;
            button1.BackColor = Color.DarkSlateGray;
            button8.BackColor = Color.DarkSlateGray;

            button8.ForeColor = Color.White;

            //button5.ForeColor = Color.DarkSlateGray;
            //button2.ForeColor = Color.White;
            button1.ForeColor = Color.White;
            //button6.ForeColor = Color.White;

            about = new customControl4();
            Controls.Add(about);
            about.Location = new Point(221, 40);
            about.BringToFront();

            // Disable other controls
            if (dashboard != null)
                dashboard.Enabled = false;
            if (report != null)
                report.Enabled = false;
            if (home != null)
                home.Enabled = false;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
            //button2.BackColor = Color.FromArgb(36, 176, 186); ;
            //button5.BackColor = Color.DarkSlateGray;
            //button6.BackColor = Color.DarkSlateGray;
            button8.BackColor = Color.DarkSlateGray;

            button8.ForeColor = Color.White;

            button1.ForeColor = Color.DarkSlateGray;
            //button2.ForeColor = Color.White;
            //button5.ForeColor = Color.White;
            //button6.ForeColor = Color.White;

            home = new customControl1();
            Controls.Add(home);
            home.Location = new Point(221, 40);
            home.BringToFront();

            // Disable other controls
            if (dashboard != null)
                dashboard.Enabled = false;
            if (report != null)
                report.Enabled = false;
            if (about != null)
                about.Enabled = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void customControl21_Load(object sender, EventArgs e)
        {

        }

        private void customControl31_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button2.BackColor = Color.White;
            button1.BackColor = Color.DarkSlateGray;
            //button5.BackColor = Color.DarkSlateGray;
            //button6.BackColor = Color.DarkSlateGray;
            button8.BackColor = Color.DarkSlateGray;

            button8.ForeColor = Color.White;
            //button2.ForeColor = Color.DarkSlateGray;
            button1.ForeColor = Color.White;
            //button5.ForeColor = Color.White;
            //button6.ForeColor = Color.White;

            dashboard = new customControl2();
            Controls.Add(dashboard);
            dashboard.Location = new Point(221, 40);
            dashboard.BringToFront();

            // Disable other controls
            if (home != null)
                home.Enabled = false;
            if (report != null)
                report.Enabled = false;
            if (about != null)
                about.Enabled = false;
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.BackColor = Color.White;
            button1.BackColor = Color.DarkSlateGray;
            //button2.BackColor = Color.DarkSlateGray;
            //button5.BackColor = Color.DarkSlateGray;
            //button6.BackColor = Color.DarkSlateGray;

            button8.ForeColor = Color.DarkSlateGray;
            button1.ForeColor = Color.White;
            //button2.ForeColor = Color.White;
            //button5.ForeColor = Color.White;
            //button6.ForeColor = Color.White;

            Patient rentalfrm = new Patient();
            Controls.Add(rentalfrm);
            rentalfrm.Location = new Point(221, 40);
            rentalfrm.BringToFront();

            // Disable other controls
            if (dashboard != null)
                dashboard.Enabled = false;
            if (report != null)
                report.Enabled = false;
            if (about != null)
                about.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the current form
            UserAdmin_Prompt prompt = new UserAdmin_Prompt();
            prompt.Show();
        }
    }
}
