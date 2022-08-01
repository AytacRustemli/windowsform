using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstFormApp.Data;
using FirstFormApp.Models;

namespace FirstFormApp.Services
{
    public class CategoryManager
    {
        AppDbContext _context = new();

        public void Add(Categoryy category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
    }
}
