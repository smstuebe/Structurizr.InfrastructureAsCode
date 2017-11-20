﻿using Structurizr.InfrastructureAsCode.Azure.Model;
using Structurizr.InfrastructureAsCode.InfrastructureRendering;
using Structurizr.InfrastructureAsCode.Model.Connectors;

namespace Structurizr.InfrastructureAsCode.Azure.Sample.Model
{
    public class ShopApi : ContainerWithInfrastructure<WebAppService>
    {
        public ShopApi(Shop shop, ShopDatabase database, ShopServiceBus serviceBus, IInfrastructureEnvironment environment)
        {
            Container = shop.System.AddContainer(
                "Shop API",
                "Provides a service layer to browse and order products",
                "ASP.NET Core MVC Web Application");

            Infrastructure = new WebAppService
            {
                Name = $"aac-sample-shop-api-{environment.Name}",
                EnvironmentInvariantName = "aac-sample-shop-api"
            };

            Uses(database).Over<Https>().InOrderTo("Stores and loads products and orders");

            Uses(serviceBus).Over(serviceBus.Infrastructure.Queue("order")).InvertUsage().InOrderTo("Get notified about orders");
        }
    }
}