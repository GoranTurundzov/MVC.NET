using NotesApp.DataAccess;
using NotesApp.DataModels;
using NotesApp.Models;
using NotesApp.Services.CustomExceptions;
using NotesApp.Services.Helpers.Mappers;
using NotesApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NotesApp.Api.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public List<NoteModel> GetUserNotes(int userId)
        {
            return _noteRepository.GetAll().Where(x => x.UserId == userId)
                                           .Select(note => NoteMapper.NoteModelToNoteModel(note)).ToList();
        }
        public NoteModel GetNoteDetails(int noteId, int userId)
        {
            var note = _noteRepository.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == userId);

            if (note == null)
            {
                throw new NoteException("Record not found");
            }

            //return new NoteModel
            //{
            //    Id = note.Id,
            //    Text = note.Text,
            //    Color = note.Color,
            //    TagType = (TagType)note.Tag,
            //    UserId = note.UserId
            //};
            var nodeModel = NoteMapper.NoteModelToNoteModel(note);

            return nodeModel;
        }

        public string AddNote(NoteModel note)
        {
            if (string.IsNullOrEmpty(note.Text))
            {
                throw new Exception("Note text is empty");
            }

            if (string.IsNullOrEmpty(note.Color))
            {
                throw new Exception("Note color is empty");
            }

            var noteModel = NoteMapper.NoteModelToNoteModel(note);
            noteModel.DateCreated = DateTime.Now;

            _noteRepository.Add(noteModel);

            return "Note successfully added";
        }

        public string DeleteNote(int noteId, int userId)
        {
            var note = _noteRepository.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == userId);

            if (note == null)
            {
                throw new Exception("Not was not found");
            }

            _noteRepository.Delete(note);

            return "Note deleted successfully";
        }

        public void UpdateNote(NoteModel note)
        {
            var noteDetails = _noteRepository.GetAll().FirstOrDefault(x => x.Id == note.Id && x.UserId == note.UserId);

            if (noteDetails == null)
            {
                throw new Exception("Not was not found");
            }

            var mappedNote = NoteMapper.NoteModelToNoteModel(note);
            _noteRepository.Update(mappedNote);
        }

        public List<NoteModel> GetUserNotesFilteredByDateTime(int userId, DateTime dateTime)
        {
            return _noteRepository.GetAll().Where(x => x.UserId == userId && x.DateCreated >= dateTime)
                                           .Select(note => NoteMapper.NoteModelToNoteModel(note)).ToList();
        }
    }
}
