﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;
using DAL;
namespace BLL
{
    public class CategoryService : BaseRepository<Category>,ICategoryService
    {
        public CategoryService(MyDbContext context)
            : base(context)
       { }
    }
    //public class UserRepository : EntityBaseRepository<User>, IUserRepository
    //{
    //    public UserRepository(SchedulerContext context)
    //        : base(context)
    //    { }
    //}
}
