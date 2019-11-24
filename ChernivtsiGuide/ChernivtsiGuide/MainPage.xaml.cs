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
            Question generalQuestion = App.questionRepository.GetQuestion(1);
            Label generalQuestionLebel = new Label() { Text = generalQuestion.Question_content };
            StackLayout stackLayout = new StackLayout()
            {
                Children = {generalQuestionLebel}
            };
            this.Content = stackLayout;
        }
    }
}
