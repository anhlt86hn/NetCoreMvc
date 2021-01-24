using NetCoreMvc.WebApp.Enums;

namespace NetCoreMvc.WebApp.Interfaces
{
    public interface ISwitchable
    {
        Status Status { set; get; }
    }
}