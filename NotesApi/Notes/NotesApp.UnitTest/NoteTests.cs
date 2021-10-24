using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotesApp.Api.Services;
using NotesApp.DataModels;
using NotesApp.Models;
using NotesApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.UnitTest
{
    [TestClass]
    public class NoteTests
    {
        [TestMethod]
        public void GetUserNotes_ValidUserId_AllUserNotes()
        {
            // Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository());
            int userId = 1;
            int expectedResult = 2;

            //Act 
            List<NoteModel> notes = noteService.GetUserNotes(userId);

            //Assery
            Assert.AreEqual(expectedResult, notes.Count);
        }
        [TestMethod]
        public void GetUserNotes_InvalidUserId_AllUserNotes()
        {
            // Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository());
            int userId = 2;
            int expectedResult = 0;

            //Act 
            List<NoteModel> notes = noteService.GetUserNotes(userId);

            //Assery
            Assert.AreEqual(expectedResult, notes.Count);
        }

        [TestMethod]
        public void GetNoteDetail_ValidUserId_Note()
        {
            //Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository());
            int userId = 1;
            int noteId = 1;
            int expectedResult = 1;

            //Act 
            NoteModel note = noteService.GetNoteDetails(userId, noteId);

            //
            Assert.AreEqual(expectedResult, note.Id);
        }
        [TestMethod]
        public void GetNoteDetail_InvalidUserId_Note()
        {
            //Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository());
            int userId = 1;
            int noteId = 5;

            //Act 
            //Assert
            Assert.ThrowsException<Exception>(() => noteService.GetNoteDetails(userId, noteId));
        }

        public void AddNote_NoteAdded()
        {
            INoteService noteService = new NoteService(new FakeNoteRepository());
            NoteModel note = new NoteModel
            {
                Color = "Red",
                TagType = TagType.Misc,
                Text = "Hello there",
                UserId = 1
            };
        }
    }
}
