namespace LetsCodeWithMe.Acceptance.Specs
{
    using System;
    using WatiN.Core;

    public static class Extensions
    {
        public static void Visit(
            this Browser instance, string relativeUrl = "/")
        {
            var url = relativeUrl ?? string.Empty;

            if (url.StartsWith("/", StringComparison.Ordinal))
            {
                url = url.Length > 1 ? url.Substring(1) : string.Empty;
            }

            var fullUrl = string.Format(
                "http://localhost:{0}/{1}", Bootstrapper.ServerPort, url);

            instance.GoTo(fullUrl);
            instance.WaitForComplete(60 * 1000); // 1 Minute
        }

        public static Element Select(
            this IElementContainer instance, string selector)
        {
            return instance.Element(Find.BySelector(selector));
        }
    }
}