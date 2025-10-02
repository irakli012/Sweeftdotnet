using Microsoft.EntityFrameworkCore;
using SweeftTasks.Data;
using SweeftTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftTasks.Services
{
    public class TeacherService
    {
        public Teacher[] GetAllTeachersByStudent(string studentName)
        {
            using var context = new SchoolDbContext();

            return context.Teachers
                .Include(t => t.Pupils)
                .Where(t => t.Pupils.Any(p => p.FirstName == studentName))
                .ToArray();
        }
    }
}
