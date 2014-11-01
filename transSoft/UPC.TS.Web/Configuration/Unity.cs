using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
namespace UPC.TS.Web.Configuration
{
    public class Unity
    {
        private static IUnityContainer container;
        public static IUnityContainer Container
        {
            get
            {
                if (container == null)
                {
                    container = new UnityContainer();
                    UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
                    section.Configure(container, "Servicio");
                }

                return container;
            }
            set
            {
                container = value;
            }
        }
    }
}