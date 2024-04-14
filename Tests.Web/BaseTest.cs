using Core;
using static Core.SeleniumWebDriver;

namespace Tests.Web;

[TestFixture]
public class BaseTest
{
    [SetUp]
    public void Setup()
    {
        NativeDriver.Driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        DriverManager.QuitDriver();
    }
}