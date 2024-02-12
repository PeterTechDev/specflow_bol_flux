using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Reflection.Metadata;
using TechTalk.SpecFlow.CommonModels;



namespace CreateBolFlow.StepDefinitions.Hero
{
    [Binding]
    public sealed class SearchBOL_Steps
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public SearchBOL_Steps(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            wait = fixture.Wait;
        }

        [When(@"the user enters ""([^""]*)"" into the search field")]
        public void WhenTheUserEntersIntoTheSearchField(string bolCode)
        {
            var searchField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#hero-next-datagrid > div > div.dx-datagrid-headers.dx-datagrid-nowrap > div > table > tbody > tr.dx-row.dx-column-lines.dx-datagrid-filter-row > td:nth-child(4) > div > div.dx-editor-container > div > div > div.dx-texteditor-input-container > input")));
            searchField.SendKeys(bolCode);
        }

        [Then(@"""([^""]*)"" should be displayed in the search results")]
        public void ThenShouldBeDisplayedInTheSearchResults(string bolCode)
        {
            var bolItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath($"//td[text()='{bolCode}']")));
            Assert.True(bolItem.Displayed);
        }
    }
}