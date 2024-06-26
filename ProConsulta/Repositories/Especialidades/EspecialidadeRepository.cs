﻿using Microsoft.EntityFrameworkCore;
using ProConsulta.Data;
using ProConsulta.Models;

namespace ProConsulta.Repositories.Especialidades;

public class EspecialidadeReposity : IEspecialidadeRepository
{
    private readonly ApplicationDbContext _context;
    public EspecialidadeReposity(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Especialidade>> GetAllAsync()
    {
		try
		{
			var especialidades = await _context.Especialidades
			.AsNoTracking()
			.ToListAsync();

			return especialidades;
		}
		catch (Exception)
		{
			_context.ChangeTracker.Clear();
			throw;
		}
    }
}

