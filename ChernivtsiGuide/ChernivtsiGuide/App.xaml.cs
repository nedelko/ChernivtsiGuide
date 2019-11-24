using ChernivtsiGuide.Repositories;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChernivtsiGuide
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "che_guide.db";
        public static QuestionRepository question_rep;
        public static QuestionRepository questionRepository
        {
            get
            {
                if (question_rep == null)
                {
                    question_rep = new QuestionRepository(DATABASE_NAME);
                }
                return question_rep;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
