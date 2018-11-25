using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lp2_Steam_List {
    class Display {

        private readonly string key;
        private string id;

        GameList list;

        public Display(string key, string[] arg) {

            this.key = key;
            list = new GameList(key, arg[0]);

            DrawMenu();
        }

        private void DrawMenu() {

            //Console.Clear();

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

        private void DrawSearchMenu() {

            Console.Clear();

            Console.WriteLine(" _________________________________");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  1. Mostrar Informação do Jogo  |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  2. Efetuar uma pesquisa        |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  3. Sair                        |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  4. Anterior                    |");
            Console.WriteLine("|_________________________________|");

            Selection();
        }

        private void Selection() {

            switch (Console.ReadLine()) {

                case "1":
                    Console.WriteLine("Input game ID:");
                    id = Console.ReadLine();
                    DisplayInformation();
                    break;

                case "2":
                    DrawSearchMenu();

                    break;

                case "3":

                    Environment.Exit(0);
                    break;

                default:

                    DrawMenu();
                    break;
            }
        }

        private void DisplayInformation() {
            
            foreach (KeyValuePair<string, Game> kvp in list) {
                if (kvp.Key == id) {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    DisplayImage(kvp.Value);                }
            }
        }

        private void DisplayImage(Game game) {
            using (WebClient client = new WebClient()) {
                if (game.HeaderImage != null) {
                    client.DownloadFile(game.HeaderImage, @"C:\Users\Shadow\Desktop\" + game.ID + ".jpg");
                    Process.Start(@"C:\Users\Shadow\Desktop\" + game.ID + ".jpg");
                }
            }
        }
    }
}
