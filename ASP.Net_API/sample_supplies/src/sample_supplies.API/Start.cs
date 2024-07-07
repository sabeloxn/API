namespace sample_supplies.API
{
    using sample_supplies.API.Configurations;
    using sample_supplies.API.Mutations;
    using sample_supplies.API.Queries;
    using sample_supplies.API.Resolvers;
    using sample_supplies.API.Subscriptions;
    using sample_supplies.API.Types;
    using sample_supplies.Core.Repositories;
    using sample_supplies.Infrastructure.Data;
    using sample_supplies.Infrastructure.Repositories;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        private readonly ApiConfiguration apiConfiguration;

        public Startup(IConfiguration configuration)
        {
            this.apiConfiguration = configuration.Get<ApiConfiguration>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurations
            services.AddSingleton(this.apiConfiguration.MongoDbConfiguration);

            // Repositories
            services.AddSingleton<Isample_suppliesContext, sample_suppliesContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ISaleRepository, SaleRepository>();

            // GraphQL
            services
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<SaleQuery>()

                // .AddMutationType(d => d.Name("Mutation"))
                //     .AddTypeExtension<SaleMutation>()

                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<SaleSubscriptions>()

                .AddType<SaleType>()
                //.AddType<ActivityResolver>()
                .AddInMemorySubscriptions();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/supplies/api/graphql");
            });
        }
    }
}
