﻿
namespace Institute.DAL.Core
{
    public abstract class Person : BaseEntity
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 
        
    }
}