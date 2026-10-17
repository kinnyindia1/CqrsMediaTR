using CqrsMediaTR.Models;
using MediatR;

namespace CqrsMediaTR.Queries
{
    public class GetAllNotesQuery : IRequest<List<Note>>
    {
    }
}
