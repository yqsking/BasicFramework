using AutoMapper;
using BasicFramework.Appliction.AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace BasicFramework.Presentaion.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //依赖注入AutoMapper
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            //配置允许跨域访问 (PS:同时配置 AllowCredentials 和 AllowAnyOrigin 会冲突报错)
            services.AddCors(options => options.AddPolicy("AllowAll",
                p => p.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()));
            services.AddHttpClient();

            services.AddSwaggerGen(item=> { 
                item.SwaggerDoc("v1",new Info {Title= "BasicFramework Api",Version="v1" });

                // 为 Swagger JSON and UI设置xml文档注释路径
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）
                var apiXmlPath = Path.Combine(basePath, "BasicFrameworkPresentaionApi.xml");
                item.IncludeXmlComments(apiXmlPath);

                var dtoXmlPath = Path.Combine(basePath, "BasicFrameworkAppliction.xml");
                item.IncludeXmlComments(dtoXmlPath);
            });
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            //启用中间件服务生成swagger作为json终节点
            app.UseSwagger();
            app.UseSwaggerUI(item=>
            {
                item.SwaggerEndpoint("/swagger/v1/swagger.json", "BasicFramework Api");
                item.RoutePrefix = string.Empty;
            });
        }
    }
}
