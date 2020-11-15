﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EditableCV_backend.Data.WorkPlaceData;
using EditableCV_backend.DataTransferObjects;
using EditableCV_backend.DataTransferObjects.WorkPlaceDto;
using EditableCV_backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace EditableCV_backend.Controllers
{
  [Route("api/workplaces")]
  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
      if (!place.IsValid)
      {
        ModelState.AddModelError("ModelValidationError", "Received work place data is invalid");
        // TODO: return ValidationProblem
        return BadRequest(ModelState);
      }
      _repository.CreateWorkPlace(place);
      _repository.SaveChanges();
      WorkPlaceReadDto readPlace = _mapper.Map<WorkPlaceReadDto>(place);
      return CreatedAtRoute(nameof(GetWorkPlace), new { Id = readPlace.Id }, readPlace);

    }
    [HttpPut("{id}")]
    public ActionResult PutWorkPlace(int id, WorkPlaceUpdateDto workPlaceDto)
    {
      WorkPlace workPlaceFromRepo = _repository.GetWorkPlaceById(id);
      if (workPlaceFromRepo == null)
      {
        return NotFound();
      }
      // updated work place for db context
      _mapper.Map(workPlaceDto, workPlaceFromRepo);
      // does nothing for current implementation, but it should be called because under _repository may be another implementation
      _repository.UpdateWorkPlace(workPlaceFromRepo);
      _repository.SaveChanges();
      return NoContent();
    }
    [HttpPatch("{id}")]
    public ActionResult PatchWorkPlace(int id, JsonPatchDocument<WorkPlaceUpdateDto> patchDocument)
    {
      WorkPlace workPlaceFromRepo = _repository.GetWorkPlaceById(id);
      if (workPlaceFromRepo == null)
      {
        return NotFound();
      }

      WorkPlaceUpdateDto workPlaceToPatch = _mapper.Map<WorkPlaceUpdateDto>(workPlaceFromRepo);
      patchDocument.ApplyTo(workPlaceToPatch, ModelState);
      // updated work place for db context
      WorkPlace workPlace = _mapper.Map(workPlaceToPatch, workPlaceFromRepo);
      if (!workPlace.IsValid)
      {
        ModelState.AddModelError("ModelValidationError", "Received work place data is invalid");
        // TODO: return ValidationProblem
        return BadRequest(ModelState);
      }
      // does nothing for current implementation, but it should be called because under _repository may be another implementation
      _repository.UpdateWorkPlace(workPlace);
      _repository.SaveChanges();
      return NoContent();
    }
    [HttpDelete("{id}")]
    public ActionResult<WorkPlaceReadDto> DeleteWorkPlace(int id)
    {
      WorkPlace workPlaceFromRepo = _repository.GetWorkPlaceById(id);
      if (workPlaceFromRepo == null)
      {
        return NotFound();
      }
      _repository.DeleteWorkPlace(workPlaceFromRepo);
      _repository.SaveChanges();
      return Ok(_mapper.Map<WorkPlaceReadDto>(workPlaceFromRepo));
    }

    private readonly IWorkPlaceRepository _repository;
    private readonly IMapper _mapper;
  }
}
