using SimpleNotes.Api.Interfaces;
using SimpleNotes.Api.Models;

namespace SimpleNotes.Api.Services
{
    public class NoteService : INoteService
    {
        private readonly List<Note> _notes = new();
        public Note Add(Note note)
        {
            _notes.Add(note);
            return note;
        }

        public void Delete(int id)
        {
            var note = GetById(id);
            if (note != null)
            {
                _notes.Remove(note);
            }
            return;
        }

        public IEnumerable<Note> GetAll()
        {
            return _notes;
        }

        public Note? GetById(int id)
        {
            return _notes.FirstOrDefault(n => n.Equals(id));
        }

        public bool Update(Note newNote)
        {
            Note? oldNote = GetById(newNote.Id);

            if (oldNote == null) {
                Console.WriteLine("Note ID does not exist");
                return false;
            }

            oldNote.Content = newNote.Content;

            return true;

        }
    }
}
