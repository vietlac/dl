using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressPCL;
using WordPressPCL.Models;

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
            return content;
        }

        public WordPressClient ChangePath(string path = "wp/v2/")
        {
            if (!client.WordPressUri.AbsolutePath.TrimEnd('/').EndsWith(path.TrimEnd('/')))
            {
                client = new WordPressClient(Requestor.Instance.Client, path);
                client.HttpResponsePreProcessing = CustomizeHttpResponse;
                Requestor.Instance.WpClient = client;
            }
            return client;
        }

        public WordPressClient ChangePathToWooCommerce()
        {
            return ChangePath("wc/v3/");
        }

        public WordPressClient ChangePathToWordPressV2()
        {
            return ChangePath("wp/v2/");
;        }

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
                throw new ArgumentNullException("tên người dùng không được phép null hoặc rỗng");
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
                throw new ArgumentNullException("mật khẩu không được phép null hoặc rỗng");
            }
            var user = await GetUserProfile();
            user.Password = password;
            user = await UpdateUserProfile(user);
            return user;
        }
    }
}
