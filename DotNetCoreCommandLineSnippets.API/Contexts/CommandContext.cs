using Microsoft.EntityFrameworkCore;
using DotNetCoreCommandLineSnippets.API.Models;

using  Microsoft.EntityFrameworkCore;
namespace DotNetCoreCommandLineSnippets.API.Contexts
{
 public class CommandContext : DbContext
 {
    public CommandContext(DbContextOptions<CommandContext> options)
    : base(options)
    {
    }
    public DbSet<Command> CommandItems {get; set;}
 }
}