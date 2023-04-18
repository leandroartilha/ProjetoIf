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
    public class AtribuicaoUserTasksController : Controller
    {
        private readonly AppDbContext _context;

        public AtribuicaoUserTasksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AtribuicaoUserTasks
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AtribuicaoUserTask.Include(a => a.Tarefa).Include(a => a.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AtribuicaoUserTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AtribuicaoUserTask == null)
            {
                return NotFound();
            }

            var atribuicaoUserTask = await _context.AtribuicaoUserTask
                .Include(a => a.Tarefa)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atribuicaoUserTask == null)
            {
                return NotFound();
            }

            return View(atribuicaoUserTask);
        }

        // GET: AtribuicaoUserTasks/Create
        public IActionResult Create(int tarefaId)
        {
            ViewBag.TarefaId = tarefaId;

            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "EmailUsuario");
            ViewData["NomeUsuarioId"] = new SelectList(_context.Usuario, "Id", "NomeUsuario");
            return View();
        }

        // POST: AtribuicaoUserTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AtribuicaoUserTask atribuicaoUserTask, int idtarefa)
        {
            var userName = _context.Usuario.Where(u => u.Id == atribuicaoUserTask.UsuarioId).Select(u => u.NomeUsuario).FirstOrDefault();

            atribuicaoUserTask.TarefaId = idtarefa;
            atribuicaoUserTask.NomeUsuarioAtribuido = userName;
            _context.Add(atribuicaoUserTask);
                await _context.SaveChangesAsync();

            return RedirectToAction("Edit", "Tarefas", new { id = idtarefa });
        }

        // GET: AtribuicaoUserTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AtribuicaoUserTask == null)
            {
                return NotFound();
            }

            var atribuicaoUserTask = await _context.AtribuicaoUserTask.FindAsync(id);
            if (atribuicaoUserTask == null)
            {
                return NotFound();
            }
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "Id", "Id", atribuicaoUserTask.TarefaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "EmailUsuario", atribuicaoUserTask.UsuarioId);
            return View(atribuicaoUserTask);
        }

        // POST: AtribuicaoUserTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,NomeUsuarioAtribuido,TarefaId")] AtribuicaoUserTask atribuicaoUserTask)
        {
            if (id != atribuicaoUserTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atribuicaoUserTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtribuicaoUserTaskExists(atribuicaoUserTask.Id))
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
            ViewData["TarefaId"] = new SelectList(_context.Tarefa, "Id", "Id", atribuicaoUserTask.TarefaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "EmailUsuario", atribuicaoUserTask.UsuarioId);
            return View(atribuicaoUserTask);
        }

        // GET: AtribuicaoUserTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AtribuicaoUserTask == null)
            {
                return NotFound();
            }

            var atribuicaoUserTask = await _context.AtribuicaoUserTask
                .Include(a => a.Tarefa)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (atribuicaoUserTask == null)
            {
                return NotFound();
            }

            return View(atribuicaoUserTask);
        }

        // POST: AtribuicaoUserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AtribuicaoUserTask == null)
            {
                return Problem("Entity set 'AppDbContext.AtribuicaoUserTask'  is null.");
            }
            var atribuicaoUserTask = await _context.AtribuicaoUserTask.FindAsync(id);
            if (atribuicaoUserTask != null)
            {
                _context.AtribuicaoUserTask.Remove(atribuicaoUserTask);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtribuicaoUserTaskExists(int id)
        {
          return (_context.AtribuicaoUserTask?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
