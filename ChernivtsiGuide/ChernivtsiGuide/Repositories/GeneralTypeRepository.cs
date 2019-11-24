using ChernivtsiGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ChernivtsiGuide.Repositories
{
    public class GeneralTypeRepository
    {
        SQLiteConnection database;
        public GeneralTypeRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
        }
        public IEnumerable<General_type> GetItems()
        {
            return (from i in database.Table<General_type>() select i).ToList();

        }
    }
}
