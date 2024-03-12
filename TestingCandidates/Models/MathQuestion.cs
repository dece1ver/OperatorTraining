using System;
using System.Windows.Controls;
using Testing.Infrastructure;

namespace Testing.Models
{
    public class MathQuestion : IQuestion
    {
        public MathQuestion(string questionText, object correctAnswer, string? imageSource)
        {
            QuestionText = questionText;
            CorrectAnswer = correctAnswer;
            ImageSource = imageSource;
        }
        public string QuestionText { get; }
        public object CorrectAnswer { get; }
        public string? ImageSource {get;}
        public object? UserAnswer { get; set; }

        public bool IsCorrectAnswer
        {
            get
            {
                if (UserAnswer is double answer && Math.Abs(answer - (double)CorrectAnswer) > 0.001) return true;
                return false;
            }
        }
    }
}
