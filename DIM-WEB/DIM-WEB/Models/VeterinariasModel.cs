using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIM_WEB.Models
{
    public class VeterinariasModel
    {
        public VeterinariasModel() {

            this.ListaVeterinaria = new List<VeterinariaModel>();
        }

        public List<VeterinariaModel> ListaVeterinaria { get; set; }

    }
}