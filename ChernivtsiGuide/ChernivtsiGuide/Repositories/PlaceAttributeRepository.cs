using ChernivtsiGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ChernivtsiGuide.Repositories
{
    public class PlaceAttributeRepository
    {
        SQLiteConnection database;
        public PlaceAttributeRepository(string filename)
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
        }
        public IEnumerable<Models.Attribute> GetAttributes(int place_type)
        {
            return database.Query<Models.Attribute>("SELECT DISTINCT attribute.attribute_code, attribute_name, attribute_question, attribute_rank FROM attribute INNER JOIN place_attribute ON attribute.attribute_code = place_attribute.attribute_code INNER JOIN place ON place.place_code = place_attribute.place_code WHERE place.place_type = ?", place_type);
        }
        public IEnumerable<Models.Attribute> GetAttributesWithCode(int placeType, int attributeCode)
        {
            return database.Query<Models.Attribute>("SELECT DISTINCT attribute.attribute_code, attribute_name, attribute_question, attribute_rank FROM attribute INNER JOIN place_attribute ON attribute.attribute_code = place_attribute.attribute_code INNER JOIN place ON place.place_code = place_attribute.place_code WHERE place.place_type = ? AND place_attribute.place_code IN (SELECT place_attribute.place_code FROM place_attribute INNER JOIN attribute ON place_attribute.attribute_code = attribute.attribute_code WHERE attribute.attribute_code = ?) AND attribute_rank = 2", placeType, attributeCode);
        }
    }
}
