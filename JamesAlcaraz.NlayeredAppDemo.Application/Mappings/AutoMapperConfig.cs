using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace JamesAlcaraz.NlayeredAppDemo.Application.Mappings
{
    public static class AutoMapperConfig
    {
        /// <summary>
        /// This will be used by DI Container
        /// </summary>
        /// <returns></returns>
        public static MapperConfiguration GetConfig()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductProfile());
            });
        }

    }
}
