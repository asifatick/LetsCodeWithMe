namespace LetsCodeWithMe.Acceptance.Specs
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;

    using TechTalk.SpecFlow;

    [Binding]
    public class Bootstrapper
    {
        public const int ServerPort = 9393;
        private const string Tools = "tools";

        private static readonly string specProjectName = typeof(Bootstrapper).Namespace;
        private static Process webServer;

        public static string ApplicationPath { get; private set; }

        [BeforeTestRun]
        public static void RunWebServer()
        {
            var currentPath = Environment.CurrentDirectory;
            string solutionRoot;

            if (currentPath.Contains(specProjectName))
            {
                solutionRoot = currentPath.Substring(
                    0, currentPath.IndexOf(specProjectName));
            }
            else if (currentPath.Contains(Tools))
            {
                solutionRoot = currentPath.Substring(
                    0, currentPath.IndexOf(Tools));
            }
            else
            {
                throw new InvalidOperationException(
                    "Cannot run acceptance specs from unknown location.");
            }

            ApplicationPath = Path.Combine(solutionRoot, "LetsCodeWithMe.Web");

            var webServerPath = Path.Combine(
                solutionRoot, Tools, "webserver", "WebDev.WebServer40.EXE");

            var arguments = string.Format(
                "/port:{0} /path:\"{1}\"",
                ServerPort,
                ApplicationPath);

            webServer = new Process
            {
                StartInfo =
                {
                    FileName = webServerPath,
                    Arguments = arguments,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    ErrorDialog = false
                }
            };

            webServer.Start();
            // Lets give it few moments  to breath
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [AfterTestRun]
        public static void StopWebServer()
        {
            if (webServer == null)
            {
                return;
            }

            if (!webServer.HasExited)
            {
                webServer.Kill();
            }

            webServer.Dispose();
        }
    }
}