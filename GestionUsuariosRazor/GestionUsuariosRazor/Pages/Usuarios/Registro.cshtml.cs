using GestionUsuariosRazor.Pages.Models;
using GestionUsuariosRazor.Pages.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GestionUsuariosRazor.Pages.Usuarios
{
    public class RegistroModel : PageModel
    {
        private readonly ApiService _ppiService;
        
        //Generar nuestro constructor.
        public RegistroModel(ApiService ppiService)
        {
            _ppiService = ppiService;
        }

        //Las propiedades o los binds, estos seran mensaje de intercambio hacia el usuario
        [BindProperty]
        public UserModel User { get; set; }

        public string Mensaje { get; set; }



        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var resultado = await _ppiService.RegisterUserAsync(User);

            //if ternario

            Mensaje = resultado ? "Se ingreso los datos" : "No se ingreso los datos";


            return Page();
        }

        

    }
}
