using EditableCV_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EditableCV_backend.Data
{
  public class MockWorkPlaceRepository : IWorkPlaceRepository
  {
    public MockWorkPlaceRepository()
    {
      _works = new List<WorkPlace>
      {
        new WorkPlace{
          Id = 1,
          CompanyName = "Big company 1",
          Position = "Big position",
          StartWorkingDate = new DateTime(2020, 06, 06),
          EndWorkingDate = new DateTime(2021, 06, 06),
        },
        new WorkPlace{
          Id = 2,
          CompanyName = "Small company 1",
          Position = "Small position",
          StartWorkingDate = new DateTime(2019, 06, 06),
          EndWorkingDate = new DateTime(2020, 06, 06),
        },
      };
      _savedWorks = new List<WorkPlace>();
      SaveChanges();
    }
    public void CreateWorkPlace(WorkPlace place)
    {
      if (place == null)
      {
        throw new ArgumentNullException(nameof(place));
      }
      _works.Add(place);
    }

    public void DeleteWorkPlace(WorkPlace place)
    {
      if (place == null)
      {
        throw new ArgumentNullException(nameof(place));
      }
      _works.Remove(place);
    }

    public IEnumerable<WorkPlace> GetAllWorkPlaces()
    {
      return new List<WorkPlace>(_savedWorks);
    }

    public WorkPlace GetWorkPlaceById(int id)
    {
      return _savedWorks.FirstOrDefault(item => item.Id == id);
    }

    public bool SaveChanges()
    {
      _savedWorks = new List<WorkPlace>();
      foreach (var place in _works)
      {
        _savedWorks.Add(new WorkPlace
        {
          Id = place.Id,
          CompanyName = place.CompanyName,
          Position = place.Position,
          StartWorkingDate = place.StartWorkingDate,
          EndWorkingDate = place.EndWorkingDate,
        });
      }
      return true;
    }

    public void UpdateWorkPlace(WorkPlace place)
    {
      if (place == null)
      {
        throw new ArgumentNullException(nameof(place));
      }
      WorkPlace savedPlace = _works.FirstOrDefault<WorkPlace>(item => item.Id == place.Id);
      if (savedPlace == null)
      {
        throw new Exception("not found");
      }
      WorkPlace updatedPlace = new WorkPlace(savedPlace);
      int index =_works.IndexOf(savedPlace);
      _works[index] = updatedPlace;
    }
    private List<WorkPlace> _works;
    private List<WorkPlace> _savedWorks;
  }
}
