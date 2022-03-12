using System.Linq;

namespace DotNetCoreCommandLineSnippets.API.Repostory
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
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
    }
 }