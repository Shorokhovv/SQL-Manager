using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using OfficeOpenXml;
using NPOI.SS.UserModel;
using System.Windows.Forms;

namespace SQL_Manager
{
    public class MoverXLS
    {
        public static void ImportExcelToSql(string filePath, string tableName, string connectionString)
        {
            string[] excelColumnNames = GetExcelColumnNames(filePath);
            string[] sqlColumnNames = ColumnNames(tableName, connectionString);

            for (int i = 0; i < sqlColumnNames.Length; i++)
            {
                sqlColumnNames[i] = sqlColumnNames[i].ToLower();
            }

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.End.Row;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var values = new List<object>();
                        var columns = new List<string>();

                        for (int col = 1; col <= excelColumnNames.Length; col++)
                        {
                            string columnName = worksheet.Cells[1, col].Text.ToLower();
                            if (sqlColumnNames.Contains(columnName))
                            {
                                columns.Add(columnName);
                                values.Add(worksheet.Cells[row, col].Text);
                            }
                        }

                        string columnNames = string.Join(", ", columns);
                        string parameterNames = string.Join(", ", columns.Select((_, index) => $"@value{index}"));

                        SqlCommand command = new SqlCommand($@"
                        BEGIN TRANSACTION;
                        SET IDENTITY_INSERT {tableName} ON;
                        INSERT INTO {tableName} ({columnNames}) VALUES ({parameterNames});
                        SET IDENTITY_INSERT {tableName} OFF;
                        COMMIT;", connection);

                        for (int i = 0; i < values.Count; i++)
                        {
                            command.Parameters.AddWithValue($"@value{i}", values[i]);
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public static void ExportSqlTableToExcel(string filePath, string tableName, string connectionString)
        {
            string excelFilePath = Path.Combine(filePath, $"{tableName}.xlsx");

            if (File.Exists(excelFilePath))
            {
                File.Delete(excelFilePath);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $"SELECT * FROM {tableName}";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        using (ExcelPackage excelPackage = new ExcelPackage())
                        {
                            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(tableName);

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                worksheet.Cells[1, i + 1].Value = reader.GetName(i);
                            }

                            int row = 2;

                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    worksheet.Cells[row, i + 1].Value = reader[i];
                                }
                                row++;
                            }
                            FileInfo excelFile = new FileInfo(excelFilePath);
                            excelPackage.SaveAs(excelFile);
                        }
                    }
                }
            }
        }
    

        #region "Вспомогательные методы"
        private static string[] ColumnNames(string tableName, string connectionString)
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

        private static string[] GetExcelColumnNames(string filePath)
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
        #endregion
    }
}
