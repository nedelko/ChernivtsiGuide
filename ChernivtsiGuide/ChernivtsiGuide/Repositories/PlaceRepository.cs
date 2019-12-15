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
        public IEnumerable<Place> GetPlaces(int place_type)
        {
            return database.Query<Place>("SELECT * FROM place WHERE place_type = ?", place_type);
        }
        public IEnumerable<Place> GetPlaces(int place_type, int attribute_code)
        {
            return database.Query<Place>("SELECT place.place_code, place_name, place.place_type, description, address, phone, open_time, close_time FROM place INNER JOIN place_attribute ON place.place_code = place_attribute.place_code WHERE place.place_type = ? AND place_attribute.attribute_code = ? ", place_type, attribute_code);
        }
        public IEnumerable<Place> GetPlaces(int place_type, int first_attribute_code, int second_attribute_code)
        {
            return database.Query<Place>("SELECT place.place_code, place_name, place.place_type, description, address, phone, open_time, close_time FROM place INNER JOIN place_attribute ON place.place_code = place_attribute.place_code WHERE place.place_type = ? AND place_attribute.attribute_code = ? INTERSECT SELECT place.place_code, place_name, place.place_type, description, address, phone, open_time, close_time FROM place INNER JOIN place_attribute ON place.place_code = place_attribute.place_code WHERE place.place_type = ? AND place_attribute.attribute_code = ? ", place_type, first_attribute_code, place_type, second_attribute_code);
        }
    }
}
