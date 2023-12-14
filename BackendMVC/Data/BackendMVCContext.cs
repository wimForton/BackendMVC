using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BackendMVC.Models;

namespace BackendMVC.Data
{
    public class BackendMVCContext : IdentityDbContext
    {
        public BackendMVCContext (DbContextOptions<BackendMVCContext> options)
            : base(options)
        {
        }

        public DbSet<BackendMVC.Models.Movie> Movie { get; set; } = default!;
        public DbSet<BackendMVC.Models.MidifileModel> MidifileModel { get; set; } = default!;
    }
}
