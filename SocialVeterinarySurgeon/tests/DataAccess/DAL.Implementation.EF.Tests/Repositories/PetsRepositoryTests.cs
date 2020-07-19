using DAL.Implementation.EF.Context;
using DAL.Implementation.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DAL.Implementation.EF.Tests.Repositories
{
    public class PetsRepositoryTests
    {
        [Fact]
        public async void GetAllAsync_ShouldReturnListOfEmployees()
        {
            // Arrange
            var employees = new List<Pet>
            {
                new Pet { Id = 21, Name = "Dick", Type = "duck", OwnerId = 23 },
                new Pet { Id = 12, Name = "Mat", Type = "cat", OwnerId = 48 }
            };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Pets1")
                .Options;

            using (var appContext = new AppContext(options))
            {

                await appContext.Pets.AddRangeAsync(employees);
                await appContext.SaveChangesAsync();
            }

            using (var appContext = new AppContext(options))
            {
                var repo = new PetsRepository(appContext);

                // Act
                var result = await repo.GetAllAsync();

                // Assert
                Assert.IsAssignableFrom<IEnumerable<Pet>>(result);
                Assert.Equal(employees.Count, result.Count());
            }
        }

        [Fact]
        public async void GetByIdAsync_ShouldReturnEmployee()
        {
            // Arrange
            var pets = new List<Pet>
            {
                new Pet { Id = 121, Name = "Dick", Type = "duck", OwnerId = 23, Owner = new Employee{ Id = 134 } },
                new Pet { Id = 212, Name = "Mat", Type = "cat", OwnerId = 48, Owner = new Employee{ Id = 12 }}
            };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Pets2")
                .Options;

            using (var appContext = new AppContext(options))
            {

                await appContext.Pets.AddRangeAsync(pets);
                await appContext.SaveChangesAsync();
            }

            using (var appContext = new AppContext(options))
            {
                var repo = new PetsRepository(appContext);

                // Act
                var result = await repo.GetByIdAsync(pets.First().Id);

                // Assert
                Assert.IsAssignableFrom<Pet>(result);
                Assert.Equal(pets.First().Id, result.Id);
            }
        }

        [Fact]
        public async void AddAsync_ShouldAddEmployee()
        {
            // Arrange
            var petToAdd = new Pet { Id = 1, Name = "Dick", Type = "duck", OwnerId = 23 };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Pets3")
                .Options;

            using (var appContext = new AppContext(options))
            {
                var repo = new PetsRepository(appContext);

                // Act
                await repo.AddAsync(petToAdd);


                // Assert
                var pet = appContext.Pets.Find(petToAdd.Id);
                Assert.Equal(petToAdd.Id, pet.Id);
                Assert.Equal(petToAdd.Name, pet.Name);
                Assert.Equal(petToAdd.Type, pet.Type);
                Assert.Equal(petToAdd.OwnerId, pet.OwnerId);
            }
        }

        [Fact]
        public async void UpdateAsync_ShouldUpdateEmployee()
        {
            // Arrange
            var petBeforeUpdate = new Pet { Id = 1, Name = "Dick", Type = "duck", OwnerId = 23 };
            var petAfterUpdate = new Pet { Id = 1, Name = "Mat", Type = "cat", OwnerId = 48 };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Pets4")
                .Options;

            using (var appContext = new AppContext(options))
            {

                await appContext.Pets.AddAsync(petBeforeUpdate);
                await appContext.SaveChangesAsync();
            }

            using (var appContext = new AppContext(options))
            {
                var repo = new PetsRepository(appContext);

                // Act
                await repo.UpdateAsync(petAfterUpdate);


                // Assert
                var pet = appContext.Pets.Find(petAfterUpdate.Id);
                Assert.Equal(petAfterUpdate.Id, pet.Id);
                Assert.Equal(petAfterUpdate.Name, pet.Name);
                Assert.Equal(petAfterUpdate.Type, pet.Type);
                Assert.Equal(petAfterUpdate.OwnerId, pet.OwnerId);
            }
        }

        [Fact]
        public async void DeleteAsync_ShouldDeleteEmployee()
        {
            // Arrange
            var petToDelete = new Pet { Id = 1, Name = "Dick", Type = "duck", OwnerId = 23 };

            var options = new DbContextOptionsBuilder<AppContext>()
                .UseInMemoryDatabase(databaseName: "Pets5")
                .Options;

            using (var appContext = new AppContext(options))
            {

                await appContext.Pets.AddAsync(petToDelete);
                await appContext.SaveChangesAsync();
            }

            using (var appContext = new AppContext(options))
            {
                var repo = new PetsRepository(appContext);

                // Act
                await repo.DeleteAsync(petToDelete.Id);


                // Assert
                var pet = appContext.Employees.Find(petToDelete.Id);
                Assert.Null(pet);
            }
        }

    }
}
