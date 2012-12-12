using MINY.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINY.Web.Datas
{
    public class DataRepository : IDataRepository
    {
        public int CreateItem( CreateItemViewModel model )
        {
            using(MinyDataContext ctx = new MinyDataContext())
            {
                try
                {
                    System.Nullable<int> CreatedItemId = ctx.sCreateItem( model.WallId, model.AuthorId, model.Note, model.Url, model.PicturePath, model.VideoPath, model.NbCol ).First();
                    if(CreatedItemId.HasValue) { return CreatedItemId.Value; }
                    return 0;
                }
                catch
                {
                    return 0;
                }
            }
        }

        public bool DeleteItem( int itemToDelete )
        {
            using(MinyDataContext ctx = new MinyDataContext())
            {
                try
                {
                    ctx.sDeleteItem( itemToDelete );
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}