using CqrsMediaTR.Data;
using CqrsMediaTR.Models;
using MediatR;

namespace CqrsMediaTR.Commands
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteCommand, int>
    {
        private readonly AppDbContext _db;
        public CreateNoteHandler(AppDbContext db) => _db = db;
        public async Task<int> Handle(CreateNoteCommand request, CancellationToken ct)
        {
            var note = new Note { Title = request.Title, Content = request.Content };
            _db.Notes.Add(note);
            await _db.SaveChangesAsync(ct);
            return note.Id;
        }
    }
}
