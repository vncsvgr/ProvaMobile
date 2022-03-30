using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProvaMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vendas : ContentPage
    {
        private App PropriedadesApp;

        double total = 0;

        List<string> produtos = new List<string>()
        {
            "Cenoura",
            "Banana",
            "Mamão",
            "Maçã",
            "Morango",
            "Abacaxi"
        };

        public Vendas()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current;

            pckProdutos.ItemsSource = produtos;

            
        }
        private void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            Produtos p = new Produtos();
            p.Nome = pckProdutos.SelectedItem.ToString();
            p.Qtde = int.Parse(edtQuantidade.Text);
            p.VlrUnitario = double.Parse(edtVlrUnitario.Text);

            PropriedadesApp.produtos.Add(p);

            lstProdutos.ItemsSource = null;
            lstProdutos.ItemsSource = PropriedadesApp.produtos;

            pckProdutos.ItemsSource = null;
            pckProdutos.ItemsSource = produtos;
            edtQuantidade.Text = "";
            edtVlrUnitario.Text = "";

            total += p.Qtde * p.VlrUnitario;

            edtValorTotal.Text = total.ToString("C");
        }

        private void sbProdutos_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstProdutos.ItemsSource = PropriedadesApp.produtos.Where(
               x => x.Nome.ToUpper().Contains(sbProdutos.Text.ToUpper()));
        }

        async private void lstProdutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var a = e.SelectedItem as Produtos;

            var resp = await DisplayAlert("Exclusão", "Deseja excluir o produto " + a.Nome + "?", "Sim", "Não");

            if (resp)
            {
                var item = PropriedadesApp.produtos.Find(x => x.Nome == a.Nome);
                PropriedadesApp.produtos.Remove(item);
                lstProdutos.ItemsSource = null;
                lstProdutos.ItemsSource = PropriedadesApp.produtos;

                total -= item.Qtde * item.VlrUnitario;
            }

            edtValorTotal.Text = total.ToString("C");
        }

        async private void btnFinalizar_Clicked(object sender, EventArgs e)
        {
            var fechar = await DisplayAlert("Fechar", "Deseja encerrar o aplicativo?", "Sim", "Não");
            if (fechar)
            {
                Environment.Exit(0);
            }
        }
    }
}