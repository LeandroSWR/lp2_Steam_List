using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lp2_Steam_List {
    class Game {
        int ID, RequiredAge, DLCCount, Metacritic, MovieCount, RecommendationCount,
            ScreenshotCount, Owners, NumberOfPlayers, AchievementCount;
        string Name, AboutText;
        DateTime ReleaseDate;
        bool ControllerSupport, PlatformWindows, PlatformLinux, PlatformMac, 
            CategorySinglePlayer, CategoryMultiplayer, CategoryCoop, 
            CategoryIncludeLevelEditor, CategoryVRSupport;
        Uri SupportURL, HeaderImage, Website;

        public Game(string stream) {
            string[] parse = stream.Split(',');
            SaveData(parse);
        }

        private void SaveData(string[] parse) {
            ID = Convert.ToInt32(parse[0]);
            Name = parse[1];
            ReleaseDate = Convert.ToDateTime(parse[2]);
            RequiredAge = Convert.ToInt32(parse[3]);
            DLCCount = Convert.ToInt32(parse[4]);
            Metacritic = Convert.ToInt32(parse[5]);
            MovieCount = Convert.ToInt32(parse[6]);
            RecommendationCount = Convert.ToInt32(parse[7]);
            ScreenshotCount = Convert.ToInt32(parse[8]);
            Owners = Convert.ToInt32(parse[9]);
            NumberOfPlayers = Convert.ToInt32(parse[10]);
            AchievementCount = Convert.ToInt32(parse[11]);
            ControllerSupport = Convert.ToBoolean(parse[12]);
            PlatformWindows = Convert.ToBoolean(parse[13]);
            PlatformLinux = Convert.ToBoolean(parse[14]);
            PlatformMac = Convert.ToBoolean(parse[15]);
            CategorySinglePlayer = Convert.ToBoolean(parse[16]);
            CategoryMultiplayer = Convert.ToBoolean(parse[17]);
            CategoryCoop = Convert.ToBoolean(parse[18]);
            CategoryIncludeLevelEditor = Convert.ToBoolean(parse[19]);
            CategoryVRSupport = Convert.ToBoolean(parse[20]);
            SupportURL = new Uri(parse[21]);
            AboutText = parse[22];
            HeaderImage = new Uri(parse[22]);
            Website = new Uri(parse[23]);
        }
    }
}