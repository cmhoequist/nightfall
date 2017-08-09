using Autofac;
using Nightfall.Application.Interfaces;
using Nightfall.Datastore.QueryHandlers;

namespace Nightfall.Datastore
{
    public class DatastoreAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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
        }
    }
}
