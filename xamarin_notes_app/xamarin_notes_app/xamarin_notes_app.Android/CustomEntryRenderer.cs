using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using xamarin_notes_app.Droid;
using xamarin_notes_app.Helper.CustomEntry;

[assembly:ExportRenderer(typeof(CustomEntry),typeof(CustomEntryRenderer))]
namespace xamarin_notes_app.Droid
{
    public class CustomEntryRenderer:EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context){ }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
               
            }
            var shape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RectShape());
            Control.Background = shape;
            Control.SetBackgroundColor(Color.White.ToAndroid());
        }

    }
}