namespace ContactMS.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IContactRepository ContactRepository { get; }

        Task CompleteAsync();
    }
}
