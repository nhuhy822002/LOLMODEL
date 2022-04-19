using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using LOLMODEL.Data;

namespace LOLMODEL.Models
{
    public static class SeedData
    { 
        public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new LOLMODELContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<LOLMODELContext>>()))
        {
            // Kiểm tra thông tin cuốn sách đã tồn tại hay chưa
            if (context.Lolmodel.Any())
            {
                return; // Không thêm nếu cuốn sách đã tồn tại trong DB
            }
                context.Lolmodel.AddRange(
                    new Lolmodel
                    {
                        Title = "Mô hình Teemo Evil",
                        ReleaseDate = DateTime.Parse("2018-10-16"),
                        Genre = "Self-Help",
                        Price = 11.98M,
                        Rating = "☆☆☆☆☆"
                    },

 new Lolmodel
 {
     Title = "Mô hình Teemo Die",
     ReleaseDate = DateTime.Parse("2021-01-12"),
     Genre = "Model Toys",
     Price = 18.59M,
     Rating = "☆☆☆☆☆"
 },
     new Lolmodel
     {
         Title = "Mô hình Ekko ",
         ReleaseDate = DateTime.Parse("2021-12-11"),
         Genre = "Moldel toys",
         Price = 29.48M,
         Rating = "☆☆☆☆"
     },
     new Lolmodel
     {
         Title = "Mô hình Teemo",
         ReleaseDate = DateTime.Parse("2021-12-10"),
         Genre = "Moldel toys",
         Price = 28.89M,
         Rating = "☆☆☆☆☆"
     }
 );
                context.SaveChanges();//lưu dữ liệu
            }
        }
    }
}

