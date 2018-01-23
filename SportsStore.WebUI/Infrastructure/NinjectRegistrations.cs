using System.Collections.Generic;
using Moq;
using Ninject.Modules;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        /// <summary>
        ///     Вызывается при загрузке модуля
        /// </summary>
        public override void Load()
        {
            //имитированная реализация интерфейса IProductRepository.
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product {Name = "Football", Price = 25},
                new Product {Name = "Surf board", Price = 179},
                new Product {Name = "Running shoes", Price = 95}
            });
            //Мы используем метод ToConstant, потому что хотим, чтобы Ninject возвращал имитацию объекта,
            //когда он получает запрос от реализации интерфейса IProductRepository:
            //Bind<IProductRepository>().ToConstant(mock.Object);
            Bind<IProductRepository>().To<EfProductRepository>();
        }
    }
}