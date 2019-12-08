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
        Label placeQuestion = new Label() { Text = "general"};
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
                generalButton.Clicked += delegate { OnButtonClicked(general_Type.General_id); };
                generalTypesStack.Children.Add(generalButton);
            }
            generalTypesStack.Orientation = StackOrientation.Horizontal;

            ScrollView generalTypeScrollView = new ScrollView()
            {
                Content = generalTypesStack,
                Orientation = ScrollOrientation.Horizontal,
            };

            StackLayout stackLayout = new StackLayout()
            {
                Children = { generalQuestionLebel, generalTypeScrollView, generalQuestionLebel, placeQuestion }
            };
            
            this.Content = new ScrollView()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = ScrollOrientation.Vertical,
                Content = stackLayout
            };
        }
        public static void OnButtonClicked(int id) {
            Console.WriteLine("Hi. You clicked {0}", id);
        }
    }
}
