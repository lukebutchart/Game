using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class Data
    {
        public AbilityTable Abilities { get; set; }
        public Table Classes { get; set; }
        public Table Special { get; set; }
        public Table Stats { get; set; }
        public Table GenerationNumbers { get; set; }

        //public List<Table> Tables { get; set; }

        public void InstantiateData()
        {
            CSVClass csvClass = new CSVClass();

            Table AbilitiesT = new Table();
            Abilities = new AbilityTable();
            Classes = new Table();
            Special = new Table();
            Stats = new Table();
            GenerationNumbers = new Table();

            AbilitiesT = csvClass.BuildTableFromCSV("Abilities");
            Abilities = Abilities.Parse(AbilitiesT);
            Classes = csvClass.BuildTableFromCSV("Classes");
            Special = csvClass.BuildTableFromCSV("Special");
            Stats = csvClass.BuildTableFromCSV("Stats");
            GenerationNumbers = csvClass.BuildTableFromCSV("GenerationNumbers");

            Abilities.UniqueAbilities = csvClass.GetUniqueColValues(Abilities, "Name");
            Abilities.HighestLevel = 5;

            AbilityGenerator abilityGen = new AbilityGenerator();
        }

        public string GetData(Table table, string columnName,int itemIndex = 1)
        {
            string item = "";
            int colIndex = new int();

            colIndex = table.ColumnNames.IndexOf(columnName);

            //if (table.Name == "GenerationNumbers") // CHECK whether  table == GenerationNumbers  works
            //{
                item = table.Columns[colIndex].Items[itemIndex];
            //}

            return item;
        }

        public int GetIndex(Table table, string columnName, string itemName)
        {
            int colIndex = new int();
            int itemIndex = new int();
            
            colIndex = table.ColumnNames.IndexOf(columnName);

            itemIndex = table.Columns[colIndex].Items.IndexOf(itemName);

            return itemIndex;
        }
    }
}
