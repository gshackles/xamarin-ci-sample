using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace TipCalc.UITests
{
    [TestFixture]
    public class TipCalculationTests
    {
        private IApp _app;

        [SetUp]
        public void SetUp()
        {
            switch (TestEnvironment.Platform)
            {
                case TestPlatform.Local:
                    var appFile = 
                        new DirectoryInfo(Path.Combine("..", "..", "testapps"))
                            .GetFileSystemInfos()
                            .OrderByDescending(file => file.LastWriteTimeUtc)
                            .First(file => file.Name.EndsWith(".app") || file.Name.EndsWith(".apk"));

                    _app = appFile.Name.EndsWith(".app")
                        ? ConfigureApp.iOS.AppBundle(appFile.FullName).StartApp() as IApp
                        : ConfigureApp.Android.ApkFile(appFile.FullName).StartApp();
                    break;
                case TestPlatform.TestCloudiOS:
                    _app = ConfigureApp.iOS.StartApp();
                    break;
                case TestPlatform.TestCloudAndroid:
                    _app = ConfigureApp.Android.StartApp();
                    break;
            }
        }

        [Test]
        public void CalculateTip()
        {
			var subTotal = 10M;
			var postTaxTotal = 12M;

			_app.EnterText(e => e.Marked("SubTotal"), subTotal.ToString());
			_app.Screenshot("When I enter a subtotal");

			_app.EnterText(e => e.Marked("PostTaxTotal"), postTaxTotal.ToString());
			_app.Screenshot("And I enter the post-tax total");

			var tipPercent = decimal.Parse(_app.Query(e => e.Marked("TipPercent")).Single().Text) / 100;
			var tipAmount = decimal.Parse(_app.Query(e => e.Marked("TipAmount")).Single().Text.Substring(1));
			var total = decimal.Parse(_app.Query(e => e.Marked("Total")).Single().Text.Substring(1));

			var expectedTipAmount = subTotal * tipPercent;
			Assert.AreEqual(expectedTipAmount, tipAmount);

			var expectedTotal = postTaxTotal + expectedTipAmount;
			Assert.AreEqual(expectedTotal, total);

			_app.Screenshot("Then the tip and total are calculated correctly");
        }
    }
}

