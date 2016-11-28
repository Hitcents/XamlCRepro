# XamlCRepro
Repro for some issues with XAMLC in Xamarin.Forms

I have created some attached properties on `Theme` to show the issue. Build the app to see XamlC throw the error.

To fix it you can either:
* Downgrade to Xamarin.Forms 2.3.2
* Turn off XamlC in AssemblyInfo.cs
* Use a color like `Red` instead of `{StaticResource Red}`

You don't really need to run the app to see the issue.
