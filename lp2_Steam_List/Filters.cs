using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lp2_Steam_List {
    class Filters {
        public int requiredAge, metacritic, recommendationCount;
        public string name = "";
        public DateTime releaseDate;
        public bool controllerSupport, platformWindows, platformLinux, platformMac,
            categorySinglePlayer, categoryMultiplayer, categoryCoop,
            categoryIncludeLevelEditor, categoryVRSupport;

        public Filters() { }
    }
}