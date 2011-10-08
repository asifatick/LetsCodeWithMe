namespace LetsCodeWithMe.Acceptance.Specs
{
    using Should;
    using TechTalk.SpecFlow;

    [Binding]
    public class VisitHomeSteps
    {
        [When(@"I navigate to blog home page")]
        public void WhenINavigateToBlogHomePage()
        {
            WebBrowser.Current.Visit("/");
        }

        [Then(@"the browser should show the blog title in browser title bar")]
        public void ThenTheBrowserShouldShowTheBlogTitleInBrowserTitleBar()
        {
            WebBrowser.Current.Title.ShouldEqual("Test Blog");
        }
    }
}