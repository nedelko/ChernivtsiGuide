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
        public SelectedPlacesPage(List<Place> places)
        {
            InitializeComponent();
            placesList.ItemsSource = places;
        }
    }
}