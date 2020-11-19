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

namespace Stylophone
{
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0056", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0058", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV1003", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0085", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2001", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2003", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2004", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2005", Justification="Generated code")]
	public partial class MainPage : Windows.UI.Xaml.Controls.Page
	{
		private void InitializeComponent()
		{
			var nameScope = new global::Windows.UI.Xaml.NameScope();
			NameScope.SetNameScope(this, nameScope);
			IsParsing = true
			;
			// Source ..\..\..\..\..\..\..\Stylophone.Shared\MainPage.xaml (Line 1:2)
			Content = 
			new global::Windows.UI.Xaml.Controls.Grid
			{
				IsParsing = true
				,
				// Source ..\..\..\..\..\..\..\Stylophone.Shared\MainPage.xaml (Line 10:6)
				Children = 
				{
					new global::Windows.UI.Xaml.Controls.TextBlock
					{
						IsParsing = true
						,
						Text = "Hello, world!"/* string/, Hello, world!, TextBlock/Text */,
						Margin = new global::Windows.UI.Xaml.Thickness(20)/* Windows.UI.Xaml.Thickness/, 20, TextBlock/Margin */,
						FontSize = 30d/* double/, 30, TextBlock/FontSize */,
						// Source ..\..\..\..\..\..\..\Stylophone.Shared\MainPage.xaml (Line 11:4)
					}
					.MainPage_2c9710e1807073ed3b626d72f71d8a9b_XamlApply((MainPage_2c9710e1807073ed3b626d72f71d8a9bXamlApplyExtensions.XamlApplyHandler0)(c0 => 
					{
						global::Uno.UI.FrameworkElementHelper.SetBaseUri(c0, "file:///E:/Projects/MpcNET2/Sources/Stylophone/Stylophone.Shared/MainPage.xaml");
						c0.CreationComplete();
					}
					))
					,
				}
			}
			.MainPage_2c9710e1807073ed3b626d72f71d8a9b_XamlApply((MainPage_2c9710e1807073ed3b626d72f71d8a9bXamlApplyExtensions.XamlApplyHandler1)(c1 => 
			{
				global::Uno.UI.ResourceResolverSingleton.Instance.ApplyResource(c1, global::Windows.UI.Xaml.Controls.Grid.BackgroundProperty, "ApplicationPageBackgroundThemeBrush", isThemeResourceExtension: true, context: global::Stylophone.Skia.Wpf.GlobalStaticResources.__ParseContext_);
				this._component_0 = c1;
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c1, "file:///E:/Projects/MpcNET2/Sources/Stylophone/Stylophone.Shared/MainPage.xaml");
				c1.CreationComplete();
			}
			))
			;
			
			this
			.Apply((c2 => 
			{
				// Source E:\Projects\MpcNET2\Sources\Stylophone\Stylophone.Shared\MainPage.xaml (Line 1:2)
				
				// WARNING Property c2.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Page, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.Apply((c3 => 
			{
				// Class Stylophone.MainPage
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c3, "file:///E:/Projects/MpcNET2/Sources/Stylophone/Stylophone.Shared/MainPage.xaml");
				c3.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();
			InitializeXamlOwner();
			Loading += delegate
			{
				_component_0.UpdateResourceBindings();
			}
			;
		}
		partial void OnInitializeCompleted();
		private global::Windows.UI.Xaml.Controls.Grid _component_0;
		private void InitializeXamlOwner()
		{
		}
	}
}
namespace Stylophone.Skia.Wpf
{
	static class MainPage_2c9710e1807073ed3b626d72f71d8a9bXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Windows.UI.Xaml.Controls.TextBlock instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.TextBlock MainPage_2c9710e1807073ed3b626d72f71d8a9b_XamlApply(this global::Windows.UI.Xaml.Controls.TextBlock instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler1(global::Windows.UI.Xaml.Controls.Grid instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.Grid MainPage_2c9710e1807073ed3b626d72f71d8a9b_XamlApply(this global::Windows.UI.Xaml.Controls.Grid instance, XamlApplyHandler1 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
