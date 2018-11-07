using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lp2_Steam_List {
    class Program {

        private static string DefaultKey { get; } = "ID";
        
        static void Main(string[] args) {

            Display myDisplay = new Display(DefaultKey, args);
        }
    }
}
