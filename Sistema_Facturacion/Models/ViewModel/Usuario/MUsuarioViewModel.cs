using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Facturacion.Models.ViewModel
{
    public class MUsuarioViewModel : Usuarios
    {

        [Required]
        [DisplayName("Tipo Usuario")]
        public int idTipoUsuarioSelected { get; set; }
        public SelectList tipoUsuarioSelect { get; set; }
        public List<TipoUsuario> usuarioList { get; set; }


        public MUsuarioViewModel()
        {
            CargarSelect();
        }

        public MUsuarioViewModel(int IdUsuario) : base(IdUsuario)
        {
            CargarSelect();
            idTipoUsuarioSelected = IdTipoUsuario;

        }

        public void CargarSelect()
        {
            usuarioList = TipoUsuario.GetTipoUsuarios();
            tipoUsuarioSelect = new SelectList(usuarioList, "IdTipoUsuario", "Tipo");
        }


        
    }
}