using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VietLacSo2022;
using WordPressPCL.Models;

namespace TestLauncherAPI
{
    internal class LoginData
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Username={Username}, Email={Email}, Gender={Gender}, Image={Image}";
        }
    }

    class Program
    {
        static async Task<LoginData> Login(string username, string password)
        {
            var data = await Requestor.Instance.DoPost<LoginData>("https://dummyjson.com/auth/login", new Dictionary<string, string> { { "username", username }, { "password", password } });
            Console.WriteLine();
            Console.WriteLine(data);
            return data;
        }

        static async Task<string> Search(string query)
        {
            var data = await Requestor.Instance.DoGet<string>("https://dummyjson.com/posts/search", new Dictionary<string, string> { { "q", query } });
            Console.WriteLine();
            Console.WriteLine(data);
            return data;
        }

        static async Task<string> ContactUs()
        {
            var data = await Requestor.Instance.DoPost<string>("https://invigroup.com/contact-us",
                new Dictionary<string, string> {
                    { "name", "abc" },
                    { "email", "abc@123.com" },
                    { "subject", "abc" },
                    { "message", "123" },
                    { "op", "Send Message" },
                    { "form_build_id", "form-oU2HUleRdCCKLH7M9_JXHJJmzYqrdwnMg-s7UoS1vys" },
                    { "form_id", "webform_submission_contact_add_form" }
                },
                30000, RequestDataType.FormUrlEncodedContent
            );
            Console.WriteLine();
            Console.WriteLine(data);
            return data;
        }

        static async Task Main(string[] args)
        {
            //await Requestor.Instance.Download("https://dl.dropboxusercontent.com/s/09g380ty3f25y69/MD5Check.rar", null, 300000, null);
            //await Login("kminchelle", "0lelplR");
            //await Search("no matter how much");
            //await ContactUs();
            //var html = await Requestor.Instance.Upload<string>("https://cgi-lib.berkeley.edu/ex/fup.cgi",
            //    new Dictionary<string, string> { { "note", "this is a test!" } },
            //    60000, @"C:\Users\ADMIN\Desktop\CÀI ĐẶT VIỆT LẠC SỚ ĐẶC BIỆT 09.11.txt", "upfile");
            //Console.WriteLine(html);

            VietLacWordPress vlwp = new();
            await vlwp.Login("vilapadev", "GUQE9JqsMKwftMnMZVKyZZ4K");

            /** Test user */
            //var user = await vlwp.RegisterNewUser("test_adfasdfasfdas", "test123@vietlac.com", "secret123");
            //Console.WriteLine($"register new user {user.Name}/{user.Email}");
            //user = await vlwp.Login("vilapadev", "GUQE9JqsMKwftMnMZVKyZZ4K");
            //Console.WriteLine($"Hello {user.Name}, ur password is \"{user.Password}\"");
            //user = await vlwp.ChangeFullName("Việt Lạc dev");
            //Console.WriteLine($"Hello {user.Name}, ur password is \"{user.Password}\"");

            /** test product */
            var totalProducts = await vlwp.TotalProducts();
            Console.WriteLine($"total products {totalProducts}");
            var products = await vlwp.GetProducts(1, 10, "crop-top");
            Console.WriteLine($"{products.ToList().Count} products found!");

            /** test product categories */
            var totalCates = await vlwp.TotalProductCategories();
            Console.WriteLine($"total cates {totalCates}");
            var categories = await vlwp.GetProductCategories();
            Console.WriteLine($"we have {categories.ToList().Count} cates!");

            Console.ReadLine();
        }
    }
}
