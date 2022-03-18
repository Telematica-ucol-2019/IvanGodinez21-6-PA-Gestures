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
    public partial class ImageTripleTapPage : ContentPage
    {
        public ImageTripleTapPage(object sender)
        {
            InitializeComponent();
            var image = (ImageButton)sender;
            mainImage.Source = image.Source;
        }
        private double startScale;
        private double currentScale;
        private double xOffset;
        private double yOffset;
        private void OnTripleTap(object sender, EventArgs args)
        {
            Console.WriteLine("Triple Tap");
            this.Navigation.PopModalAsync();
        }
        private void OnPagePinch(object sender, PinchGestureUpdatedEventArgs args)
        {
            Console.WriteLine("Pinch");
            if (args.Status == GestureStatus.Started)
            {
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }

            if (args.Status == GestureStatus.Running)
            {
                currentScale += (args.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (args.ScaleOrigin.X - deltaX) * deltaWidth;
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (args.ScaleOrigin.Y - deltaY) * deltaHeight;
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);
                Content.TranslationX = Math.Min(0, Math.Max(targetX, -Content.Width * (currentScale - 1)));
                Content.TranslationY = Math.Min(0, Math.Max(targetY, -Content.Height * (currentScale - 1)));
            }

            Content.Scale = currentScale;
            {
                if (args.Status == GestureStatus.Completed)
                {
                    xOffset = Content.TranslationX;
                    yOffset = Content.TranslationY;
                }
            }
        }
    }
}