namespace DesignPatterns.LazyLoad.VirtualProxy
{
    public class CompanyFactory
    {
        public Company CreateFromName(string companyName)
        {
            return new CompanyProxy
            {
                CompanyName = companyName
            };
        }
    }
}
