using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;


namespace timetrack
{
    public partial class Form1 : Form
    {
        DataTable tb = new DataTable();
        DataSet ds = new DataSet();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            dataGridView1.Rows.Add(i++, " ", textBox1.Text, "", DateTime.Now);
            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                if (textBox1.Text != String.Empty)
                {
                    dataGridView1.Rows[j].Cells[0].Value = j + 1;
                }
                else
                {
                    ClearDataGrid();
                    MessageBox.Show("Укажите время со скольки и до скольки вы работали", "Ошибка!", MessageBoxButtons.OK);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(DateTime.Now.Date);
        }

        private void maskedTextBox1_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBoxCalculate();
        }

        private void maskedTextBox2_TextChanged(object sender, EventArgs e)
        {
            MaskedTextBoxCalculate();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(dataGridView1.Size.Width + 10, dataGridView1.Size.Height + 10);
            dataGridView1.DrawToBitmap(bmp, dataGridView1.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Excel (*.XLS)|*.XLS";
            opf.ShowDialog();

            string filename = opf.FileName;

            string ConStr = String.Format("Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=Excel 8.0;", filename);
            System.Data.DataSet ds = new System.Data.DataSet("EXCEL");
            OleDbConnection cn = new OleDbConnection(ConStr);
            cn.Open();
            DataTable schemaTable = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string sheet1 = (string)schemaTable.Rows[0].ItemArray[2];
            string select = String.Format("SELECT * FROM [{0}]", sheet1);
            OleDbDataAdapter ad = new OleDbDataAdapter(select, cn);
            ad.Fill(ds);

            tb = ds.Tables[0];
            cn.Close();
            dataGridView1.DataSource = tb;
        }

        private void сохранитьВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application excelapp = new Excel.Application();
                Excel.Workbook workbook = excelapp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.ActiveSheet;

                for (int i = 1; i < dataGridView1.RowCount + 1; i++)
                {
                    for (int j = 1; j < dataGridView1.ColumnCount + 1; j++)
                    {
                        worksheet.Rows[i].Columns[j] = dataGridView1.Rows[i - 1].Cells[j - 1].Value;
                    }
                }

                excelapp.AlertBeforeOverwriting = false;
                workbook.SaveAs(@"C:\Users\erokhinya\Desktop\СУРВ.xls");
                excelapp.Quit();
            }
            catch (Exception)
            {

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ClearDataGrid();
        }

        private void ClearDataGrid()
        {
            tb.Clear();
            dataGridView1.Rows.Clear();
        }

        private void MaskedTextBoxCalculate()
        {
            if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull)
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime time1 = DateTime.ParseExact(maskedTextBox1.Text, "HH:mm", provider);
                DateTime time2 = DateTime.ParseExact(maskedTextBox2.Text, "HH:mm", provider);
                textBox1.Text = Convert.ToString((time2.Hour - time1.Hour) + " ч." + (time2.Minute - time1.Minute)) + " м.";
            }
            else
            {
                textBox1.Text = "0";
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime time1 = DateTime.ParseExact(maskedTextBox1.Text, "HH:mm", provider);
                    DateTime time2 = DateTime.ParseExact(maskedTextBox2.Text, "HH:mm", provider);
                    textBox1.Text = Convert.ToString(((time2.Hour - time1.Hour) - 1) + " ч." + (time2.Minute - time1.Minute)) + " м.";
                }
            }
            else
            {
                if (maskedTextBox1.MaskFull && maskedTextBox2.MaskFull)
                {
                    CultureInfo provider = CultureInfo.InvariantCulture;
                    DateTime time1 = DateTime.ParseExact(maskedTextBox1.Text, "HH:mm", provider);
                    DateTime time2 = DateTime.ParseExact(maskedTextBox2.Text, "HH:mm", provider);
                    textBox1.Text = Convert.ToString((time2.Hour - time1.Hour) + " ч." + (time2.Minute - time1.Minute)) + " м.";
                }
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProg about = new AboutProg();
            about.Show();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings setForm = new Settings();
            setForm.Show();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = (TextBox)e.Control;
            txt.ReadOnly = true;
            ComboBox cmb = (ComboBox)e.Control;
        }

        private void какИспользоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Used form = new Used();
            form.Show();
        }
    }
}
