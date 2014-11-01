// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Sample
{
	[Register ("View")]
	partial class View
	{
		[Outlet]
		MonoTouch.UIKit.UIButton showEditor { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (showEditor != null) {
				showEditor.Dispose ();
				showEditor = null;
			}
		}
	}
}
