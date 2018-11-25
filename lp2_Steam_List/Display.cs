using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lp2_Steam_List {

    /// <summary>
    /// This Class is responsible for most drawings present on the program
    /// </summary>
    class Display {

        private readonly string key;       // The key attributed to the dictionary
        private string id, orderCriteria;  // The ID given to a game on the file and the criteria from which they will be ordered
        private int currentPage = 0;       // The currently selected page that shows info about a game

        // A few Class derived variables to be instanced later on
        private GameList list;
        private Filters filters;
        private FilteredList filteredList;
        private Game[] filteredGameDisplay;

        /// <summary>
        /// The Class Constructor
        /// </summary>
        /// <param name="key">The key belonging to the dictionary</param>
        /// <param name="arg">Arguments accepted by the console</param>
        public Display(string key, string[] arg) {
            
            this.key = key;                     // The key this method accepts is the one above it
            list = new GameList(key, arg[0]);   // Instantiates a list of games 
            filters = new Filters();            // Instantiates the filters from the searches

            // Calls the method to draw the Menu
            DrawMenu();
        }

        /// <summary>
        /// Draws the Menu
        /// </summary>
        private void DrawMenu() {

            // Clears the Console
            Console.Clear();

            // WriteLines that print the Menu
            Console.WriteLine(" _________________________________");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  1. Mostrar Informação do Jogo  |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  2. Efetuar uma pesquisa        |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|  3. Sair                        |");
            Console.WriteLine("|_________________________________|");

            // Calls the Selection method which waits for input
            Selection();
        }

        /// <summary>
        /// Draws the Search Menu
        /// </summary>
        private void DrawSearchMenu() {

            // Clears the Console
            Console.Clear();

            // WriteLines that print the Search Menu
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

            // Calls the SearchMenuSelection method which waits for input
            SearchMenuSelection();
        }

        /// <summary>
        /// Draws the parameters responsible for ordering the games
        /// </summary>
        private void OrderCriteria() {

            // Clears the Console
            Console.Clear();

            // WriteLines that print the ordering parameters
            Console.WriteLine("Selecciona o critério de ordenação:\n");
            Console.WriteLine("1. Por ID (ascendente)\n" +
                "2. Por nome(ascendente, por ordem alfabética)\n" +
                "3. Por data de lançamento(descendente, do mais recente para o mais antigo)\n" +
                "4. Por número de DLCs(descendente)\n5. Por nota no Metacritic(descendente)\n" +
                "6. Por número de recomendações(descendente)\n" +
                "7. Por número de pessoas que têm o jogo(descendente)\n" +
                "8. Por número de pessoas que efetivamente jogaram ao jogo(descendente)\n" +
                "9. Por número de achievements(descendente)\n" + 
                
                "\n0. Back");

            // Calls the CriteriaSelection method which waits for input
            CriteriaSelection();
        }

        /// <summary>
        /// Draws the parameters responsible for filtering the games
        /// </summary>
        private void GameFilters() {

            // Clears the Console
            Console.Clear();

            // WriteLines that print the filtering parameters
            Console.WriteLine("\n1. Por nome\n2. Por data\n3. Por idade\n" +
                "4. Por nota do Metacritic\n5. Por número de recomendações\n" +
                "6. Por suporte de controlador\n7. Por suporte para Windows\n" +
                "8. Por suporte para Linux\n9. Por suporte para Mac\n" +
                "10. Por suporte para singleplayer\n11. Por suporte para multiplayer\n" +
                "12. Por suporte para multiplayer cooperativo\n" +
                "13. Por inclusão de editor de níveis\n14. Por suporte para VR\n");
            Console.Write("0. Back");

            // Calls the FilterSelection method which waits for input
            FilterSelection();
        }

        /// <summary>
        /// Defines each game as a 'page' that can be viewed like a book
        /// </summary>
        private void GamePage() {

            // Initiates a previously established array with the size of the List of filters selected
            filteredGameDisplay = new Game[filteredList.Count];

            // Simple local variable that gets later incremented
            int i = 0;
            
            foreach (Game g in filteredList) {

                if (g != null) {

                    filteredGameDisplay[i] = g;
                    i++;
                }
            }

            // Calls the PageSelection method which waits for input
            PageSelection();
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

                    filteredList = new FilteredList(filters, list, orderCriteria);

                    GamePage();

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
                case "0":
                    DrawSearchMenu();
                    break;
                default:
                    CriteriaSelection();
                    break;
            }
            DrawSearchMenu();
        }

        private void FilterSelection() {
            switch (Console.ReadLine()) {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Intruduz o nome:");
                    filters.name = Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Ex de data: (Nov 1 2000)");
                    Console.WriteLine("Introduz a data apartir da qual o jogo foi lançado:");
                    string date = Console.ReadLine();
                    DateTime.TryParse(date, out filters.releaseDate);
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Introduz a idade apartir da qual o jogo pode se acedido:");
                    filters.requiredAge = Convert.ToInt32(Console.ReadLine());
                    break;
                case "4":
                    Console.Clear();
                    Console.WriteLine("Introduz a nota minima de metacritic:");
                    filters.metacritic = Convert.ToInt32(Console.ReadLine());
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Introduz o numero minimo de recomendações:");
                    filters.recommendationCount = Convert.ToInt32(Console.ReadLine());
                    break;
                case "6":
                    filters.controllerSupport = true;
                    break;
                case "7":
                    filters.platformWindows = true;
                    break;
                case "8":
                    filters.platformLinux = true;
                    break;
                case "9":
                    filters.platformMac = true;
                    break;
                case "10":
                    filters.categorySinglePlayer = true;
                    break;
                case "11":
                    filters.categoryMultiplayer = true;
                    break;
                case "12":
                    filters.categoryCoop = true;
                    break;
                case "13":
                    filters.categoryIncludeLevelEditor = true;
                    break;
                case "14":
                    filters.categoryVRSupport = true;
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

        private void PageSelection() {

            Console.Clear();

            Console.WriteLine(filteredGameDisplay[currentPage].ToString() + "\n");

            Console.WriteLine($"Left Arrow - Go Back  | {currentPage} - " +
                $"{filteredGameDisplay.Length - 1} |  Right Arrow - Go Forward\n");
            Console.WriteLine("Esc + Enter para sair.");

            switch (Console.ReadKey().Key) {

                case ConsoleKey.LeftArrow:

                    if (currentPage != 0) {

                        currentPage--;
                    }

                    break;

                case ConsoleKey.RightArrow:

                    if(currentPage < filteredGameDisplay.Length - 1) {

                        currentPage++;
                    }

                    break;

                case ConsoleKey.Escape:

                    return;

                default:

                    PageSelection();
                    break;
            }

            PageSelection();
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

            string imagePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (WebClient client = new WebClient()) {
                if (game.headerImage != null) {
                    client.DownloadFile(game.headerImage, imagePath + game.id + ".jpg");
                    Process.Start(imagePath + game.id + ".jpg");
                }
            }
        }
    }
}
