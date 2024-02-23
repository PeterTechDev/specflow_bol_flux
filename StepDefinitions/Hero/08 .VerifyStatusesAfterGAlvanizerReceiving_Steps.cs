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
    public sealed class VerifyStatusesAfterGAlvanizerReceiving_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public VerifyStatusesAfterGAlvanizerReceiving_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }
    }
}