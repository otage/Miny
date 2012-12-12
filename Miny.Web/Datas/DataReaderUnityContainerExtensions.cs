using Microsoft.Practices.Unity;
using MINY.Web.Datas;
using System;

namespace MINY.Web.Datas
{
    public class DataReaderUnityContainerExtension<TContextLifetimeManager> : UnityContainerExtension where TContextLifetimeManager : LifetimeManager
    {
        protected override void Initialize()
        {
            Container.RegisterType<IDataReader, DataReader>( Activator.CreateInstance<TContextLifetimeManager>() );
        }
    }
}