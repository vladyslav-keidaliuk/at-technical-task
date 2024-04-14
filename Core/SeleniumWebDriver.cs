using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Core;

public class SeleniumWebDriver
{
    private static readonly ThreadLocal<SeleniumWebDriver> _instance = new(() => new SeleniumWebDriver());
    public static SeleniumWebDriver NativeDriver => _instance.Value;
    private IWebDriver _driver;
    public IWebDriver Driver => _driver ??= DriverManager.GetDriver();
    private WebDriverWait? Waiter => new(Driver, TimeSpan.FromSeconds(10));

    public void GoToUrl(string? url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    public string GetUrl()
    {
        return Driver.Url;
    }

    public IWebElement FindElement(By element)
    {
        return Waiter!.Until(w => w.FindElement(element));
    }

    public bool WaitForCondition(Func<bool> condition)
    {
        WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
        try
        {
            return wait.Until(_ => condition());
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    public void WaitUntilElementToBeClickable(By locator)
    {
        Waiter!.Until(ExpectedConditions.ElementToBeClickable(locator));
    }
}