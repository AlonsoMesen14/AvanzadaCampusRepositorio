using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampussAvanzadaa.Model.RubrosViewModel
{



    public class CrearViewModel
    {
        [Display(Name = "Codigo Grupo")]
        public string GrupoSeleccionado { get; set; }
        [Display(Name = "Nombre Rubro")]
        public string NombreRubro { get; set; }
        [Display(Name = "Porcentaja")]
        public int Porcentaje { get; set; }

        public ICollection<Grupos> Grupo { get; set; }
        public ICollection<Rubros> Rubros { get; set; }

    }
}
