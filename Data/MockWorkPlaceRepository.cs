using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data
{
  public class MockWorkPlaceRepository : IWorkPlaceRepository
  {
    public IEnumerable<WorkPlace> GetAllWorkPlaces()
    {
      return new List<WorkPlace>
      {
        new WorkPlace
        {
          Id = 1,
          CompanyName = "Some Company",
          Position = "Sample Position",
          Experience = "Did a lot",
          StartWorkingTime = new DateTime(2000, 12, 1),
          EndWorkingTime = new DateTime(2005, 12, 1),
          IsCurrentlyWorking = false,
          CompanyIcon = null,
        },
        new WorkPlace
        {
          Id = 2,
          CompanyName = "Some Company 2",
          Position = "Sample Position 2",
          Experience = "Fired instantly",
          StartWorkingTime = new DateTime(2001, 12, 1),
          EndWorkingTime = new DateTime(2006, 12, 1),
          IsCurrentlyWorking = false,
          CompanyIcon = null,
        }
      };
    }

    public WorkPlace GetWorkPlaceById(int id)
    {
      return new WorkPlace
      {
        Id = 1,
        CompanyName = "Some Company",
        Position = "Sample Position",
        Experience = "Did a lot",
        StartWorkingTime = new DateTime(2000, 12, 1),
        EndWorkingTime = new DateTime(2005, 12, 1),
        IsCurrentlyWorking = false,
        CompanyIcon = null,
      };
    }
  }
}
