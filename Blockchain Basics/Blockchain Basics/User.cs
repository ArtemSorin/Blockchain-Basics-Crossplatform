using System;
using System.Collections.Generic;
using Firebase;
using System.Text;

namespace Blockchain_Basics
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public double UserProgress { get; set; }
        public int UserLessonsProgress { get; set; }
        public int UserGamesProgress { get; set; }
        public string UserSelectedLessons { get; set; }
        public string UserProfile { get; set; }
        public string UserAchievements { get; set; }
        public int UserPrimogames { get; set; }
        public bool Game_thitd_achievement { get; set; }
        public bool Game_third { get; set; }
    }
}
