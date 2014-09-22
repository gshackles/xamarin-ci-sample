using NUnit.Framework;
using TipCalc;

namespace TipCalc.Tests.Models
{
    [TestFixture]
    public class TipCalcModelTests
    {
        [Test]
        public void TipPercent_Updated_TipAmountAndTotalAreUpdated()
        {
            var model = new TipCalcModel
            {
                SubTotal = 10,
                PostTaxTotal = 12
            };

            model.TipPercent = 20;

            Assert.AreEqual(14, model.Total);
            Assert.AreEqual(2, model.TipAmount);
        }
    }
}