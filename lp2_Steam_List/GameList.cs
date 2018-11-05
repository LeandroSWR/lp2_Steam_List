﻿using System;
using System.Collections.Generic;
using System.IO;

namespace lp2_Steam_List {
    class GameList : Dictionary<string, Game> {
        static string path;
        string key;

        public GameList(string key, string[] arg) {
            this.key = key;
            path = arg[0];
            FillDictionary();
        }

        public GameList(string key) {

        }

        private void FillDictionary() {
            try {
                using (StreamReader sr = new StreamReader(path)) {
                    string s = "";
                    Game game;
                    int nKey = -1;

                    while ((s = sr.ReadLine()) != null) {
                        string[] line = s.Split(',');

                        // Set a dinamic key, acording to the search parameters
                        if (nKey == -1) {
                            for (int i = 0; i < line.Length; i++) {
                                if (line[i] == key) {
                                    nKey = i;
                                }
                            }
                        }

                        game = new Game(s);

                        if (!ContainsKey(line[nKey])) {
                            Add(line[nKey], game);
                        }
                    }
                }
            }
            catch {
                Console.WriteLine("Could not read the file.");
            }
        }
    }
}