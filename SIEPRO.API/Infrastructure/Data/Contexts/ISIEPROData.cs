namespace SIEPRO.API.Infrastructure.Data.Contexts
{
    public interface ISIEPROData
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
