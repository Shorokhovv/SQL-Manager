using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SQL_Manager
{
    public partial class Form1 : Form
    {
        private static string connectionString = "Server = EX-MACHINE;Initial Catalog = Zachet; Integrated Security = True";
        private static string loadedFile;
        public Form1()
        {
            InitializeComponent();           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ObjectMethod.ReLoadListBox(Tables_ListBox, connectionString);
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                bool isExcelFile = files.All(file =>
                    file.EndsWith(".xls", StringComparison.OrdinalIgnoreCase) ||
                    file.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase));

                e.Effect = isExcelFile ? DragDropEffects.Copy : DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length == 1)
            {
                loadedFile = files[0];
                Load_XLS.Visible = true;
            }
            else
            {
                MessageBox.Show("Прогамма способна работать только с 1 файлом!");
            }
        }

        private void Load_XLS_Click(object sender, EventArgs e)
        {
            string path = loadedFile;
            Load_XLS.Visible = false;
            ObjectMethod.ImportExcelToSql(path, Tables_ListBox, connectionString);
            loadedFile = null;
        }

        private void BackUp_AtSQL_Click(object sender, EventArgs e)
        {
            string path = $@"C:\Users\Devil\Desktop\XLS";
            ObjectMethod.SaveToExcel(path, Tables_ListBox, connectionString);
            MessageBox.Show($@"Файл с именем {Tables_ListBox.SelectedItem.ToString()} сохранён по адресу {path}");
        }

        private void Create_AtSQL_Click(object sender, EventArgs e)
        {
            ObjectMethod.AddToSQL(Tables_ListBox, DataGridView_SQL, connectionString);
        }

        private void Override_AtSQL_Click(object sender, EventArgs e)
        {
            ObjectMethod.OverrideSQL_Element(Tables_ListBox, DataGridView_SQL, connectionString);
        }

        private void Find_AtSQL_Click(object sender, EventArgs e)
        {
            if (Tables_ListBox.SelectedIndex >= 0)
            {
                string tableName = Tables_ListBox.SelectedItem.ToString();

                CRUD.FindElementInTable(connectionString, tableName, DataGridView_SQL);
            }
            else
            {
                MessageBox.Show("Таблица не выбрана!");
            }
        }

        private void Delete_AtSQL_Click(object sender, EventArgs e)
        {
            ObjectMethod.DeleteFromDB(Tables_ListBox, DataGridView_SQL, connectionString);
        }

        private void Tables_ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tables_ListBox.SelectedItem != null)
            {
                ObjectMethod.DataGridView_Load(Tables_ListBox, DataGridView_SQL, connectionString);
            }
        }

        private void Reset_ListBox_Click(object sender, EventArgs e)
        {
            ObjectMethod.ReLoadListBox(Tables_ListBox, connectionString);
        }

        private void DataGridView_SQL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ObjectMethod.SelectItem(DataGridView_SQL, e); 
        }

        #region "Вспомогательные методы"
        public static string SelectFolderUsingOpenFileDialog()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Выберите папку";
                ofd.ValidateNames = false;
                ofd.CheckFileExists = false;
                ofd.CheckPathExists = true;
                ofd.FileName = "Папка"; 

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    return System.IO.Path.GetDirectoryName(ofd.FileName);
                }
                else
                {
                    MessageBox.Show("Путь не выбран", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return null;
                }
            }
        }
        #endregion
    }
}
