using SweeftTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftTasks.Data
{
    public static class SeedData
    {
        public static void Seed(SchoolDbContext context)
        {
            if (context.Teachers.Any())
                return;

            var teacher1 = new Teacher { FirstName = "John", LastName = "smith", Subject = "Math" };
            var teacher2 = new Teacher { FirstName = "walter", LastName = "white", Subject = "Science" };

            var pupil1 = new Pupil { FirstName = "Jesse", LastName = "Pinkman" };
            var pupil2 = new Pupil { FirstName = "Giorgi", LastName = "Johnson" };
            var pupil3 = new Pupil { FirstName = "Johnny", LastName = "White" };

            teacher1.Pupils.Add(pupil1);
            teacher2.Pupils.Add(pupil1);
            teacher2.Pupils.Add(pupil2);
            teacher1.Pupils.Add(pupil3);

            context.Teachers.AddRange(teacher1, teacher2);

            context.SaveChanges();
        }
    }
}
