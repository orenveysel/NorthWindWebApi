using System.Net.Http;
using System.Text.Json;
using System;
using System.Text;
namespace NorthwindApi.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PostCategory();
            GetCategories();
        }

        private static void GetCategories()
        {
            HttpClient httpClient = new HttpClient(); // HttpClient 
            httpClient.BaseAddress = new Uri("https://northwind.now.sh/");

            var result = httpClient.GetAsync("api/categories").Result;// Async metodunun direk sonucunu almaya zorlar 

            var jsonString = result.Content.ReadAsStringAsync().Result;

            var categories = JsonSerializer.Deserialize<List<Category>>(jsonString);

            foreach (var category in categories)
                System.Console.WriteLine($"Id: {category.id} - Name: {category.name} - Description:{category.description}");
            System.Console.WriteLine("Hello, World!");
        }

        private static void PostCategory()
        {
            using var httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri("https://northwind.now.sh/");

            Category category = new Category()
            {
                id = 0,
                description = "Client Test Ürün Açıklama",
                name= "Test"
            };

            var serializeCategory = JsonSerializer.Serialize(category);

            StringContent stringContent = new StringContent(serializeCategory, Encoding.UTF8, "application/json");

            var result = httpClient.PostAsync("api/Categories", stringContent).Result;

            if (result.IsSuccessStatusCode)
                System.Console.WriteLine("Kategory ekleme başarılı.");
            else
                System.Console.WriteLine($"Kategory eklenemedi. Hata Kodu: {result.StatusCode}");
        }
    }
}
