using System.Linq;
using DotNetCoreCommandLineSnippets.API.Models;
using DotNetCoreCommandLineSnippets.API.Contexts;
using DotNetCoreCommandLineSnippets.API.Services;
using System.Collections.Generic;
using DotNetCoreCommandLineSnippets.API.Contexts;

namespace DotNetCoreCommandLineSnippets.API.Repostory
{
    public class SqlCommandAPIRepo : ICommandAPIService
    {
        private readonly CommandContext _context;
        public SqlCommandAPIRepo(CommandContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.CommandItems.ToList();
        }
        public Command GetCommandById(int id)
        {
                return _context.CommandItems.FirstOrDefault(p => p.Id == id);
        }

        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
 }