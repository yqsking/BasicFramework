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
        /// ����ע�����
        /// </summary>
        /// <param name="services"></param>
        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options=>
            {
                //����ѭ������
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                //����ö�ٸ�ʽ
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                //����ʱ���ʽ
                options.SerializerSettings.DateFormatString ="yyyy-MM-dd HH:mm:ss";
            });
            //�������������� (PS:ͬʱ���� AllowCredentials �� AllowAnyOrigin ���ͻ����)
            services.AddCors(options => options.AddPolicy("AllowAll",
                p => p.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader()));

            services.AddHttpClient();

            //���AutoMapper��֧��
            services.AddAutoMapper(typeof(UserProfile).Assembly);

        }

        /// <summary>
        /// ����http����ܵ�
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

            //��������������
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();

            // ��·�м��������Controller·��
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
