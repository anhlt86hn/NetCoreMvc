using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreMvc.WebApp.Interface
{
    interface IDateTracking
    {
        DateTime DateCreated { set; get; }
        DateTime? DateModified { get; set; }
    }
}
