using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STI.Models;

namespace STI.Data
{
    public class DBInitializer
    {
        public static void Initialize(STIContext context)
        {
            context.Database.EnsureCreated();
            if (context.temas_curso.Any())
            {
                return;
            }
            var temas_curso = new temas_curso[]
            {

            };

            foreach (temas_curso a in temas_curso)
            {
                context.temas_curso.Add(a);
                {
                    context.SaveChanges();
                }
            }
        }
    }
}
