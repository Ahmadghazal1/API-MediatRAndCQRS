﻿using Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository  CategoryRepository { get; }
        Task CompleteAsync();
        
    }
}
