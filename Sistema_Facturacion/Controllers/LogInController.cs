using Sistema_Facturacion.Models;
using Sistema_Facturacion.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sistema_Facturacion.Controllers
{
    public class LogInController : Controller
    {
        ConexionDb conexion = new ConexionDb();
        SqlCommand cmd = new SqlCommand();

        // GET: LogIn
        public ActionResult LogIn()
        {
            return View();
        }

       
        [HttpPost]
        public string LogIn(string Usuario, string Password)
        {
            try
            {
               
                LogInViewModel login = new LogInViewModel(Usuario);

                if(login.Username!="")
                {
                    if (Password == login.Password)
                    {
                        FormsAuthentication.SetAuthCookie(login.Username, false);
                        Session["usuario"] = Usuario;
                        return "Exito";
                    }
                    {
                        return "No coinciden";
                    }
                }
                else
                {
                    return "No existe";
                }
                
            }
            catch (Exception e)
            {
                return "Error";
            }
        }

        
    }
}
