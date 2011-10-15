namespace LetsCodeWithMe.DataAccess.Community
{
    using System.Linq;

    using NHibernate;
    using NHibernate.Linq;

    using DataAccess;
    using DomainObjects;

    public class BlogRepository : IBlogRepository
    {
        private readonly ISession session;

        public BlogRepository(ISession session)
        {
            this.session = session;
        }

        public virtual Blog One()
        {
            return session.Query<Blog>().First();
        }
    }
}