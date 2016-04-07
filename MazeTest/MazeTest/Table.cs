using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class Table
    {
        /// <summary>
        /// The name of the table.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A list of every column name in the table.
        /// </summary>
        public List<string> ColumnNames { get; set; }
        /// <summary>
        /// The number of rows in the table including the header row.
        /// </summary>
        public int RowCount { get; set; }
        /// <summary>
        /// A list of every column in the table.
        /// </summary>
        public List<Column> Columns { get; set; }
    }
}
