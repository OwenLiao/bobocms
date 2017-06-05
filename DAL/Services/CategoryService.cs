using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public class CategoryService : BaseRepository<Category>,ICategoryService
    {
        public CategoryService(MyDbContext context)
            : base(context)
       { }
    }
}
