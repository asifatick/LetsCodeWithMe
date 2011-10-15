using System.Linq;
using LetsCodeWithMe.DataAccess;
using LetsCodeWithMe.DomainObjects;
using NHibernate;
using NHibernate.Linq;

namespace LetsCodeWIthMe.DataAccess.Community
{
    public class PostRepository : IPostRepository
    {
        private readonly ISession session;

        public PostRepository(ISession session)
        {
            this.session = session;
        }

        public virtual Post FindBySlug(string slug)
        {
            return session.Query<Post>().SingleOrDefault(p => p.Slug == slug);
        }
    }
}