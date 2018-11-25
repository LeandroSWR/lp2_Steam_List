using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lp2_Steam_List {
    class Game {

        public int id, requiredAge, dlcCount, metacritic, movieCount, recommendationCount,
            screenshotCount, owners, numberOfPlayers, achievementCount;
        public string name, aboutText;
        public DateTime releaseDate;
        public bool controllerSupport, platformWindows, platformLinux, platformMac, 
            categorySinglePlayer, categoryMultiplayer, categoryCoop, 
            categoryIncludeLevelEditor, categoryVRSupport;
        public Uri supportURL, headerImage, website;

        public Game(string stream) {

            string[] parse = stream.Split(',');
            SaveData(parse);
        }

        private void SaveData(string[] parse) {

            id = Convert.ToInt32(parse[0]);
            name = parse[1];
            DateTime.TryParse(parse[2], out releaseDate);
            requiredAge = Convert.ToInt32(parse[3]);
            dlcCount = Convert.ToInt32(parse[4]);
            metacritic = Convert.ToInt32(parse[5]);
            movieCount = Convert.ToInt32(parse[6]);
            recommendationCount = Convert.ToInt32(parse[7]);
            screenshotCount = Convert.ToInt32(parse[8]);
            owners = Convert.ToInt32(parse[9]);
            numberOfPlayers = Convert.ToInt32(parse[10]);
            achievementCount = Convert.ToInt32(parse[11]);
            controllerSupport = Convert.ToBoolean(parse[12]);
            platformWindows = Convert.ToBoolean(parse[13]);
            platformLinux = Convert.ToBoolean(parse[14]);
            platformMac = Convert.ToBoolean(parse[15]);
            categorySinglePlayer = Convert.ToBoolean(parse[16]);
            categoryMultiplayer = Convert.ToBoolean(parse[17]);
            categoryCoop = Convert.ToBoolean(parse[18]);
            categoryIncludeLevelEditor = Convert.ToBoolean(parse[19]);
            categoryVRSupport = Convert.ToBoolean(parse[20]);
            Uri.TryCreate(parse[21], UriKind.Absolute, out supportURL);
            aboutText = parse[22];
            Uri.TryCreate(parse[23], UriKind.Absolute, out headerImage);
            Uri.TryCreate(parse[24], UriKind.Absolute, out website);
        }

        public override string ToString() {
            return string.Format($"ID: {id}\nName: {name}\nReleaseDate: {releaseDate}\n" +
                $"RequiredAge: {requiredAge}\nDLCCount: {dlcCount}\nMetacritic: {metacritic}\n" +
                $"MovieCount: {movieCount}\nRecommendationCount: {recommendationCount}\n" +
                $"ScreenshotCount: {screenshotCount}\nOwners: {owners}\nNumberOfPlayers: " +
                $"{numberOfPlayers}\nAchievementCount: {achievementCount}\nControllerSupport: " +
                $"{controllerSupport}\nPlatformWindows: {platformWindows}\nPlatformLinux: " +
                $"{platformLinux}\nPlatformMac: {platformMac}\nCategorySinglePlayer: " +
                $"{categorySinglePlayer}\nCategoryMultiplayer: {categoryMultiplayer}\n" +
                $"CategoryCoop: {categoryCoop}\nCategoryIncludeLevelEditor: " +
                $"{categoryIncludeLevelEditor}\nCategoryVRSupport: {categoryVRSupport}\n" +
                $"SupportURL: {supportURL}\nAboutText: {aboutText}\nHeaderImage: " +
                $"{headerImage}\nWebsite: {website}");
        }
    }
}