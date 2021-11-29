using System;
using System.IO;
using _03_DataAccess.Abstract;
using _03_DataAccess.Concrete.EntityFramework;
using _04_Business.Abstract;
using _04_Business.Concrete;
using _05_MvcWebUI.Entities;
using _05_MvcWebUI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace _05_MvcWebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();

            services.AddScoped<IRestaurantService, RestaurantManager>();
            services.AddScoped<IRestaurantDal, EfRestaurantDal>();

            services.AddSingleton<IReceiptSessionService, ReceiptSessionService>();
            services.AddSingleton<IReceiptService, ReceiptService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<UserManager<CustomIdentityUser>>();
            services.AddScoped<SignInManager<CustomIdentityUser>>();
            services.AddScoped<RoleManager<CustomIdentityRole>>();

            services.AddDbContext<CustomIdentityDbContext>(options => options.UseSqlServer(@"data source=DESKTOP-M6O799J\SQLEXPRESS;initial catalog=OrderINC;user id=sa;password=sa;multipleactiveresultsets=true;"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>().AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();
            services.AddMvc();
            services.AddDistributedMemoryCache();
            services.AddSession();

            services.AddControllersWithViews();
            services.AddMvc(option => option.EnableEndpointRouting = false);





        }
        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<CustomIdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<CustomIdentityUser>>();

            IdentityResult roleResult;
            //Adding Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                CustomIdentityRole role = new CustomIdentityRole
                {
                    Name = "Admin"
               };
                roleResult = await RoleManager.CreateAsync(role);
            }
            //Assign Admin role to the main User here we have given our newly registered 
            //login id for Admin management
            var user = await UserManager.FindByEmailAsync("admin@gmail.com");
            var User = new CustomIdentityUser();
            await UserManager.AddToRoleAsync(user, "Admin");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IServiceProvider services)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer();

            app.UseStaticFiles();

            app.UseSession();

            app.UseMvc();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseHttpsRedirection();







            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            CreateUserRoles(services).Wait();
        }

        

       
    }
}
