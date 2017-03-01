using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Application.ApplicationServices.Specifications
{
    /// <summary>
    /// Interface to be applied on DTOs that will be used on generic CRUD methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHaveId<T>
    {
        T Id { get; set; }
    }
}
