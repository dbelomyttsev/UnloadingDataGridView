using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnloadingDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<Сontact> phonesList = new List<Сontact>
            {
                new Сontact{Name="Дима", Number="7(950)358-59-76"},
                new Сontact{Name="Иван", Number="7(950)037-14-12"},
                new Сontact{Name="Данил", Number="7(950)592-33-45"},
            };
            dataGridView1.DataSource = phonesList;
        }

        enum Types
        {
            txt,
            csv
        }

        private void SaveDataGridView(DataGridView dgv, Types type)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            string filename = saveFileDialog.FileName;
            if (filename == "")
                return;

            StreamWriter sw = new StreamWriter(filename  + "." + type, false, Encoding.UTF8);


            int columnCount = dgv.Columns.Count;
            for (int i = 0; i < columnCount; i++)
            {
                sw.Write(dgv.Columns[i].HeaderText);
                if (i < columnCount - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);


            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells[i].Value != null)
                        {
                            sw.Write(row.Cells[i].Value);
                        }
                        if (i < row.Cells.Count - 1)
                        {
                            sw.Write(";");
                        }
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveDataGridView(dataGridView1, Types.csv);
                MessageBox.Show("Файл сохранен");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveDataGridView(dataGridView1, Types.txt);
                MessageBox.Show("Файл сохранен");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
