namespace LetsCodeWithMe.Web.Unit.Specs.HomeController
{
    using System.Web.Mvc;

    using Machine.Specifications;
    using NSubstitute;

    using DataAccess;
    using DomainObjects;
    using Web;

    [Subject(typeof(HomeController))]
    public class when_visiting_index
    {
        static IBlogRepository repository;
        static HomeController controller;
        static Blog blog;
        static ViewResult result;

        Establish context = () =>
        {
            blog = new Blog { Title = "Test Blog" };

            repository = Substitute.For<IBlogRepository>();
            repository.One().Returns(blog);

            controller = new HomeController(repository);
        };

        Because of = () => result = (ViewResult)controller.Index();

        It should_render_default_view = () =>
            result.ViewName.ShouldBeEmpty();

        It should_set_blog_title_as_page_title = () =>
            ((string)result.ViewBag.Title).ShouldEqual(blog.Title);
    }
}