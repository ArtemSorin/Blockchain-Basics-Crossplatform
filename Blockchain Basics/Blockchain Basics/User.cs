using System;
using System.Collections.Generic;
using SQLite;
using System.Text;

namespace Blockchain_Basics
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public double UserProgress { get; set; }
        public int UserLessonsProgress { get; set; }
        public int UserGamesProgress { get; set; }
        public string UserSelectedLessons { get; set; }
    }
}
