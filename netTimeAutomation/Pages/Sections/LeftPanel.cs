using Microsoft.Playwright;

namespace netTimeAutomation.Pages.Sections {
    public class LeftPanel{
        #region private properties
        // TODO: todos los localizadores deberian seguir el estandar de la industria, el data-testid
        // Crear tareas para añadir el tag en los controles del modulo de manager
        private readonly IPage page;
        #endregion

        #region public Locators
        public ILocator ButtonMarkings => page.Locator("[src='./assets/svg/white/moviments_brand.svg']");
        public ILocator ButtonSchedule => page.Locator("[src='./assets/svg/white/calendar_brand.svg']");
        public ILocator ButtonPlanners => page.Locator("[src='./assets/svg/white/planificacion_brand.svg']");
        public ILocator ButtonLists => page.Locator("[src='./assets/svg/white/listado_brand.svg']");
        public ILocator ButtonDocuments => page.Locator("[src='./assets/svg/white/consulta_brand.svg']");
        public ILocator ButtonConfiguration => page.Locator("[src='./assets/svg/white/setting_brand.svg']");
        public ILocator ButtonCreateMark => page.Locator("[src='./assets/svg/white/clock_brand.svg']");
        public ILocator ImageLogo => page.Locator("[src='./assets/img/logos/ntOneLogoWhite.svg']");

        public ILocator Version => page.GetByText("/^Version");
        #endregion

        protected enum Languages {            
            Catalan = 1,
            English = 2,
            Spanish = 3,            
            Euskara = 4,
            French = 5,
            Portuguese = 6
        }

        public LeftPanel(IPage page) {
            this.page = page;
        }

        public async Task ChangeLanguage(Languages newLanguage){

        }
    }
}
