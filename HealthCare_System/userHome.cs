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
    public partial class userHome : UserControl
    {
        public userHome()
        {
            InitializeComponent();
        }

        public void UpdateLabel(string name)
        {
            nameLbl.Text = name;
        }
        
    }
}
