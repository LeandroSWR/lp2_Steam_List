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
                    filter.Name, StringComparison.OrdinalIgnoreCase) >= 0 || filter.Name == "") &&
                    (game.ReleaseDate >= filter.ReleaseDate || filter.ReleaseDate == null) &&
                    (game.RequiredAge >= filter.RequiredAge || filter.RequiredAge == 0) &&
                    (game.Metacritic >= filter.Metacritic || filter.Metacritic == 0) &&
                    (game.RecommendationCount >= filter.RecommendationCount || filter.RecommendationCount == 0) &&
                    (game.ControllerSupport || !filter.ControllerSupport) &&
                    (game.PlatformWindows || !filter.PlatformWindows) &&
                    (game.PlatformLinux || !filter.PlatformLinux) &&
                    (game.PlatformMac || !filter.PlatformMac) &&
                    (game.CategorySinglePlayer || !filter.CategorySinglePlayer) &&
                    (game.CategoryMultiplayer || !filter.CategoryMultiplayer) &&
                    (game.CategoryCoop || !filter.CategoryCoop) &&
                    (game.CategoryIncludeLevelEditor || !filter.CategoryIncludeLevelEditor) &&
                    (game.CategoryVRSupport || !filter.CategoryVRSupport));

            foreach (Game g in filteredGame) {
                Add(g);
            }
        }
    }
}
