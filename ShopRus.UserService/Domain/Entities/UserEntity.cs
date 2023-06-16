using System.ComponentModel.DataAnnotations.Schema;

namespace ShopRus.UserService.Domain.Entities
{
    public class UserEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsMailConfirmed { get; set; }

        public string ValidationKey { get; set; }

        public DateTime ValidationDate { get; set; }

        [ForeignKey("UserType")]
        public int UserTypeId { get; set; }

        public virtual UserTypeEntity UserType { get; set; }
    }
}
