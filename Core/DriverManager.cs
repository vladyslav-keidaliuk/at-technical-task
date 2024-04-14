using Core.Configuration;
using OpenQA.Selenium;

namespace Core;

/// <summary>
/// Manages the lifecycle of WebDriver instances for browser automation.
/// </summary>
public class DriverManager
{
    private static ThreadLocal<IWebDriver> Driver = new();

    public static IWebDriver GetDriver()
    {
        if (Driver.Value == null)
        {
            var browserSelected = Enum.TryParse(Config.Model.Browser, out Browser browser) ? browser : Browser.Chrome;
            Driver.Value = DriverProvider.GetDriverFactory(browserSelected).CreateDriver();
        }

        return Driver.Value;
    }

    /// <summary>
    /// Quits the WebDriver instance for the current thread and disposes of its resources.
    /// </summary>
    public static void QuitDriver()
    {
        if (Driver.Value != null)
        {
            Driver.Value.Quit();
            Driver.Value.Dispose();
            Driver.Value = null;
        }
    }
}