using System.ComponentModel;

namespace AppNot
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            Contener.Content = new Views.NotViwe();
        }

     
    }

}
