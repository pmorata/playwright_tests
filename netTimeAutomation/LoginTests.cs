using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace netTimeAutomation;

public class LoginTests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : PageTest {
        private Pages.LoginPage loginPage;
        private Pages.DashboardPage dashboardPage;

        [SetUp]
        public void Setup() {
            loginPage = new Pages.LoginPage(Page);
            dashboardPage = new Pages.DashboardPage(Page);
        }

        [Test]
        public async Task UserNavigatesToDashboard() {            
            await loginPage.GoTo();
            await loginPage.LoginForm(Environment.GetEnvironmentVariable("EmployeeLogin") ?? "", Environment.GetEnvironmentVariable("EmployeePassword") ?? "");
            await Expect(dashboardPage.LetPanel.ButtonMarkings).ToBeVisibleAsync();
            await Expect(dashboardPage.LetPanel.ButtonSchedule).ToBeVisibleAsync();
            await Expect(dashboardPage.LetPanel.ButtonPlanners).ToBeVisibleAsync();
            await Expect(dashboardPage.LetPanel.ButtonLists).ToBeVisibleAsync();
            await Expect(dashboardPage.LetPanel.ButtonDocuments).ToBeVisibleAsync();
            await Expect(dashboardPage.LetPanel.ButtonConfiguration).ToBeVisibleAsync();
            await Expect(dashboardPage.LetPanel.ButtonCreateMark).ToBeVisibleAsync();
            await Expect(dashboardPage.LetPanel.ImageLogo).ToBeVisibleAsync();
            await Expect(dashboardPage.TopBar.ButtonHelp).ToBeVisibleAsync();
            await Expect(dashboardPage.TopBar.ButtonNotifications).ToBeVisibleAsync();
            await Expect(dashboardPage.TopBar.ButonLogout).ToBeVisibleAsync();
        }

        [Test]
        public async Task UserLoginsWithAuthenticationForm() {
            await loginPage.GoTo();
            await loginPage.LoginForm(Environment.GetEnvironmentVariable("EmployeeLogin") ?? "", Environment.GetEnvironmentVariable("EmployeePassword") ?? "");
            //await Page.WaitForTimeoutAsync(10000);


            //await Page.GotoAsync("https://playwright.dev");

            //// Expect a title "to contain" a substring.
            //await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
            //// Click the get started link.
            //var getStarted = Page.GetByRole(AriaRole.Link, new() { Name = "Get started" });
            //await Expect(getStarted).ToBeVisibleAsync();
            //await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");
            //await getStarted.ClickAsync();

            //await Expect(Page).ToHaveURLAsync(new Regex(".*intro"));
            //// Expects page to have a heading with the name of Installation.
            //await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
        }
    }
}
