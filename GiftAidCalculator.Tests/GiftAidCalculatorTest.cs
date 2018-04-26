using NUnit.Framework;
using Moq;

namespace GiftAidCalculator.Tests
{
    [TestFixture]
    public class GiftAidCalculator1Test
    {
        
        [Test]
        public void Story1()
        {
            var gac = new GiftAidCalculator1(20m);
            
            Assert.AreEqual(20m, gac.TaxRate, "Tax rate is correctly set");
            Assert.AreEqual(25m, gac.GiftAidAmount(100m), "Gift aid is calculated correctly for tax rate 20%");
            Assert.AreEqual(0m, gac.GiftAidAmount(0m), "Gift aid is calculated correctly for amount 0");
        }


        [Test]
        public void Story2()
        {
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(ds => ds.GetTaxRate()).Returns(20m);
            
            var gac = new GiftAidCalculator2(mockDataStore.Object);
            Assert.AreEqual(20m, gac.TaxRate, "Tax rate is correctly retrieved from data store");
            Assert.AreEqual(25m, gac.GiftAidAmount(100), "Gift aid is calculated correctly for tax rate 20% retrieved from data store");

            mockDataStore.Setup(ds => ds.GetTaxRate()).Returns(15m);
            Assert.AreEqual(15m, gac.TaxRate, "Tax rate changes when data store updates");
        }


        [Test]
        public void Story3()
        {
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(ds => ds.GetTaxRate()).Returns(15m);

            var gac = new GiftAidCalculator3(mockDataStore.Object);
            Assert.AreEqual(17.65m, gac.GiftAidAmount(100), "Gift aid is correctly rounded up to 2nd place");
            Assert.AreEqual(17.70m, gac.GiftAidAmount(100.29m), "Gift aid is correctly rounded up 1st place");
            Assert.AreEqual(18.00m, gac.GiftAidAmount(102), "Gift aid is correctly rounded up to whole integer");
            Assert.AreEqual(17.47m, gac.GiftAidAmount(99), "Gift aid is correctly rounded down");
        }


        [Test]
        public void Story4()
        {
            var mockDataStore = new Mock<IDataStore>();
            mockDataStore.Setup(ds => ds.GetTaxRate()).Returns(20m);
            mockDataStore.Setup(ds => ds.GetEventSupplementRate("running")).Returns(5m);
            mockDataStore.Setup(ds => ds.GetEventSupplementRate("swimming")).Returns(3m);

            var gac = new GiftAidCalculator4(mockDataStore.Object);
            Assert.AreEqual(25m, gac.GiftAidAmount(100), "Gift aid is correctly calculated when no event type is supplied");
            Assert.AreEqual(25m, gac.GiftAidAmount(100, "cycling"), "Gift aid is correctly calculated when non-supported event type is supplied");
            Assert.AreEqual(26.25m, gac.GiftAidAmount(100, "running"), "Gift aid is correctly calculated for running events");
            Assert.AreEqual(25.75m, gac.GiftAidAmount(100, "swimming"), "Gift aid is correctly calculated for running events");            
        }
    }
}