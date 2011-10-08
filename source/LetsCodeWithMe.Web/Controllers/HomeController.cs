namespace LetsCodeWithMe.Web
{
    using System.Web.Mvc;

    using DataAccess;

    public class HomeController : Controller
    {
        private readonly IBlogRepository blogRepository;

        public HomeController(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public HomeController() : this(new FakeBlogRepository())
        {
        }

        public ActionResult Index()
        {
            var blog = blogRepository.One();

            ViewBag.Title = blog.Title;

            return View();
        }
    }
}