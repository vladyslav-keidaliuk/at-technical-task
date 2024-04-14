using Business.Pages;
using static Core.SeleniumWebDriver;

[assembly: LevelOfParallelism(1)]

namespace Tests.Web
{
    [TestFixture]
    [Parallelizable(ParallelScope.Children)]
    public class Tests : BaseTest
    {
        private readonly LoginPage _loginPage;

        public Tests()
        {
            _loginPage = new LoginPage(NativeDriver);
        }

        [TestCaseSource(nameof(ValidTestData))]
        public void LoginWithCredentialsTest(string username, string password)
        {
            SiteNavigation.GoToQaSortedDotCom(NativeDriver);
            _loginPage.InsertUsername(username); 
            _loginPage.InsertPassword(password); 
            _loginPage.ClickSubmitButton();

            var expectedUrl = "https://qa.sorted.com/newtrack/loginSuccess";

            Assert.That(NativeDriver.GetUrl(), Is.EqualTo(expectedUrl));
        }

        private static IEnumerable<TestCaseData> ValidTestData()
        {
            yield return new TestCaseData("john_smith@sorted.com", "Pa55w0rd");
        }
    }
}