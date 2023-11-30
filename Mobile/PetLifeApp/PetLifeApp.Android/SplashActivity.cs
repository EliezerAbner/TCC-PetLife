using Android.App;
using Android.Content;
using Android.OS;
using Com.Airbnb.Lottie;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Animation;

namespace PetLifeApp.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
              MainLauncher = true,
              NoHistory = true)]
    public class SplashActivity : Activity, Animator.IAnimatorListener
    {
        public void OnAnimationCancel(Animator animation)
        {
            throw new NotImplementedException();
        }

        public void OnAnimationEnd(Animator animation)
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layout1);

            var animationView = FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            animationView.AddAnimatorListener(this);
        }
    }
}