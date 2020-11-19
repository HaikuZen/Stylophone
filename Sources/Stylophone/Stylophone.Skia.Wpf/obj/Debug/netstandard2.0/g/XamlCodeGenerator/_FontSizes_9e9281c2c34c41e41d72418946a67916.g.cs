// <autogenerated />
#pragma warning disable 618  // Ignore obsolete members warnings
#pragma warning disable 105  // Ignore duplicate namespaces
#pragma warning disable 1591 // Ignore missing XML comment warnings
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.UI;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Text;
using Uno.Extensions;
using Uno;
using Uno.UI.Helpers.Xaml;
using Stylophone.Skia.Wpf;

#if __ANDROID__
using _View = Android.Views.View;
#elif __IOS__
using _View = UIKit.UIView;
#elif __MACOS__
using _View = AppKit.NSView;
#elif UNO_REFERENCE_API
using _View = Windows.UI.Xaml.UIElement;
#elif NET461
using _View = Windows.UI.Xaml.UIElement;
#endif

namespace Stylophone.Skia.Wpf
{
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0056", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0058", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV1003", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0085", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2001", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2003", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2004", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2005", Justification="Generated code")]
	public sealed partial class GlobalStaticResources
	{
		// This non-static inner class is a means of reducing size of AOT compilations by avoiding many accesses to static members from a static callsite, which adds costly class initializer checks each time.
		internal sealed class ResourceDictionarySingleton__1 : global::Uno.UI.IXamlResourceDictionaryProvider
		{
			private static ResourceDictionarySingleton__1 _instance;
			internal static ResourceDictionarySingleton__1 Instance
			{
				get
				{
					if (_instance == null)
					{
						_instance = new ResourceDictionarySingleton__1();
					}

					return _instance;
				}
			}

			internal global::Uno.UI.Xaml.XamlParseContext __ParseContext_ {get; }

			private ResourceDictionarySingleton__1()
			{
				__ParseContext_ = global::Stylophone.Skia.Wpf.GlobalStaticResources.__ParseContext_;
			}

			// Skipping initializer 1 for LargeFontSize  - Literal declaration, will be eagerly materialized and added to the dictionary
			// Skipping initializer 2 for MediumFontSize  - Literal declaration, will be eagerly materialized and added to the dictionary
			private global::Windows.UI.Xaml.ResourceDictionary __FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary;

			internal global::Windows.UI.Xaml.ResourceDictionary _FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary
			{
				get
				{
					if (__FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary == null)
					{
						__FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary = 
						new global::Windows.UI.Xaml.ResourceDictionary
						{
							IsParsing = true
							,
							["LargeFontSize"] = 
							24d							,
							["MediumFontSize"] = 
							16d							,
						}
						;
						__FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary.Source = new global::System.Uri("ms-resource:///Files/Styles/_FontSizes.xaml");
						__FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary.CreationComplete();
					}
					return __FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary;
				}
			}

			ResourceDictionary global::Uno.UI.IXamlResourceDictionaryProvider.GetResourceDictionary() => _FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary;
		}

		internal static global::Windows.UI.Xaml.ResourceDictionary _FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary => ResourceDictionarySingleton__1.Instance._FontSizes_9e9281c2c34c41e41d72418946a67916_ResourceDictionary;
	}
}
namespace Stylophone.Skia.Wpf.__Resources
{
}
namespace Stylophone.Skia.Wpf
{
	static class _FontSizes_9e9281c2c34c41e41d72418946a67916XamlApplyExtensions
	{
	}
}
