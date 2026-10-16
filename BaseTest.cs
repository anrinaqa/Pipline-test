using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Allure.NUnit;

namespace MyCompany.Tests
{
    [AllureNUnit] // Интеграция с Allure-отчетами
    public class BaseTest : PageTest
    {
        [SetUp]
        public async Task SetupBeforeEachTest()
        {
            // Здесь можно прописать общие настройки, например, размеры экрана
            await Context.Tracing.StartAsync(new()
            {
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
        }

        [TearDown]
        public async Task TearDownAfterEachTest()
        {
            // Если тест упал, Allure прикрепит скриншот автоматически
            await Context.Tracing.StopAsync(new()
            {
                Path = Path.Combine(TestContext.CurrentContext.WorkDirectory, "allure-results", "trace.zip")
            });
        }
    }
}