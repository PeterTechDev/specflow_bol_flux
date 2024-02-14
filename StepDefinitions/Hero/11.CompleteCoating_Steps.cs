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



namespace CreateBolFlow.StepDefinitions.Hero
{
    [Binding]
    public sealed class CompleteCoating_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

    public CompleteCoating_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [Then(@"the user attaches a xlsx file")]
        public void ThenTheUserAttachesAXlsxFile()
        {
            var fileInput = driver.FindElement(By.CssSelector("input[type='file'][id='fileType5']"));
            var filePath = @"C:\bolPics\azz5.xlsx";

            fileInput.SendKeys(filePath);
        }

        [Then(@"the user enters a valid available pickup date ""([^""]*)""")]
        public void ThenTheUserEntersAValidAvailablePickupDate(string pickupDate)
        {
            var AvailableDateInput = driver.FindElement(By.CssSelector("#AvailableToPickupDate .dx-texteditor-input"));
            AvailableDateInput.Clear();
            AvailableDateInput.SendKeys(pickupDate);
        }

        [Then(@"the user fills in the pieces coated number ""([^""]*)""")]
        public void ThenTheUserFillsInThePiecesCoatedNumber(string piecesCoated)
        {
            var piecesReceivedTd = driver.FindElement(By.
                XPath("//tbody[@role='presentation']//td[@role='gridcell'][@aria-colindex='1'][@tabindex='0']"));
            piecesReceivedTd.Click();
            var inputElement = driver.FindElement(By.XPath("//td[@role='gridcell'][@aria-colindex='1'][@tabindex='0']//input[contains(@class, 'dx-texteditor-input')]"));

            inputElement.SendKeys(piecesCoated);
        }
    }
}