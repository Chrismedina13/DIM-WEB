using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIM_WEB.Models
{
    public class CampaniasModel
    {
        public CampaniasModel() {

            this.Campanias = new List<CampaniaModel>();
        }

        public List<CampaniaModel> Campanias { get; set; }
    }
}