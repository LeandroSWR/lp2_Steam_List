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
        private string id, orderCriteria;

        GameList list;
        Filters filters;
        FilteredList filteredList;

        public Display(string key, string[] arg) {

            this.key = key;
            list = new GameList(key, arg[0]);
            filters = new Filters();

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

            Console.WriteLine(" ________________________________________");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|  1. Especificar critério de ordenação  |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|  2. Especificar filtros de pesquisa    |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|  3. Realizar pesquisa                  |");
            Console.WriteLine("|                                        |");
            Console.WriteLine("|  4. Voltar atrás                       |");
            Console.WriteLine("|________________________________________|");

            SearchMenuSelection();
        }

        private void OrderCriteria() {
            Console.Clear();
            Console.WriteLine("Selecciona o critério de ordenação:\n");
            Console.WriteLine("1. Por ID (ascendente)\n" +
                "2. Por nome(ascendente, por ordem alfabética)\n" +
                "3. Por data de lançamento(descendente, do mais recente para o mais antigo)\n" +
                "4. Por número de DLCs(descendente)\n5. Por nota no Metacritic(descendente)\n" +
                "6. Por número de recomendações(descendente)\n" +
                "7. Por número de pessoas que têm o jogo(descendente)\n" +
                "8. Por número de pessoas que efetivamente jogaram ao jogo(descendente)\n" +
                "9. Por número de achievements(descendente)" + 
                
                "0. Back");

            CriteriaSelection();
        }

        private void GameFilters() {
            Console.Clear();
            Console.WriteLine("\n1. Por nome\n2. Por data\n3. Por idade\n" +
                "4. Por nota do Metacritic\n5. Por número de recomendações\n" +
                "6. Por suporte de controlador\n7. Por suporte para Windows\n" +
                "8. Por suporte para Linux\n9. Por suporte para Mac\n" +
                "10. Por suporte para singleplayer\n11. Por suporte para multiplayer\n" +
                "12. Por suporte para multiplayer cooperativo\n" +
                "13. Por inclusão de editor de níveis\n14. Por suporte para VR\n");
            Console.Write("0. Back");

            FilterSelection();
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
            DrawMenu();
        }

        private void SearchMenuSelection() {

            switch (Console.ReadLine()) {

                case "1":
                    OrderCriteria();
                    break;

                case "2":
                    GameFilters();

                    break;

                case "3":

                    filteredList = new FilteredList(filters, list);
                    
                    foreach(Game g in filteredList) {
                        if(g != null) {
                            Console.WriteLine(g.ToString());
                        }
                    }

                    break;

                case "4":

                    DrawMenu();
                    break;

                default:

                    DrawSearchMenu();
                    break;
            }
            SearchMenuSelection();
        }

        private void CriteriaSelection() {
            switch (Console.ReadLine()) {
                case "1":
                    orderCriteria = "ID";
                    break;
                case "2":
                    orderCriteria = "nome";
                    break;
                case "3":
                    orderCriteria = "data";
                    break;
                case "4":
                    orderCriteria = "dlc";
                    break;
                case "5":
                    orderCriteria = "metacritic";
                    break;
                case "6":
                    orderCriteria = "recomendacoes";
                    break;
                case "7":
                    orderCriteria = "nJogo";
                    break;
                case "8":
                    orderCriteria = "jJogo";
                    break;
                case "9":
                    orderCriteria = "achievements";
                    break;
                default:
                    CriteriaSelection();
                    break;
            }
        }

        private void FilterSelection() {
            switch (Console.ReadLine()) {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Intruduz o nome:");
                    filters.Name = Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Ex de data: (Nov 1 2000)");
                    Console.WriteLine("Introduz a data apartir da qual o jogo foi lançado:");
                    string date = Console.ReadLine();
                    DateTime.TryParse(date, out filters.ReleaseDate);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Introduz a idade apartir da qual o jogo pode se acedido:");
                    filters.RequiredAge = Convert.ToInt32(Console.ReadLine());
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Introduz a nota minima de metacritic:");
                    filters.Metacritic = Convert.ToInt32(Console.ReadLine());
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Introduz o numero minimo de recomendações:");
                    filters.RecommendationCount = Convert.ToInt32(Console.ReadLine());
                    break;
                case "6":
                    filters.ControllerSupport = true;
                    break;
                case "7":
                    filters.PlatformWindows = true;
                    break;
                case "8":
                    filters.PlatformLinux = true;
                    break;
                case "9":
                    filters.PlatformMac = true;
                    break;
                case "10":
                    filters.CategorySinglePlayer = true;
                    break;
                case "11":
                    filters.CategoryMultiplayer = true;
                    break;
                case "12":
                    filters.CategoryCoop = true;
                    break;
                case "13":
                    filters.CategoryIncludeLevelEditor = true;
                    break;
                case "14":
                    filters.CategoryVRSupport = true;
                    break;
                case "0":
                    DrawSearchMenu();
                    break;
                default:
                    CriteriaSelection();
                    break;
            }
            GameFilters();
        }

        private void DisplayInformation() {
            
            foreach (KeyValuePair<string, Game> kvp in list) {
                if (kvp.Key == id) {
                    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    DisplayImage(kvp.Value);
                    Console.ReadLine();
                }
            }
        }

        private void DisplayImage(Game game) {
            using (WebClient client = new WebClient()) {
                if (game.HeaderImage != null) {
                    client.DownloadFile(game.HeaderImage, @"C:\Users\Public\Desktop\" + game.ID + ".jpg");
                    Process.Start(@"C:\Users\Public\Desktop\" + game.ID + ".jpg");
                }
            }
        }
    }
}
