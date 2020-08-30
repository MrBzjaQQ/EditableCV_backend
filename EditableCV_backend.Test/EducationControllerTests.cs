using AutoMapper;
using EditableCV_backend.Controllers;
using EditableCV_backend.Data.EducationInstitutionData;
using EditableCV_backend.Data.WorkPlaceData;
using EditableCV_backend.DataTransferObjects.EducationalInstitutionDto;
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
  public class EducationControllerTests
  {
    public EducationControllerTests()
    {
      _repo = new MockEducationRepository();
      _profile = new ResumeProfile();
      _config = new MapperConfiguration(p => p.AddProfile(_profile));
      _mapper = new Mapper(_config);
      var mockValidator = new Mock<IObjectModelValidator>();
      mockValidator.Setup(o => o.Validate(
        It.IsAny<ActionContext>(),
        It.IsAny<ValidationStateDictionary>(),
        It.IsAny<string>(),
        It.IsAny<object>()
      ));
      _controller = new EducationController(_repo, _mapper)
      {
        ObjectValidator = mockValidator.Object,
      };
    }

    [Fact]
    public void GetAllInstitutions_ShouldReturnIEnumerableOfInstitutions()
    {
      // Arrange and act
      var institutionsResult = _controller.GetAllInstitutions();
      // Assert
      var okResult = Assert.IsType<OkObjectResult>(institutionsResult.Result);
    }

    [Fact]
    public void PostInstitution_ShouldCreateInstitution()
    {
      // Arrange
      InstitutionCreateDto createInstitution = new InstitutionCreateDto
      {
        Institution = "Best",
        Faculty = "Good",
        Progress = ":-)",
        StartDate = new DateTime(START_YEAR, START_MONTH, START_DAY),
        EndDate = new DateTime(END_YEAR, END_MONTH, END_DAY),
      };
      // Act
      var createResult = _controller.PostInstitution(createInstitution);
      // Assert
      var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(createResult.Result);
      var readInstitution = Assert.IsType<InstitutionReadDto>(createdAtRouteResult.Value);
      Assert.Equal(createInstitution.Institution, readInstitution.Institution);
      Assert.Equal(createInstitution.Faculty, readInstitution.Faculty);
      Assert.Equal(createInstitution.Progress, readInstitution.Progress);
      Assert.Equal(createInstitution.StartDate.Year, readInstitution.StartDate.Year);
      Assert.Equal(createInstitution.StartDate.Month, readInstitution.StartDate.Month);
      Assert.Equal(createInstitution.StartDate.Day, readInstitution.StartDate.Day);
      Assert.Equal(createInstitution.EndDate.Year, readInstitution.EndDate.Year);
      Assert.Equal(createInstitution.EndDate.Month, readInstitution.EndDate.Month);
      Assert.Equal(createInstitution.EndDate.Day, readInstitution.EndDate.Day);
    }

    [Fact]
    public void DeleteInstitution_ShouldDeleteEntity()
    {
      // Arrange
      InstitutionCreateDto createInstitution = new InstitutionCreateDto
      {
        Institution = "Best",
        Faculty = "Good",
        Progress = ":-)",
        StartDate = new DateTime(START_YEAR, START_MONTH, START_DAY),
        EndDate = new DateTime(END_YEAR, END_MONTH, END_DAY),
      };
      // Act & Assert
      var createResult = _controller.PostInstitution(createInstitution);
      var createdAtRouteResult = Assert.IsType<CreatedAtRouteResult>(createResult.Result);
      var readInstitution = Assert.IsType<InstitutionReadDto>(createdAtRouteResult.Value);
      var deleteResult = _controller.DeleteInstitution(readInstitution.Id);
      var okResult = Assert.IsType<OkObjectResult>(deleteResult.Result);
      var deletedItem = Assert.IsType<InstitutionReadDto>(okResult.Value);
      var notFound = Assert.IsType<NotFoundResult>(_controller.GetInstitutionById(deletedItem.Id).Result);
    }

    [Fact]
    public void PostWorkPlace_ShouldReturnBadRequest()
    {
      // Arrange
      InstitutionCreateDto createDto = new InstitutionCreateDto
      {
        // Empty
      };
      // Act
      var result = _controller.PostInstitution(createDto);
      // Assert
      var createdAtRoute = Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public void PatchInstitution_ShouldUpdateModel()
    {
      // Arrange
      JsonPatchDocument<InstitutionUpdateDto> patchDoc = new JsonPatchDocument<InstitutionUpdateDto>(
        new List<Microsoft.AspNetCore.JsonPatch.Operations.Operation<InstitutionUpdateDto>>
        {
          new Operation<InstitutionUpdateDto>("replace", "/institution", null, COMPARE_VALUE),
          new Operation<InstitutionUpdateDto>("replace", "/faculty", null, COMPARE_VALUE),
        },
        new DefaultContractResolver()
      );
      // Act & Assert
      Assert.IsType<NoContentResult>(_controller.PatchInstitution(ID, patchDoc));
      var okResult = Assert.IsType<OkObjectResult>(_controller.GetInstitutionById(ID).Result);
      var itemData = Assert.IsType<InstitutionReadDto>(okResult.Value);
      Assert.Equal(COMPARE_VALUE, itemData.Institution);
      Assert.Equal(COMPARE_VALUE, itemData.Faculty);
    }
    [Fact]
    public void PatchInstitution_ShouldReturnBadRequest()
    {
      // Arrange
      JsonPatchDocument<InstitutionUpdateDto> patchDoc = new JsonPatchDocument<InstitutionUpdateDto>(
        new List<Microsoft.AspNetCore.JsonPatch.Operations.Operation<InstitutionUpdateDto>>
        {
          new Operation<InstitutionUpdateDto>("replace", "/institution", null, null),
          new Operation<InstitutionUpdateDto>("replace", "/faculty", null, null),
        },
        new DefaultContractResolver()
      );
      // Act & Assert
      Assert.IsType<BadRequestObjectResult>(_controller.PatchInstitution(ID, patchDoc));
    }

    private readonly MockEducationRepository _repo;
    private readonly ResumeProfile _profile;
    private readonly MapperConfiguration _config;
    private readonly Mapper _mapper;
    private readonly EducationController _controller;
    const int START_YEAR = 2020, START_MONTH = 6, START_DAY = 6;
    const int END_YEAR = 2021, END_MONTH = 6, END_DAY = 6;
    const int ID = 1;
    const string COMPARE_VALUE = "Test Case";
  }
}
