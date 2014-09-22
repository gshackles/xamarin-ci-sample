using Android.App;
using Android.OS;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

namespace TipCalc.Android
{
    [Activity(Label = "TipCalc", MainLauncher = true)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

			Forms.ViewInitialized += (sender, e) => 
			{
				if (!string.IsNullOrWhiteSpace(e.View.StyleId))
					e.NativeView.ContentDescription = e.View.StyleId;
			};

            SetPage(App.GetMainPage());
        }
    }
}