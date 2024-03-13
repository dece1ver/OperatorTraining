using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Testing.Models;

namespace Testing.Infrastructure
{
    public class QuestionTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ChoiceQuestionTemplate { get; set; }
        public DataTemplate MathQuestionTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return item switch
            {
                ChoiceQuestion => ChoiceQuestionTemplate,
                MathQuestion => MathQuestionTemplate,
                _ => base.SelectTemplate(item, container),
            };
        }
    }
}
