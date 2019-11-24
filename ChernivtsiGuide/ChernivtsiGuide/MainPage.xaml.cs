using ChernivtsiGuide.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChernivtsiGuide
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            List<Label> labels = new List<Label>();
            Question generalQuestion = App.questionRepository.GetQuestion(1);
            Label generalQuestionLebel = new Label() { Text = generalQuestion.Question_content };
            IEnumerable<General_type> general_Types = App.generalTypeRepository.GetItems();
            StackLayout stackLayout1 = new StackLayout();            
            foreach (General_type general_Type in general_Types) {
                stackLayout1.Children.Add(new Label() { Text = general_Type.General_name });
                stackLayout1.Children.Add(new Label() { Text = general_Type.General_name });
                stackLayout1.Children.Add(new Label() { Text = general_Type.General_name });
                stackLayout1.Children.Add(new Label() { Text = general_Type.General_name });
            }
            ScrollView scrollView = new ScrollView() {
                Content = stackLayout1,
                Orientation = ScrollOrientation.Vertical
            };
            StackLayout stackLayout = new StackLayout()
            {
                Children = {generalQuestionLebel}
            };
            stackLayout1.Orientation = StackOrientation.Horizontal;
            this.Content = new ScrollView()
            {
                HorizontalOptions = LayoutOptions.Fill,
                Orientation = ScrollOrientation.Horizontal,
                Content = stackLayout1
            };
        }
    }
}
