namespace Pulse.Documentos.Domain.Data.Migrator {
    public abstract class Migration {
        public abstract long Version { get; }

        public abstract void Execute(MigratorDatabase migratorDatabase);
    }
}
