namespace LetsCodeWithMe.DataAccess
{
    using DomainObjects;

    public class FakeBlogRepository : IBlogRepository
    {
        public Blog One()
        {
            return new Blog { Title = "Test Blog" };
        }
    }
}