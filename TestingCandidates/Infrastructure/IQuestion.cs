using System.Windows.Controls;

namespace Testing.Infrastructure
{
    public interface IQuestion
    {
        string QuestionText { get; }
        object CorrectAnswer { get; }
        string? ImageSource { get; }
        object? UserAnswer { get; set;}
        bool IsCorrectAnswer { get; }
    }
}
