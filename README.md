# XamlCRepro
Repro for some issues with XAMLC in Xamarin.Forms

I have created `ScaleExtension` to show the issues. Build the app to see XamlC throw the errors.

To fix it you can either:
* Downgrade to Xamarin.Forms 2.3.2
* Turn off XamlC in AssemblyInfo.cs

Note that if you run the app, it doesn't look like anything -- just take note that it does not have XAML that errors when interpreted at runtime.
