
namespace Institute.BLL.Core
{
    public class ServiceResult<TEntity> where TEntity : class
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public TEntity? Data { get; set; }
    }
}
