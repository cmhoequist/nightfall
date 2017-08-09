using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nightfall.API.Controllers;
using Nightfall.Application.Commands;
using Nightfall.Application.Interfaces;
using Nightfall.Core;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Results;

namespace UnitTests.Api
{
    [TestClass]
    public class PlayerControllerTests
    {
        private Mock<IPlayerPersistenceHandler> _mockPersistenceHandler;
        private PlayerController _controller;
        private Player _testPlayer;
        private IFixture _fixture;

        [TestInitialize]
        public void BeforeEachTest()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization());
            _fixture.Customize<HttpRequestContext>(c => c.Without(x => x.ClientCertificate)); //Solves an error creating PlayerController: System.Security.Cryptography.CryptographicException: pCertContext is an invalid handle..
            _controller = _fixture.Create<PlayerController>();
            _testPlayer = Player.Reconstitute(
                            _fixture.Create<int>(),
                            _fixture.Create<string>(),
                            _fixture.Create<int>(),
                            _fixture.Create<int>(),
                            _fixture.Create<int>());

            _mockPersistenceHandler = _fixture.Freeze<Mock<IPlayerPersistenceHandler>>();
            _mockPersistenceHandler
                    .Setup(x => x.Save(It.IsAny<Player>()))
                    .Returns(Task.FromResult(_testPlayer));
        }

        [TestMethod]
        public async Task SavePlayerReturnsOkForValidPlayer()
        {
            var response = await _controller.Save(_fixture.Create<AddPlayerCommand>());
            response.Should().BeOfType(typeof(OkNegotiatedContentResult<Player>));
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task SavePlayerReturnsBadRequestWhenPlayerIsNull()
        {
            var response = await _controller.Save(null);
            response.Should().BeOfType(typeof(BadRequestErrorMessageResult));
        }
    }
}
