using System;
using System.Collections.Generic;
using System.Linq;

namespace lp2_Steam_List {
    class FilteredList : List<Game> {

        private GameList games; // Declares a new GameList
        private Filters filter; // Declares a new Filters
        private List<Game> tempList; // Declares a new tempList
        private string orderCriteria; // Declares a new oderCriteria

        /// <summary>
        /// FilteredList Constructor
        /// </summary>
        /// <param name="filter">Game Object that contains all the filters information</param>
        /// <param name="games">The main dictionary of Game</param>
        /// <param name="orderCriteria">Holds a string that represents the order criteria</param>
        public FilteredList(Filters filter, GameList games, string orderCriteria) {

            this.games = games; // Passes the value to the in class variable
            this.filter = filter; // Passes the value to the in class variable
            this.orderCriteria = orderCriteria; // Passes the value to the in class variable
            tempList = new List<Game>(); // Initiates a new list that will serve as a temporary list
            FilterGames(); // Executes FilterGames()

            SortGames(); // Executes SortGames()
            
        }

        /// <summary>
        /// Filters the game list
        /// </summary>
        private void FilterGames() {
            List<Game> temp = new List<Game>(); // Creates a new list to temporarly hold instances of Game
            // Runs trough the dicionary passing every value into the temporary list
            foreach (KeyValuePair<string, Game> kvp in games) {
                temp.Add(kvp.Value); // Adds an instance of Game to the list
            }

            // Filters the game list using the filter parameters selecteb by the user
            IEnumerable<Game> filteredGame = temp.Where(game => (game.name.IndexOf(
                    filter.name, StringComparison.OrdinalIgnoreCase) >= 0 || filter.name == "") &&
                    (game.releaseDate >= filter.releaseDate || filter.releaseDate == null) &&
                    (game.requiredAge >= filter.requiredAge || filter.requiredAge == 0) &&
                    (game.metacritic >= filter.metacritic || filter.metacritic == 0) &&
                    (game.recommendationCount >= filter.recommendationCount || filter.recommendationCount == 0) &&
                    (game.controllerSupport || !filter.controllerSupport) &&
                    (game.platformWindows || !filter.platformWindows) &&
                    (game.platformLinux || !filter.platformLinux) &&
                    (game.platformMac || !filter.platformMac) &&
                    (game.categorySinglePlayer || !filter.categorySinglePlayer) &&
                    (game.categoryMultiplayer || !filter.categoryMultiplayer) &&
                    (game.categoryCoop || !filter.categoryCoop) &&
                    (game.categoryIncludeLevelEditor || !filter.categoryIncludeLevelEditor) &&
                    (game.categoryVRSupport || !filter.categoryVRSupport));

            // Passes the values from one list to an other
            foreach (Game g in filteredGame) {
                tempList.Add(g);
            }
        }

        /// <summary>
        /// Responsible for sorting all games acording to the selected sort method
        /// </summary>
        private void SortGames() {

            switch (orderCriteria) {

                case "ID":
                    tempList = tempList.OrderBy(game => game.id).ToList(); // Sorts by ID
                    break;

                case "nome":
                    tempList = tempList.OrderBy(game => game.name).ToList(); // Sorts by Name
                    break;

                case "data":
                    tempList = tempList.OrderByDescending(game => game.releaseDate).ToList(); // Sorts by the Release Date Descending
                    break;

                case "dlc":
                    tempList = tempList.OrderByDescending(game => game.dlcCount).ToList(); // Sorts by number of Dlc Descending
                    break;

                case "metacritic":
                    tempList = tempList.OrderByDescending(game => game.metacritic).ToList(); // Sorts by the metacritic score Descending
                    break;

                case "recomendacoes":
                    tempList = tempList.OrderByDescending(game => game.recommendationCount).ToList(); // Sorts by the number of recomendations Descending
                    break;

                case "nJogo":
                    tempList = tempList.OrderByDescending(game => game.owners).ToList(); // Sorts by number of Owners Descending
                    break;

                case "jJogo":
                    tempList = tempList.OrderByDescending(game => game.numberOfPlayers).ToList(); // Sorts by number of Players Descending
                    break; 

                case "achievements":
                    tempList = tempList.OrderByDescending(game => game.achievementCount).ToList(); // Sorts by numer of Achievements Descending
                    break;
            }

            // Passes all the values into the main list
            foreach (Game game in tempList) {
                Add(game);
            }
        }
    }
}
