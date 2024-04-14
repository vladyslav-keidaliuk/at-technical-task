using Core;
using OpenQA.Selenium;

namespace Business.Pages;

/// <summary>
/// Represents the login page of the application.
/// </summary>
public class LoginPage : BasePage
{
    // Locators for elements on the login page
    private readonly By _userNameInput = By.Id("username");
    private readonly By _passwordInput = By.Id("password");
    private readonly By _submitBtn = By.Id("loginBtn");

    public LoginPage(SeleniumWebDriver webDriver) : base(webDriver) { }

    /// <summary>
    /// Inputs the username into the username input field.
    /// </summary>
    /// <param name="username">The username to input.</param>
    public void InsertUsername(string username)
    {
        DriverManager.WaitUntilElementToBeClickable(_userNameInput);
        DriverManager.FindElement(_userNameInput).SendKeys(username);
    }

    /// <summary>
    /// Inputs the password into the password input field.
    /// </summary>
    /// <param name="password">The password to input.</param>
    public void InsertPassword(string password)
    {
        DriverManager.WaitUntilElementToBeClickable(_passwordInput);
        DriverManager.FindElement(_passwordInput).SendKeys(password);
    }

    /// <summary>
    /// Clicks the submit button to perform the login action.
    /// </summary>
    public void ClickSubmitButton()
    {
        DriverManager.FindElement(_submitBtn).Click();
    }
}