using Microsoft.Playwright;

namespace netTimeAutomation.Pages.Sections {
    public class TopBar {
        #region private properties
        // TODO: todos los localizadores deberian seguir el estandar de la industria, el data-testid
        // Crear tareas para añadir el tag en los controles del modulo de manager
        private readonly IPage page;
        #endregion

        #region public Locators
        public ILocator DateAndTime => page.Locator("#DIV_DATE_TIME");
        public ILocator ButtonHelp => page.Locator("#BT_HELP");
        public ILocator ButtonNotifications => page.Locator("#BT_NOTIF");
        public ILocator ButonLogout => page.Locator("#BT_LOGOUT");
        #endregion

        public TopBar(IPage page) {
            this.page = page;
        }

        public async Task LogOut() {
            await ButonLogout.ClickAsync();
        }

        public async Task ShowHelp() {
            await ButtonHelp.ClickAsync();
        }

        public async Task ShowNotifications() {
            await ButtonNotifications.ClickAsync();
        }
    }
}