using NUnit.Framework;
using System.Linq;
using Xamarin.UITest;

namespace App1.UnitTestProject
{
    [TestFixture(Platform.Android)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void TakeFirstScreenShot()
        {
            app.Screenshot("This is the first screen.");
        }

        [Test]
        public void ClickThirdItemThenGoBack()
        {
            app.Screenshot("Home Screen");

            var thirdItemExists = app.Query("Third item").Any();
            Assert.IsTrue(thirdItemExists);
            app.Tap(x => x.Text("Third item"));

            app.Screenshot("Item Details Screen");
            app.WaitForElement(x => x.Marked("Description:"));
            var descrptionExists = app.Query("This is an item description.").Any();
            Assert.IsTrue(descrptionExists);
            app.Back();

            app.WaitForElement(x => x.Marked("About"));
            var aboutExists = app.Query("About").Any();
            Assert.IsTrue(aboutExists);
            var addExists = app.Query("Add").Any();
            Assert.IsTrue(addExists);
            app.Tap(x => x.Text("Add"));

            app.Screenshot("Add Item Screen");
            app.WaitForElement(x => x.Marked("Description"));
            app.Back();

        }

    }
}

