using Microsoft.VisualStudio.TestTools.UnitTesting;
using CompaniesHouse;

namespace TestCompaniesHouse
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetSpecificcompanyDetails()
        {
            //Act

            string link = "/company/06226088";

            //Arrange
            var result = CompaniesHouseQuery.GetSpecificCompanyDetails(link);

            //Assert
        }

        [TestMethod]
        public void TestGetDirectorDetails()
        {
            //Act

            string link = "/company/06226088";

            //Arrange
            var result = CompaniesHouseQuery.GetDirectorDetails(link);

            //Assert
            Assert.AreNotEqual(0, result.Count);
        }
    }
}
