using System;
using Xunit;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Json;
using System.Text;
using System.Linq;
using Webstore.Infrastructure;

namespace Webstore.Test.Webservice
{
    public class ProductsControllerTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        public ProductsControllerTests()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Webstore.Webservice.ProductApi.Startup>());
            _client = _server.CreateClient();

        }

        [Fact]
        public async Task CanGetProducts()
        {
            IEnumerable<Webstore.Models.Product> products = null;

            using (HttpClient client = _server.CreateClient())
            {
                products = await ServiceClient.GetAsync<IEnumerable<Webstore.Models.Product>>(client, "/api/products");
            }

            Assert.True(products != null, "Failed to get Products");
        }

        [Fact]
        public async Task CanAddProduct()
        {
            var products = new[]
            {
                new
                {
                    Name = "product vs",
                    Price = 10.5,
                    Properties = new []
                    {
                        new
                            {
                                Property = new
                                {
                                    Name="Count",
                                    Type="integer"
                                },
                                Value=10
                            }
                    }
                }
            };

            IEnumerable<Webstore.Models.Product> result = null;

            using (HttpClient client = _server.CreateClient())
            {
                result = await ServiceClient.PostAsync<IEnumerable<Webstore.Models.Product>>(client, "/api/products", products);
            }

            var product = result.FirstOrDefault();

            Assert.True(product != null);
            Assert.True(product.ProductId == 1);
            Assert.True(product.Name == "product vs");
            Assert.True(product.Price == 10.5);

        }

        [Fact]
        public async Task AddAndGetProduct()
        {
            //Given a new Product
            var body = new[]
            {
                new
                {
                    Name = "Tuscany Tea",
                    Price = 10.5,
                    Properties = new []
                    {
                        new
                            {
                                Property = new
                                {
                                    Name="Count",
                                    Type="integer"
                                },
                                Value=10
                            }
                    }
                }
            };

            //When the Product is added
            using (HttpClient client = _server.CreateClient())
            {
                await ServiceClient.PostAsync<IEnumerable<Webstore.Models.Product>>(client, "/api/products", body);
            }
            //AND calling to get all products
            IEnumerable<Webstore.Models.Product> products = null;

            using (HttpClient client = _server.CreateClient())
            {
                products = await ServiceClient.GetAsync<IEnumerable<Webstore.Models.Product>>(client, "/api/products");
            }

            //Then
            Assert.NotNull(products);
            var newProduct = products.FirstOrDefault();
            Assert.NotNull(newProduct);
            Assert.True(newProduct.ProductId == 1);
            Assert.True(newProduct.Name == "Tuscany Tea", "Product name doest not match");
            Assert.True(newProduct.Price == 10.5, "Product Price does not match");

            Assert.True(newProduct.Properties.Count() > 0);
        }
    }
}