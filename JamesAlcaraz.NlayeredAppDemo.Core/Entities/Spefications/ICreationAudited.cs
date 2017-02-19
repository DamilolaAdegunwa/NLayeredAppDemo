using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamesAlcaraz.NlayeredAppDemo.Core.Entities.Spefications
{
    public interface ICreationAudited
    {
        DateTime DateCreated { get; set; }
        string UserCreated { get; set; }
    }
}
