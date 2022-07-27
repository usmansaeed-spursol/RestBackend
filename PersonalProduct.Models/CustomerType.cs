using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalCompany.PersonalProduct.Models
{
    [Table("tbl_Customer_Types")]
    public partial class CustomerType
    {
        [Key]
        [Column("Id")]
        public virtual int Id { get; set; }
        [Column("Customer_Type_Name")]
        public virtual string CustomerTypeName { get; set; }
        [Column("Active")]
        public virtual bool Active { get; set; }
        [Column("Created_On")]
        public virtual DateTime CreatedOn { get; set; }
        [Column("Created_By")]
        public virtual string CreatedBy { get; set; }
        [Column("Last_Modified_On")]
        public virtual DateTime? LastModifiedOn { get; set; }
        [Column("Last_Modified_By")]
        public virtual string LastModifiedBy { get; set; }
    }
}
