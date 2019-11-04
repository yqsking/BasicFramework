using AutoMapper;
using BasicFramework.Appliction.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BasicFramework.Presentaion.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 依赖注入服务
        /// </summary>
        /// <param name="services"></param>
        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options=>
            {
                //忽略循环引用
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //设置枚举格式
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                //设置时间格式
                options.SerializerSettings.DateFormatString ="yyyy-MM-dd HH:mm:ss";
            });
            //配置允许跨域访问 (PS:同时配置 AllowCredentials 和 AllowAnyOrigin 会冲突报错)
            services.AddCors(options => options.AddPolicy("AllowAll",
                p => p.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()));

            services.AddHttpClient();

            //添加AutoMapper的支持
            services.AddAutoMapper(typeof(UserProfile).Assembly);

        }

        /// <summary>
        /// 配置http请求管道
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          
            app.UseRouting();

            app.UseAuthorization();

            //启动允许跨域访问
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            // 短路中间件，配置Controller路由
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
