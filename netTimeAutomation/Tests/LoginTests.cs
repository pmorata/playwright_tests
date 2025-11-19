using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace netTimeAutomation.Tests;

public class LoginTests{
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
        public async Task EmployeeLoginsAndSeesDefaultButtons() {
            await loginPage.LoginEmployee();
            await Expect(dashboardPage.LeftPanel.ButtonMarkings).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonSchedule).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonPlanners).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonLists).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonDocuments).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonConfiguration).ToBeVisibleAsync();
            // El marcaje remoto es opcional, por eso se comenta la verificacion de su boton
            //await Expect(dashboardPage.LeftPanel.ButtonCreateMark).ToBeVisibleAsync();
            await CheckHeaderAndLogo();
        }

        [Test]
        public async Task ManagerLoginsAndSeesDefaultButtons() {
            await loginPage.LoginManagement();
            await Expect(dashboardPage.LeftPanel.ButtonPeople).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonTimetable).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonLists).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonAccesses).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonVisits).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonDocuments).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ButtonConfiguration).ToBeVisibleAsync();
            await CheckHeaderAndLogo();
        }

        private async Task CheckHeaderAndLogo() {
            await Expect(dashboardPage.TopBar.ButtonHelp).ToBeVisibleAsync();
            await Expect(dashboardPage.TopBar.ButtonNotifications).ToBeVisibleAsync();
            await Expect(dashboardPage.TopBar.ButonLogout).ToBeVisibleAsync();
            await Expect(dashboardPage.LeftPanel.ImageLogo).ToBeVisibleAsync();
        }


        [TearDown]
        public async Task CloseUserSession() {
            await dashboardPage.TopBar.LogOut();
        }
        //[Test]
        //public async Task UserLoginsWithAuthenticationForm() {
        //    await loginPage.GoTo();
        //    await loginPage.LoginForm(Environment.GetEnvironmentVariable("EmployeeLogin") ?? "", Environment.GetEnvironmentVariable("EmployeePassword") ?? "");            
        //}

    }
}
