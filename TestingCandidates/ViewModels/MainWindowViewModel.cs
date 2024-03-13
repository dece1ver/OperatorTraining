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
using System.Linq;
using Testing.Models;

namespace Testing.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        int currentQuestionIndex = 0;
        public MainWindowViewModel()
        {
            _Questions = new();
            _Status = string.Empty;
            _QuizResult = string.Empty;
            _CandidateName = string.Empty;
            UpdateQuizCommand = new LambdaCommand(OnUpdateQuizCommandExecuted, CanUpdateQuizCommandExecute);
            NextQuestionCommand = new LambdaCommand(OnNextQuestionCommandExecuted, CanNextQuestionCommandExecute);
            _CurrentQuestion = null;
            State = AppState.StartScreen;
            GenerateCandidatesQuestions();
        }

        private ObservableCollection<IQuestion> _Questions;
        /// <summary> Вопросы </summary>
        public ObservableCollection<IQuestion> Questions
        {
            get => _Questions;
            set => Set(ref _Questions, value);
        }

        private IQuestion? _CurrentQuestion;
        /// <summary> Текущий вопрос </summary>
        public IQuestion? CurrentQuestion
        {
            get => _CurrentQuestion;
            set => Set(ref _CurrentQuestion, value);
        }

        private bool _IsComplete;
        /// <summary> Завершен ли опрос </summary>
        public bool IsComplete
        {
            get => _IsComplete;
            set => Set(ref _IsComplete, value);
        }



        private AppState _State;
        /// <summary> Статус приложения </summary>
        public AppState State
        {
            get => _State;
            set => Set(ref _State, value);
        }


        private string _QuizResult;
        /// <summary> Результат опроса </summary>
        public string QuizResult
        {
            get => _QuizResult;
            set => Set(ref _QuizResult, value);
        }


        private string _CandidateName;
        /// <summary> Кто проходит опрос </summary>
        public string CandidateName
        {
            get => _CandidateName;
            set => Set(ref _CandidateName, value);
        }


        private string _Status;
        /// <summary> Статус </summary>
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
                State = AppState.Quiz;
            } else
            {
                currentQuestionIndex++;
            }
            if (currentQuestionIndex < Questions.Count)
            {
                CurrentQuestion = Questions[currentQuestionIndex];
                Status = $"{CurrentQuestion.GetType().Name} №{currentQuestionIndex} | Ответ: {CurrentQuestion.UserAnswer}/{CurrentQuestion.CorrectAnswer}";
            }
            else
            {
                State = AppState.ShowResult;
                Status = "Опрос завершен";
                QuizResult = $"Проходил опрос: {CandidateName}\n" +
                    $"Правильных ответов: {Questions.Count(q => q.IsCorrectAnswer)}/{Questions.Count}\n";

                foreach (var question in Questions)
                {
                    QuizResult += $"\nВопрос{(string.IsNullOrEmpty(question.ImageSource) ? "" : " (с картинкой)")}:\n{question.QuestionText}\n" +
                        $"Ваш ответ: {question.UserAnswer} ({(question.IsCorrectAnswer ? "верно" : "неверно")})" +
                        $"\nПравильный ответ {question.CorrectAnswer:0.##}\n";
                }
            }
        }
        private static bool CanNextQuestionCommandExecute(object p) => true;
    }
}
