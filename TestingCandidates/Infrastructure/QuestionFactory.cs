using System.Collections.Generic;
using System.Windows.Controls;
using Testing.Models;

namespace Testing.Infrastructure
{
    public class QuestionFactory
    {
        /// <summary>
        /// Создать вопрос с вариантами ответа
        /// </summary>
        /// <param name="questionText">Текст вопроса</param>
        /// <param name="correctAnswer">Правильный ответ</param>
        /// <param name="image">Сопровождающее изображение (опционально)</param>
        /// <returns></returns>
        public static IQuestion CreateChoiceQuestion(string questionText, object correctAnswer, Dictionary<int, string> answers, string imageSource = "")
        {
            return new ChoiceQuestion(questionText, correctAnswer, answers, imageSource);
        }

        /// <summary>
        /// Создать математический вопрос 
        /// </summary>
        /// <param name="questionText">Текст вопроса</param>
        /// <param name="correctAnswer">Правильный ответ</param>
        /// <param name="image">Сопровождающее изображение (опционально)</param>
        /// <returns></returns>
        public static IQuestion CreateMathQuestion(string questionText, object correctAnswer, string imageSource = "")
        {
            return new MathQuestion(questionText, correctAnswer, imageSource);
        }
    }
}
