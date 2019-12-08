using ChernivtsiGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ChernivtsiGuide.Repositories
{
    public class PlaceTypeRepository
    {
        SQLiteConnection database;
        public PlaceTypeRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
        }
        public IEnumerable<Place_type> GetItemsById(int id)
        {
            return database.Query<Place_type>("SELECT * FROM place_type WHERE general_type = ?", id);
        }
    }
}
