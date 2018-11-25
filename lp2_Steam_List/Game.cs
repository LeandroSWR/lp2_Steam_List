using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lp2_Steam_List {
    class Game {
        public int RequiredAge, DLCCount, Metacritic, MovieCount, RecommendationCount,
            ScreenshotCount, Owners, NumberOfPlayers, AchievementCount;
        public string Name, AboutText;
        public DateTime ReleaseDate;
        public bool ControllerSupport, PlatformWindows, PlatformLinux, PlatformMac, 
            CategorySinglePlayer, CategoryMultiplayer, CategoryCoop, 
            CategoryIncludeLevelEditor, CategoryVRSupport;
        Uri SupportURL, Website;
        public Uri HeaderImage;
        public int ID;

        public Game(string stream) {
            string[] parse = stream.Split(',');
            SaveData(parse);
        }

        private void SaveData(string[] parse) {
            ID = Convert.ToInt32(parse[0]);
            Name = parse[1];
            DateTime.TryParse(parse[2], out ReleaseDate);
            RequiredAge = Convert.ToInt32(parse[3]);
            DLCCount = Convert.ToInt32(parse[4]);
            Metacritic = Convert.ToInt32(parse[5]);
            MovieCount = Convert.ToInt32(parse[6]);
            RecommendationCount = Convert.ToInt32(parse[7]);
            ScreenshotCount = Convert.ToInt32(parse[8]);
            Owners = Convert.ToInt32(parse[9]);
            NumberOfPlayers = Convert.ToInt32(parse[10]);
            AchievementCount = Convert.ToInt32(parse[11]);
            ControllerSupport = Convert.ToBoolean(parse[12]);
            PlatformWindows = Convert.ToBoolean(parse[13]);
            PlatformLinux = Convert.ToBoolean(parse[14]);
            PlatformMac = Convert.ToBoolean(parse[15]);
            CategorySinglePlayer = Convert.ToBoolean(parse[16]);
            CategoryMultiplayer = Convert.ToBoolean(parse[17]);
            CategoryCoop = Convert.ToBoolean(parse[18]);
            CategoryIncludeLevelEditor = Convert.ToBoolean(parse[19]);
            CategoryVRSupport = Convert.ToBoolean(parse[20]);
            Uri.TryCreate(parse[21], UriKind.Absolute, out SupportURL);
            AboutText = parse[22];
            Uri.TryCreate(parse[23], UriKind.Absolute, out HeaderImage);
            Uri.TryCreate(parse[24], UriKind.Absolute, out Website);
        }

        public override string ToString() {
            return string.Format($"ID: {ID}\n Name: {Name}\n ReleaseDate: {ReleaseDate}\n " +
                $"RequiredAge: {RequiredAge}\n DLCCount: {DLCCount}\n Metacritic: {Metacritic}\n " +
                $"MovieCount: {MovieCount}\n RecommendationCount: {RecommendationCount}\n " +
                $"ScreenshotCount: {ScreenshotCount}\n Owners: {Owners}\n NumberOfPlayers: " +
                $"{NumberOfPlayers}\n AchievementCount: {AchievementCount}\n ControllerSupport: " +
                $"{ControllerSupport}\n PlatformWindows: {PlatformWindows}\n PlatformLinux: " +
                $"{PlatformLinux}\n PlatformMac: {PlatformMac}\n CategorySinglePlayer: " +
                $"{CategorySinglePlayer}\n CategoryMultiplayer: {CategoryMultiplayer}\n " +
                $"CategoryCoop: {CategoryCoop}\n CategoryIncludeLevelEditor: " +
                $"{CategoryIncludeLevelEditor}\n CategoryVRSupport: {CategoryVRSupport}\n " +
                $"SupportURL: {SupportURL}\n AboutText: {AboutText}\n HeaderImage: " +
                $"{HeaderImage}\n Website: {Website}");
        }
    }
}