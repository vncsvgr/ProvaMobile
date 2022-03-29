using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProvaMobile
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();


    }

    async private void btnLogar_Clicked(object sender, EventArgs e)
        {
            string usuario = "etec";
            string senha = "etecjau";

            if (edtUsuario.Text == usuario && edtSenha.Text == senha)
            {
                await Navigation.PushAsync(new Vendas());
            }
            else
            {
                await DisplayAlert("ERRO", "Usuário ou senha incorretos", "OK");
            }
        }
    }
}
