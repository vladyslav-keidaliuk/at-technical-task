using Core.DriverFactory;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;

namespace Core;

public enum Browser
{
    Chrome,
    Edge
}

/// <summary>
/// Provides driver factories and WebDriver instances for browser automation.
/// </summary>
public class DriverProvider
{
    public static IWebDriver GetDriver(Browser browser)
    {
        return browser switch
        {
            Browser.Chrome => new ChromeDriver(),
            Browser.Edge => new EdgeDriver(),
            _ => new ChromeDriver()
        };
    }

    public static BaseDriverFactory GetDriverFactory(Browser browser)
    {
        return browser switch
        {
            Browser.Chrome => new ChromeDriverFactory(),
            Browser.Edge => new EdgeDriverFactory(),
            _ => new ChromeDriverFactory()
        };
    }
}