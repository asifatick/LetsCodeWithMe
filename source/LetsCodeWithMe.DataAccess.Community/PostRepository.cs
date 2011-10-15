namespace LetsCodeWithMe.DataAccess.Community
{
    using System.Linq;
    using NHibernate;
    using NHibernate.Linq;

    using DataAccess;
    using DomainObjects;

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