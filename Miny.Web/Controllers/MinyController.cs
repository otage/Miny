using MINY.Web.Datas;
using MINY.Web.Models.ViewModels;
using MINY.Web.Services;
using System;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MINY.Web.Controllers
{
    public class MinyController : Controller
    {
        private IDataReader _dataReader = new DataReader();
        private IDataRepository _repository = new DataRepository();
        private IMinyServices _services = new MinyServices(); 

        public ActionResult Wall(int id)
        {
            return View( new WallViewModel
                {
                    WallDetail = _dataReader.GetWallDetailById(id),
                    Items = _dataReader.GetWallItemsById(id)
                }
            );
        }

        [HttpPost]
        public ActionResult CreateItem( CreateItemViewModel model )
        {
            if(Request.IsAjaxRequest())
            {
                if(!model.IsEmpty)
                {
                    return Json( _services.BuildItemToPrepend( _dataReader.GetItemById( _repository.CreateItem( model ) ) ) );
                }
                //TODO return Json EmptyModelError
            }
            
            return _repository.CreateItem( model ) != 0 ?
                (ActionResult)RedirectToAction( "Wall" ) : View( "_createItemError" ); // TODO Handle error
        }

        [HttpGet]
        public ActionResult DeleteItem( int id )
        {
            if(Request.IsAjaxRequest())
            {
                return _repository.DeleteItem( id ) ?
                    Json( id, JsonRequestBehavior.AllowGet ) : Json( 0, JsonRequestBehavior.AllowGet );
            }

            return _repository.DeleteItem( id ) ?
                    (ActionResult)RedirectToAction( "Wall" ) : View( "_deleteItemConfirmation" ); // TODO handle Confirmation
        }
    }
}
