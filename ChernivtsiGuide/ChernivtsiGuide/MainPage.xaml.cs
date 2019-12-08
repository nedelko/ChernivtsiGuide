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
        static ScrollView placeTypeScrollView = new ScrollView();
        static Label placeTypeLabel = new Label();
        public MainPage()
        {
            this.Resources.Add(StyleSheet.FromAssemblyResource
                (IntrospectionExtensions.GetTypeInfo(typeof(MainPage)).Assembly,
            "ChernivtsiGuide.mystyles.css"));

            Question generalQuestion = App.questionRepository.GetQuestion(1);
            Label generalQuestionLebel = new Label() { Text = generalQuestion.Question_content };

            IEnumerable<General_type> general_Types = App.generalTypeRepository.GetItems();
            StackLayout generalTypesStack = new StackLayout();
            foreach (General_type general_Type in general_Types) {
                Button generalButton = new Button() { Text = general_Type.General_name, WidthRequest = 200, HeightRequest = 50};
                generalButton.Clicked += delegate { OnGeneralButtonClicked(general_Type.General_id, general_Type.General_question); };
                generalTypesStack.Children.Add(generalButton);
            }
            generalTypesStack.Orientation = StackOrientation.Horizontal;

            ScrollView generalTypeScrollView = new ScrollView()
            {
                Content = generalTypesStack,
                Orientation = ScrollOrientation.Horizontal,
            };

            //Content
            StackLayout stackLayout = new StackLayout()
            {
                Children = { generalQuestionLebel, generalTypeScrollView, placeTypeLabel, placeTypeScrollView }
            };
            
            this.Content = new ScrollView()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = ScrollOrientation.Vertical,
                Content = stackLayout
            };
        }
        public static void OnGeneralButtonClicked(int id, int placeTypeQuestion) {
            IEnumerable<Place_type> place_Types = App.placeTypeRepository.GetItemsById(id);
            StackLayout placeTypesStack = new StackLayout();
            foreach (Place_type place_Type in place_Types) {
                Button placeTypeButton = new Button() { Text = place_Type.Name, WidthRequest = 200, HeightRequest = 50 };
                placeTypesStack.Children.Add(placeTypeButton);
            }
            placeTypesStack.Orientation = StackOrientation.Horizontal;
            Console.WriteLine(placeTypeQuestion);
            placeTypeLabel.Text = App.questionRepository.GetQuestion(placeTypeQuestion).Question_content;
            placeTypeScrollView.Content = placeTypesStack;
            placeTypeScrollView.Orientation = ScrollOrientation.Horizontal;
        }
    }
}
