using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto03_WSChamados.Models
{
    public class ChamadosContext : DbContext
    {
        public ChamadosContext() : 
            base("name=ChamadosEntities"){ }
                
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Chamado>()
                .ToTable("TBChamados");

            modelBuilder.Entity<Chamado>().Property(c => c.Cnpj)                
                .HasMaxLength(14)
                .IsRequired();

            modelBuilder.Entity<Chamado>().Property(c => c.DataChamado)
                .HasColumnType("DateTime")                
                .IsRequired();

        }

        public DbSet<Chamado> Chamados { get; set; }        

    }
}