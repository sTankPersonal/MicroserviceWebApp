using BuildingBlocks.CrossCutting.Utils;

namespace BuildingBlocks.CrossCutting.Persistence
{
    public  class DatabaseOptions
    {
        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get => _connectionString.ThrowIfNullOrEmpty($"{nameof(DatabaseOptions)}.{nameof(ConnectionString)}");
            set => _connectionString = value;
        }
    }
}
