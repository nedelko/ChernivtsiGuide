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
        public List<PlaceImages> GetPlaces(int place_type)
        {
            List<Place> places = database.Query<Place>("SELECT * FROM place WHERE place_type = ?", place_type).ToList();
            var images = (from i in database.Table<Photo>() select i).ToList();
            return GetPlacesWithImages(places, images);
        }
        public List<PlaceImages> GetPlaces(int place_type, int attribute_code)
        {
            List<Place> places = database.Query<Place>("SELECT place.place_code, place_name, place.place_type, description, address, phone, open_time, close_time FROM place INNER JOIN place_attribute ON place.place_code = place_attribute.place_code WHERE place.place_type = ? AND place_attribute.attribute_code = ? ", place_type, attribute_code);
            var images = (from i in database.Table<Photo>() select i).ToList();
            return GetPlacesWithImages(places, images);
        }
        public List<PlaceImages> GetPlaces(int place_type, int first_attribute_code, int second_attribute_code)
        {
            List<Place> places = database.Query<Place>("SELECT place.place_code, place_name, place.place_type, description, address, phone, open_time, close_time FROM place INNER JOIN place_attribute ON place.place_code = place_attribute.place_code WHERE place.place_type = ? AND place_attribute.attribute_code = ? INTERSECT SELECT place.place_code, place_name, place.place_type, description, address, phone, open_time, close_time FROM place INNER JOIN place_attribute ON place.place_code = place_attribute.place_code WHERE place.place_type = ? AND place_attribute.attribute_code = ? ", place_type, first_attribute_code, place_type, second_attribute_code);
            var images = (from i in database.Table<Photo>() select i).ToList();
            return GetPlacesWithImages(places, images);
        }
        private static List<PlaceImages> GetPlacesWithImages(List<Place> places, List<Photo> images) {
            List<PlaceImages> placeImages = new List<PlaceImages>();
            foreach (Place place in places)
            {
                List<string> photos = new List<string>();
                foreach (Photo photo in images)
                {
                    if (photo.Place_code == place.Place_code)
                    {
                        photos.Add(photo.Image_url);
                    }
                }
                placeImages.Add(new PlaceImages
                {
                    Place_code = place.Place_code,
                    Place_name = place.Place_name,
                    Place_type = place.Place_type,
                    Description = place.Description,
                    Address = place.Address,
                    Phone = place.Phone,
                    Open_time = place.Open_time,
                    Close_time = place.Close_time,
                    images = photos
                });
            }
            return placeImages;
        }
    }
}
