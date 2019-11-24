using ChernivtsiGuide.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ChernivtsiGuide.Repositories
{
    public class QuestionRepository
    {
        SQLiteConnection database;
        public QuestionRepository(string filename) {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
            database = new SQLiteConnection(databasePath);
        }
        public Question GetQuestion(int id) {
            return database.Get<Question>(id);
        }
    }
}
