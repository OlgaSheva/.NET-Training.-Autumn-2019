using NUnit.Framework;
using System.Collections.Generic;
using Task_1_BasicXML;
using Task_1_BasicXML.Models;
using Task_1_BasicXML.UriExtensions;

namespace Task1_BasicXML_Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToURIAdressModelTest_StringUri_ValidUriAdressModel()
        {
            string uri = "https://github.com/AnzhelikaKravchuk?tab=repositories";
            var expected = new URIAdress
            {
                HostName = "github.com",
                URNSegments = new List<string>() { "AnzhelikaKravchuk" },
                Parameters = new List<URNParameters>() { new URNParameters() { Value = "tab", Key = "repositories", } },
            };
            var parser = new URIParser();
            var actual = parser.Parse(uri).ToURIAdressModel();

            Assert.AreEqual(expected.HostName, actual.HostName);
            Assert.AreEqual(expected.URNSegments, actual.URNSegments);
            Assert.AreEqual(expected.Parameters[0].Key, actual.Parameters[0].Key);
            Assert.AreEqual(expected.Parameters[0].Value, actual.Parameters[0].Value);
        }
    }
}