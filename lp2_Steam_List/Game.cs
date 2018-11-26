using System;

namespace lp2_Steam_List {
    /// <summary>
    /// Games contains all the information about a certain game
    /// </summary>
    class Game {

        public int id, requiredAge, dlcCount, metacritic, movieCount, recommendationCount,
            screenshotCount, owners, numberOfPlayers, achievementCount; // Declares all the necessary ints
        public string name, aboutText; // Declares all the necessary strings
        public DateTime releaseDate; // Declares all the necessary DateTimes
        public bool controllerSupport, platformWindows, platformLinux, platformMac, 
            categorySinglePlayer, categoryMultiplayer, categoryCoop, 
            categoryIncludeLevelEditor, categoryVRSupport; // Declares all the necessary bools
        public Uri supportURL, headerImage, website; // Declares all the necessary Uris

        /// <summary>
        /// Game costructor takes in a string argument
        /// </summary>
        /// <param name="stream">string contaning all the info about the game</param>
        public Game(string stream) {

            // Parses the string to later be saved into individuale variables
            string[] parse = stream.Split(',');

            // Calls SaveData() method passing in the pars string array
            SaveData(parse);
        }

        /// <summary>
        /// Makes use of the recieved array to save the correct data type into a specific variable
        /// </summary>
        /// <param name="parse">string array contaning all the info about the game</param>
        private void SaveData(string[] parse) {

            id = Convert.ToInt32(parse[0]); // Saves the parsed value into a int
            name = parse[1]; // Saves the parsed value into the variable
            DateTime.TryParse(parse[2], out releaseDate); // Tries to create a DateTime making use of a string
            requiredAge = Convert.ToInt32(parse[3]); // Saves the parsed value into a int
            dlcCount = Convert.ToInt32(parse[4]); // Saves the parsed value into a int
            metacritic = Convert.ToInt32(parse[5]); // Saves the parsed value into a int
            movieCount = Convert.ToInt32(parse[6]); // Saves the parsed value into a int
            recommendationCount = Convert.ToInt32(parse[7]); // Saves the parsed value into a int
            screenshotCount = Convert.ToInt32(parse[8]); // Saves the parsed value into a int
            owners = Convert.ToInt32(parse[9]); // Saves the parsed value into a int
            numberOfPlayers = Convert.ToInt32(parse[10]); // Saves the parsed value into a int
            achievementCount = Convert.ToInt32(parse[11]); // Saves the parsed value into a int
            controllerSupport = Convert.ToBoolean(parse[12]); // Saves the parsed value into the bool
            platformWindows = Convert.ToBoolean(parse[13]); // Saves the parsed value into the bool
            platformLinux = Convert.ToBoolean(parse[14]); // Saves the parsed value into the bool
            platformMac = Convert.ToBoolean(parse[15]); // Saves the parsed value into the bool
            categorySinglePlayer = Convert.ToBoolean(parse[16]); // Saves the parsed value into the bool
            categoryMultiplayer = Convert.ToBoolean(parse[17]); // Saves the parsed value into the bool
            categoryCoop = Convert.ToBoolean(parse[18]); // Saves the parsed value into the bool
            categoryIncludeLevelEditor = Convert.ToBoolean(parse[19]); // Saves the parsed value into the bool
            categoryVRSupport = Convert.ToBoolean(parse[20]); // Saves the parsed value into the bool
            Uri.TryCreate(parse[21], UriKind.Absolute, out supportURL); // Tries to create a Uri making use of a string
            aboutText = parse[22]; // Saves the parsed value into the string
            Uri.TryCreate(parse[23], UriKind.Absolute, out headerImage);// Tries to create a Uri making use of a string
            Uri.TryCreate(parse[24], UriKind.Absolute, out website);// Tries to create a Uri making use of a string
        }

        /// <summary>
        /// Overide the ToString() method to print a formated string specifying all the info about the game
        /// </summary>
        /// <returns>Returns all the info</returns>
        public override string ToString() {

            // The Message itself
            return string.Format($"ID: {id}\nName: {name}\n" +
                $"ReleaseDate: {releaseDate.ToString("dd/MM/yyyy")}\nRequiredAge: {requiredAge}" +
                $"\nDLCCount: {dlcCount}\nMetacritic: {metacritic}\nMovieCount: {movieCount}\n" +
                $"RecommendationCount: {recommendationCount}\nScreenshotCount: {screenshotCount}" +
                $"\nOwners: {owners}\nNumberOfPlayers: {numberOfPlayers}\n" +
                $"AchievementCount: {achievementCount}\nControllerSupport: {controllerSupport}\n" +
                $"PlatformWindows: {platformWindows}\nPlatformLinux: {platformLinux}\n" +
                $"PlatformMac: {platformMac}\nCategorySinglePlayer: {categorySinglePlayer}\n" +
                $"CategoryMultiplayer: {categoryMultiplayer}\nCategoryCoop: {categoryCoop}\n" +
                $"CategoryIncludeLevelEditor: {categoryIncludeLevelEditor}\n" +
                $"CategoryVRSupport: {categoryVRSupport}\nSupportURL: {supportURL}\n" +
                $"AboutText: {aboutText}\nHeaderImage: {headerImage}\nWebsite: {website}");
        }
    }
}