using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SQL_Manager
{
    public class ObjectMethod
    {
        public static void DataGridView_Load(ListBox list, DataGridView grid, string conneconnectionString)
        {
            string tableName = list.SelectedItem.ToString();
            string query = $"SELECT * FROM {tableName}";

            using (SqlConnection connection = new SqlConnection(conneconnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                grid.DataSource = table;
            }
        }
        
        public static void ImportExcelToSql(string filePath, ListBox list, string connectionString)
        {
            if (!string.IsNullOrEmpty(filePath) & !string.IsNullOrEmpty(list.SelectedItem.ToString()))
            {
                MoverXLS.ImportExcelToSql(filePath, list.SelectedItem.ToString(), connectionString);
            }
            else
            {
                MessageBox.Show("Ошибка добавления элементов в таблицу");
            }
        }
        public static void SaveToExcel(string filePath, ListBox list,string connectionString)
        {
            if (filePath != null & list.SelectedItem.ToString() != null)
            {
                MoverXLS.ExportSqlTableToExcel(filePath, list.SelectedItem.ToString(), connectionString);
            }
            else MessageBox.Show("Пустой путь файла");
        }

        public static void SelectItem(DataGridView grid, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = grid.Rows[e.RowIndex];
                string cellValue = row.Cells[e.ColumnIndex].Value.ToString();
            }
        }

        public static void ReLoadListBox(ListBox list, string connectionString)
        {
            list.Items.Clear();

            string[] tableNames = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DataTable tables = connection.GetSchema("Tables");

                tableNames = new string[tables.Rows.Count];
                for (int i = 0; i < tables.Rows.Count; i++)
                {
                    list.Items.Add(tables.Rows[i]["TABLE_NAME"].ToString());
                }
            }
        }

        public static void DeleteFromDB(ListBox list, DataGridView grid, string connectionString)
        {
            if (list.SelectedIndex >= 0)
            {
                string tableName = list.SelectedItem.ToString();
                CRUD.DeleteItem(connectionString, tableName);
                DataGridView_Load(list, grid, connectionString);
            }
            else
            {
                MessageBox.Show("Таблица не выбрана!");
            }
        }

        public static void ShowFindings(ListBox list, DataGridView grid, string connectionString)
        {
            if (list.SelectedIndex >= 0)
            {
                string tableName = list.SelectedItem.ToString();

                CRUD.FindElementInTable(connectionString, tableName, grid);
                DataGridView_Load(list, grid, connectionString);
            }
            else
            {
                MessageBox.Show("Таблица не выбрана!");
            }
        }

        public static void AddToSQL(ListBox list, DataGridView grid, string connectionString)
        {
            string tableName;
            if (list.SelectedIndex >= 0)
            {
                tableName = list.SelectedItem.ToString();
                try
                {
                    CRUD.AddNewValueToTable(connectionString, tableName);
                    DataGridView_Load(list, grid, connectionString);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                MessageBox.Show("Таблица не выбрана!");
            }
        }

        public static void OverrideSQL_Element(ListBox list, DataGridView grid, string connectionString)
        {
            if (list.SelectedIndex >= 0)
            {
                CRUD.UpdateTable(list.SelectedItem.ToString() ,connectionString);
                DataGridView_Load(list, grid, connectionString);
            }
            else
            {
                MessageBox.Show("Таблица не выбрана!");
            }
        }

        #region "Выспомогательные методы"
        private static DataTable DGV_To_DT(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();

            // Добавляем столбцы в DataTable
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.Name, column.ValueType);
            }

            // Добавляем строки в DataTable
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow) // Пропускаем новую строку, если она есть
                {
                    DataRow dataRow = dataTable.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataRow[cell.ColumnIndex] = cell.Value ?? DBNull.Value; // Обработка null значений
                    }
                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
        #endregion
    }
}

