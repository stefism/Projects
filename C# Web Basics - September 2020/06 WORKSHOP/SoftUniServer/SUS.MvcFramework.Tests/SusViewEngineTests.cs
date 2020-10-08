using System;
using Xunit;

namespace SUS.MvcFramework.Tests
{
    public class SusViewEngineTests
    {
        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("IfElseFor")]
        [InlineData("ViewModel")]
        public void TestGetHtml(string fileName)
        {
            var viewModel = new TestViewModel
            {
                DateOfBirth = new DateTime(2019, 6, 1),
                Name = "Na baba kucheto",
                Price = 12345.67m
            };

            IViewEngine viewEngine = new SusViewEngine();
            var result = viewEngine.GetHtml(...., viewModel);
            Assert.Equal(...., result);

            string view = @"";
        }

        public class TestViewModel
        {
            public string Name { get; set; }

            public decimal Price { get; set; }

            public DateTime DateOfBirth { get; set; }
        }
    }
}
