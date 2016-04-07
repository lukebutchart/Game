using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class AbilityTable : Table
    {
        public List<string> UniqueAbilities { get; set; }

        public AbilityTable Parse(Table table)
        {
            AbilityTable abilityTable = new AbilityTable();

            abilityTable.ColumnNames = table.ColumnNames;
            abilityTable.Columns = table.Columns;
            abilityTable.Name = table.Name;
            abilityTable.RowCount = table.RowCount;

            return abilityTable;
        }

        public int HighestLevel { get; set; }
    }
}
