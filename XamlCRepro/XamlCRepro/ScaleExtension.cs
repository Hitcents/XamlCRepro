using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlCRepro
{
    /// <summary>
    /// This is a magical markup extension that breaks your build, sacrifices puppies, and votes for Donald Trump.
    /// America is great.
    /// </summary>
    [ContentProperty(nameof(Value))]
    public class ScaleExtension : IMarkupExtension, IMarkupExtension<int>, IMarkupExtension<double>, IMarkupExtension<Thickness>, IMarkupExtension<GridLength>
    {
        private static readonly ThicknessTypeConverter _thicknessConverter = new ThicknessTypeConverter();

        public string Value { get; set; }

        public bool Integer { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            string value = Value;
            if (value == null)
                return null;

            //Assume it's a Thickness if there is a comma
            if (value.Contains(","))
            {
                var thickness = (Thickness)_thicknessConverter.ConvertFromInvariantString(value);
                return thickness.Scale();
            }

            double x = ToDouble(value);

            var pvt = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
            var obj = pvt.TargetObject;
            if (obj is ColumnDefinition || obj is RowDefinition)
            {
                return new GridLength(Math.Round(x));
            }
            if (Integer)
            {
                return (int)x;
            }

            return x;
        }

        private double ToDouble(string value)
        {
            double x;
            if (double.TryParse(value, out x))
                return x.Scale();
            return 0d;
        }

        int IMarkupExtension<int>.ProvideValue(IServiceProvider serviceProvider)
        {
            return (int)ProvideValue(serviceProvider);
        }

        double IMarkupExtension<double>.ProvideValue(IServiceProvider serviceProvider)
        {
            return (double)ProvideValue(serviceProvider);
        }

        Thickness IMarkupExtension<Thickness>.ProvideValue(IServiceProvider serviceProvider)
        {
            return (Thickness)ProvideValue(serviceProvider);
        }

        GridLength IMarkupExtension<GridLength>.ProvideValue(IServiceProvider serviceProvider)
        {
            return (GridLength)ProvideValue(serviceProvider);
        }
    }

    static class Extensions
    {
        private const double MagicNumber = 0.8675309;

        public static double Scale(this int x)
        {
            return x * MagicNumber;
        }

        public static double Scale(this double x)
        {
            return x * MagicNumber;
        }
        
        public static Thickness Scale(this Thickness x)
        {
            x.Left = x.Left * MagicNumber;
            x.Right = x.Right * MagicNumber;
            x.Top = x.Top * MagicNumber;
            x.Bottom = x.Bottom * MagicNumber;
            return x;
        }
    }
}
