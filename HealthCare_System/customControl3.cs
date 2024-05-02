using Microsoft.Office.Interop.Excel;
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

namespace HealthCare_System
{
    public partial class customControl3 : UserControl
    {
        private DataGridView currentDataGridView; // Store the current DataGridView
        private string templateFilePath;
        private string reportFilePath;
        

        public customControl3()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void inventory1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            templateFilePath = "";
            reportFilePath = "";
            Customer customerFrm = new Customer();

            Controls.Add(customerFrm);
            customerFrm.Location = new System.Drawing.Point(0, 163);
            customerFrm.BringToFront();
            customerFrm.DataGridViewControl.Rows.Clear();
            customerFrm.LoadData();

            templateFilePath = System.Windows.Forms.Application.StartupPath + @"\reportTemplate\Customer Report.xlsx";
/*            reportFilePath = System.Windows.Forms.Application.StartupPath + @"\generatedReport\Customer Report " + dateGenerated + ".xlsx";
*/
            // Store the current DataGridView
            currentDataGridView = customerFrm.DataGridViewControl;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            templateFilePath = "";
            Inventory inventoryFrm = new Inventory();

            Controls.Add(inventoryFrm);
            inventoryFrm.Location = new System.Drawing.Point(0, 163);
            inventoryFrm.BringToFront();
            inventoryFrm.DataGridViewControl.Rows.Clear();
            inventoryFrm.LoadData();

            templateFilePath = System.Windows.Forms.Application.StartupPath + @"\reportTemplate\Inventory Report.xlsx";
            

            Console.WriteLine(reportFilePath);
            currentDataGridView = inventoryFrm.DataGridViewControl;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            templateFilePath = "";
            Sales salesFrm = new Sales();

            Controls.Add(salesFrm);
            salesFrm.Location = new System.Drawing.Point(0, 163);
            salesFrm.BringToFront();
            salesFrm.DataGridViewControl.Rows.Clear();
            salesFrm.LoadData();


            templateFilePath = System.Windows.Forms.Application.StartupPath + @"\reportTemplate\Sales Report.xlsx";

            // Store the current DataGridView
            currentDataGridView = salesFrm.DataGridViewControl;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (currentDataGridView != null)
            {
                ExportToExcel(currentDataGridView);
            }
            else
            {
                MessageBox.Show("No DataGridView selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToExcel(DataGridView dataGridView)
        {
            DateTime now = DateTime.Now;
            string dateGenerated = now.ToString("yyyy-MM-dd hh-mm-ss");

            Workbook workbook = null;
            Worksheet worksheet = null;
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            try
            {
                // Create a new instance of Excel application
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;

                // Open the existing Excel template file
                workbook = excelApp.Workbooks.Open(templateFilePath);

                // Get the first worksheet in the workbook (index starts from 1)
                worksheet = workbook.Sheets[1];

                // Start row index in Excel (assuming you have headers)
                int rowIndex = 16;

                // Assign different report file paths based on which button was clicked
                if (templateFilePath.Contains("Customer Report"))
                {
                    reportFilePath = System.Windows.Forms.Application.StartupPath + @"\generatedReport\Customer Report " + dateGenerated + ".xlsx";
                }
                else if (templateFilePath.Contains("Inventory Report"))
                {
                    reportFilePath = System.Windows.Forms.Application.StartupPath + @"\generatedReport\Inventory Report " + dateGenerated + ".xlsx";
                }
                else if (templateFilePath.Contains("Sales Report"))
                {
                    reportFilePath = System.Windows.Forms.Application.StartupPath + @"\generatedReport\Sales Report " + dateGenerated + ".xlsx";
                }

                // Loop through DataGridView rows and populate Excel cells
                foreach (DataGridViewRow dgvRow in dataGridView.Rows)
                {
                    // Skip the new row if it's not populated
                    if (!dgvRow.IsNewRow)
                    {
                        // Loop through DataGridView columns and populate Excel cells
                        for (int colIndex = 0; colIndex < dataGridView.Columns.Count; colIndex++)
                        {
                            // Populate each cell in the current row
                            worksheet.Cells[rowIndex, colIndex + 2] = dgvRow.Cells[colIndex].Value;
                        }

                        // Move to the next row in Excel
                        rowIndex++;
                    }
                }

                // Save changes to the Excel file
                workbook.SaveAs(reportFilePath);
                excelApp.Workbooks.Open(reportFilePath).PrintPreview();

                MessageBox.Show("Data exported to Excel successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log, display error message)
                MessageBox.Show("Error exporting data to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (workbook != null)
                {
                    /*workbook.Close(); // Close the workbook before quitting*/
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                }

                if (excelApp != null)
                {
                    excelApp.Quit(); // Quit Excel application
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                }
            }
        }

        
    }
}
