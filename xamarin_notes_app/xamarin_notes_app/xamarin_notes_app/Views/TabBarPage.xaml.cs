using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace xamarin_notes_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabBarPage : TabbedPage
    {
        public TabBarPage()
        {
            InitializeComponent();
            CurrentPage = Children[1];
          
        }
    }
}