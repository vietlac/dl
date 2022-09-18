using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressPCL;
using WordPressPCL.Models;
using WordPressPCL.Utility;

namespace VietLacSo2022
{
    public class VietLacWordPress
    {
        private WordPressClient client;

        public VietLacWordPress(string baseUrl)
        {
            Requestor.Instance.BaseAddress = baseUrl;
            client = Requestor.Instance.WpClient;
            client.HttpResponsePreProcessing = CustomizeHttpResponse;
        }

        public VietLacWordPress(): this("https://vietlac.com/wp-json/")
        {}

        private string CustomizeHttpResponse(string content)
        {
            // Console.WriteLine(content);
            // TODO: modify JSON response of WordPressPCL if necessary
            return content;
        }

        public async Task UpdateAccessToken(string username, string password)
        {
            if (!await IsValidAccessToken())
            {
                await client.Auth.RequestJWTokenAsync(username, password);
            }
        }

        public async Task<bool> IsValidAccessToken()
        {
            return await client.Auth.IsValidJWTokenAsync();
        }

        public async Task<User> Login(string username, string password)
        {
            await client.Auth.RequestJWTokenAsync(username, password);
            return await GetUserProfile();
        }

        public void Logout()
        {
            client.Auth.Logout();
        }

        public async Task<User> RegisterNewUser(string userName, string email, string password)
        {
            if (!Utils.IsEmail(email)) {
                throw new InvalidArgumentException("địa chỉ email không hợp lệ");
            }
            var user = new User(userName, email, password);
            user = await client.Users.CreateAsync(user);
            return user;
        }

        public async Task<User> GetUserProfile()
        {
            return await client.Users.GetCurrentUser();
        }

        public async Task<User> GetUserProfile(object userId)
        {
            return await client.Users.GetByIDAsync(userId, true, true);
        }

        public async Task<User> UpdateUserProfile(User user)
        {
            return await client.Users.UpdateAsync(user);
        }

        public async Task<User> ChangeAvatar(string urlImage96, string urlImage48, string urlImage24)
        {
            var user = await GetUserProfile();
            user.AvatarUrls = new AvatarURL() { Size24 = urlImage24, Size48 = urlImage48, Size96 = urlImage96 };
            return await UpdateUserProfile(user);
        }

        public async Task<User> ChangeFullName(string fullname)
        {
            if (string.IsNullOrEmpty(fullname))
            {
                throw new InvalidArgumentException("tên người dùng không được phép null hoặc rỗng");
            }
            var user = await GetUserProfile();
            if (user.Name != fullname)
            {
                user.Name = fullname;
                return await UpdateUserProfile(user);
            }
            return user;
        }

        public async Task<User> ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new InvalidArgumentException("mật khẩu không được phép null hoặc rỗng");
            }
            var user = await GetUserProfile();
            user.Password = password;
            user = await UpdateUserProfile(user);
            return user;
        }

        public async Task<IEnumerable<Product>> GetProducts(int page = 1, int pageSize = 10, string searchPhrase = null)
        {
            ProductsQueryBuilder q = new ProductsQueryBuilder() { Page = page, PerPage = pageSize, Search = searchPhrase };
            return await client.Products.ListProductsAsync(q);
        }

        public async Task<Product> ProductDetail(object id)
        {
            return await client.Products.GetProductAsync(id);
        }

        public async Task<int> TotalProducts()
        {
            return await client.Products.GetCountAsync();
        }
    }
}
