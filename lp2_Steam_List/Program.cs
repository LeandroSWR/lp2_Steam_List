﻿namespace lp2_Steam_List {

    /// <summary>
    /// The program starts here
    /// </summary>
    class Program {

        /** \brief The first key to ever be used by the dictionary */
        private static string DefaultKey { get; } = "ID";

        /// <summary>
        /// The Main method from the Program Class
        /// </summary>
        /// <param name="args">Arguments accepted by the console</param>
        static void Main(string[] args) {

            // Creates an instance of the Display class
            Display myDisplay = new Display(DefaultKey, args);
        }
    }
}
