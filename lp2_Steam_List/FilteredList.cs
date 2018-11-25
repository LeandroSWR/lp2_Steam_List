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
            foreach (Game game in temp) {
                IEnumerable<Game> filteredGame = temp.Where(Game => Game.Name == filter.Name);
                Add(filteredGame as Game);
            }
        }
    }
}
