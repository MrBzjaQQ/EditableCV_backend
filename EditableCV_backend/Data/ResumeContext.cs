using EditableCV_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data
{
  public class ResumeContext : DbContext
  {
    public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
    {

    }

    public DbSet<WorkPlace> WorkPlaces { get; set; }
  }
}
