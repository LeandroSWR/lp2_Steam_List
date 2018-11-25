using System;
using System.Collections.Generic;
using System.Linq;

namespace lp2_Steam_List {
    class FilteredList : List<Game> {
        private GameList games;
        private Filters filter;

        public FilteredList(Filters filter, GameList games) {
            this.games = games;
            this.filter = filter;
            FilterGames();
        }

        private void FilterGames() {
            List<Game> temp = new List<Game>();
            foreach (KeyValuePair<string, Game> kvp in games) {
                temp.Add(kvp.Value);
            }


            IEnumerable<Game> filteredGame = temp.Where(game => (game.Name.IndexOf(
                    filter.name, StringComparison.OrdinalIgnoreCase) >= 0 || filter.name == "") &&
                    (game.ReleaseDate >= filter.releaseDate || filter.releaseDate == null) &&
                    (game.RequiredAge >= filter.requiredAge || filter.requiredAge == 0) &&
                    (game.Metacritic >= filter.metacritic || filter.metacritic == 0) &&
                    (game.RecommendationCount >= filter.recommendationCount || filter.recommendationCount == 0) &&
                    (game.ControllerSupport || !filter.controllerSupport) &&
                    (game.PlatformWindows || !filter.platformWindows) &&
                    (game.PlatformLinux || !filter.platformLinux) &&
                    (game.PlatformMac || !filter.platformMac) &&
                    (game.CategorySinglePlayer || !filter.categorySinglePlayer) &&
                    (game.CategoryMultiplayer || !filter.categoryMultiplayer) &&
                    (game.CategoryCoop || !filter.categoryCoop) &&
                    (game.CategoryIncludeLevelEditor || !filter.categoryIncludeLevelEditor) &&
                    (game.CategoryVRSupport || !filter.categoryVRSupport));

            foreach (Game g in filteredGame) {
                Add(g);
            }
        }
    }
}
