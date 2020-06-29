using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Data;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Controllers
{
    public class TaxisController : Controller
    {
        private readonly DataContext _context;

        public TaxisController(DataContext context)
        {
            _context = context;
        }

        // GET: Taxis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Taxis.ToListAsync());
        }

        // GET: Taxis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxyEntity = await _context.Taxis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taxyEntity == null)
            {
                return NotFound();
            }

            return View(taxyEntity);
        }

        // GET: Taxis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taxis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Placa")] TaxyEntity taxyEntity)
        {
            if (ModelState.IsValid)
            {
                taxyEntity.Placa = taxyEntity.Placa.ToUpper();
                _context.Add(taxyEntity);

                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if(ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Alerta! Esta placa ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(taxyEntity);
        }

        // GET: Taxis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxyEntity = await _context.Taxis.FindAsync(id);
            if (taxyEntity == null)
            {
                return NotFound();
            }
            return View(taxyEntity);
        }

        // POST: Taxis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaxyEntity taxyEntity)
        {
            if (id != taxyEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                taxyEntity.Placa = taxyEntity.Placa.ToUpper();
                _context.Update(taxyEntity);
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    if (ex.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Alerta! Esta placa ya existe");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, ex.InnerException.Message);
                    }
                }
            }
            return View(taxyEntity);
        }

        // GET: Taxis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taxyEntity = await _context.Taxis.FindAsync(id);
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (taxyEntity == null)
            {
                return NotFound();
            }

            _context.Taxis.Remove(taxyEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

      
    }
}
