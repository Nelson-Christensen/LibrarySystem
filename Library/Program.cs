using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using Library.Models;

namespace Library {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            // Set the DataDirectory (used in the connection-string) to be the executing app directory
            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
            // Recreate the database only if the models change
            Database.SetInitializer<LibraryContext>(
                new DropCreateDatabaseIfModelChanges<LibraryContext>());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LibraryForm());
        }
    }
}
