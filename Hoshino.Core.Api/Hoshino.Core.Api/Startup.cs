using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Hoshino.Core.Api.Filter;
using Hoshino.Core.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Hoshino.Core.Api
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
            ConfigHelper.loadConfig();

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilter));
                options.Filters.Add(typeof(GlobalActionFilter));

            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region 自动注入服务层
            dynamic type = (new Program()).GetType();
            string currentDirectory = Path.GetDirectoryName(type.Assembly.Location);

            DirectoryInfo dir = new DirectoryInfo(currentDirectory);
            foreach (FileInfo fi in dir.GetFiles("*.dll"))
            {
                foreach (var item in GetClassName<Interface.IService.IDependency>(fi.FullName))
                {
                    foreach (var typeArray in item.Value)
                    {
                        services.AddScoped(typeArray, item.Key);
                    }
                }
            }
            #endregion

            services.AddHttpContextAccessor();
        }
        private static Dictionary<Type, Type[]> GetClassName<T>(string assemblyPath)
        {
            Type baseType = typeof(T);

            if (!string.IsNullOrWhiteSpace(assemblyPath))
            {
                Assembly assembly = Assembly.LoadFrom(assemblyPath);
                List<Type> ts = assembly.GetTypes().Where(type => baseType.IsAssignableFrom(type)).ToList();

                var result = new Dictionary<Type, Type[]>();
                foreach (var item in ts.Where(s => !s.IsInterface))
                {
                    var interfaceType = item.GetInterfaces();
                    if (item.IsGenericType) continue;
                    result.Add(item, interfaceType);
                }
                return result;
            }
            return new Dictionary<Type, Type[]>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}
            HttpContextHelper.ServiceProvider = app.ApplicationServices;

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "v1/{controller}/{action}/{id?}");

            });
            //app.UseHttpsRedirection();
            //app.UseMvc();
        }
    }
}
