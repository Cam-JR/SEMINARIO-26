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
    public partial class Listado_Tipos : ContentPage
    {
        public Listado_Tipos()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvTipos.ItemsSource = ClsTipos.GetTipos();
        }
        private void lvTipos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                NavegarTipos(e.SelectedItem as Tipos);
        }

        private void btnNuevo_Clicked(object sender, EventArgs e)
        {
            NavegarTipos(new Tipos());
        }
        void NavegarTipos(Tipos tipo)
        {
            CRUD_tipos pagina = new CRUD_tipos();
            pagina.Tipo = tipo;
            Navigation.PushAsync(pagina);
        }
    }
}