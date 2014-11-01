using System.Diagnostics;
using MonoTouch.UIKit;
using AviarySdk;

namespace Sample
{
	public partial class View : UIViewController
	{
		public View () : base ("View", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			AFPhotoEditorController.SetAPIKey ("929e0a21022ee6c4", "4e10abef42a46f94");

			UIImage image = UIImage.FromFile ("sample.jpg");
			var editor = new AFPhotoEditorController (image);
			editor.Delegate = new MyEditorDelegate ( this);

			showEditor.TouchUpInside += (sender, e) => PresentViewController (editor, true, null);
		}

		internal class MyEditorDelegate : AFPhotoEditorControllerDelegate
		{
			readonly UIViewController _container;

			public MyEditorDelegate ( UIViewController container)
			{
				_container = container;
			}

			public override void FinishedWithImage (AFPhotoEditorController editor, UIImage image)
			{
				_container.DismissViewController (true, null);
			}

			public override void PhotoEditorCanceled (AFPhotoEditorController editor)
			{
				_container.DismissViewController (true, null);
			}
		}
	}
}