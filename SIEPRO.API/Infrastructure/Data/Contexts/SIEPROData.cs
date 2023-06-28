namespace SIEPRO.API.Infrastructure.Data.Contexts
{
    public class SIEPROData : ISIEPROData
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
