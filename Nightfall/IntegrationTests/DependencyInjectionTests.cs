using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nightfall.API;
using System.Linq;
using Autofac;
using System.Web.Http;

namespace IntegrationTests
{
    [TestClass]
    public class DependencyInjectionTests
    {
        [TestMethod]
        public void CanResolveAllControllers()
        {
            var container = DependencyInjection.Bootstrap();

            var controllerTypes = typeof(DependencyInjection).Assembly.GetTypes().Where(testc => testc.IsAssignableTo<ApiController>()).ToArray();
            Assert.IsTrue(controllerTypes.Any());
            foreach(var controller in controllerTypes)
            {
                Assert.IsNotNull(container.Resolve(controller));
            }
        }
    }
}
