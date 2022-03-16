using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gestures
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageSwipePage : ContentPage
    {
        public ImageSwipePage(object sender)
        {
            InitializeComponent();
            var image = (ImageButton)sender;
            mainImage.Source = image.Source;
        }
        private void OnPageSwipe(object sender, EventArgs args)
        {
            this.Navigation.PopModalAsync();
        }
    }
}