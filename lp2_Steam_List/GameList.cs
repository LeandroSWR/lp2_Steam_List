using System;
using System.Collections.Generic;
using System.IO;

namespace lp2_Steam_List {
    /// <summary>
    /// Class GameList functions a a Dictionary saving all the games from the selected file
    /// </summary>
    class GameList : Dictionary<string, Game> {

        /** \brief Defines the path of the file */
        string path;

        /** \brief The key of the Dictionary */
        readonly string key;

        /// <summary>
        /// GameList constructor
        /// </summary>
        /// <param name="key">game id</param>
        /// <param name="arg">list file path</param>
        public GameList(string key, string arg) {
            this.key = key; // Pass the key value to the in class variable
            path = arg; // Pass the  arg value to the in class variable
            FillDictionary(); // Calls the FillDictionary method
        }
        /// <summary>
        /// Reads the file line by line filing in the dictionary
        /// </summary>
        private void FillDictionary() {
            try { // Tries to do this
                using (StreamReader sr = new StreamReader(path)) { // Creates a new StreamReader
                    // Iniciates a new boolean to know if we're reading the first line
                    bool skipFirstLine = false; 
                    string s = ""; // Iniciates a new empty string
                    Game game; // Declares a new instance of Game
                    // While the line passed to the string s isn't null do something
                    while ((s = sr.ReadLine()) != null) {
                        string[] line = s.Split(','); // Parse the s string into an array

                        if (skipFirstLine) { // if skipFristLine is true we can start adding games

                            game = new Game(s); // Creates a new game passing it the s string
                            // Asks if the dictionary already contains the game we're trying to add
                            if (!ContainsKey(line[0])) { 
                                Add(line[0], game); // if it doesn't we can add the game to it
                            }
                        }
                        // Set skipFirstLine to true so we can add games to the dictionary
                        skipFirstLine = true; 
                        
                    }
                }
            }
            catch (Exception e){ // If it fails
                Console.WriteLine($"Error: {e.Message}"); // Display an error message
            }
        }
    }
}
