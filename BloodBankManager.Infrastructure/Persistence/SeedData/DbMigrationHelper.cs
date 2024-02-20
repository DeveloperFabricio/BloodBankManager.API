using BloodBankManager.Core.Entities;
using BloodBankManager.Core.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BloodBankManager.Infrastructure.Persistence.SeedData
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelper.EnsureSeedData(app).Wait();
        }
    }
    public static class DbMigrationHelper
    {
        public static async Task EnsureSeedData(WebApplication serviceScope)
        {
            var services = serviceScope.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }

        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var enviroment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var dbContext = scope.ServiceProvider.GetRequiredService<BloodBankManagerDbContext>();

            if (enviroment.IsDevelopment() || enviroment.IsEnvironment("EFCore"))
            {
                await dbContext.Database.MigrateAsync();

                await EnsureSeedInformations(dbContext);
            }
        }

        public static async Task EnsureSeedInformations(BloodBankManagerDbContext dbContext)
        {
            if (dbContext.BloodStorages.Any())
                return;

            await dbContext.BloodStorages.AddAsync(new BloodStorage(BloodType.A, RhFactor.Positive, 0));
            await dbContext.BloodStorages.AddAsync(new BloodStorage(BloodType.A, RhFactor.Negative, 0));

            await dbContext.BloodStorages.AddAsync(new BloodStorage(BloodType.B, RhFactor.Positive, 0));
            await dbContext.BloodStorages.AddAsync(new BloodStorage(BloodType.B, RhFactor.Negative, 0));

            await dbContext.BloodStorages.AddAsync(new BloodStorage(BloodType.AB, RhFactor.Positive, 0));
            await dbContext.BloodStorages.AddAsync(new BloodStorage(BloodType.AB, RhFactor.Negative, 0));

            await dbContext.BloodStorages.AddAsync(new BloodStorage(BloodType.O, RhFactor.Positive, 0));
            await dbContext.BloodStorages.AddAsync(new BloodStorage(BloodType.O, RhFactor.Negative, 0));

            await dbContext.SaveChangesAsync();
        }
    }
}
