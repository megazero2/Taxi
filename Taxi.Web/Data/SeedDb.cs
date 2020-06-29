using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckTaxisAsync();
        }

        private async Task CheckTaxisAsync()
        {
            if (_dataContext.Taxis.Any())
            {
                return;
            }

            _dataContext.Taxis.Add(new TaxyEntity
            {
                Placa = "TPQ123",
                Viajes = new List<ViajeEntity>
                {
                    new ViajeEntity
                    {
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30), 
                        Qualification = 4.5f,
                        Source = "ITM Fraternidad",
                        Target = "ITM Robledo",
                        Remarks = "Muy buen servicio"
                    },
                    new ViajeEntity
                    {
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.8f,
                        Source = "ITM Robledo",
                        Target = "ITM Fraternidad",
                        Remarks = "Conductor muy amable"
                    }
                }
            });

            _dataContext.Taxis.Add(new TaxyEntity
            {
                Placa = "THW321",
                Viajes = new List<ViajeEntity>
                {
                    new ViajeEntity
                    {
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.5f,
                        Source = "ITM Fraternidad",
                        Target = "ITM Robledo",
                        Remarks = "Muy buen servicio"
                    },
                    new ViajeEntity
                    {
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMinutes(30),
                        Qualification = 4.8f,
                        Source = "ITM Robledo",
                        Target = "ITM Fraternidad",
                        Remarks = "Conductor muy amable"
                    }
                }
            });

        }
    }
}
