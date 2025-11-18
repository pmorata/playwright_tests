using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netTimeAutomation.Pages {
    public class LoginPage {
        #region private properties
        // TODO: todos los localizadores deberian seguir el estandar de la industria, el data-testid
        // Crear tareas para añadir el tag en los controles del modulo de manager
        private ILocator loginEmployee => page.Locator("#btn-sso-emp");
        private ILocator loginManagement => page.Locator("#btn-sso-usr");
        private ILocator buttonLoginForm => page.Locator("#normal-login");
        private ILocator linkPasswordRecovery => page.Locator("#recovery-link");
        private ILocator textboxUser => page.Locator("#input-user");
        private ILocator textboxPassword => page.Locator("#input-password");
        private ILocator buttonLogin => page.GetByRole(AriaRole.Button, new() { Name = "Login" });
        private ILocator buttonSSO => page.GetByRole(AriaRole.Button, new() { Name = "SSO" });
        private readonly IPage page;
        #endregion

        public LoginPage(IPage page) {
            this.page = page;
        }

        public async Task GoTo() {
            await page.GotoAsync(Environment.GetEnvironmentVariable("netOneURL") ?? "");
        }
        public async Task LoginEmployee() {
            await loginEmployee.ClickAsync();
        }

        public async Task LoginManagement() {
            await loginManagement.ClickAsync();
        }

        public async Task ShowLoginForm() {
            await buttonLoginForm.ClickAsync();
        }
        public async Task ShowSSO() {
            await buttonSSO.ClickAsync();
        }

        public async Task LoginForm(string user, string password) {
            await ShowLoginForm();
            await textboxUser.FillAsync(user);
            await textboxPassword.FillAsync(password);
            await buttonLogin.ClickAsync();
        }
    }
}
