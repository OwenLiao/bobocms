namespace Model
{
    public class ArticleCategory
    {
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

    //public class DetailArticleCategory : ArticleCategory { }
   // public class ListArticleCategory : ArticleCategory { }
}
