using HealthCare_app.Models;
using HealthcareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class FacilityRepository : IRepository<Facility>
{
    private readonly HealthcareDbContext _context;

    public FacilityRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Facility>> GetAllAsync()
    {
        return await _context.Facilities.ToListAsync();
    }

    public async Task<Facility> GetAsync(int id)
    {
        return await _context.Facilities.FindAsync(id);
    }

    public async Task<IEnumerable<Facility>> FindAsync(Expression<Func<Facility, bool>> predicate)
    {
        return await _context.Facilities.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Facility entity)
    {
        await _context.Facilities.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<Facility> entities)
    {
        await _context.Facilities.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public void Update(Facility entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChangesAsync();
    }

    public void Remove(Facility entity)
    {
        _context.Facilities.Remove(entity);
        _context.SaveChangesAsync();
    }

    public void RemoveRange(IEnumerable<Facility> entities)
    {
        _context.Facilities.RemoveRange(entities);
        _context.SaveChangesAsync();
    }
}