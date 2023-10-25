using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GuillermoAlvarez_Examen1P.Models;

namespace GuillermoAlvarez_Examen1P.Data
{
    public class GuillermoAlvarez_Examen1PContext : DbContext
    {
        public GuillermoAlvarez_Examen1PContext (DbContextOptions<GuillermoAlvarez_Examen1PContext> options)
            : base(options)
        {
        }

        public DbSet<GuillermoAlvarez_Examen1P.Models.GuillermoAlvarez_Tabla> GuillermoAlvarez_Tabla { get; set; } = default!;
    }
}
