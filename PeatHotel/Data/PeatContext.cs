using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeatHotel.Models;

namespace PeatHotel.Data
{
    public class PeatContext : DbContext
    {
        public PeatContext (DbContextOptions<PeatContext> options)
            : base(options)
        {
        }

        public DbSet<PeatHotel.Models.Cliente> Cliente { get; set; }

        public DbSet<PeatHotel.Models.HospedagemTipo> HospedagemTipo { get; set; }

        public DbSet<PeatHotel.Models.Peat> Peat { get; set; }

        public DbSet<PeatHotel.Models.Servico> Servico { get; set; }

        public DbSet<PeatHotel.Models.Hospedagem> Hospedagem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Cliente");
            modelBuilder.Entity<HospedagemTipo>().ToTable("HospedagemTipo");
            modelBuilder.Entity<Peat>().ToTable("Peat");
            modelBuilder.Entity<Servico>().ToTable("Servico");
            modelBuilder.Entity<Hospedagem>().ToTable("Hospedagem");
        }

        public DbSet<PeatHotel.Models.HistoricoPeat> HistoricoPeat { get; set; }
    }
}
