using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using Testing.Infrastructure.Extensions;
using Testing.Infrastructure;
using Testing.Infrastructure.Commands;
using Testing.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Images = Testing.Infrastructure.Images;

namespace Testing.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        int currentQuestionIndex = 0;
        public MainWindowViewModel()
        {
            _Questions = new();
            _Status = string.Empty;
            UpdateQuizCommand = new LambdaCommand(OnUpdateQuizCommandExecuted, CanUpdateQuizCommandExecute);
            NextQuestionCommand = new LambdaCommand(OnNextQuestionCommandExecuted, CanNextQuestionCommandExecute);
            _CurrentQuestion = null;
            GenerateCandidatesQuestions();
        }

        private ObservableCollection<IQuestion> _Questions;
        /// <summary> Описание </summary>
        public ObservableCollection<IQuestion> Questions
        {
            get => _Questions;
            set => Set(ref _Questions, value);
        }


        private IQuestion? _CurrentQuestion;
        /// <summary> Описание </summary>
        public IQuestion? CurrentQuestion
        {
            get => _CurrentQuestion;
            set => Set(ref _CurrentQuestion, value);
        }


        private string _Status;
        /// <summary> Описание </summary>
        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }


        void GenerateCandidatesQuestions()
        {
            Questions = new();
            double var1;
            double var2;

            var1 = new Random().NextDoubleInRangeWithStep(0.6, 0.8, 0.2);
            Questions.Add(QuestionFactory.CreateMathQuestion($"Вычислите {var1:0.##} + {var1:0.##}", var1 * 2));

            var1 /= 2;
            Questions.Add(QuestionFactory.CreateMathQuestion($"Вычислите {var1:0.##} * {var1:0.##}", var1 * var1));

            var2 = new Random().NextDoubleInRangeWithStep(0.05, var1 - 0.1, 0.01);
            Questions.Add(QuestionFactory.CreateMathQuestion($"Вычислите {var1:0.##} + {var2:0.##}", var1 + var2));

            var1 = new Random().NextDoubleInRangeWithStep(20, 30, 1);
            var2 = new Random().NextDoubleInRangeWithStep(0.1, 0.8, 0.01);
            Questions.Add(QuestionFactory.CreateMathQuestion($"Вычислите {var1:0.##} - {var2:0.##}", var1 - var2));

            var1 = new Random().NextDoubleInRangeWithStep(15, 70, 1);
            var2 = 90 - var1;

            Questions.Add(QuestionFactory.CreateMathQuestion($"Укажите угол А если угол B равен {var1:0}°", var2, Images.TriangleAngleImage));

            Questions.Add(QuestionFactory.CreateMathQuestion($"Укажите угол А (углы равны)", 120.0, Images.RoundAnglesImage));

            var1 = new Random().NextDoubleInRangeWithStep(6, 16, 1);
            var2 = new Random().NextDoubleInRangeWithStep(20, 40, 5);
            Questions.Add(QuestionFactory.CreateMathQuestion($"Укажите А", var1 + var2, Images.CenterMillImage));

            Questions.Add(QuestionFactory.CreateMathQuestion($"Укажите сумму отрезков А, В и С", 60.5, Images.SegmentsImage));

            Questions.Add(QuestionFactory.CreateChoiceQuestion("Если левая шестерня поворачивается в указанном стрелкой направлении, то в каком направлении поворачивается правая шестерня?",
                2, 
                new Dictionary<int, string>()
                {
                    {1, "В направлении стрелки А" },
                    {2, "В направлении стрелки B" },
                    {3, "Не знаю" },
                }, Images.Bennet1Image));
        }

        public ICommand UpdateQuizCommand { get; }
        private void OnUpdateQuizCommandExecuted(object p)
        {
            GenerateCandidatesQuestions();
        }
        private static bool CanUpdateQuizCommandExecute(object p) => true;

        public ICommand NextQuestionCommand { get; }
        private void OnNextQuestionCommandExecuted(object p)
        {
            if (CurrentQuestion == null)
            {
                currentQuestionIndex = 0;
            } else
            {
                currentQuestionIndex++;
            }
            CurrentQuestion = Questions[currentQuestionIndex];
            Status = $"{CurrentQuestion.GetType().Name} №{currentQuestionIndex} | Ответ: {CurrentQuestion.UserAnswer}/{CurrentQuestion.CorrectAnswer}";
        }
        private static bool CanNextQuestionCommandExecute(object p) => true;
    }
}
