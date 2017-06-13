using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public class ArticleService : BaseRepository<Article>, IArticleService
    {
        public ArticleService(MyDbContext context)
            : base(context)
       { }
    }


}
