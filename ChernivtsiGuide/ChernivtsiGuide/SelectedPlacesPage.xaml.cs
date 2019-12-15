using ChernivtsiGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChernivtsiGuide
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedPlacesPage : ContentPage
    {
        public SelectedPlacesPage(List<PlaceImages> places)
        {
            InitializeComponent();
            placesList.ItemsSource = places;
        }

        public void TapGestureRecognizer_MapsTapped(object sender, EventArgs e)
        {
            Label lblClicked = (Label)sender;
            string txt = lblClicked.ClassId;
            txt = txt.Replace(",", "");
            txt = txt.Replace(".", "");
            txt = txt.Replace(" ", "+");
            Device.OpenUri(new Uri("https://www.google.com.ua/maps/place/" + txt));
        }
    }
}