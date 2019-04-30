
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.App;
using Gr.Net.MaroulisLib;

namespace SmartFridge
{
    [Activity(Label = "Smart Fridge", MainLauncher = true,NoHistory = true,Theme = "@style/Theme.AppCompat.Light.NoActionBar")]
    public class SplashScreenActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var splash = new EasySplashScreen(this)
                .WithFullScreen()
                .WithTargetActivity(Java.Lang.Class.FromType(typeof(LoginActivity)))
                .WithSplashTimeOut(3000)
                .WithBackgroundColor(Color.ParseColor("#99ffcc"))
                .WithBackgroundResource(Resource.Drawable.refrigeratorSplash)
                .WithFooterText("©2019,4InfinityTeam");
            SetContentView(splash.Create());
        }
    }
}