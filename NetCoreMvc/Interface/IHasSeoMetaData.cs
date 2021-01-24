namespace NetCoreMvc.WebApp.Interfaces
{
    public interface IHasSeoMetaData
    {
        string SeoPageTitle { set; get; }

        string SeoKeywords { set; get; }

        string SeoDescription { get; set; }
    }
}