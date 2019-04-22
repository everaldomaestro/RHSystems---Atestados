namespace Atestados.Infra.Data.EF.Context
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Atestados.Domain.Entities;
    using Atestados.Infra.Data.EF.EntityMap;

    public class AtestadosContext : DbContext
    {
        public AtestadosContext()
            : base("name=Atestados")
        {
        }

        public virtual DbSet<Atestado> Atestado { get; set; }
        public virtual DbSet<AtestadosAux> AtestadosAux { get; set; }
        public virtual DbSet<Cid> Cid { get; set; }
        public virtual DbSet<ClinicaHospital> ClinicaHospital { get; set; }
        public virtual DbSet<Colaborador> Colaborador { get; set; }
        public virtual DbSet<Operador> Operador { get; set; }
        public virtual DbSet<Setor> Setor { get; set; }
        public virtual DbSet<Unidade> Unidade { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new AtestadoMap());
            modelBuilder.Configurations.Add(new AtestadosAuxMap());
            modelBuilder.Configurations.Add(new CidMap());
            modelBuilder.Configurations.Add(new ClinicaHospitalMap());
            modelBuilder.Configurations.Add(new ColaboradorMap());
            modelBuilder.Configurations.Add(new OperadorMap());
            modelBuilder.Configurations.Add(new SetorMap());
            modelBuilder.Configurations.Add(new UnidadeMap());

            //modelBuilder.Properties()
            //    .Where(p => p.Name == p.ReflectedType.Name + "Id")
            //    .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(30));
        }
    }
}