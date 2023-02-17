using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prac1.Data
{
    [Table("Loai")]
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }

        public string TenLoai { get; set; }
        
        public virtual IList<HangHoa> HangHoa { get; set;}   
    }
}
