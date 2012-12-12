using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINY.Web.Datas
{
    public interface IDataReader
    {
        vItem GetItemById( int id );
        vWallDetail GetWallDetailById( int id );
        IEnumerable<vItem> GetWallItemsById( int id );
    }
}