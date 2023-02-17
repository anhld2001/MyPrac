using System.ComponentModel.DataAnnotations;

namespace Prac1.Model
{
    public class LoaiModel
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string TenLoai { get; set; }
    }
}
