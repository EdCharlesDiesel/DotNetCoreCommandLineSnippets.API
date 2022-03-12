using AutoMapper;
using DotNetCoreCommandLineSnippets.API.Dtos;
using DotNetCoreCommandLineSnippets.API.Models;
namespace DotNetCoreCommandLineSnippets.API.Profiles
{
xzczxc public class CommandsProfile : Profile
 {
 public CommandsProfile()
 {
 CreateMap<Command, CommandReadDto>();
 }
 }
}