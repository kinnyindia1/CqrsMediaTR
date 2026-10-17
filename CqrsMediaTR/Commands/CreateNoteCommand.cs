using MediatR;

namespace CqrsMediaTR.Commands
{
    public class CreateNoteCommand : IRequest<int>
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public CreateNoteCommand(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}
