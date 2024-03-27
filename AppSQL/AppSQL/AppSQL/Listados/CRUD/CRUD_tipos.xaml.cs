using AppSQL.Data;
using AppSQL.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQL.Listados
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CRUD_tipos : ContentPage
	{
        public Tipos Tipo;
        public CRUD_tipos ()
		{
			InitializeComponent ();
            pk.Items.Add("Activo");
            pk.Items.Add("Desactivado");

            pk.SelectedItem = "Activo";

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = this.Tipo;
        }
        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            if (Tipo.id == 0)
                ClsTipos.AgregarTipo(Tipo);
            else
                ClsTipos.ModificarTipo(Tipo);

            Navigation.PopAsync();
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (Tipo.id != 0)
            {
                ClsTipos.EliminarTipo(Tipo);
                Navigation.PopAsync();
            }
        }
    }
}