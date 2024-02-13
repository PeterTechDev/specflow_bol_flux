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
    public sealed class VerifyStatusesBeforeAction_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public VerifyStatusesBeforeAction_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [Then(@"the Rubicon status should be ""([^""]*)""")]
        public void ThenTheRubiconStatusShouldBe(string rubiconExpectedStatus)
        {
            Thread.Sleep(1000);
            IWebElement rubiconStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#hero-next-datagrid > div > div.dx-datagrid-rowsview.dx-datagrid-nowrap.dx-last-row-border.dx-scrollable.dx-visibility-change-handler.dx-scrollable-both.dx-scrollable-simulated > div > div > div.dx-scrollable-content > div > table > tbody > tr.dx-row.dx-data-row.dx-row-lines.dx-column-lines > td:nth-child(5)")));
            Assert.Equal(rubiconExpectedStatus, rubiconStatus.Text);
        }

        [Then(@"the Hero Status should be ""([^""]*)""")]
        public void ThenTheHeroStatusShouldBe(string heroExpectedStatus)
        {
            Thread.Sleep(2000);
            IWebElement heroStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#hero-next-datagrid > div > div.dx-datagrid-rowsview.dx-datagrid-nowrap.dx-last-row-border.dx-scrollable.dx-visibility-change-handler.dx-scrollable-both.dx-scrollable-simulated > div > div > div.dx-scrollable-content > div > table > tbody > tr.dx-row.dx-data-row.dx-row-lines.dx-column-lines > td:nth-child(6)")));
            Assert.Equal(heroExpectedStatus, heroStatus.Text);
        }

        [Then(@"the QC Inspection status should be ""([^""]*)""")]
        public void ThenTheQCInspectionStatusShouldBe(string qcExpectedStatus)
        {
            Thread.Sleep(2000);
            IWebElement qcStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#hero-next-datagrid > div > div.dx-datagrid-rowsview.dx-datagrid-nowrap.dx-last-row-border.dx-scrollable.dx-visibility-change-handler.dx-scrollable-both.dx-scrollable-simulated > div > div > div.dx-scrollable-content > div > table > tbody > tr.dx-row.dx-data-row.dx-row-lines.dx-column-lines > td:nth-child(10)")));
            Assert.Equal(qcExpectedStatus, qcStatus.Text);
        }

        [Then(@"the Shipping Inspection status should be ""([^""]*)""")]
        public void ThenTheShippingInspectionStatusShouldBe(string shippingExpectedStatus)
        {
            Thread.Sleep(2000);
            IWebElement shippingStatus = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#hero-next-datagrid > div > div.dx-datagrid-rowsview.dx-datagrid-nowrap.dx-last-row-border.dx-scrollable.dx-visibility-change-handler.dx-scrollable-both.dx-scrollable-simulated > div > div > div.dx-scrollable-content > div > table > tbody > tr.dx-row.dx-data-row.dx-row-lines.dx-column-lines > td:nth-child(12)")));
            Assert.Equal(shippingExpectedStatus, shippingStatus.Text);
        }
    }
}