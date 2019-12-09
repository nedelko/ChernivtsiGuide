using ChernivtsiGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ChernivtsiGuide.Repositories
{
    public class PlaceRepository
    {
        SQLiteConnection database;
        public PlaceRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
        }
        public IEnumerable<Place> GetPlaces(int id)
        {
            return database.Query<Place>("SELECT * FROM place_type WHERE general_type = ?", id);
        }
    }
}
