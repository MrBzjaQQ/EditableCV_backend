using AutoMapper;
using EditableCV_backend.Controllers;
using EditableCV_backend.Data;
using EditableCV_backend.DataTransferObjects;
using EditableCV_backend.Models;
using EditableCV_backend.Profiles;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Moq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EditableCV_backend.Test
{
  public class WorkPlacesControllerTests
  {
    public WorkPlacesControllerTests()
    {
      _repo = new MockWorkPlaceRepository();
      _profile = new WorkPlacesProfile();
      _config = new MapperConfiguration(p => p.AddProfile(_profile));
      _mapper = new Mapper(_config);
      var mockValidator = new Mock<IObjectModelValidator>();
      mockValidator.Setup(o => o.Validate(
        It.IsAny<ActionContext>(),
        It.IsAny<ValidationStateDictionary>(),
        It.IsAny<string>(),
        It.IsAny<object>()
      ));
      _controller = new WorkPlacesController(_repo, _mapper)
      {
        ObjectValidator = mockValidator.Object,
      };
    }
    [Fact]
    public void GetAllWorkplaces_ShouldReturnIEnumerableOfWorkPlaces()
    {
      // Arrange
      IEnumerable<WorkPlace> workPlacesData = _repo.GetAllWorkPlaces();
      // Act
      var placesResult = _controller.GetAllWorkPlaces();
      // Assert
      var okRequestResult = Assert.IsType<OkObjectResult>(placesResult.Result);
      IEnumerable<WorkPlaceReadDto> workPlacesResult = Assert.IsAssignableFrom<IEnumerable<WorkPlaceReadDto>>(okRequestResult.Value);
      Assert.Equal(workPlacesResult.Count(), workPlacesData.Count());
    }

    [Fact]
    public void PostWorkPlace_ShouldCreateWorkPlace()
    {
      // Arrange
      WorkPlaceCreateDto createDto = new WorkPlaceCreateDto
      {
        CompanyName = "Some Company",
        Position = "Some Position",
        Experience = "A lot",
        StartWorkingDate = new DateTime(START_YEAR, START_MONTH, START_DAY),
        EndWorkingDate = new DateTime(END_YEAR, END_MONTH, END_DAY),
      };
      // Act
      var result = _controller.PostWorkPlace(createDto);
      // Assert
      var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
      var readDto = Assert.IsType<WorkPlaceReadDto>(createdAtRoute.Value);
      Assert.Equal(createDto.CompanyName, readDto.CompanyName);
      Assert.Equal(createDto.Position, readDto.Position);
      Assert.Equal(createDto.Experience, readDto.Experience);
      Assert.Equal(createDto.StartWorkingDate.Year, readDto.StartWorkingDate.Year);
      Assert.Equal(createDto.StartWorkingDate.Month, readDto.StartWorkingDate.Month);
      Assert.Equal(createDto.StartWorkingDate.Day, readDto.StartWorkingDate.Day);
      Assert.Equal(createDto.EndWorkingDate.Year, readDto.EndWorkingDate.Year);
      Assert.Equal(createDto.EndWorkingDate.Month, readDto.EndWorkingDate.Month);
      Assert.Equal(createDto.EndWorkingDate.Day, readDto.EndWorkingDate.Day);
    }
    [Fact]
    public void DeleteWorkPlace_ShouldDeleteEntity()
    {
      WorkPlaceCreateDto createDto = new WorkPlaceCreateDto
      {
        CompanyName = "Some Company",
        Position = "Some Position",
        Experience = "A lot",
        StartWorkingDate = new DateTime(START_YEAR, START_MONTH, START_DAY),
        EndWorkingDate = new DateTime(END_YEAR, END_MONTH, END_DAY),
      };
      // Act
      var postResult = _controller.PostWorkPlace(createDto);
      var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(postResult.Result);
      var readDto = Assert.IsType<WorkPlaceReadDto>(createdAtRoute.Value);
      var result = _controller.DeleteWorkPlace(readDto.Id);
      // Assert
      var okResult = Assert.IsType<OkObjectResult>(result.Result);
      var deletedItem = Assert.IsType<WorkPlaceReadDto>(okResult.Value);
      var notFound = Assert.IsType<NotFoundResult>(_controller.GetWorkPlace(deletedItem.Id).Result);
    }

    [Fact]
    public void PostWorkPlace_ShouldReturnBadRequest()
    {
      // Arrange
      WorkPlaceCreateDto createDto = new WorkPlaceCreateDto
      {
        CompanyName = "",
      };
      // Act
      var result = _controller.PostWorkPlace(createDto);
      // Assert
      var createdAtRoute = Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public void PatchWorkPlace_ShouldUpdateModel()
    {
      JsonPatchDocument<WorkPlaceUpdateDto> patchDoc = new JsonPatchDocument<WorkPlaceUpdateDto>(
        new List<Microsoft.AspNetCore.JsonPatch.Operations.Operation<WorkPlaceUpdateDto>>
        {
          new Operation<WorkPlaceUpdateDto>("replace", "/position", null, COMPARE_VALUE),
          new Operation<WorkPlaceUpdateDto>("replace", "/companyName", null, COMPARE_VALUE),
        },
        new DefaultContractResolver()
      );
      Assert.IsType<NoContentResult>(_controller.PatchWorkPlace(ID, patchDoc));
      var okResult = Assert.IsType<OkObjectResult>(_controller.GetWorkPlace(ID).Result);
      var itemData = Assert.IsType<WorkPlaceReadDto>(okResult.Value);
      Assert.Equal(COMPARE_VALUE, itemData.CompanyName);
      Assert.Equal(COMPARE_VALUE, itemData.Position);
    }

    [Fact]
    public void PatchWorkPlace_ShouldReturnValidationProblem()
    {
      JsonPatchDocument<WorkPlaceUpdateDto> patchDoc = new JsonPatchDocument<WorkPlaceUpdateDto>(
        new List<Microsoft.AspNetCore.JsonPatch.Operations.Operation<WorkPlaceUpdateDto>>
        {
           new Operation<WorkPlaceUpdateDto>("replace", "/position", null, null),
           new Operation<WorkPlaceUpdateDto>("replace", "/companyName", null, COMPARE_VALUE),
        },
        new DefaultContractResolver()
      );
    }

    private readonly MockWorkPlaceRepository _repo;
    private readonly WorkPlacesProfile _profile;
    private readonly MapperConfiguration _config;
    private readonly Mapper _mapper;
    private readonly WorkPlacesController _controller;
    const int START_YEAR = 2020, START_MONTH = 6, START_DAY = 6;
    const int END_YEAR = 2021, END_MONTH = 6, END_DAY = 6;
    const int ID = 1;
    const string COMPARE_VALUE = "Test Case";
  }
}
