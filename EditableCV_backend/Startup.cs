using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EditableCV_backend.Data;
using EditableCV_backend.Data.CommonInfoData;
using EditableCV_backend.Data.ContactInfoData;
using EditableCV_backend.Data.EducationInstitutionData;
using EditableCV_backend.Data.ImageData;
using EditableCV_backend.Data.Skills;
using EditableCV_backend.Data.WorkPlaceData;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace EditableCV_backend
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<ResumeContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("ResumeConnection")));

      services.AddControllers().AddNewtonsoftJson(s =>
      {
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
      });

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      services.AddScoped<IWorkPlaceRepository, SqlWorkPlaceRepository>();
      services.AddScoped<IImageDataRepository, SqlImageDataRepository>();
      services.AddScoped<ICommonInfoRepository, SqlCommonInfoRepository>();
      services.AddScoped<IEducationRepository, SqlEducationRepository>();
      services.AddScoped<ISkillsRepository, SqlSkillsRepository>();
      services.AddScoped<IContactInfoRepository, SqlContactInfoRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
