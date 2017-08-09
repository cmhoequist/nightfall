using Autofac;
using Nightfall.API.Controllers;
using Nightfall.Datastore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationTests
{
    public class TestBootstrapper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new DatastoreAutofacModule());

            builder
                .RegisterType<PlayerController>();

            builder.RegisterType<QueryHelper>()
                .WithParameter(
                    new TypedParameter(typeof(string), ConfigurationManager.ConnectionStrings["NightfallDB"].ConnectionString));

            builder.RegisterType<PlayerFactory>();

            return builder.Build();
        }
    }
}
