using Microsoft.Playwright;
using NUnit.Framework;

namespace MyCompany.Tests
{
    [TestFixture]
    public class AuthorizationTests : BaseTest
    {
        [Test]
        [Description("Проверка открытия главной страницы сайта для тренировки")]
        public async Task Test_OpenMainPage_ShouldShowCorrectTitle()
        {
            // 1. Открываем сайт (можете заменить на любой публичный)
            await Page.GotoAsync("https://wikipedia.org");

            // 2. Ищем элемент (например, заголовок или текст)
            var languageButton = Page.GetByRole(AriaRole.Heading, new() { Name = "Wikipedia" });

            // 3. Ассерт — проверка, что элемент виден на экране
            await Assertions.Expect(languageButton).ToBeVisibleAsync();
        }
    }
}
