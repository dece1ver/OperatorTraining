using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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
using Testing.Infrastructure;
using Testing.Models;

namespace Testing.Views
{
    /// <summary>
    /// Логика взаимодействия для MathQuestionControl.xaml
    /// </summary>
    public partial class MathQuestionControl : UserControl
    {
        public MathQuestionControl()
        {
            InitializeComponent();
        }

        public MathQuestion Question
        {
            get { return (MathQuestion)GetValue(QuestionProperty); }
            set { SetValue(QuestionProperty, value); }
        }

        public static readonly DependencyProperty QuestionProperty =
            DependencyProperty.Register(nameof(Question), typeof(MathQuestion), typeof(MathQuestionControl), new PropertyMetadata(null));


        public double? ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register("ImageHeight", typeof(double), typeof(MathQuestionControl), new PropertyMetadata(double.NaN));


    }
}
