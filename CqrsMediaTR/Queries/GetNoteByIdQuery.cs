using CqrsMediaTR.Models;
using MediatR;

namespace CqrsMediaTR.Queries
{
    public class GetNoteByIdQuery : IRequest<Note?>
    {
        public int Id { get; set; }

        public GetNoteByIdQuery(int id) => Id = id;
    }
}
