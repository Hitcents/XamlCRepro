using Xamarin.Forms;

namespace XamlCRepro
{
    public class Theme
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.CreateAttached("StartColor", typeof(Color), typeof(Theme), Color.Transparent);

        public static readonly BindableProperty EndColorProperty = BindableProperty.CreateAttached("EndColor", typeof(Color), typeof(Theme), Color.Transparent);

        public static Color GetStartColor(BindableObject obj)
        {
            return (Color)obj.GetValue(StartColorProperty);
        }

        public static void SetStartColor(BindableObject obj, Color value)
        {
            obj.SetValue(StartColorProperty, value);
        }

        public static Color GetEndColor(BindableObject obj)
        {
            return (Color)obj.GetValue(EndColorProperty);
        }

        public static void SetEndColor(BindableObject obj, Color value)
        {
            obj.SetValue(EndColorProperty, value);
        }
    }
}
