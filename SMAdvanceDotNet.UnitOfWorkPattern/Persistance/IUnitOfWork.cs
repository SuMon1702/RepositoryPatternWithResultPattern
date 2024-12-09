using SMAdvanceDotNet.UnitOfWorkPattern.Persistance.Repositories;

namespace SMAdvanceDotNet.UnitOfWorkPattern.Persistance
{
    public interface IUnitOfWork
    {
        IBlogRepository BlogRepository { get; }
    }
}
