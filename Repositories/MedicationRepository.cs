using HealthCare_app.Models;
using HealthcareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class MedicationRepository : IRepository<Medication>
{
    private readonly HealthcareDbContext _context;

    public MedicationRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medication>> GetAllAsync()
    {
        return await _context.Medications.ToListAsync();
    }

    public async Task<Medication> GetAsync(int id)
    {
        return await _context.Medications.FindAsync(id);
    }

    public async Task<IEnumerable<Medication>> FindAsync(Expression<Func<Medication, bool>> predicate)
    {
        return await _context.Medications.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Medication entity)
    {
        await _context.Medications.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<Medication> entities)
    {
        await _context.Medications.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public void Update(Medication entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChangesAsync();
    }

    public void Remove(Medication entity)
    {
        _context.Medications.Remove(entity);
        _context.SaveChangesAsync();
    }

    public void RemoveRange(IEnumerable<Medication> entities)
    {
        _context.Medications.RemoveRange(entities);
        _context.SaveChangesAsync();
    }
}