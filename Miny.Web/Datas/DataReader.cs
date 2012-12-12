using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINY.Web.Datas
{
    public class DataReader : IDataReader
    {
        public vItem GetItemById( int id )
        {
            using(MinyDataContext ctx = new MinyDataContext())
            {
                return ctx.vItems.Where( x => x.ItemId == id ).FirstOrDefault();
            }
        }

        public vWallDetail GetWallDetailById( int id )
        {
            using( MinyDataContext ctx = new MinyDataContext() )
            {
                return ctx.vWallDetails.Where( x => x.WallId == id ).FirstOrDefault();
            };
        }

        public IEnumerable<vItem> GetWallItemsById( int id )
        {
            using( MinyDataContext ctx = new MinyDataContext() )
            {
                return ctx.vItems.Where( x => x.WallId == id ).ToList();
            };
        }
    }
}