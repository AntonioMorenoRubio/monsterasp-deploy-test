using Microsoft.EntityFrameworkCore;
using monster.web.Domain.Entities;

namespace monster.web.Data.DAO;

public class BarcoDao(AppDbContext context)
{

    public async Task<List<Barco>> GetAll()
    { 
        return await context.Barcos.ToListAsync();
    }
    
    public async Task<Barco?> FindById(int id)
    {
        return await context.Barcos.FindAsync(id).AsTask();
    }

    public async Task<Barco> Insert(Barco barco)
    {
        context.Barcos.Add(barco);
        await context.SaveChangesAsync();
        return barco;
    }

    public async Task<Barco> Update(Barco barco)
    {
        var existing = await context.Barcos.FindAsync(barco.Id);
        if (existing is null) return null;

        context.Entry(existing).CurrentValues.SetValues(barco);
        await context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> Delete(int id)
    {
        var barco = await context.Barcos.FindAsync(id);
        if (barco is null) return false;

        context.Barcos.Remove(barco);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Exists(Barco barco)
    {
        var existing = await context.Barcos.FirstOrDefaultAsync(x => x.Nombre == barco.Nombre);
        return existing is not null ? true : false;
    }
}