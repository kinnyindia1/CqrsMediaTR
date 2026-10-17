using CqrsMediaTR.Data;
using CqrsMediaTR.Models;
using MediatR;

namespace CqrsMediaTR.Queries
{
    public class GetNoteByIdHandler : IRequestHandler<GetNoteByIdQuery, Note?>
    {
        private readonly AppDbContext _db;
        public GetNoteByIdHandler(AppDbContext db) => _db = db;

        public async Task<Note?> Handle(GetNoteByIdQuery request, CancellationToken ct)
        {
            return await _db.Notes.FindAsync(new object[] { request.Id }, ct);
        }
    }
}
