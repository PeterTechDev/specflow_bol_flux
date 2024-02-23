﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace CreateBolFlow.Features.Hero
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class _17_VerifyStatuses_AfterTicketCreationFeature : object, Xunit.IClassFixture<_17_VerifyStatuses_AfterTicketCreationFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "17.VerifyStatusesAfterTicketCreation.feature"
#line hidden
        
        public _17_VerifyStatuses_AfterTicketCreationFeature(_17_VerifyStatuses_AfterTicketCreationFeature.FixtureData fixtureData, CreateBolFlow_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/Hero", "17. Verify Statuses - After Ticket Creation", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
    #line hidden
#line 4
        testRunner.Given("the Rubicon login page is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 5
        testRunner.When("the user enters valid login credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 6
        testRunner.And("the user clicks the Login button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 7
        testRunner.When("the user clicks on the Vendor Search icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="17. Verify Statuses - After Ticket Creation")]
        [Xunit.TraitAttribute("FeatureTitle", "17. Verify Statuses - After Ticket Creation")]
        [Xunit.TraitAttribute("Description", "17. Verify Statuses - After Ticket Creation")]
        [Xunit.TraitAttribute("Category", "TestCaseKey=PSP-T41")]
        [Xunit.TraitAttribute("Category", "17")]
        [Xunit.InlineDataAttribute("MNST-GALV-GUST-651-1", "TODO", "TODO", "Passed", "Passed", new string[0])]
        public void _17_VerifyStatuses_AfterTicketCreation(string bolNumber, string rubiconStatus, string heroStatus, string qcStatus, string shippingStatus, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "TestCaseKey=PSP-T41",
                    "17"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("bolNumber", bolNumber);
            argumentsOfScenario.Add("rubiconStatus", rubiconStatus);
            argumentsOfScenario.Add("heroStatus", heroStatus);
            argumentsOfScenario.Add("qcStatus", qcStatus);
            argumentsOfScenario.Add("shippingStatus", shippingStatus);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("17. Verify Statuses - After Ticket Creation", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 10
    this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
    this.FeatureBackground();
#line hidden
#line 12
        testRunner.When(string.Format("the user enters \"{0}\" into the search field", bolNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 13
        testRunner.Then(string.Format("\"{0}\" should be displayed in the search results", bolNumber), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 14
        testRunner.Then(string.Format("the Rubicon status should be \"{0}\"", rubiconStatus), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 15
        testRunner.And(string.Format("the Hero Status should be \"{0}\"", heroStatus), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 16
        testRunner.And(string.Format("the QC Inspection status should be \"{0}\"", qcStatus), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 17
        testRunner.And(string.Format("the Shipping Inspection status should be \"{0}\"", shippingStatus), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                _17_VerifyStatuses_AfterTicketCreationFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                _17_VerifyStatuses_AfterTicketCreationFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion