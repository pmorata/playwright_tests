using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using netTimeAutomation.Pages.Sections;
using System.Diagnostics.CodeAnalysis;
using static netTimeAutomation.Pages.Sections.LeftPanel;
using static netTimeAutomation.Pages.Widgets.ChangeLanguage;

namespace netTimeAutomation.Pages {
    public class DashboardPage {
        #region private properties
        // TODO: todos los localizadores deberian seguir el estandar de la industria, el data-testid
        // Crear tareas para añadir el tag en los controles del modulo de manager
        private ILocator listEmployees => page.Locator("id=BTCOMBO");
        private ILocator dropDownMarkingType => page.Locator("id=WGT_CONTAINER");
        private ILocator buttonMark => page.Locator("id=BTN");
        //private ILocator markingType => page.Locator("id=gg-row");
        private ILocator markingType(int? index) => page.Locator($"id=gg-row" + index.HasValue is null ? "entity-id={index}" : "");
        private readonly IPage page;
        #endregion


        public LeftPanel LeftPanel => new LeftPanel(page);
        public TopBar TopBar => new TopBar(page);

        public DashboardPage(IPage page) {
            this.page = page;
        }

        public async Task ExpandMarkingTypeDropDown() 
        {
            await dropDownMarkingType.ClickAsync();
        }

        //public async Task SelectMarkingType(string markingTypeName) {            
        //    await markingType().GetByText(markingTypeName).ClickAsync();            
        //}
        //public async Task SelectMarkingType(int markingTypeName) {
        //    return page.Locator($"id=gg-row:has-text(\"{markingTypeName}\")").ClickAsync();
        //}
    }
}
