using Autofac;
using Autofac.Integration.WebApi;
using Nightfall.Application.Interfaces;
using Nightfall.Datastore.QueryHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Nightfall.API
{
    public class DependencyInjection
    {
        public static IContainer Bootstrap()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder
                .RegisterType<ChampionQueryRepository>()
                .As<IChampionQueryRepository>();
            builder
                .RegisterType<ZonePersistenceHandler>()
                .As<IZonePersistenceHandler>();
            builder
                .RegisterType<PlayerPersistenceHandler>()
                .As<IPlayerPersistenceHandler>();
            builder
                .RegisterType<GamePersistenceHandler>()
                .As<IGamePersistenceHandler>();

            return builder.Build();
        }
    }
}