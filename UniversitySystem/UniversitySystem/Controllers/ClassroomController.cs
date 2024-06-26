using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.Context;
using UniversitySystem.Entities;
using UniversitySystem.Models;

namespace UniversitySystem.Controllers;

[Authorize(Roles = "AdministrativeEmployee")]
public class ClassroomController : Controller
{
    private readonly UniversityContext _context;

    public ClassroomController(UniversityContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var classrooms = await _context.Classrooms
            .Select(c => new ClassroomViewModel
            {
                Id = c.Id,
                Building = c.Building,
                RoomNumber = c.RoomNumber,
                Capacity = c.Capacity
            }).ToListAsync();

        return View(classrooms);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ClassroomViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var classroom = new Classroom
        {
            Building = viewModel.Building,
            RoomNumber = viewModel.RoomNumber,
            Capacity = viewModel.Capacity
        };

        _context.Add(classroom);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classroom = await _context.Classrooms.FindAsync(id);
        if (classroom == null)
        {
            return NotFound();
        }

        var viewModel = new ClassroomViewModel
        {
            Id = classroom.Id,
            Building = classroom.Building,
            RoomNumber = classroom.RoomNumber,
            Capacity = classroom.Capacity
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ClassroomViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var classroom = await _context.Classrooms.FindAsync(id);
        if (classroom == null)
        {
            return NotFound();
        }

        classroom.Building = viewModel.Building;
        classroom.RoomNumber = viewModel.RoomNumber;
        classroom.Capacity = viewModel.Capacity;

        _context.Update(classroom);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var classroom = await _context.Classrooms.FirstOrDefaultAsync(m => m.Id == id);
        if (classroom == null)
        {
            return NotFound();
        }

        var viewModel = new ClassroomViewModel
        {
            Id = classroom.Id,
            Building = classroom.Building,
            RoomNumber = classroom.RoomNumber,
            Capacity = classroom.Capacity
        };

        return View(viewModel);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var classroom = await _context.Classrooms.FindAsync(id);

        _context.Classrooms.Remove(classroom!);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}