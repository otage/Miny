using MINY.Web.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINY.Web.Services
{
    public interface IMinyServices
    {
        string BuildItemToPrepend( vItem item );
        bool IsUrl( string url );
    }
}