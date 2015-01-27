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
            Mapper.CreateMap<UsuarioModels, SRV_USUARIO>();
            Mapper.CreateMap<PasajeroModels, SRV_PASAJERO>();
            Mapper.CreateMap<TarifaModels, SRV_TARIFA>();
            Mapper.CreateMap<PromocionModels, SRV_PROGRAMACION>();
            Mapper.CreateMap<PersonalModels, SRV_PERSONAL>();
            Mapper.CreateMap<TipoTarjetaModels, SRV_TIPO_TARJETA>();
            Mapper.CreateMap<TarjetaModels, SRV_TARJETA>();
            Mapper.CreateMap<CompraModels, SRV_COMPRA>();
            #endregion

            #region Mapping Entity to WebModel

            Mapper.CreateMap<SRV_TARIFA,TarifaModels>();
            Mapper.CreateMap<contactenos, ContactenosModels>();
            Mapper.CreateMap<SRV_USUARIO, UsuarioModels>();
            Mapper.CreateMap<SRV_PASAJERO, PasajeroModels>();
            Mapper.CreateMap<SRV_PROGRAMACION, PromocionModels>();
            Mapper.CreateMap<SRV_PERSONAL, PersonalModels>();
            Mapper.CreateMap<SRV_TIPO_TARJETA, TipoTarjetaModels>();
            Mapper.CreateMap<SRV_TARJETA, TarjetaModels>();
            Mapper.CreateMap<SRV_COMPRA, CompraModels>();
            #endregion
        }    
    }
}
