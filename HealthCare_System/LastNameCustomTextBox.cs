using System;
using System.Drawing;
using System.Windows.Forms;

namespace EDP_GUI
{
    public partial class customTextBox : UserControl
    {
        public customTextBox()
        {
            InitializeComponent();
        }

        bool isFocused = false;

        private void labelTimer_Tick(object sender, EventArgs e)
        {
            int y = label1.Location.Y;
            if (!isFocused)
            {
                y -= 2;
                label1.Location = new Point(label1.Location.X, y);
                if (y <= 3)
                {
                    isFocused = true;
                    labelTimer.Stop();
                    label1.Font = new Font("Montserrat", 9);
                    y = 0;
                    label1.ForeColor = Color.Silver;
                }
            }
            else
            {
                y += 2;
                label1.Location = new Point(label1.Location.X, y);
                if (y >= 16)
                {
                    isFocused = false;
                    labelTimer.Stop();
                    label1.Font = new Font("Montserrat", 10);
                    y = 16;
                    label1.ForeColor = Color.Black;
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                labelTimer.Start();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                labelTimer.Start();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Pass the click event to the textbox
            textBox1.Focus();
        }

        // Intercept mouse down event to pass it to the textbox
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            // Pass the mouse down event to the textbox
            PassEventToControl(textBox1, "OnMouseDown", e);
        }

        // Intercept mouse up event to pass it to the textbox
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            // Pass the mouse up event to the textbox
            PassEventToControl(textBox1, "OnMouseUp", e);
        }

        // Method to pass mouse events to another control
        private void PassEventToControl(Control control, string eventName, MouseEventArgs e)
        {
            // Convert mouse coordinates from label to textbox
            Point textBoxPoint = textBox1.PointToClient(label1.PointToScreen(e.Location));

            // Pass the mouse event to the textbox
            control.GetType().GetMethod(eventName,
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .Invoke(control, new object[] { new MouseEventArgs(e.Button, e.Clicks, textBoxPoint.X, textBoxPoint.Y, e.Delta) });
        }
    }
}
