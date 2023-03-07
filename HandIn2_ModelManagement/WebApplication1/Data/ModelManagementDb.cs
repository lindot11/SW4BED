using Microsoft.EntityFrameworkCore;
using ModelManagement.Models;

namespace ModelManagement.Data
{
    public class ModelManagementDb : DbContext
    {
        public ModelManagementDb(DbContextOptions<ModelManagementDb> options) : base(options) { }

        public DbSet<Model> Models => Set<Model>();
        public DbSet<Job> Jobs => Set<Job>();
        public DbSet<Expense> Expenses => Set<Expense>();

    }
}
