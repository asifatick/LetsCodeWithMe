using System.Linq;
using LetsCodeWithMe.DataAccess;
using LetsCodeWithMe.DomainObjects;
using NHibernate;
using NHibernate.Linq;

namespace LetsCodeWIthMe.DataAccess.Community
{
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