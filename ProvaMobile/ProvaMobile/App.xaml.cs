using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProvaMobile
{
    public partial class App : Application
    {

        public List<Produtos> produtos = new List<Produtos>();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());


        }

    protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
