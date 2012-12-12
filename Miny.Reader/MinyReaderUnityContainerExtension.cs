using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miny.Reader
{
    public class MinyReaderUnityContainerExtension<TContextLifetimeManager> : UnityContainerExtension where TContextLifetimeManager : LifetimeManager
    {
        protected override void Initialize()
        {
            Container.RegisterType<IMinyReader, MinyReader>( Activator.CreateInstance<TContextLifetimeManager>() );
        }
    }
}
