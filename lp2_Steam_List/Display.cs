using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

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
            
            // Foreach loop that adds a given filter to a game...
            foreach (Game g in filteredList) {

                // ...if that game exists in the list
                if (g != null) {

                    filteredGameDisplay[i] = g;
                    i++;
                }
            }

            // Calls the PageSelection method which waits for input
            PageSelection();
        }

        /// <summary>
        /// Method that reads the user's input on the Menu 
        /// </summary>
        private void Selection() {

            // Reads the input
            switch (Console.ReadLine()) {

                // Asks for an ID and shows the corresponding game
                case "1":

                    Console.Clear();
                    Console.WriteLine("Input game ID:");
                    id = Console.ReadLine();
                    DisplayInformation();
                    break;

                // Draws the SearchMenu
                case "2":

                    DrawSearchMenu();
                    break;

                // Closes the Console
                case "3":

                    Environment.Exit(0);
                    break;
                    
                // Draws the Menu if the input is incorrect
                default:

                    DrawMenu();
                    break;
            }

            // Draws the Menu
            DrawMenu();
        }

        /// <summary>
        /// Method that reads the user's input on the SearchMenu
        /// </summary>
        private void SearchMenuSelection() {

            switch (Console.ReadLine()) {

                // Draws the 'CriteriaMenu'
                case "1":

                    OrderCriteria();
                    break;

                // Draws the 'FiltersMenu'
                case "2":

                    GameFilters();
                    break;

                // Initiates the filter by taking in previously set parameters
                case "3":

                    filteredList = new FilteredList(filters, list, orderCriteria);
                    GamePage();
                    break;

                // Draws the Menu
                case "4":

                    DrawMenu();
                    break;

                // Draws the SearchMenu
                default:

                    DrawSearchMenu();
                    break;
            }

            // The method calls itself after exiting the 'switch'
            SearchMenuSelection();
        }

        /// <summary>
        /// Method that reads the user's input on the 'CriteriaMenu'
        /// </summary>
        private void CriteriaSelection() {

            switch (Console.ReadLine()) {

                // Sort by ID (ascending)
                case "1":
                    orderCriteria = "ID";
                    break;

                // Sort by Name (ascending)
                case "2":
                    orderCriteria = "nome";
                    break;

                // Sort by Date (descending)
                case "3":
                    orderCriteria = "data";
                    break;

                // Sort by DLC Count (descending)
                case "4":
                    orderCriteria = "dlc";
                    break;

                // Sort by MetaCritic Score (descending)
                case "5":
                    orderCriteria = "metacritic";
                    break;

                // Sort by Recommendations Count (descending)
                case "6":
                    orderCriteria = "recomendacoes";
                    break;

                // Sort by number of Owners (descending)
                case "7":
                    orderCriteria = "nJogo";
                    break;

                // Sort by number of Players (descending)
                case "8":
                    orderCriteria = "jJogo";
                    break;

                // Sort by number of Achievements (descending)
                case "9":
                    orderCriteria = "achievements";
                    break;

                // Goes back to the SearchMenu
                case "0":
                    DrawSearchMenu();
                    break;

                // Draws the CriteriaMenu if the input is incorrect
                default:
                    CriteriaSelection();
                    break;
            }

            // Draws the SearchMenu
            DrawSearchMenu();
        }

        /// <summary>
        /// Method that reads the user's input on the 'FiltersMenu' 
        /// </summary>
        private void FilterSelection() {
            // Reads the user input
            switch (Console.ReadLine()) {
                // Asks fot the name
                case "1":
                    Console.Clear();
                    Console.WriteLine("Intruduz o nome:");
                    filters.name = Console.ReadLine();
                    break;
                // Asks for the date
                case "2":
                    Console.Clear();
                    Console.WriteLine("Ex de data: (Nov 1 2000)");
                    Console.WriteLine("Introduz a data apartir da qual o jogo foi lançado:");
                    string date = Console.ReadLine();
                    DateTime.TryParse(date, out filters.releaseDate);
                    break;
                // Asks for the age
                case "3":
                    Console.Clear();
                    Console.WriteLine("Introduz a idade apartir da qual o jogo pode se acedido:");
                    filters.requiredAge = Convert.ToInt32(Console.ReadLine());
                    break;
                // Asks for the minimum metacritic score
                case "4":
                    Console.Clear();
                    Console.WriteLine("Introduz a nota minima de metacritic:");
                    filters.metacritic = Convert.ToInt32(Console.ReadLine());
                    break;
                // Asks for the minumum number of recomendations
                case "5":
                    Console.Clear();
                    Console.WriteLine("Introduz o numero minimo de recomendações:");
                    filters.recommendationCount = Convert.ToInt32(Console.ReadLine());
                    break;
                // Sets the controllerSupport filter to true
                case "6":
                    filters.controllerSupport = true;
                    break;
                // Sets the platformWindows filter to true
                case "7":
                    filters.platformWindows = true;
                    break;
                // Sets the platformLinux filter to true
                case "8":
                    filters.platformLinux = true;
                    break;
                // Sets the platformMac filter to true
                case "9":
                    filters.platformMac = true;
                    break;
                // Sets the categorySinglePlayer filter to true
                case "10":
                    filters.categorySinglePlayer = true;
                    break;
                // Sets the categoryMultiplayer filter to true
                case "11":
                    filters.categoryMultiplayer = true;
                    break;
                // Sets the categoryCoop filter to true
                case "12":
                    filters.categoryCoop = true;
                    break;
                // Sets the categoryIncludeLevelEditor filter to true
                case "13":
                    filters.categoryIncludeLevelEditor = true;
                    break;
                // Sets the categoryVRSupport filter to true
                case "14":
                    filters.categoryVRSupport = true;
                    break;
                // Calls the DrawSearchMenu method
                case "0":
                    DrawSearchMenu();
                    break;
                    // Calls the CriteriaSelection method
                default:
                    CriteriaSelection();
                    break;
            }
            // Goes back to the Game Filter selection
            GameFilters();
        }

        /// <summary>
        /// Method responsible for the slection of the games' pages
        /// </summary>
        private void PageSelection() {

            // Clears the Console
            Console.Clear();
            // Displays the currently selected game information
            Console.WriteLine(filteredGameDisplay[currentPage].ToString() + "\n");
            // Displays a information bar letting the user know the current page
            Console.WriteLine($"Left Arrow - Go Back  | {currentPage} - " +
                $"{filteredGameDisplay.Length - 1} |  Right Arrow - Go Forward\n");
            Console.WriteLine("Esc + Enter para sair."); // Displays info on how to go back
            // Reads the user input
            switch (Console.ReadKey().Key) {
                // Asks if the input was the left arrow
                case ConsoleKey.LeftArrow:
                    // Asks if the current page is not 0
                    if (currentPage != 0) {
                        // if it's not 0 decreasses the value by 1
                        currentPage--;
                    }

                    break;
                // Asks if the input was the right arrow
                case ConsoleKey.RightArrow:
                    // Asks if the current page number is lower than the array size
                    if (currentPage < filteredGameDisplay.Length - 1) {
                        // if it's not increasses the value by 1
                        currentPage++;
                    }

                    break;
                    // Asks if the input was the Esc kry
                case ConsoleKey.Escape:
                    // If it was return
                    return;

                default:
                    // The default rebots the method in case there was a wrong input
                    PageSelection();
                    break;
            }
            // After switching the page we rebot the method to way for the next input
            PageSelection();
        }
        /// <summary>
        /// Displays a Game information
        /// </summary>
        private void DisplayInformation() {
            // Goes throught the dictionary searching for the selected key by the user
            foreach (KeyValuePair<string, Game> kvp in list) {
                // Asks if the current game key is equal to the one we're searching for
                if (kvp.Key == id) {
                    // If it is we clear the console
                    Console.Clear();
                    Console.WriteLine(kvp.Value.ToString()); // Displays the game information
                    DisplayImage(kvp.Value); // Call a method to download and open the header image
                    Console.ReadLine(); // Awaits for a user input to continue
                }
            }
        }
        /// <summary>
        /// Responsible for downloading and opening the header image for a determined game
        /// </summary>
        /// <param name="game">Current Game</param>
        private void DisplayImage(Game game) {
            // Set the default path to be the users Desktop
            string imagePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            // Create a new WebClient
            using (WebClient client = new WebClient()) {
                // Verify the the selected game does have a header image
                if (game.headerImage != null) {
                    // If so Download the image to the Desktop
                    client.DownloadFile(game.headerImage, $"{imagePath}{game.id}.jpg");
                    Process.Start($"{imagePath}{game.id}.jpg"); // Opens the downloaded image
                }
            }
        }
    }
}
