
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Net.Wifi;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using Android.Widget;
using Gr.Net.MaroulisLib;
using SmartFridge.Model;
using SmartFridge.WebReference;

namespace SmartFridge
{
    [Activity(Label = "Smart Fridge", MainLauncher = true,NoHistory = true,Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class SplashScreenActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.RequestedOrientation = ScreenOrientation.Portrait;
            var splash = new EasySplashScreen(this)
                .WithFullScreen()
                .WithTargetActivity(Java.Lang.Class.FromType(typeof(LoginActivity)))
                .WithSplashTimeOut(2000)
                .WithBackgroundColor(Color.ParseColor("#99ffcc"))
                .WithBackgroundResource(Resource.Drawable.refrigeratorSplash)
                .WithFooterText("©2019,4InfinityTeam");
            SetContentView(splash.Create());
        }
    }
}