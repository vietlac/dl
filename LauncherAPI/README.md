### LauncherAPI
Adapter kết nối Việt Lạc desktop launcher với CMS Việt Lạc (WordPress) sử dụng thư viện WordPressPCL (C# .NET)

### CMS Việt Lạc API endpoint
https://vietlac.com/wp-json/

### Hướng dẫn build và dev
- Cài Visual Studio 2022
- Cài .netstandard 2.0 và .NET core 6.0
- Checkout thư viện WordPressPCL từ https://github.com/coorhair/WordPressPCL.git (fork từ https://github.com/wp-net/WordPressPCL.git và được modify để tích hợp với WooCommerce Restful API)
- Mở Visual Studio load solution "VietLacSo2022" và thêm project "WordPressPCL" vào solution
