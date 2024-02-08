
namespace Institute.BLL.Core
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        ServiceResult<IEnumerable<TEntity>> GetAll();
        ServiceResult<TEntity> GetById(int Id);
    }
}
