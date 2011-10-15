namespace LetsCodeWithMe.DataAccess
{
    using DomainObjects;

    public interface IPostRepository
    {
        Post FindBySlug(string slug);
    }
}