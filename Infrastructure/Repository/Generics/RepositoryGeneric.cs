﻿using Domain.Interfaces.Generics;
using Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generics {
    public class RepositoryGeneric<T> : IGeneric<T>, IDisposable where T : class {

        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public RepositoryGeneric() {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }
        
        public async Task Add(T Object) {
            using (var data = new ContextBase(_OptionsBuilder)) {
                await data.Set<T>().AddAsync(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Object) {
            using (var data = new ContextBase(_OptionsBuilder)) {
                data.Set<T>().Remove(Object);
                await data.SaveChangesAsync();
            }
        }

        public async Task<List<T>> List() {
            using (var data = new ContextBase(_OptionsBuilder)) {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<T> SearchId(int Id) {
            using (var data = new ContextBase(_OptionsBuilder)) {
                return await data.Set<T>().FindAsync(Id);
            }
        }

        public async Task Update(T Object) {
            using (var data = new ContextBase(_OptionsBuilder)) {
                data.Set<T>().Update(Object);
                await data.SaveChangesAsync();
            }
        }


        private bool _disposed = false;

        // Instantiate a SafeHandle instance.
        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose() => Dispose(true);

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing) {
            if (_disposed) {
                return;
            }

            if (disposing) {
                // Dispose managed state (managed objects).
                _safeHandle?.Dispose();
            }

            _disposed = true;
        }
    }
}
