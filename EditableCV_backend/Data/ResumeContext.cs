﻿using EditableCV_backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data
{
  public class ResumeContext : IdentityDbContext<User>
  {
    public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
    {
      Database.EnsureCreated();
    }

    public DbSet<WorkPlace> WorkPlaces { get; set; }
    public DbSet<ImageModel> Images { get; set; }
    public DbSet<CommonInfo> CommonInfos { get; set; }
    public DbSet<EducationalInstitution> EducationalInstitutions { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<ContactInfo> ContactInfos { get; set; }
  }
}
