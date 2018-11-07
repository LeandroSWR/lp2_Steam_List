using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lp2_Steam_List {
    class Display {

        private readonly string key, arg;

        GameList list;

        public Display(string key, string[] arg) {

            this.key = key;
            this.arg = arg[0];

            DrawMenu();
        }

        private void DrawMenu() {

            Console.Clear();

            Console.WriteLine(" _________________________________");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  1. Mostrar Informação do Jogo  |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  2. Efetuar uma pesquisa        |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  3. Sair                        |");
            Console.WriteLine("|_________________________________|");

            Selection();
        }

        private void Selection() {

            switch (Console.ReadLine()) {

                case "1":

                    list = new GameList(key, arg);
                    break;

                case "2":


                    break;

                case "3":

                    Environment.Exit(0);
                    break;

                default:

                    DrawMenu();
                    break;
            }
        }
    }
}
