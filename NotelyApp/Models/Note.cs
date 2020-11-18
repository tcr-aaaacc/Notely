using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotelyApp.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Detail { get; set; }
    }
}

