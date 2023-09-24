using HealthCare_app.Models;
using HealthcareManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

public class AppointmentRepository : IRepository<Appointment>
{
    private readonly HealthcareDbContext _context;

    public AppointmentRepository(HealthcareDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await _context.Appointments.ToListAsync();
    }

    public async Task<Appointment> GetAsync(int id)
    {
        return await _context.Appointments.FindAsync(id);
    }

    public async Task<IEnumerable<Appointment>> FindAsync(Expression<Func<Appointment, bool>> predicate)
    {
        return await _context.Appointments.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Appointment entity)
    {
        await _context.Appointments.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IEnumerable<Appointment> entities)
    {
        await _context.Appointments.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public void Update(Appointment entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChangesAsync();
    }

    public void Remove(Appointment entity)
    {
        _context.Appointments.Remove(entity);
        _context.SaveChangesAsync();
    }

    public void RemoveRange(IEnumerable<Appointment> entities)
    {
        _context.Appointments.RemoveRange(entities);
        _context.SaveChangesAsync();
    }
}