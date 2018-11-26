using System;

namespace lp2_Steam_List {
    /// <summary>
    /// Holds all possible filters as variable to be later compared with the ones present in a GameList
    /// </summary>
    class Filters {
        /** \brief Required age to play the game */
        public int requiredAge;
        /** \brief Metacritic score */
        public int metacritic;
        /** \brief Number of recomendations */
        public int recommendationCount;
        /** \brief Game name */
        public string name = "";
        /** \brief Game realease date */
        public DateTime releaseDate;
        /** \brief Game has controller support */
        public bool controllerSupport;
        /** \brief Game is for platform Windows */
        public bool platformWindows;
        /** \brief Game is for platform Linux */
        public bool platformLinux;
        /** \brief Game is for platform Mac */
        public bool platformMac;
        /** \brief Game is Single Player */
        public bool categorySinglePlayer;
        /** \brief Game is Multi Player */
        public bool categoryMultiplayer;
        /** \brief Game has Co-op */
        public bool categoryCoop;
        /** \brief Game includes level editor */
        public bool categoryIncludeLevelEditor;
        /** \brief Game supports VR */
        public bool categoryVRSupport;

        public Filters() { } // Empty Filters constructor
    }
}