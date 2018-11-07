using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STI.Data
{
    public class DBInitializer
    {
        public static void Initialize(STIContext context)
        {
            context.Database.EnsureCreated();
            if (context.curso.Any())
            {
                return;
            }
            {
                var curso = new curso[]
                {
                    new curso {};

                foreach (curso a in curso)
                {
                    context.curso.Add(a);
                }
                    context.SaveChanges();
                }
            }
        }
    }
}
