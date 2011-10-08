namespace LetsCodeWithMe.Acceptance.Specs
{
    using TechTalk.SpecFlow;
    using WatiN.Core;

    [Binding]
    public class WebBrowser
    {
        private const string Key = "browser";

        public static Browser Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(Key))
                {
                    ScenarioContext.Current[Key] = new IE();
                }

                return (Browser)ScenarioContext.Current[Key];
            }
        }

        [AfterScenario]
        public static void Close()
        {
            if (!ScenarioContext.Current.ContainsKey(Key))
            {
                return;
            }

            ((Browser)ScenarioContext.Current[Key]).Close();
        }
    }
}