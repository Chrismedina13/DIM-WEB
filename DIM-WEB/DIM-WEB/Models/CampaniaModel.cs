using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIM_WEB.Models
{
    public class CampaniaModel
    {
        public CampaniaModel() {

        }

        public Campania Campania { get; set; }
        public Direccion Direccion { get; set; }
        public string RazasPermitidas { get; set; }
    }
}