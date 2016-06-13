using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class NamesTable : Table
    {
        /// <summary>
        /// A list of all unique genders. (INCLUDES EMPTY STRING AT INDEX 0)
        /// </summary>
        public List<string> UniqueGenders { get; set; }

        public List<string> MaleNameList { get; set; }

        public List<string> FemaleNameList { get; set; }

        public NamesTable Parse(Table table)
        {
            NamesTable namesTable = new NamesTable();

            namesTable.ColumnNames = table.ColumnNames;
            namesTable.Columns = table.Columns;
            namesTable.Name = table.Name;
            namesTable.RowCount = table.RowCount;

            return namesTable;
        }
    }
}