using System;

namespace CodeBase.Services.General.Disposal
{
    public interface IDisposer
    {
        void Add(IDisposable disposable);
        void DisposeAll();
    }
}