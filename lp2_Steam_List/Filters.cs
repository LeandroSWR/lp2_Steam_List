using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lp2_Steam_List {
    class Filters {
        public int RequiredAge, Metacritic, RecommendationCount;
        public string Name;
        public DateTime ReleaseDate;
        public bool ControllerSupport, PlatformWindows, PlatformLinux, PlatformMac,
            CategorySinglePlayer, CategoryMultiplayer, CategoryCoop,
            CategoryIncludeLevelEditor, CategoryVRSupport;

        public Filters() { }
    }
}