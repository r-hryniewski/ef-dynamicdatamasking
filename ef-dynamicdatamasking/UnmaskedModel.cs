namespace ef_dynamicdatamasking
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UnmaskedModel : DbContext
    {
        public UnmaskedModel()
            : base("name=UnmaskedModel")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
