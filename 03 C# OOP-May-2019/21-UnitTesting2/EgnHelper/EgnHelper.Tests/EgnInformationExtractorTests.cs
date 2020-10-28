using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;

namespace EgnHelper.Tests
{
    public class EgnInformationExtractorTests
    {
        private EgnInformationExtractor informationExtractor;

        [SetUp]
        public void SetUp()
        {
            informationExtractor
                = new EgnInformationExtractor(new EgnValidator());
        }
        //610105750
        //ЕГН на мъж, роден на 5 януари 1961 г. в регион София - окръг

        [Test]
        public void ExtractInformationForEgn610105750IsWorkCorrectly()
        {
            EgnInformation information = informationExtractor.Extract("6101057509");

            Assert.That(information.PlaceOfBirth, Is.EqualTo("София - окръг"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(1961, 1, 5)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на мъж, роден на 5 януари 1961 г. в регион София - окръг"));
        }

        //8032056031
        //ЕГН на жена, родена на 5 декември 1880 г. в регион Смолян

        [Test]
        public void ExtractInformationForEgn8032056031IsWorkCorrectly()
        {
            EgnInformation information = informationExtractor.Extract("8032056031");

            Assert.That(information.PlaceOfBirth, Is.EqualTo("Смолян"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(1880, 12, 5)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Female));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на жена, родена на 5 декември 1880 г. в регион Смолян"));
        }

        //7552010005
        //ЕГН на мъж, роден на 1 декември 2075 г. в регион Благоевград

        [Test]
        public void ExtractInformationForEgn7552010005IsWorkCorrectly()
        {
           EgnInformation information = informationExtractor.Extract("7552010005");

            Assert.That(information.PlaceOfBirth, Is.EqualTo("Благоевград"));
            Assert.That(information.DateOfBirth, Is.EqualTo(new DateTime(2075, 12, 1)));
            Assert.That(information.Sex, Is.EqualTo(Sex.Male));
            Assert.That(information.ToString(), Is.EqualTo("ЕГН на мъж, роден на 1 декември 2075 г. в регион Благоевград"));
        }

        [Test]
        public void TestExtractWithNullValue()
        {
            Assert.That(() => informationExtractor.Extract(null), 
                Throws.ArgumentNullException);
        }

        [Test]
        public void TestExtractWithInvalidEgn()
        {
            Assert.That(() => informationExtractor.Extract("dfgdf"),
                Throws.ArgumentException);
        }

        [Test]
        public void TestInvalidEgnWithMockObject()
        {
            var alwaysFalse = new Mock<IEgnValidator>();
            alwaysFalse.Setup(x => x.IsValid(It.IsAny<string>()))
                .Returns(false);

            var mockEgnInformationExtractor 
                = new EgnInformationExtractor(alwaysFalse.Object);

            Assert.That(() => mockEgnInformationExtractor.Extract("dfgdf"),
               Throws.ArgumentException);
        }
    }
}
