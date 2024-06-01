﻿using Microsoft.EntityFrameworkCore;
using WebAPI.DAL.Entities;

namespace WebAPI.DAL
{
    public class DataBaseContext : DbContext
    {
        //Así me conecto a la BD por medio de este constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        //Este método que es propio de EF CORE me sirve para configurar unos índices de cada campo de una tabla en BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); //Aquí creo un índice del campo Name para la tabla Countries
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique(); // Haciendo un índice compuesto
        }

        #region DbSets

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }

        #endregion
    }
}
