using AutoMapper;
using BasicFramework.Appliction.AutoMapper;
using BasicFramework.Impl.DBContext;
using BasicFramework.Presentaion.Api.MiddleWare;
using log4net;
using log4net.Config;
using log4net.Repository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace BasicFramework.Presentaion.Api
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 日志仓储
        /// </summary>
        public static ILoggerRepository LogRepository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LogRepository = LogManager.CreateRepository("BasicFrameworkLogRepository");
            XmlConfigurator.Configure(LogRepository, new FileInfo("log4net.config"));
        }

        /// <summary>
        /// 
        /// </summary>
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
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin() .AllowAnyMethod() .AllowAnyHeader()));
            services.AddHttpClient();

            //依赖注入automapper
            services.AddAutoMapper(typeof(UserProfile).Assembly);

            //依赖注入中介者
            services.AddMediatR(typeof(IMediator));

            //依赖注入数据库上下文对象
            var sqlConnection = Configuration.GetConnectionString("Default");
            services.AddDbContext<BasicFrameworkDbContext>(option => option.UseSqlServer(sqlConnection,provider0ptions => provider0ptions.CommandTimeout(120)));

            //依赖注入公用服务
            services.RegisterCommon();
            //依赖注入仓储
            services.RegisterRepositorys();
            //依赖注入命令
            services.RegisterCommand();
            //依赖注入查询器
            services.RegisterQueries();

            //添加swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BasicFramework  API",
                    Version = "v1"
                });
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPathApi = Path.Combine(basePath, "BasicFramework.Presentaion.Api.xml");
                var xmlPathModel = Path.Combine(basePath, "BasicFramework.Appliction.xml");
                options.IncludeXmlComments(xmlPathApi);
                options.IncludeXmlComments(xmlPathModel);

            });


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
            app.UseMiddleware<ExceptionHandlerMiddleWare>();
            app.UseAuthorization();

         
            //启动Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BasicFramework API V1");
                c.OAuthClientId("BasicFrameworkSwaggerUI");
                c.OAuthAppName("BasicFramework Swagger UI");
            });
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
