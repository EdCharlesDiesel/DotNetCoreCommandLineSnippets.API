using AutoMapper;
using DotNetCoreCommandLineSnippets.API.Dtos;
using DotNetCoreCommandLineSnippets.API.Models;

namespace DotNetCoreCommandLineSnippets.API.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<CommandUpdateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
        }
    }
}