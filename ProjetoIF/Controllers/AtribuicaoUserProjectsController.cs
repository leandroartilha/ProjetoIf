using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoIF.Context;
using ProjetoIF.Models;

namespace ProjetoIF.Controllers
{
    public class AtribuicaoUserProjectsController : Controller
    {
        private readonly AppDbContext _context;

        public AtribuicaoUserProjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AtribuicaoUserProjects
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AtribuicaoUserProject.Include(a => a.Projeto).Include(a => a.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AtribuicaoUserProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AtribuicaoUserProject == null)
            {
                return NotFound();
            }

            var atribuicaoUserProject = await _context.AtribuicaoUserProject
                .Include(a => a.Projeto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atribuicaoUserProject == null)
            {
                return NotFound();
            }

            return View(atribuicaoUserProject);
        }

        // GET: AtribuicaoUserProjects/Create
        public IActionResult Create(int projetoId)
        {
            ViewBag.ProjetoId = projetoId;

            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "EmailUsuario");
            ViewData["NomeUsuarioId"] = new SelectList(_context.Usuario, "Id", "NomeUsuario");
            return View();
        }

        // POST: AtribuicaoUserProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtribuicaoUserProject atribuicaoUserProject, int idprojeto)
        {
            var userName = _context.Usuario.Where(u => u.Id == atribuicaoUserProject.UsuarioId).Select(u => u.NomeUsuario).FirstOrDefault();

            atribuicaoUserProject.ProjetoId = idprojeto;
            atribuicaoUserProject.NomeUsuarioAtribuido = userName;
            _context.Add(atribuicaoUserProject);
            await _context.SaveChangesAsync();

            return RedirectToAction("Edit", "Projetos", new { id = idprojeto });
        }

        // GET: AtribuicaoUserProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AtribuicaoUserProject == null)
            {
                return NotFound();
            }

            var atribuicaoUserProject = await _context.AtribuicaoUserProject.FindAsync(id);
            if (atribuicaoUserProject == null)
            {
                return NotFound();
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "Id", "Id", atribuicaoUserProject.ProjetoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "EmailUsuario", atribuicaoUserProject.UsuarioId);
            return View(atribuicaoUserProject);
        }

        // POST: AtribuicaoUserProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,NomeUsuarioAtribuido,ProjetoId")] AtribuicaoUserProject atribuicaoUserProject)
        {
            if (id != atribuicaoUserProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atribuicaoUserProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtribuicaoUserProjectExists(atribuicaoUserProject.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjetoId"] = new SelectList(_context.Projeto, "Id", "Id", atribuicaoUserProject.ProjetoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "EmailUsuario", atribuicaoUserProject.UsuarioId);
            return View(atribuicaoUserProject);
        }

        // GET: AtribuicaoUserProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AtribuicaoUserProject == null)
            {
                return NotFound();
            }

            var atribuicaoUserProject = await _context.AtribuicaoUserProject
                .Include(a => a.Projeto)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atribuicaoUserProject == null)
            {
                return NotFound();
            }

            return View(atribuicaoUserProject);
        }

        // POST: AtribuicaoUserProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AtribuicaoUserProject == null)
            {
                return Problem("Entity set 'AppDbContext.AtribuicaoUserProject'  is null.");
            }
            var atribuicaoUserProject = await _context.AtribuicaoUserProject.FindAsync(id);
            if (atribuicaoUserProject != null)
            {
                _context.AtribuicaoUserProject.Remove(atribuicaoUserProject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtribuicaoUserProjectExists(int id)
        {
          return (_context.AtribuicaoUserProject?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
