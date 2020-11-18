using System;
using System.Collections.Generic;
using NotelyApp.Models;

namespace NotelyApp.Repositories
{
    public interface INoteRepository
    {
        void SaveNote(Note note);
        IEnumerable<Note> GetAllNote();
        Note FindNoteById(Guid id);
    }
}