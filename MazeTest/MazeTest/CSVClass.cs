using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class CSVClass
    {
        /// <summary>
        /// Returns a Table object created from a given table file. (default csv)
        /// </summary>
        /// <param name="fileName">The name of the file to build a Table from. (no extension)</param>
        /// <param name="extension">The extension of the file.</param>
        /// <param name="directory">The directory of the file.</param>
        /// <returns>A Table object of the given table file.</returns>
        public Table BuildTableFromCSV(string fileName, string extension = ".csv", string directory = @"C:\Users\luke.butchart\Documents\_Test Repository\MazeTest\MazeTest\bin\Debug\")
        {
            if (!extension.Contains("."))
            {
                extension = "." + extension;
            }

            if (fileName.Contains(extension))
            {
                extension = "";
            }

            try
            {
                var reader = new StreamReader(File.OpenRead(directory + fileName + extension));

                Table table = new Table();
                Column column = new Column();
                int columnCount = 0;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    columnCount = values.Count();
                }

                table.Columns = new List<Column>();
                table.ColumnNames = new List<string>();

                for (int i = 0; i < columnCount; i++)
                {
                    column = new Column();
                    table.Columns.Add(column);
                    table.ColumnNames.Add("");
                }

                reader = new StreamReader(File.OpenRead(directory + fileName + extension));

                for (int columnNum = 0; columnNum < columnCount; columnNum++)
                {
                    table.Columns[columnNum].Items = new List<string>();
                }

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    for (int columnNum = 0; columnNum < columnCount; columnNum++)
                    {
                        table.Columns[columnNum].Items.Add(values[columnNum]);
                    }
                }

                for (int columnNum = 0; columnNum < columnCount; columnNum++)
                {
                    table.Columns[columnNum].Name = table.Columns[columnNum].Items[0];
                    table.ColumnNames[columnNum] = table.Columns[columnNum].Name;
                }

                table.RowCount = table.Columns[0].Items.Count();


                if (fileName.Contains(extension))
                {
                    fileName = fileName.Remove(fileName.IndexOf(extension));
                }

                if (fileName.Contains("."))
                {
                    fileName = fileName.Replace(".","");
                }

                table.Name = fileName;

                return table;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<string> GetUniqueColValues(Table table, string colName)
        {
            int colIndex = table.ColumnNames.IndexOf(colName);

            List<string> list = new List<string>();

            foreach (string item in table.Columns[colIndex].Items)
            {
                if (!list.Contains(item))
                {
                    list.Add(item);
                }
            }

            return list;
        }
    }
}