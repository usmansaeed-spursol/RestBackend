using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PersonalCompany.PersonalProduct.Models
{
    [Table("tbl_Product")]
    public partial class Product
    {
        [Key]
        [Column("Id")]
        public virtual int Id { get; set; }
        [Column("Product_Name")]
        public virtual string ProductName { get; set; }
        [Column("Active")]
        public virtual bool Active { get; set; }
        [Column("Product_Description")]

        public virtual string ProductDescription { get; set; }
    }
}
