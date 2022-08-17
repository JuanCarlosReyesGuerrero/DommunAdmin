using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.ServicesLayer.Interfaces
{
    public interface ICommonServices
    {
        string ShowAlert(Alerts obj, string message);
    }
}
