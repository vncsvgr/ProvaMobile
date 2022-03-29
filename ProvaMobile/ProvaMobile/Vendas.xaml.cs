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
            "cenoura",
            "banana"
        };


        //List<Produtos> produtos = new List<Produtos>
        //{
        //    new Produtos {Nome="Cenoura"},
        //    new Produtos {Nome="Banana"},
        //    new Produtos {Nome="Morango"},

        //};

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

            //pckProdutos.ItemsSource = null;
            edtQuantidade.Text = "";
            edtVlrUnitario.Text = "";

            total += p.Qtde * p.VlrUnitario;

            edtValorTotal.Text = total.ToString("F");


            //Smartphone sp = new Smartphone();
            //sp.Fabricante = edtFabricante.Text;
            //sp.Modelo = edtModelo.Text;
            //sp.Cor = edtCor.Text;

            //PropriedadesApp.Smart.Add(sp);

            //edtFabricante.Text = "";
            //edtModelo.Text = "";
            //edtCor.Text = "";
        }

        private void sbProdutos_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void lstProdutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void btnFinalizar_Clicked(object sender, EventArgs e)
        {

        }

        private void pckProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}