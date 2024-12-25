using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SQL_Manager
{
    public class CRUD
    {
        // СОЗДАНИЕ НОВОГО ЭЛЕМЕНТА ТАБЛИЦЫ
        public static void AddNewValueToTable(string connectionString, string tableName)
        {
            string[] columnNames = ColumnNames(tableName, connectionString);
            object[] values = Answers(columnNames);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($@"
                BEGIN TRANSACTION;
                SET IDENTITY_INSERT {tableName} ON;
                INSERT INTO {tableName} ({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", columnNames.Select((cn, index) => "@p" + index))});
                SET IDENTITY_INSERT {tableName} OFF;
                COMMIT;", connection);

                for (int i = 0; i < columnNames.Length; i++)
                {
                    command.Parameters.AddWithValue("@p" + i, values[i]);
                }

                if (Confirmation("Вы уверены что хотите добавить этот элемент?"))
                {

                    command.ExecuteNonQuery();
                }
                else MessageBox.Show("Элемент НЕ добавлен");
            }
        }

        // ПОЛУЧАЕТ СТРОКУ С ЭЛЕМЕНТОМ И НАЗВАНИЕ СТОЛБЦОВ  
        public static void UpdateTable(string tableName, string connectionString)
        {
            string id = Element($"Введите id для изменения значения из таблицы '{tableName}'");
            if (!string.IsNullOrEmpty(id))
            {
                string[] columnNames = ColumnNames(tableName, connectionString);
                string[] userInputs = Answers(columnNames);

                List<string> values = new List<string>();

                for (int i = 0; i < columnNames.Length; i++)
                {
                    if (!string.IsNullOrEmpty(userInputs[i]))
                    {
                        values.Add(userInputs[i]);
                    }
                }

                if (values.Count > 0)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        if (Confirmation($"Вы уверены, что хотите удалить элемент под номером {id} из таблицы '{tableName}'?"))
                        {
                            string command = $@"
                                BEGIN TRANSACTION;
                                SET IDENTITY_INSERT {tableName} ON;
                                DELETE FROM {tableName} WHERE ID = {id};
                                INSERT INTO {tableName} ({string.Join(", ", columnNames)}) VALUES ({string.Join(", ", values)});
                                SET IDENTITY_INSERT {tableName} OFF;
                                COMMIT;";

                            using (SqlCommand transactionCommand = new SqlCommand(command, connection))
                            {
                                transactionCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }



        // ПОИСК элементов ПО СОВПАДЕНИЮ
        public static void FindElementInTable(string connectionString, string tableName, DataGridView grid)
        {
            string element = Element($"Введите искомый элемент из <{tableName}>: ");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($@"SELECT * FROM {tableName} WHERE {string.Join(" OR ", ColumnNames(tableName, connectionString).Select(cn => $"{cn} LIKE '%{element}%'"))}", connection);
                SqlDataReader reader = command.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);

                grid.DataSource = table;
                connection.Close();
            }
        }

        // УДАЛЕНИЕ ЭЛЕМЕНТА ПО ID
        public static void DeleteItem(string connectionString, string tableName)
        {
            string id = Element("Введите id для удаления: ").ToString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($@"
                BEGIN TRANSACTION;
                DELETE FROM {tableName} WHERE ID = {id}
                COMMIT;", connection);

                if (Confirmation($"Вы уверены что хотите удалить элмент под номером {id} из таблицы {tableName} ?"))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Элемент с ID = {id} успешно удален из таблицы '{tableName}'");
                    }
                    else
                    {
                        MessageBox.Show($"Элемент с ID = {id} не найден в таблице '{tableName}'");
                    }
                }
            }
        }

#region "Вспомогательные методы"

        // МЕТОД ПОЛУЧАЮЩИЙ ИМЯ ТАБЛИЦЫ И СТРОКУ ПОДКЛЮЧЕНИЯ И ВОЗВРАЩАЮЩИЙ НАЗВАНИЯ КОЛОНОК ТАБЛИЦЫ
        public static string[] ColumnNames(string tableName, string connectionString)
        {
            string[] columnNames = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT * FROM {tableName}", connection);

                SqlDataReader reader = command.ExecuteReader();

                DataTable schemaTable = reader.GetSchemaTable();
                columnNames = new string[schemaTable.Rows.Count];

                for (int i = 0; i < schemaTable.Rows.Count; i++)
                {
                    columnNames[i] = schemaTable.Rows[i]["ColumnName"].ToString();
                }
            }
            return columnNames;
        }

        public static string[] GetExcelColumnNames(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0]; // Получаем первый лист
                int colCount = worksheet.Dimension.End.Column; // Количество столбцов
                string[] columnNames = new string[colCount];

                for (int col = 1; col <= colCount; col++)
                {
                    columnNames[col - 1] = worksheet.Cells[1, col].Text.ToLower(); // Получаем названия столбцов и приводим к нижнему регистру
                }

                return columnNames;
            }
        }
        // СТИЛИЗОВАННЫЙ МЕТОД ОПРОСНИК ПОЛУЧАЮЩИЙ СТРОКУ И ВОЗВРАЩАЮЩИЙ НА НЕЁ ОТВЕТ 
        public static string Element(string message) // запихать в if not null
        {
            Form inputForm = new Form();
            inputForm.Text = message;
            inputForm.Size = new System.Drawing.Size(500, 200);
            inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputForm.TopMost = true;
            inputForm.StartPosition = FormStartPosition.CenterScreen;

            TextBox inputBox = new TextBox();
            inputBox.Size = new System.Drawing.Size(250, 20);
            inputBox.Location = new System.Drawing.Point(10, 20);
            inputForm.Controls.Add(inputBox);

            Button okButton = new Button();
            okButton.Text = "Далее";
            okButton.DialogResult = DialogResult.OK;
            okButton.Location = new System.Drawing.Point(10, 50);
            inputForm.AcceptButton = okButton;
            inputForm.Controls.Add(okButton);

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                return inputBox.Text;
            }
            else
            {
                return null;
            }
        }

        //ВОЗВРАЩАЕТ ОТЕТ ОТ ПОЛЬЗОВАТЕЛЯ ОТНОСИТЕЛЬНО ЭЛЕМЕНТУ МАССИВА 
        public static string[] Answers(string[] elements)
        {
            string[] answers = new string[elements.Length];
            for (int i = 0; i < elements.Length; i++)
            {
                string answer = Element(elements[i]);
                if (answer != null)
                {
                    answers[i] = answer;
                }
                else
                {
                    answers[i] = string.Empty;
                }
            }
            return answers;
        }

        // РАЗРЕШЕНИЕ ПОЛЬЗОВАТЕЛЯ
        public static bool Confirmation(string message)
        {
            DialogResult result = MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

#endregion
    }
}
