using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class Column
    {
        /// <summary>
        /// The name (header) of the column.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A list of the items in the column including header.
        /// </summary>
        public List<string> Items { get; set; }
    }
}
