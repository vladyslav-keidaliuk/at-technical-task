using Core;

namespace Business.Pages;

public class BasePage
{
    protected SeleniumWebDriver DriverManager;

    public BasePage(SeleniumWebDriver driverManager)
    {
        this.DriverManager = driverManager;
    }
}