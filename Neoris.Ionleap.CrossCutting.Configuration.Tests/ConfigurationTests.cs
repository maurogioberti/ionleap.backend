using Neoris.Ionleap.CrossCutting.Configuration.DataMembers;
using Neoris.Ionleap.CrossCutting.Utils.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Neoris.Ionleap.CrossCutting.Configuration.Tests
{
    [TestClass]
    public class ConfigurationTests
    {

        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void Security_OnPropertyNull_FileCanBeRead()
        {
            //Arrange
            var security = ConfigurationModule.Security;

            //Act
            bool verify = security.PropertiesNullOrDefault(x => x.TokenMinutesAlive,
                                                            x => x.TokenSecretKey);
            //Assert
            Assert.IsFalse(verify);
        }

        [TestMethod]
        public void Security_OnPropertyNull_FileCannotBeRead()
        {
            //Arrange
            var security = Mock.Of<Security>(m =>
                                            m.TokenSecretKey == null &&
                                            m.TokenMinutesAlive == default);
            //Act
            bool verify = security.PropertiesNullOrDefault(x => x.TokenMinutesAlive,
                                                            x => x.TokenSecretKey);
            //Assert
            Assert.IsTrue(verify);
        }
    }
}
