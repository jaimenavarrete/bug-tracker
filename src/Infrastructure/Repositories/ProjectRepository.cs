using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly BugTrackerContext _context;

        public ProjectRepository(BugTrackerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAll() => 
            await _context.Projects.ToListAsync() ?? Enumerable.Empty<Project>();

        public async Task<Project?> GetById(string id) => 
            await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

        public async Task<bool> Insert(Project project)
        {
            _context.Projects.Add(project);
            var affectedRows = await _context.SaveChangesAsync();

            return affectedRows > 0;
        }

        public async Task<bool> Update(Project project)
        {
            _context.Update(project);
            var affectedRows = await _context.SaveChangesAsync();

            return affectedRows > 0;
        }

        public async Task<bool> Delete(Project project)
        {
            _context.Remove(project);
            var affectedRows = await _context.SaveChangesAsync();

            return affectedRows > 0;
        }
    }
}
