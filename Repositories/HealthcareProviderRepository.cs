using HealthCare_app.Models;
using HealthcareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class HealthcareProviderRepository : IRepository<HealthcareProvider>
{
    private readonly HealthcareDbContext _context;

    public HealthcareProviderRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<HealthcareProvider>> GetAllAsync()
    {
        return await _context.HealthcareProviders.Include(h => h.Facility).ToListAsync();
    }

    public async Task<HealthcareProvider> GetAsync(int id)
    {
        return await _context.HealthcareProviders.Include(h => h.Facility).FirstOrDefaultAsync(h => h.Id == id);
    }

    public async Task<IEnumerable<HealthcareProvider>> FindAsync(Expression<Func<HealthcareProvider, bool>> predicate)
    {
        return await _context.HealthcareProviders.Include(h => h.Facility).Where(predicate).ToListAsync();
    }

    public async Task AddAsync(HealthcareProvider entity)
    {
        await _context.HealthcareProviders.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<HealthcareProvider> entities)
    {
        await _context.HealthcareProviders.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public void Update(HealthcareProvider entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChangesAsync();
    }

    public void Remove(HealthcareProvider entity)
    {
        _context.HealthcareProviders.Remove(entity);
        _context.SaveChangesAsync();
    }

    public void RemoveRange(IEnumerable<HealthcareProvider> entities)
    {
        _context.HealthcareProviders.RemoveRange(entities);
        _context.SaveChangesAsync();
    }
}