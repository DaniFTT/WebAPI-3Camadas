﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T Object);
        Task Updade(T Object);
        Task Delete(T Object);
        Task<T> GetById(int Id);
        Task<List<T>> List();
    }
}
