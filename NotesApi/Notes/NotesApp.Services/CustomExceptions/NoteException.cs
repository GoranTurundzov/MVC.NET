using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Services.CustomExceptions
{
    public class NoteException : Exception
    {
        public NoteException()
        {

        }

        public NoteException(string message) : base(message)
        {

        }
        public NoteException(string message , Exception ex) : base (message , ex)
        {

        }
    }
}
