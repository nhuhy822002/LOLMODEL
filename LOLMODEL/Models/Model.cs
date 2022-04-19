using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LOLMODEL.Models
{
    public class Lolmodel
    {
        [Display(Name = "Mã sản phẩm")]
        public int Id { get; set; }

        [StringLength(60, ErrorMessage = "Không dài quá {1} kí tự và không dưới {2} kí tự", MinimumLength = 3)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Tên sản phẩm")]
        public string Title { get; set; }

        [Display(Name = "Ngày phát hành")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        [StringLength(30)]
        [Display(Name = "Thể loại")]
        public string Genre { get; set; }

        [Range(1, 100000000)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name ="Giá bán")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


       /* [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required] */
        [Display(Name = "Đánh giá")]
        public string Rating { get; set; }

    }
}
