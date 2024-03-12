using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Testing.Infrastructure;

namespace Testing.Models
{
    public class ChoiceQuestion : IQuestion
    {
        public ChoiceQuestion(string questionText, object correctAnswer, Dictionary<int, string> answers, string? imageSource)
        {
            QuestionText = questionText;
            if (CorrectAnswer is < 1 or > 3) throw new ArgumentException("Допускается только 3 варианта ответа.");
            CorrectAnswer = correctAnswer;
            if (answers.Count != 3) throw new ArgumentException("Допускается только 3 варианта ответа.");
            Answers = answers;
            ImageSource = imageSource;
        }
        public string QuestionText { get; }
        public object CorrectAnswer { get; }
        public string? ImageSource {get;}
        public object? UserAnswer { get; set; }
        public Dictionary<int, string> Answers { get; set; }

        public bool IsCorrectAnswer
        {
            get
            {
                if (UserAnswer is int answer && answer == (int)CorrectAnswer) return true;
                return false;
            }
        }

        
    }
}
