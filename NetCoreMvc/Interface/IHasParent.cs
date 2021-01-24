namespace NetCoreMvc.WebApp.Interfaces
{
    public interface IHasParent<TPrimaryKey>
    {
        TPrimaryKey ParentId { set; get; }

        string ParentPath { get; set; }

        int? Level { get; set; }
    }
}