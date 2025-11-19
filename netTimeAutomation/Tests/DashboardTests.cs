using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using netTimeAutomation.Pages;
using System.Text.RegularExpressions;
using static netTimeAutomation.Pages.Widgets.ChangeLanguage;

namespace netTimeAutomation.Tests;

public class DashboardTests{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : PageTest {        
        private DashboardPage dashboardPage;
        private Pages.Widgets.ChangeLanguage changeLanguage;
        private Pages.Sections.LeftPanel leftPanel;
        private LoginPage loginPage;

        [SetUp]
        public void Setup() {
            loginPage = new LoginPage(Page);
            dashboardPage = new Pages.DashboardPage(Page);
            changeLanguage = new Pages.Widgets.ChangeLanguage(Page);
        }

        [Test]
        public async Task EmployeeCanChangeLanguageToFrench() {
            await loginPage.GoTo();
            await loginPage.LoginForm(Environment.GetEnvironmentVariable("EmployeeLogin") ?? "", Environment.GetEnvironmentVariable("EmployeePassword") ?? "");
            await dashboardPage.LeftPanel.ButtonConfiguration.ClickAsync();
            await dashboardPage.LeftPanel.ButtonChangeLanguage.ClickAsync();
            await Expect(changeLanguage.ButtonSave).ToBeVisibleAsync();
            await Expect(changeLanguage.ButtonClose).ToBeVisibleAsync();
            await Expect(changeLanguage.ListLanguages).ToBeVisibleAsync();
            await changeLanguage.ListLanguages.ClickAsync();            
            await Expect(changeLanguage.Language(Languages.French)).ToBeVisibleAsync();
            await changeLanguage.Language(Languages.French).ClickAsync();
            await changeLanguage.ButtonSave.ClickAsync();            
            //await Expect(Page.Locator("#BT_CLOSE")).ToBeVisibleAsync();
        }
    }
}
