using SimpleNotes.Api.Models;

namespace SimpleNotes.Api.Interfaces
{
    public interface INoteService
    {
        IEnumerable<Note> GetAll();
        Note? GetById(int id);
        Note Add(Note note);

        bool Update(Note note);
        void Delete(int id);
        
    }
}
