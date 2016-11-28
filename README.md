# XamlCRepro
Repro for an issue with XamlC in Xamarin.Forms

I have created some attached properties on `Theme` to show the issue. Build the app to see XamlC throw the error.

It seems to be when:
* Create an attached property that is of type `Color`
* Set it in XAML with `{StaticResource}`

To fix it you can either:
* Downgrade to Xamarin.Forms 2.3.2
* Turn off XamlC in AssemblyInfo.cs
* Use a color like `Red` instead of `{StaticResource Red}`

You don't really need to run the app to see the issue.
