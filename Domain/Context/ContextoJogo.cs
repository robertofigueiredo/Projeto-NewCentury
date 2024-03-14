using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Context
{
    public class ContextoJogo : DbContext
    {

        public DbSet<AdivinhaInteiro> AdivinhaInteiro {  get; set; }

        public ContextoJogo(DbContextOptions<ContextoJogo> options) : base(options)
        {
            
        }
    }
}
