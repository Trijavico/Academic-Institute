
namespace Institute.DAL.Core
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreationDate = DateTime.Now;
            Deleted = false;
        }

        public int CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UserMod { get; set; }
        public DateTime? ModifyDate { get; set; }
        public int? DeleteUser { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool UserDeleted { get; set; }
    }
}
