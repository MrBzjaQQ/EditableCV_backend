using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EditableCV_backend.Data;
using EditableCV_backend.DataTransferObjects;
using EditableCV_backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [Route("api/workplaces")]
  [ApiController]
  public class WorkPlacesController : ControllerBase
  {
    public WorkPlacesController(IWorkPlaceRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }
    [HttpGet]
    public ActionResult<IEnumerable<WorkPlaceReadDto>> GetAllWorkPlaces()
    {
      IEnumerable<WorkPlace> workPlaces = _repository.GetAllWorkPlaces();
      return Ok(_mapper.Map<IEnumerable<WorkPlaceReadDto>>(workPlaces));
    }
    [HttpGet("{id}", Name = "GetWorkPlace")]
    public ActionResult<WorkPlaceReadDto> GetWorkPlace(int id)
    {
      WorkPlace place = _repository.GetWorkPlaceById(id);
      if (place == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<WorkPlaceReadDto>(place));
    }
    [HttpPost]
    public ActionResult<WorkPlaceReadDto> PostWorkPlace(WorkPlaceCreateDto workPlaceDto)
    {
      WorkPlace place = _mapper.Map<WorkPlace>(workPlaceDto);
      _repository.CreateWorkPlace(place);
      _repository.SaveChanges();
      WorkPlaceReadDto readPlace = _mapper.Map<WorkPlaceReadDto>(place);
      return CreatedAtRoute(nameof(GetWorkPlace), new { Id = readPlace.Id }, readPlace);
    }

    private readonly IWorkPlaceRepository _repository;
    private readonly IMapper _mapper;
  }
}
