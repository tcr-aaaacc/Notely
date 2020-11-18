using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotelyApp.Models;

namespace NotelyApp.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly List<Note> notes;

        public NoteRepository()
        {
            notes = new List<Note>();
        }
        public Note FindNoteById(Guid id)
        {
            var note = notes.Find(n => n.Id == id);
            return note;
        }

        public void SaveNote(Note note)
        {
            notes.Add(note);
        }

        public IEnumerable<Note> GetAllNote()
        {
            return notes;
        }
    }
}

