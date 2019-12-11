using ChernivtsiGuide.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;

namespace ChernivtsiGuide
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        static Label placeTypeLabel = new Label();
        static ScrollView placeTypeScrollView = new ScrollView();
        static Label placeAttribute1Label = new Label();
        static ScrollView placeAttribute1ScrollView = new ScrollView();
        static Label placeAttribute2Label = new Label();
        static ScrollView placeAttribute2ScrollView = new ScrollView();
        static Button confirmButton = new Button() { Text = "СФОРМУВАТИ СПИСОК", HorizontalOptions = LayoutOptions.FillAndExpand, IsVisible = false };

        static int placeTypeSelected;

        public MainPage()
        {
            this.Resources.Add(StyleSheet.FromAssemblyResource
                (IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly,
            "ChernivtsiGuide.mystyles.css"));

            Question generalQuestion = App.questionRepository.GetQuestion(1);
            Label generalQuestionLebel = new Label() { Text = generalQuestion.Question_content };

            IEnumerable<General_type> general_Types = App.generalTypeRepository.GetItems();
            StackLayout generalTypesStack = new StackLayout();
            foreach (General_type general_Type in general_Types)
            {
                Button generalButton = new Button() { Text = general_Type.General_name, WidthRequest = 200, HeightRequest = 50 };
                generalButton.Clicked += delegate { OnGeneralButtonClicked(general_Type.General_id, general_Type.General_question); };
                Image generalImage = new Image { Source = general_Type.General_type_logo };
                StackLayout generalImageButton = new StackLayout();
                generalImageButton.Children.Add(generalButton);
                generalImageButton.Children.Add(generalImage);
                generalTypesStack.Children.Add(generalImageButton);
            }
            generalTypesStack.Orientation = StackOrientation.Horizontal;

            ScrollView generalTypeScrollView = new ScrollView()
            {
                Content = generalTypesStack,
                Orientation = ScrollOrientation.Horizontal,
            };

            StackLayout confirmStackLayout = new StackLayout() {
                Children = { confirmButton }
            };

            //Content
            StackLayout stackLayout = new StackLayout()
            {
                Children = { generalQuestionLebel, generalTypeScrollView, placeTypeLabel, placeTypeScrollView, placeAttribute1Label, placeAttribute1ScrollView, placeAttribute2Label, placeAttribute2ScrollView, confirmStackLayout }
            };

            this.Content = new ScrollView()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = ScrollOrientation.Vertical,
                Content = stackLayout
            };
        }
        public static void OnGeneralButtonClicked(int id, int placeTypeQuestion)
        {
            placeAttribute1Label.Text = null;
            placeAttribute1ScrollView.Content = null;
            placeAttribute2Label.Text = null;
            placeAttribute2ScrollView.Content = null;
            confirmButton.IsVisible = false;
            IEnumerable<Place_type> place_Types = App.placeTypeRepository.GetItemsById(id);
            StackLayout placeTypesStack = new StackLayout();
            foreach (Place_type place_Type in place_Types)
            {
                Button placeTypeButton = new Button() { Text = place_Type.Name, WidthRequest = 200, HeightRequest = 50 };
                placeTypeButton.Clicked += delegate { OnPlaceTypeButtonClicked(place_Type.Id); };
                Image placeImage = new Image { Source = place_Type.Type_logo };
                StackLayout placeImageButton = new StackLayout();
                placeImageButton.Children.Add(placeTypeButton);
                placeImageButton.Children.Add(placeImage);
                placeTypesStack.Children.Add(placeImageButton);
            }
            placeTypesStack.Orientation = StackOrientation.Horizontal;
            placeTypeLabel.Text = App.questionRepository.GetQuestion(placeTypeQuestion).Question_content;
            placeTypeScrollView.Content = placeTypesStack;
            placeTypeScrollView.Orientation = ScrollOrientation.Horizontal;
        }
        public static void OnPlaceTypeButtonClicked(int placeType)
        {
            placeAttribute1Label.Text = null;
            placeAttribute1ScrollView.Content = null;
            placeAttribute2Label.Text = null;
            placeAttribute2ScrollView.Content = null;
            confirmButton.IsVisible = false;
            IEnumerable<Models.Attribute> attributes = App.placeAttributeRepository.GetAttributes(placeType);
            if (attributes.Any())
            {
                IEnumerable<Models.Attribute> rank1Attributes = attributes.Where(attribute => attribute.Attribute_rank == 1);
                StackLayout rank1AttributeStack = new StackLayout();
                foreach (Models.Attribute attribute in rank1Attributes)
                {
                    Button rank1AttributeButton = new Button() { Text = attribute.Attribute_name, WidthRequest = 200, HeightRequest = 50 };
                    rank1AttributeButton.Clicked += delegate { OnAttributeButtonClicked(attributes); };
                    rank1AttributeStack.Children.Add(rank1AttributeButton);
                }
                rank1AttributeStack.Orientation = StackOrientation.Horizontal;
                placeAttribute1Label.Text = App.questionRepository.GetQuestion(rank1Attributes.ToList()[0].Attribute_question).Question_content;
                placeAttribute1ScrollView.Content = rank1AttributeStack;
                placeAttribute1ScrollView.Orientation = ScrollOrientation.Horizontal;
            }
            else
            {
                confirmButton.IsVisible = true;
            }
        }
        public static void OnAttributeButtonClicked(IEnumerable<Models.Attribute> attributes) {
            confirmButton.IsVisible = false;
            IEnumerable<Models.Attribute> rank2Attributes = attributes.Where(attribute => attribute.Attribute_rank == 2);
            if (rank2Attributes.Any())
            {
                StackLayout rank2AttributeStack = new StackLayout();
                foreach (Models.Attribute attribute in rank2Attributes)
                {
                    Button rank2AttributeButton = new Button() { Text = attribute.Attribute_name, WidthRequest = 200, HeightRequest = 50 };
                    rank2AttributeButton.Clicked += delegate { confirmButton.IsVisible = true; };
                    rank2AttributeStack.Children.Add(rank2AttributeButton);
                }
                rank2AttributeStack.Orientation = StackOrientation.Horizontal;
                placeAttribute2Label.Text = App.questionRepository.GetQuestion(rank2Attributes.ToList()[0].Attribute_question).Question_content;
                placeAttribute2ScrollView.Content = rank2AttributeStack;
                placeAttribute2ScrollView.Orientation = ScrollOrientation.Horizontal;
            }
            else {
                confirmButton.IsVisible = true;
            }
        }
    }
}
