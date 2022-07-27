using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blockchain_Basics
{
    public class DataBase
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
