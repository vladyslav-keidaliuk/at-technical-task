using Core;
using Core.Configuration;

namespace Business.Pages;

public class SiteNavigation : BasePage
{
    public SiteNavigation(SeleniumWebDriver driverManager) : base(driverManager) { }

    public static void GoToQaSortedDotCom(SeleniumWebDriver driver)
    {
       driver.GoToUrl(Config.Model.Url);
    }
}