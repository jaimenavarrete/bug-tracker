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
            await _context.Projects.ToListAsync();

        public async Task<Project> GetById(string id) => 
            await _context.Projects.FirstAsync(p => p.Id == id);

        public async Task<Project> Insert(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<Project> Update(Project project)
        {
            _context.Update(project);
            await _context.SaveChangesAsync();

            return project;
        }

        public async Task<bool> Delete(string id)
        {
            var project = await GetById(id);

            _context.Remove(project);
            var rows = await _context.SaveChangesAsync();

            return rows > 0;
        }
    }
}
