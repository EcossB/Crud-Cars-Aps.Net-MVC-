using Microsoft.AspNetCore.Mvc.Rendering;

namespace Segundo_parcial_CRUD.Models.ViewModels
{
    public class AutoVM
    {
        public Auto oAuto { get; set; }

        public List<SelectListItem> oListaEstatus { get; set; }        
    }
}
