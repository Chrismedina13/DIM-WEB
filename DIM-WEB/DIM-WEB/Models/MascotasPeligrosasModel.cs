using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIM_WEB.Models
{
    public class MascotasPeligrosasModel
    {
        public MascotasPeligrosasModel() {

            listaMascotaPeligrosas = new List<MascotaPeligrosaModel>();
        }

        public List<MascotaPeligrosaModel> listaMascotaPeligrosas { get; set; }

    }
}