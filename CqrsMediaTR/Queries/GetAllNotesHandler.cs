using CqrsMediaTR.Data;
using CqrsMediaTR.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediaTR.Queries
{
    public class GetAllNotesHandler : IRequestHandler<GetAllNotesQuery, List<Note>>
    {
        private readonly AppDbContext _db;
        public GetAllNotesHandler(AppDbContext db) => _db = db;

        public async Task<List<Note>> Handle(GetAllNotesQuery request, CancellationToken ct)
        {
            return await _db.Notes.ToListAsync(ct);
        }
    }
}
