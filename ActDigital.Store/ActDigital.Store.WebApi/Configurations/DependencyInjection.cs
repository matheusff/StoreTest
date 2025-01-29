using ActDigital.Store.Core.Communication.Mediator;
using ActDigital.Store.Core.Data.EventSourcing;
using ActDigital.Store.Core.Messages.Notifications;
using ActDigital.Store.Sales.Application.Commands;
using ActDigital.Store.Sales.Application.Events;
using ActDigital.Store.Sales.Application.Queries;
using ActDigital.Store.Sales.Domain.Repositories;
using ActDigital.Store.Sales.Infrastructure;
using ActDigital.Store.Sales.Infrastructure.Data;
using EventSourcing;
using EventStore.Client;
using MediatR;

namespace ActDigital.Store.WebApi.Configurations
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Event Sourcing
            //services.AddSingleton<EventStoreClient>();
            services.AddSingleton<IEventStoreService, EventStoreService>();
            services.AddSingleton<IEventSourcingRepository, EventSourcingRepository>();
            

            // Services
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<SalesContext>();

            services.AddScoped<INotificationHandler<ItemCancelledEvent>, SaleEventHandler>();
            services.AddScoped<INotificationHandler<SaleCancelledEvent>, SaleEventHandler>();
            services.AddScoped<INotificationHandler<SaleCreatedEvent>, SaleEventHandler>();
            services.AddScoped<INotificationHandler<SaleModifiedEvent>, SaleEventHandler>();

            services.AddScoped<IRequestHandler<AddSaleCommand, bool>, SaleCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateSaleCommand, bool>, SaleCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveSaleCommand, bool>, SaleCommandHandler>();

            services.AddScoped<IConfigurationManager, ConfigurationManager>();
            services.AddScoped<ISaleQueries, SaleQueries>();
        }
    }
}