using Microsoft.EntityFrameworkCore;
using SixMinApi.Models;

namespace SixMinApi.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCommand(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            await _context.AddAsync(cmd);
        }

        public void Delete(Command cmd)
        {
            if (cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Remove(cmd);
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            return await _context.Commands.ToListAsync();
        }

        public async Task<Command?> GetCommandById(int id)
        {
            return await _context.Commands.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}