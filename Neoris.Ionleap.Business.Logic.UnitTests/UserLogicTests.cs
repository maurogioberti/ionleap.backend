using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Neoris.Ionleap.Business.Logic.Abstractions.Security;
using Neoris.Ionleap.Business.Logic.Implementations.Security;
using Neoris.Ionleap.Business.Logic.UnitTests.Infrastructure;
using Neoris.Ionleap.ResourceAccess.Adapters.Abstractions.Security;
using Neoris.Ionleap.ResourceAccess.Entities.Security;
using System;
using System.Collections.Generic;

namespace Neoris.Ionleap.Business.Logic.UnitTests
{
    [TestClass]
    public class UserLogicTests : TestBase<UserLogic>
    {
        private Mock<IUserAdapter> _userAdapter;
        private Mock<IRoleLogic> _roleLogic;
        private Mock<IPermissionLogic> _permissionLogic;

        [TestInitialize]
        public override void Init()
        {
            base.Init();

            _userAdapter = new Mock<IUserAdapter>();
            _roleLogic = new Mock<IRoleLogic>();
            _permissionLogic = new Mock<IPermissionLogic>();

            this.Target = new UserLogic(this._userAdapter.Object, this._roleLogic.Object, this._permissionLogic.Object);
        }

        [TestClass]
        public class Method_UserGranted : UserLogicTests
        {
            [TestInitialize]
            public override void Init()
            {
                base.Init();

                //Stubs
                _userAdapter.Setup(u => u.Get(It.IsAny<string>())).Returns(FakeUserEntity);
            }

            [TestMethod]
            public void User_OnAuthenticate_PasswordFailed()
            {
                //Arrange
                string username = "test";
                string password = "tes";

                //Act
                bool authenticated = this.Target.Authenticate(username, password, out string token);

                //Assert
                Assert.IsFalse(authenticated);
            }

            [TestMethod]
            public void User_OnAuthenticate_WrongUserFailed()
            {
                //Arrange
                string username = "tes";
                string password = "test";

                //Act
                bool authenticated = this.Target.Authenticate(username, password, out string token);

                //Assert
                Assert.IsFalse(authenticated);
            }

            [TestMethod]
            public void User_OnAuthenticate_Succeeded()
            {
                //Arrange
                string username = "test";
                string password = "test";

                //Act
                bool authenticated = this.Target.Authenticate(username, password, out string token);

                //Assert
                Assert.IsTrue(authenticated);
            }

            [TestMethod]
            public void NonExistingUser_OnAuthenticate_Failed()
            {
                //Arrange
                string username = "empty";
                string password = "user";

                //Stub Non-User Response
                _userAdapter.Setup(u => u.Get(It.IsAny<string>())).Returns(default(User));

                //Act
                bool authenticated = this.Target.Authenticate(username, password, out string token);

                //Assert
                Assert.IsFalse(authenticated);
            }

            [TestMethod]
            public void AdminUser_OnPermit_Allowed()
            {
                //Arrange
                User fakeAdminUser = this.FakeUserEntity;
                fakeAdminUser.IsAdmin = true;
                _userAdapter.Setup(u => u.Get(It.IsAny<string>())).Returns(fakeAdminUser);
                this.Target.Authenticate("test", "test", out string token);

                //Act
                bool allowed = this.Target.Allowed(default, default);

                //Assert
                Assert.IsTrue(allowed);
            }

            [TestMethod]
            public void AnyUser_OnPermit_Allowed()
            {
                //Arrange
                string username = "test";
                this.StubPermission();

                //Act
                bool allowed = this.Target.Allowed("User", "Permit", username);

                //Assert
                Assert.IsTrue(allowed);
            }

            [TestMethod]
            public void AnyUser_OnPermit_Denied()
            {
                //Arrange
                string username = "test";
                this.StubPermission();

                //Act
                bool allowed = this.Target.Allowed("Accounting", "AddExtraMoney", username);

                //Assert
                Assert.IsFalse(allowed);
            }

            private void StubPermission()
            {
                _permissionLogic.Setup(p => p.Get(It.IsAny<User>())).Returns(FakePermissionEntity);
            }

            private User FakeUserEntity => new User()
                                            {
                                                Identity = 1,
                                                Active = true,
                                                Name = "test",
                                                DateCreated = new DateTime(),
                                                Email = "test",
                                                IsAdmin = false,
                                                Password = "fbwH0d4qexF+eBHYk6aQjzjtJawdPZcNzUd3Wo5CI6g=",
                                                PasswordSalt = "I5YIl4ReQNAbYxMl9i7gBPhqSS+DukLWR0TEzp/90nA=",
                                                ProfilePictureUrl = "test",
                                                Surname = "test",
                                                DateBirth = new DateTime(),
                                                EmployeeFileNumber = 1,
                                                Username = "test",
                                                DateModified = null,
                                            };

            private List<Permission> FakePermissionEntity = new List<Permission> 
                                                                { new Permission() 
                                                                    {
                                                                        Controller = "User",
                                                                        Action = "Permit"
                                                                    } 
                                                                };

        }
    }
}