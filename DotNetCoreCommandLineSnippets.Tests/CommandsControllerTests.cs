using System;
using Xunit;
using DotNetCoreCommandLineSnippets.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Moq;
using AutoMapper;
using DotNetCoreCommandLineSnippets.API.Models;
using DotNetCoreCommandLineSnippets.API.Services;
using DotNetCoreCommandLineSnippets.API.Profiles;

namespace DotNetCoreCommandLineSnippets.Tests
{
    public class CommandsControllerTests: IDisposable
    {
        Mock<ICommandAPIService> mockRepo;
        CommandsProfile realProfile;
        MapperConfiguration configuration;
        IMapper mapper;
        
        public CommandsControllerTests()
        {
            mockRepo = new Mock<ICommandAPIService>();
            realProfile = new CommandsProfile();
            configuration = new MapperConfiguration(cfg => cfg.
            AddProfile(realProfile));
            mapper = new Mapper(configuration);
        }

        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            configuration = null;
            realProfile = null;
        }

        [Fact]
        public void GetCommandItems_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetAllCommands()).Returns(GetCommands(0));
            var controller = new CommandsController(mockRepo.Object, mapper);

            //Act
            var result = controller.GetAllCommands();
            
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllCommands_ReturnsOneItem_WhenDBHasOneResource_Old()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetAllCommands()).Returns(GetCommands(1));
            var controller = new CommandsController(mockRepo.Object, mapper);
            
            //Act
            var result = controller.GetAllCommands();
            
            //Assert
            var okResult = result.Result as OkObjectResult;
            var commands = okResult.Value as List<CommandReadDto>;
            Assert.Single(commands);
        }

        [Fact]
        public void GetAllCommands_Returns200OK_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetAllCommands()).Returns(GetCommands(1));
            var controller = new CommandsController(mockRepo.Object, mapper);
            //Act
            var result = controller.GetAllCommands();
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetAllCommands_ReturnsCorrectType_WhenDBHasOneResource()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetAllCommands()).Returns(GetCommands(1));
            var controller = new CommandsController(mockRepo.Object, mapper);
            
            //Act
            var result = controller.GetAllCommands();
            
            //Assert
            Assert.IsType<ActionResult<IEnumerable<CommandReadDto>>>(result);
        }

        [Fact]
        public void GetCommandByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetCommandById(0)).Returns(() => null);
            var controller = new CommandsController(mockRepo.Object, mapper);
            
            //Act
            var result = controller.GetCommandById(1);
            
            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetCommandByID_Returns200OK__WhenValidIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetCommandById(1)).Returns(new Command { Id = 1,
            HowTo = "mock",
            Platform = "Mock",
            CommandLine = "Mock" });
            var controller = new CommandsController(mockRepo.Object, mapper);
            
            //Act
            var result = controller.GetCommandById(1);
            
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetCommandByID_Returns200OK__WhenValidIDProvided()
        {
            //Arrange
            mockRepo.Setup(repo =>
            repo.GetCommandById(1)).Returns(new Command { Id = 1,
            HowTo = "mock",
            Platform = "Mock",
            CommandLine = "Mock" });
            var controller = new CommandsController(mockRepo.Object, mapper);
            
            //Act
            var result = controller.GetCommandById(1);
            
            //Assert
            Assert.IsType<ActionResult<CommandReadDto>>(result);
        }

        private List<Command> GetCommands(int num)
        {
            var commands = new List<Command>();
            if (num > 0)
            {
                commands.Add(new Command
                        {
                            Id = 0,
                            HowTo = "How to generate a migration",
                            CommandLine = "dotnet ef migrations add <Name of Migration>",
                            Platform = ".Net Core EF"
                        });
            }
        
            return commands;
        }
    }
}