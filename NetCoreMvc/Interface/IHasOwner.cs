namespace NetCoreMvc.WebApp.Interfaces
{
    /// <summary>
    /// This interface is used to mark the owner of an object.
    /// </summary>
    public interface IHasOwner<T>
    {
        T OwnerId { set; get; }
    }
}