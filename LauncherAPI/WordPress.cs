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
        private readonly WordPressClient client;

        public VietLacWordPress(string baseUrl)
        {
            Requestor.Instance.BaseAddress = baseUrl;
            client = new WordPressClient(Requestor.Instance.Client)
            {
                HttpResponsePreProcessing = CustomizeHttpResponse
            };
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

        public async Task<Customer> Login(string username, string password)
        {
            await client.Auth.RequestJWTokenAsync(username, password);
            var user = await GetUserProfile();
            return await GetCustomerProfile(user.Id);
        }

        public void Logout()
        {
            client.Auth.Logout();
        }

        public async Task<Customer> RegisterNewUser(string userName, string email, string password)
        {
            if (!Utils.IsEmail(email)) {
                throw new InvalidArgumentException("địa chỉ email không hợp lệ");
            }
            //var user = new User(userName, email, password);
            //user = await client.Users.CreateAsync(user);
            var user = new Customer(userName, email, password);
            user = await client.Customers.CreateCustomerAsync(user);
            return user;
        }

        private async Task<User> GetUserProfile()
        {
            return await client.Users.GetCurrentUser();
        }

        public async Task<Customer> GetCustomerProfile()
        {
            var user = await GetUserProfile();
            return await GetCustomerProfile(user.Id);
        }

        public async Task<Customer> GetCustomerProfile(object userId)
        {
            return await client.Customers.GetCustomerAsync(userId, false);
        }

        //public async Task<User> UpdateUserProfile(User user)
        //{
        //    return await client.Users.UpdateAsync(user);
        //}

        public async Task<Customer> UpdateCustomerProfile(Customer customer)
        {
            return await client.Customers.UpdateCustomerAsync(customer);
        }

        //public async Task<User> ChangeAvatar(string urlImage96, string urlImage48, string urlImage24)
        //{
        //    var user = await GetUserProfile();
        //    user.AvatarUrls = new AvatarURL() { Size24 = urlImage24, Size48 = urlImage48, Size96 = urlImage96 };
        //    return await UpdateUserProfile(user);
        //}

        public async Task<Customer> ChangeCustomerAvatar(string imageUrl)
        {
            var user = await GetUserProfile();
            var customer = await GetCustomerProfile(user.Id);
            customer.AvatarUrl = imageUrl;
            return await UpdateCustomerProfile(customer);
        }

        public async Task<Customer> ChangeFullName(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new InvalidArgumentException("firstName không được phép null hoặc rỗng");
            }
            if (string.IsNullOrEmpty(lastName))
            {
                throw new InvalidArgumentException("lastName không được phép null hoặc rỗng");
            }
            var user = await GetUserProfile();
            var customer = await GetCustomerProfile(user.Id);
            var hasChanged = false;
            if (customer.FirstName?.ToLower() != firstName.ToLower())
            {
                customer.FirstName = firstName;
                hasChanged = true;
            }
            if (customer.LastName?.ToLower() != lastName.ToLower())
            {
                customer.LastName = lastName;
                hasChanged = true;
            }
            if (hasChanged)
            {
                customer = await UpdateCustomerProfile(customer);
            }
            return customer;
        }

        public async Task<Customer> ChangePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new InvalidArgumentException("mật khẩu không được phép null hoặc rỗng");
            }
            var user = await GetUserProfile();
            var customer = await GetCustomerProfile(user.Id);
            customer.Password = password;
            customer = await UpdateCustomerProfile(customer);
            return customer;
        }

        public async Task<bool> DeleteCustomer(object customerId)
        {
            return await client.Customers.DeleteCustomerAsync(customerId);
        }

        public async Task<int> TotalCustomers()
        {
            return await client.Customers.GetCountAsync();
        }

        public async Task<IEnumerable<CustomerDownload>> CustomerDownloadHistories()
        {
            var user = await GetUserProfile();
            return await client.Customers.ListCustomerDownloadsAsync(user.Id);
        }

        public async Task<IEnumerable<Customer>> GetCustomers(int page = 1, int pageSize = 10)
        {
            CustomersQueryBuilder q = new CustomersQueryBuilder() { Page = page, PerPage = pageSize, Role = CustomerRole.Customer };
            return await client.Customers.ListCustomersAsync(q);
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

        public async Task<IEnumerable<ProductCategory>> GetProductCategories(int page = 1, int pageSize = 10, string searchPhrase = null)
        {
            ProductCategoriesQueryBuilder q = new ProductCategoriesQueryBuilder() { Page = page, PerPage = pageSize, Search = searchPhrase };
            return await client.ProductCategories.ListCategoriesAsync(q);
        }

        public async Task<ProductCategory> ProductCategoryDetail(object id)
        {
            return await client.ProductCategories.GetCategoryAsync(id);
        }

        public async Task<int> TotalProductCategories()
        {
            return await client.ProductCategories.GetCountAsync();
        }

        public async Task<bool> DeleteProductCategory(object categoryId)
        {
            return await client.ProductCategories.DeleteCategoryAsync(categoryId);
        }

        public async Task<bool> DeleteProduct(object productId)
        {
            return await client.Products.DeleteProductAsync(productId);
        }
    }
}
