using Autofac;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using System.Web.Http.Results;

namespace IntegrationTests
{
    [TestClass]
    public class PlayerTests
    {
        private PlayerController _controller;
        private AddPlayerCommand _addPlayerCommand;
        private PlayerFactory _factory;

        [TestInitialize]
        public void AfterEach()
        {
            var container = TestBootstrapper.BuildContainer();
            _controller = container.Resolve<PlayerController>();
            _factory = container.Resolve<PlayerFactory>();

            _addPlayerCommand = _factory.CreateAddPlayerCommand();
        }

        [TestMethod]
        public async Task SavedPlayerIsGettable()
        {
            //Arrange
            await _controller.Save(_addPlayerCommand);

            //Act
            var t = await _controller.GetByName(_addPlayerCommand.Name);
            var a = t as OkNegotiatedContentResult<Player>;
            var player = a.Content;

            //Assert
            _addPlayerCommand.Name.ShouldBeEquivalentTo(player.Name);
            _addPlayerCommand.ChampionId.ShouldBeEquivalentTo(player.ChampionId);
            _addPlayerCommand.ZoneId.ShouldBeEquivalentTo(player.ZoneId);
            _addPlayerCommand.GameId.ShouldBeEquivalentTo(player.GameId);
        }

    }
}
