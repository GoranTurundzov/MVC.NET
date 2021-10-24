using Moq;
using NotesApp.DataAccess;
using NotesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NotesApp.UnitTest
{
    public static class MockHelper
    {
        public static IRepository<User> MockUserRepository()
        {

            var md5 = new MD5CryptoServiceProvider();
            var passwordData = md5.ComputeHash(Encoding.ASCII.GetBytes("asdqwe123"));
            var hashedPassword = Encoding.ASCII.GetString(passwordData);
            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Firstname = "Bob",
                    LastName = "BObsky",
                    Username = "Bob007",
                    Password = hashedPassword
                }
            };

            Mock<IRepository<User>> mockUserRepo = new Mock<IRepository<User>>();

            mockUserRepo.Setup(x => x.GetAll()).Returns(users);
            mockUserRepo.Setup(x => x.Add(It.IsAny<User>())).Callback((User user) => users.Add(user));
            mockUserRepo.Setup(x => x.Delete(It.IsAny<User>())).Callback((User user) => users.Remove(user));
            mockUserRepo.Setup(x => x.Update(It.IsAny<User>())).Callback((User user) => users[users.IndexOf(user)] = user);

            return mockUserRepo.Object;
        }
        public static IRepository<Note> MockNoteRepository()
        {
            List<Note> notes = new List<Note>()
            {
                new Note
                {
                    Id = 1,
                    Text = "Don't forget to water the plant!",
                    Color = "Orange",
                    Tag = 3,
                    UserId = 1
                },
                 new Note
                {
                    Id = 2,
                    Text = "Drink more water",
                    Color = "Red",
                    Tag = 3,
                    UserId = 1
                }
            };

            Mock<IRepository<Note>> mockNoteRepo = new Mock<IRepository<Note>>();

            mockNoteRepo.Setup(x => x.GetAll()).Returns(notes);
            mockNoteRepo.Setup(x => x.Add(It.IsAny<Note>())).Callback((Note note) => notes.Add(note));
            mockNoteRepo.Setup(x => x.Delete(It.IsAny<Note>())).Callback((Note note) => notes.Remove(note));
            mockNoteRepo.Setup(x => x.Update(It.IsAny<Note>())).Callback((Note note) => notes[notes.IndexOf(note)] = note);

            return mockNoteRepo.Object;
        }
    }
}
