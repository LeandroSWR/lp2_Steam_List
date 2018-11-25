using System;
using System.Collections.Generic;
using System.Linq;

namespace lp2_Steam_List {
    class FilteredList : List<Game> {

        private GameList games;
        private Filters filter;
        private List<Game> tempList;
        private string orderCriteria;

        public FilteredList(Filters filter, GameList games, string orderCriteria) {
            this.games = games;
            this.filter = filter;
            this.orderCriteria = orderCriteria;
            tempList = new List<Game>();
            FilterGames();

            SortGames();
            
        }

        private void FilterGames() {
            List<Game> temp = new List<Game>();
            foreach (KeyValuePair<string, Game> kvp in games) {
                temp.Add(kvp.Value);
            }

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

            foreach (Game g in filteredGame) {
                tempList.Add(g);
            }
        }

        private void SortGames() {

            switch (orderCriteria) {

                case "ID":
                    tempList = tempList.OrderBy(game => game.id).ToList();
                    break;

                case "nome":
                    tempList = tempList.OrderBy(game => game.name).ToList();
                    break;

                case "data":
                    tempList = tempList.OrderByDescending(game => game.releaseDate).ToList();
                    break;

                case "dlc":
                    tempList = tempList.OrderByDescending(game => game.dlcCount).ToList();
                    break;

                case "metacritic":
                    tempList = tempList.OrderByDescending(game => game.metacritic).ToList();
                    break;

                case "recomendacoes":
                    tempList = tempList.OrderByDescending(game => game.recommendationCount).ToList();
                    break;

                case "nJogo":
                    tempList = tempList.OrderByDescending(game => game.owners).ToList();
                    break;

                case "jJogo":
                    tempList = tempList.OrderByDescending(game => game.numberOfPlayers).ToList();
                    break;

                case "achievements":
                    tempList = tempList.OrderByDescending(game => game.achievementCount).ToList();
                    break;
            }

            foreach (Game game in tempList) {
                
                Add(game);
            }
        }
    }
}
