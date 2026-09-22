using DaniilBudanovKt_31_23.Database;
using DaniilBudanovKt_31_23.Filters;
using DaniilBudanovKt_31_23.Models;
using DaniilBudanovKt_31_23.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaniilBudanovKt_31_23.Services.Implementations
{
    public class AcademicGroupService : IAcademicGroupService
    {
        private readonly StudentDbContext _context;

        public AcademicGroupService(StudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<AcademicGroup>> GetAcademicGroupsAsync(
            AcademicGroupFilter filter)
        {
            var query = _context.AcademicGroups.AsQueryable();

            if (filter.SpecialtyId.HasValue)
            {
                query = query.Where(x =>
                    x.SpecialtyId == filter.SpecialtyId.Value);
            }

            if (filter.Year.HasValue)
            {
                query = query.Where(x =>
                    x.Year == filter.Year.Value);
            }

            if (filter.IsDeleted.HasValue)
            {
                query = query.Where(x =>
                    x.IsDeleted == filter.IsDeleted.Value);
            }

            return await query.ToListAsync();
        }

        public async Task<AcademicGroup> AddAcademicGroupAsync(AcademicGroup group)
        {
            _context.AcademicGroups.Add(group);

            await _context.SaveChangesAsync();

            return group;
        }

        public async Task<AcademicGroup?> UpdateAcademicGroupAsync(AcademicGroup group)
        {
            var existingGroup = await _context.AcademicGroups.FirstOrDefaultAsync(x => x.Id == group.Id);
            if (existingGroup == null)
            {
                return null;
            }

            existingGroup.Name = group.Name;
            existingGroup.Year = group.Year;
            existingGroup.SpecialtyId = group.SpecialtyId;

            await _context.SaveChangesAsync();

            return existingGroup;
        }

        public async Task<bool> DeleteAcademicGroupAsync(int id)
        {
            var group = await _context.AcademicGroups.FirstOrDefaultAsync(x => x.Id == id);

            if (group == null)
            {
                return false;
            }

            group.IsDeleted = true;

            var students = await _context.Students
                .Where(x => x.AcademicGroupId == id)
                .ToListAsync();

            foreach (var student in students)
            {
                student.IsDeleted = true;
            }

            await _context.SaveChangesAsync();

            return true;
        }
    }
}