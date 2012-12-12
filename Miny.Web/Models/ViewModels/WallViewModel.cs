using MINY.Web.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MINY.Web.Models.ViewModels
{
    public class WallViewModel
    {
        public vWallDetail WallDetail { get; set; }
        public IEnumerable<vItem> Items { get; set; }

        public IEnumerable<vItem> SortedItems
        {
            get { return Items.Reverse(); }
        }
    }
}