using MINY.Web.Datas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MINY.Web.Services
{
    public class MinyServices : IMinyServices
    {
        public string BuildItemToPrepend( vItem item )
        {
            string open =
                String.Format( "<div id=\"item-{0}\" class=\"item col col{1}\">", item.ItemId, item.NbCol );

            string deleteLink =
                String.Format( "<a data-ajax=\"true\" data-ajax-confirm=\"Supprimer définitivement ?\" data-ajax-success=\"ItemDeleted\" href=\"/Miny/DeleteItem/{0}\">Delete this item</a>", item.ItemId );

            string close = "</div>";

            string note = item.Note != null
                ? String.Format( "<div class=\"note element\">{0}</div>", item.Note )
                : "";

            string picture = item.PicturePath != null
                ? String.Format( "<div class=\"picture element\"> <img src=\"{0}\" alt=\"Sorry, image not found...\" /></div>", item.PicturePath )
                : "";

            string video = item.VideoPath != null
                ? String.Format( "<div class=\"video element\"><iframe class=\"videoHeight{0}\" src=\"{1}\" alt=\"Sorry, video not found...\"></iframe></div>", item.NbCol, item.VideoPath )
                : "";

            string url = item.Url != null
                ? String.Format( "<div class=\"url element\"><a href=\"{0}\">{0}</a></div>", item.Url )
                : "";

            return open + note + picture + video + url + deleteLink + close;
        }

        public bool IsUrl( string url ) // Working great
        {
            Regex regex = new Regex(
                "http://([\\w+?\\.\\w+])+([a-zA-Z0-9\\~\\!\\@\\#\\$\\%\\^\\&amp;\\*\\(\\)_\\-\\=\\+\\\\\\/\\?\\.\\:\\;\\'\\,]*)?",
                RegexOptions.IgnoreCase
                );

            Match m = regex.Match( url );
            return m.Success ? true : false;
        }
    }
}