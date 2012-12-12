using MINY.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINY.Web.Datas
{
    public interface IDataRepository
    {
        int CreateItem( CreateItemViewModel model );
        bool DeleteItem( int itemToDelete );
    }
}