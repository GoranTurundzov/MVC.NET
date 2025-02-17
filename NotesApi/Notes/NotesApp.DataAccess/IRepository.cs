﻿using System.Collections.Generic;

namespace NotesApp.DataAccess
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
