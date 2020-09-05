using AutoMapper;
using EditableCV_backend.Controllers;
using EditableCV_backend.Data.Skills;
using EditableCV_backend.DataTransferObjects.SkillDto;
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
using System.Text;
using Xunit;

namespace EditableCV_backend.Test
{
  public class SkillControllerTests
  {
    public SkillControllerTests()
    {
      _repo = new MockSkillsRepository();
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
      _controller = new SkillsController(_repo, _mapper)
      {
        ObjectValidator = mockValidator.Object,
      };
    }

    [Fact]
    public void GetAllSkills_ShouldReturnIEnumerableOfSkills()
    {
      // Arrange
      IEnumerable<Skill> skills = _repo.GetAllSkills();
      // Act
      var skillsResult = _controller.GetAllSkills();
      // Assert
      var okResultResult = Assert.IsType<OkObjectResult>(skillsResult.Result);
    }

    [Fact]
    public void PostSkill_ShouldCreateSkill()
    {
      // Arrange
      SkillCreateDto createDto = new SkillCreateDto
      {
        Name = "Name 3",
        Description = "Description 3",
      };
      // Act
      var result = _controller.PostSkill(createDto);
      // Assert
      var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
      var readDto = Assert.IsType<SkillReadDto>(createdAtRoute.Value);
      Assert.Equal(createDto.Name, readDto.Name);
      Assert.Equal(createDto.Description, readDto.Description);
    }

    [Fact]
    public void PostWorkPlace_ShouldReturnBadRequest()
    {
      // Arrange
      SkillCreateDto createDto = new SkillCreateDto
      {
        Name = string.Empty,
      };
      // Act
      var result = _controller.PostSkill(createDto);
      // Assert
      Assert.IsType<BadRequestObjectResult>(result.Result);
    }

    [Fact]
    public void DeleteWorkPlace_ShouldDeleteEntity()
    {
      // Arrange
      SkillCreateDto createDto = new SkillCreateDto
      {
        Name = "Name 3",
        Description = "Description 3",
      };
      // Act
      var result = _controller.PostSkill(createDto);
      // Assert
      var createdAtRoute = Assert.IsType<CreatedAtRouteResult>(result.Result);
      var readDto = Assert.IsType<SkillReadDto>(createdAtRoute.Value);
      var deleteResult = _controller.DeleteSkill(readDto.Id);
      var okResult = Assert.IsType<OkObjectResult>(deleteResult.Result);
      var deletedItem = Assert.IsType<SkillReadDto>(okResult.Value);
      Assert.IsType<NotFoundResult>(_controller.GetSkillById(deletedItem.Id).Result);
    }

    [Fact]
    public void PatchSkill_ShouldUpdateModel()
    {
      // Arrange
      JsonPatchDocument<SkillUpdateDto> patchDoc = new JsonPatchDocument<SkillUpdateDto>(
        new List<Microsoft.AspNetCore.JsonPatch.Operations.Operation<SkillUpdateDto>>
        {
          new Operation<SkillUpdateDto>("replace", "/name", null, COMPARE_VALUE),
          new Operation<SkillUpdateDto>("replace", "/description", null, COMPARE_VALUE),
        },
        new DefaultContractResolver()
      );
      // Act & Assert
      Assert.IsType<NoContentResult>(_controller.PatchSkill(ID, patchDoc));
      var okResult = Assert.IsType<OkObjectResult>(_controller.GetSkillById(ID).Result);
      var skillReadDto = Assert.IsType<SkillReadDto>(okResult.Value);
      Assert.Equal(COMPARE_VALUE, skillReadDto.Name);
      Assert.Equal(COMPARE_VALUE, skillReadDto.Description);
    }

    [Fact]
    public void PatchWorkPlace_ShouldReturnValidationProblem()
    {
      // Arrange
      JsonPatchDocument<SkillUpdateDto> patchDoc = new JsonPatchDocument<SkillUpdateDto>(
        new List<Microsoft.AspNetCore.JsonPatch.Operations.Operation<SkillUpdateDto>>
        {
          new Operation<SkillUpdateDto>("replace", "/name", null, null),
          new Operation<SkillUpdateDto>("replace", "/description", null, string.Empty),
        },
        new DefaultContractResolver()
      );
      Assert.IsType<BadRequestObjectResult>(_controller.PatchSkill(ID, patchDoc));
    }

    private readonly MockSkillsRepository _repo;
    private readonly ResumeProfile _profile;
    private readonly MapperConfiguration _config;
    private readonly Mapper _mapper;
    private readonly SkillsController _controller;
    private const string COMPARE_VALUE = "Compare Value";
    private const int ID = 1;
  }
}
