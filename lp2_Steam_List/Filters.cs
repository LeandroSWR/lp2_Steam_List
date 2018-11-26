using System;

namespace lp2_Steam_List {
    /// <summary>
    /// Holds all possible filters as variable to be later compared with the ones present in a GameList
    /// </summary>
    class Filters {

        public int requiredAge, metacritic, recommendationCount; // Declares all ints
        public string name = ""; // Declares all strings
        public DateTime releaseDate; // Declares all DateTimes
        public bool controllerSupport, platformWindows, platformLinux, platformMac,
            categorySinglePlayer, categoryMultiplayer, categoryCoop,
            categoryIncludeLevelEditor, categoryVRSupport; // Declares all bools

        public Filters() { } // Empty Filters constructor
    }
}