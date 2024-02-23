using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;
using SeleniumExtras.WaitHelpers;
using System.Net.NetworkInformation;
using OpenQA.Selenium.Interactions;
using System.Security.Claims;



namespace CreateBolFlow.StepDefinitions.Hero
{
    [Binding]
    public sealed class Variables
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

    public Variables(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        //[Given(@"We need to have beter variables to have solid tests")]
        //public void GivenWeNeedToHaveBeterVariablesToHaveSolidTests()
        //{

        //    There are 22 variables so far the need to be included name or ID
        //   variables that need ID or Name
        //       var WTECmenu = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
        //             XPath($"//span[text()='{menuName}']")));
        //    var manufactoringMenuItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
        //        XPath($"//span[text()='{manufactoringMenu}']")));
        //    var bolMenuItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
        //        XPath($"//span[text()='{bolMenu}']")));
        //    var listMenuItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.
        //        XPath($"//span[text()='{listMenu}']")));

        //    //BOL search field - Very important and very fragile
        //    var searchField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
        //        ElementIsVisible(By.CssSelector("#hero-next-datagrid > div > div.dx-datagrid-headers.dx-datagrid-nowrap > div > table > tbody > tr.dx-row.dx-column-lines.dx-datagrid-filter-row > td:nth-child(4) > div > div.dx-editor-container > div > div > div.dx-texteditor-input-container > input")));
        //    //THe four status Rubicon, Hero, QC and Shipping - Very important and very fragile
        //    IWebElement heroStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#hero-next-datagrid > div > div.dx-datagrid-rowsview.dx-datagrid-nowrap.dx-last-row-border.dx-scrollable.dx-visibility-change-handler.dx-scrollable-both.dx-scrollable-simulated > div > div > div.dx-scrollable-content > div > table > tbody > tr.dx-row.dx-data-row.dx-row-lines.dx-column-lines > td:nth-child(6)")));

        //    // Button depois do select da BOL list
        //    var dropdownElements = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
        //                            PresenceOfAllElementsLocatedBy(By.ClassName("dx-scrollview-content")));

        //    if (dropdownElements.Count >= 2)
        //    {
        //        var dropdown = dropdownElements[1];

        //        int yOffset = -5;
        //        Actions actions = new Actions(driver);
        //        actions.MoveToElement(dropdown, 0, yOffset).Click().Perform();
        //    }
        //    else
        //    {
        //        throw new NoSuchElementException("The dropdown element with the specified class was not found or there are not enough elements.");
        //    }

        //    //Save button because the error 500 that happens in the automated tests
        //    var saveButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Save']")));

        //    //Sucess or Fail message
        //    var message = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//span[contains({successMessage})]")));

        //    //Inputs in movimentation page (Ship to coat applicator, Complete Coating etc)
        //    var dateInput = driver.FindElement(By.CssSelector("#EstimatedCoatingCompletionDate .dx-texteditor-input"));

        //    // One of the most difficult to find the HTML element: piecesReceived and piecesCoated input
        //    var piecesReceivedTd = driver.FindElement(By.
        //        XPath("//tbody[@role='presentation']//td[@role='gridcell'][@aria-colindex='1'][@tabindex='0']"));
        //    var inputElement = driver.FindElement(By.XPath("//td[@role='gridcell'][@aria-colindex='1'][@tabindex='0']//input[contains(@class, 'dx-texteditor-input')]"));

        //    //QC inspection list select button and its QC Log button
        //    var selectButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.
        //                            XPath("//td[@aria-colindex='13']//span[text()='Select']/..")));
        //    var selecButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath($"//div[text()='{buttonTitle}']/..")));
        //    selecButton.Click();

        //    //Those radio buttons in the QC inspection I Believe that god help me to find the right xpath and to code it
        //    int index = 1;
        //    while (index <= 10)
        //    {
        //        var xpath = $"(//div[contains(@class, 'dx-radiobutton')]//div[contains(text(), '{yes}')])[{index}]";
        //        var radioButtonWithYes = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));

        //        radioButtonWithYes.Click();

        //        index++;
        //        Thread.Sleep(500);
        //    }
        //}
    }
}