﻿using ChernivtsiGuide.Repositories;
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
        public static GeneralTypeRepository generaTypeRep;
        public static GeneralTypeRepository generalTypeRepository
        {
            get
            {
                if (generaTypeRep == null)
                {
                    generaTypeRep = new GeneralTypeRepository(DATABASE_NAME);
                }
                return generaTypeRep;
            }
        }
        public static PlaceTypeRepository placeTypeRep;
        public static PlaceTypeRepository placeTypeRepository
        {
            get
            {
                if (placeTypeRep == null)
                {
                    placeTypeRep = new PlaceTypeRepository(DATABASE_NAME);
                }
                return placeTypeRep;
            }
        }
        public static PlaceAttributeRepository placeAttributeRep;
        public static PlaceAttributeRepository placeAttributeRepository
        {
            get
            {
                if (placeAttributeRep == null)
                {
                    placeAttributeRep = new PlaceAttributeRepository(DATABASE_NAME);
                }
                return placeAttributeRep;
            }
        }
        public static PlaceRepository placeRep;
        public static PlaceRepository placeRepository
        {
            get
            {
                if (placeRep == null)
                {
                    placeRep = new PlaceRepository(DATABASE_NAME);
                }
                return placeRep;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
