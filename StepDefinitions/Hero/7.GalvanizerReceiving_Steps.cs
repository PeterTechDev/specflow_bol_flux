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
    public sealed class GalvanizerReceiving_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public GalvanizerReceiving_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [Then(@"the Receive page for ""([^""]*)"" is displayed")]
        public void ThenTheReceivePageForIsDisplayed(string bolNumber)
        {
            var receivePage = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                ElementIsVisible(By.XPath($"//div[contains(text(), 'Receive - BOL #: {bolNumber}')]")));
            Assert.True(receivePage.Displayed);
        }

        [When(@"the user fills in a valid Internal job number ""([^""]*)""")]
        public void WhenTheUserFillsInAValidInternalJobNumber(string internalJobNumber)
        {
            var internalJobNumberinput = driver.FindElement(By.CssSelector("input[name='InternalJobNumber']"));
            internalJobNumberinput.Clear();
            internalJobNumberinput.SendKeys(internalJobNumber);
        }

        [When(@"the user enters a valid estimated coating completion date ""([^""]*)""")]
        public void WhenTheUserEntersAValidEstimatedCoatingCompletionDate(string completionDate)
        {
            var dateInput = driver.FindElement(By.CssSelector("#EstimatedCoatingCompletionDate .dx-texteditor-input"));
            dateInput.Clear();
            dateInput.SendKeys(completionDate);

        }

        [When(@"the user fills in the pieces received number ""([^""]*)""")]
        public void WhenTheUserFillsInThePiecesReceivedNumber(string piecesReceived)
        {
            var piecesReceivedTd = driver.FindElement(By.
                XPath("//tbody[@role='presentation']//td[@role='gridcell'][@aria-colindex='1'][@tabindex='0']"));
            piecesReceivedTd.Click();
            var inputElement = driver.FindElement(By.XPath("//td[@role='gridcell'][@aria-colindex='1'][@tabindex='0']//input[contains(@class, 'dx-texteditor-input')]"));

            inputElement.SendKeys(piecesReceived);
        }


        [When(@"the user attaches a signed BOL picture")]
        public void WhenTheUserAttachesASignedBOLPicture()
        {
            var signedBolPictureInput = driver.FindElement(By.CssSelector("input[type='file'][id='fileType6']"));
            var filePath = @"C:\bolPics\steel1.jpg";

            signedBolPictureInput.SendKeys(filePath);
        }

        [Then(@"the message ""([^""]*)"" is displayed")]
        public void ThenTheMessageIsDisplayed(string message)
        {
            var heroSyncedStatusDt = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//span[contains(text(), '{message}')]")));
            Assert.True(heroSyncedStatusDt.Displayed);
        }
    }
}