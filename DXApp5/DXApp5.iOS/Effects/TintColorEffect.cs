using System.ComponentModel;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using DXApp5.Effects;
using DXApp5.iOS.Effects;

[assembly: ResolutionGroupName("DXApp5")]
[assembly: ExportEffect(typeof(TintColorEffect), nameof(TintEffect))]
namespace DXApp5.iOS.Effects {
    public class TintColorEffect : PlatformEffect {
        UIImageView control;

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args) {
            if (args.PropertyName == TintEffect.TintColorProperty.PropertyName) {
                UpdateColor();
            }
        }

        protected override void OnAttached() {
            control = Control as UIImageView;
            UpdateColor();
        }

        protected override void OnDetached() {
            control = null;
        }

        void UpdateColor() {
            try {
                if (control?.Image is UIImage image) {
                    var color = TintEffect.GetTintColor(Element);
                    control.Image = image.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                    control.TintColor = color.ToUIColor();
                }
            } catch {
                //do nothing
            }
        }
    }
}
