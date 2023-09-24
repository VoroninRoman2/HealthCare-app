using HealthCare_app.Models;
using HealthcareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class PatientRepository : IRepository<Patient>
{
    private readonly HealthcareDbContext _context;

    public PatientRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<Patient> GetAsync(int id)
    {
        return await _context.Patients.FindAsync(id);
    }

    public async Task<IEnumerable<Patient>> FindAsync(Expression<Func<Patient, bool>> predicate)
    {
        return await _context.Patients.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Patient entity)
    {
        await _context.Patients.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<Patient> entities)
    {
        await _context.Patients.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public void Update(Patient entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChangesAsync();
    }

    public void Remove(Patient entity)
    {
        _context.Patients.Remove(entity);
        _context.SaveChangesAsync();
    }

    public void RemoveRange(IEnumerable<Patient> entities)
    {
        _context.Patients.RemoveRange(entities);
        _context.SaveChangesAsync();
    }
}