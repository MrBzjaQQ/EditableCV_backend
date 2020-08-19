using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EditableCV_backend.Data;
using EditableCV_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [Route("api/workplaces")]
  [ApiController]
  public class WorkPlacesController : ControllerBase
  {
    public WorkPlacesController(IWorkPlaceRepository repository)
    {
      _repository = repository;
    }
    [HttpGet]
    public ActionResult<IEnumerable<WorkPlace>> GetAllWorkPlaces()
    {
      IEnumerable<WorkPlace> workPlaces = _repository.GetAllWorkPlaces();
      return Ok(workPlaces);
    }
    [HttpGet("{id}")]
    public ActionResult<WorkPlace> GetWorkPlace(int id)
    {
      WorkPlace place = _repository.GetWorkPlaceById(id);
      return Ok(place);
    }

    private readonly IWorkPlaceRepository _repository;
  }
}
