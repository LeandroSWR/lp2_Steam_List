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
        }
    }
}