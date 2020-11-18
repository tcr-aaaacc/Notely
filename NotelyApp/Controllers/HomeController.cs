using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NotelyApp.Models;
using NotelyApp.Repositories;


namespace NotelyApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteRepository _noteRepository;


        public HomeController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }







        public IActionResult NoteDetail(Guid id = default)
        {
            Note note = _noteRepository.FindNoteById(id);
            return View(note);
        }//显示Note的具体内容




        public IActionResult NoteBuilder()
        {
            return View();
        }//显示创建Note的页面

        public IActionResult NoteEditor(Guid id)
        {
            if (id != Guid.Empty)
            {
                var note = _noteRepository.FindNoteById(id);
                return View(note);
            }
            return View();
        }//显示Note的编辑页面，并将要编辑的Note显示出来





        public IActionResult NewNote(Note note)
        {
            note.Id = Guid.NewGuid();
            _noteRepository.SaveNote(note);
            return RedirectToAction("NoteList");
        }//创建新的note，并跳转到NoteList页面

        public IActionResult EditNote(Note note)
        {
            if (note != null && note.Id != Guid.Empty)
            {
                var _note = _noteRepository.FindNoteById(note.Id);
                _note.Subject = note.Subject;
                _note.Detail = note.Detail;
            }
            return RedirectToAction("NoteList");
        }//对现有的note进行编辑保存，然后跳转到NoteList页面

        public IActionResult NoteList()
        {
            IEnumerable<Note> notes = _noteRepository.GetAllNote();
            return View(notes);
        }
    }
}
