using System;
using System.Collections.Generic;
using System.Threading;
using Moq;
using NUnit.Framework;
using University.Info.Domain;
using University.Info.Interfaces.Repository;

namespace University.Info.Application.Tests
{
    public class UniversityInformationRetrieverTests
    {
        [Test]
        public void Given_Null_University_Information_Provider_When_Calling_Constructor_Then_Throws_Argument_Null_Exception()
        {

            UniversityInformationRetriever universityInformationRetriever = null;

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => universityInformationRetriever = CreateDefaultUniversityInformationRetriever( null));


            //Assert
            Assert.IsNotNull(exception);
            Assert.IsTrue(!string.IsNullOrEmpty(exception.Message));
            Assert.IsNull(universityInformationRetriever);

        }

        private static UniversityInformationRetriever CreateDefaultUniversityInformationRetriever(IUniversityInformationProvider provider)
        {
            return new UniversityInformationRetriever(provider);
        }

        [Test]
        public void When_Calling_Get_University_Information_By_Country_Then_Returns_List_Of_University_Information()
        {
            //Arrange
            var mockUniversityInformationProvider = CreateMockProductStockStatusProviderThatReturnsUniversityInformation();

            var universityInformationRetriever = CreateDefaultUniversityInformationRetriever(mockUniversityInformationProvider.Object);

            IEnumerable<UniversityInformation> informations = null;

            //Act
            Assert.DoesNotThrowAsync(async () => informations = await universityInformationRetriever.GetUniversityInformationByCountry(It.IsAny<string>()).ConfigureAwait(false));

            //Assert
            Assert.IsNotNull(informations);
            Assert.IsNotEmpty(informations);

            mockUniversityInformationProvider.Verify(provider => provider.GetUniversityInformationByCountry(It.IsAny<string>()), Times.Once);
            mockUniversityInformationProvider.VerifyNoOtherCalls();
        }

        private Mock<IUniversityInformationProvider> CreateMockProductStockStatusProviderThatReturnsUniversityInformation()
        {
            var universityInformation = new List<UniversityInformation>
            {
                new UniversityInformation() { UniversityName = "Test"}
            };

            var mockUniversityInformationProvider = CreateMockUniversityInformationProvider();
            mockUniversityInformationProvider
                .Setup(provider => provider.GetUniversityInformationByCountry(It.IsAny<string>()))
                .ReturnsAsync(universityInformation);
            return mockUniversityInformationProvider;
        }

        private static Mock<IUniversityInformationProvider> CreateMockUniversityInformationProvider()
        {
            return new Mock<IUniversityInformationProvider>();
        }



    }
}
