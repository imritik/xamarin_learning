using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin_notes_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomCardView : ContentView
    {
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(
            propertyName: "TitleText",
            returnType: typeof(string),
            declaringType: typeof(CustomCardView),
            propertyChanged: TitleTextPropertyChanged
            );

        public static readonly BindableProperty DescriptionProperty = BindableProperty.Create(
           propertyName: "Description",
           returnType: typeof(string),
           declaringType: typeof(CustomCardView),
           propertyChanged: DescriptionPropertyChanged
           );

        public static readonly BindableProperty DateStringProperty = BindableProperty.Create(
           propertyName: "DateString",
           returnType: typeof(string),
           declaringType: typeof(CustomCardView),
           propertyChanged: DateStringPropertyChanged
           );

        public string DateString
        {
            get
            {
                return base.GetValue(DateStringProperty).ToString();
            }
            set
            {
                base.SetValue(DateStringProperty, value);
            }
        }

        public string TitleText
        {
            get
            {
                return base.GetValue(TitleTextProperty).ToString();
            }
            set
            {
                base.SetValue(TitleTextProperty, value);
            }
        }

        public string Description
        {
            get
            {
                return base.GetValue(DescriptionProperty).ToString();
            }
            set
            {
                base.SetValue(DescriptionProperty, value);
            }
        }

        private static void TitleTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomCardView)bindable;
            if (control.title != null)
            {
                control.title.Text = newValue?.ToString();
            }

        }

        private static void DescriptionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomCardView)bindable;
            if (control.description != null)
            {
                control.description.Text = newValue?.ToString();
            }
        }

        private static void DateStringPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomCardView)bindable;
            if (control.dateString != null)
            {
                control.dateString.Text = newValue?.ToString();
            }
        }
        public CustomCardView()
        {
            InitializeComponent();
        }
    }
}