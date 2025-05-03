using System.Runtime.CompilerServices;

namespace Andromeda.Services.Ui;

public interface ITaskWrapper : ITaskWrapperBase<ITaskWrapper>
{
    TaskAwaiter GetAwaiter();
}

public interface ITaskWrapper<T> : ITaskWrapperBase<ITaskWrapper<T>>
{
    TaskAwaiter<T> GetAwaiter();
}
