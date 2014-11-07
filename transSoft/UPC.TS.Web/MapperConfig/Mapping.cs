using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UPC.TS.Entities;
using UPC.TS.BusinessLogic;
using UPC.TS.BusinessContract;
using UPC.TS.Web.Models;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using AutoMapper;

namespace UPC.TS.Web.MapperConfig
{
    public class Mapping 
    {
        public static void Mapear()
        {
            #region Mapping WebModel to Entity

            Mapper.CreateMap<ContactenosModels, contactenos>();

            #endregion

            #region Mapping Entity to WebModel

            Mapper.CreateMap<contactenos, ContactenosModels>();

            #endregion
        }    
    }
}