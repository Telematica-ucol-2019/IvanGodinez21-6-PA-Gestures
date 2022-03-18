using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gestures
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnImageButtonClickedTypeSwipe(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;
            await this.Navigation.PushModalAsync(new ImageSwipePage(imageButton));
        }
        private async void OnImageButtonClickedTypeTripleTap(object sender, EventArgs args)
        {
            var imageButton = (ImageButton)sender;
            await this.Navigation.PushModalAsync(new ImageTripleTapPage(imageButton));
        }
    }
}
