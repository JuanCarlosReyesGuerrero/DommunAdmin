using DommunAdmin.ServicesLayer.Interfaces;
using static DommunAdmin.Commons.Enums;

namespace DommunAdmin.ServicesLayer.Services
{
    public class CommonServices : ICommonServices
    {
        //public static string ShowAlert(Alerts obj, string message)
        //{
        //    string alertDiv = null;
        //    switch (obj)
        //    {
        //        case Alerts.Success:
        //            alertDiv = "<div class='alert alert-success alert-dismissible fade show' role='alert'><b>" + message + "</b><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
        //            break;
        //        case Alerts.Danger:                    
        //            alertDiv = "<div class='alert alert-danger alert-dismissible fade show' role='alert'><b>" + message + "</b><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
        //            break;
        //        case Alerts.Info:
        //            alertDiv = "<div class='alert alert-info alert-dismissible fade show' role='alert'><b>" + message + "</b><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
        //            break;
        //        case Alerts.Warning:
        //            alertDiv = "<div class='alert alert-warning alert-dismissible fade show' role='alert'><b>" + message + "</b><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
        //            break;
        //    }
        //    return alertDiv;
        //}

        public CommonServices()
        {

        }

        public string ShowAlert(Alerts obj, string message)
        {
            string alertDiv = null;
            switch (obj)
            {
                case Alerts.Success:
                    alertDiv = "<div class='alert alert-success alert-dismissible fade show' role='alert'><b>" + message + "</b><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
                    break;
                case Alerts.Danger:
                    alertDiv = "<div class='alert alert-danger alert-dismissible fade show' role='alert'><b>" + message + "</b><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
                    break;
                case Alerts.Info:
                    alertDiv = "<div class='alert alert-info alert-dismissible fade show' role='alert'><b>" + message + "</b><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
                    break;
                case Alerts.Warning:
                    alertDiv = "<div class='alert alert-warning alert-dismissible fade show' role='alert'><b>" + message + "</b><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
                    break;
            }
            return alertDiv;
        }
    }
}
