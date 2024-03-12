using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Testing.Models;

namespace Testing.Views
{
    /// <summary>
    /// Логика взаимодействия для ChoiceQuestionControl.xaml
    /// </summary>
    public partial class ChoiceQuestionControl : UserControl
    {
        public ChoiceQuestionControl()
        {
            InitializeComponent();
        }

        public ChoiceQuestion Question
        {
            get { return (ChoiceQuestion)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }

        public static readonly DependencyProperty QuestionProperty =
            DependencyProperty.Register(nameof(Question), typeof(ChoiceQuestion), typeof(ChoiceQuestionControl), new PropertyMetadata(null));
    }
}
