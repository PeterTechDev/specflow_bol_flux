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
    public sealed class VerifyStatusesAfterShipToCustomer_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

    public VerifyStatusesAfterShipToCustomer_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }
    }
}