using System;
using System.ComponentModel;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;

namespace AviarySdk {

	[Protocol]
	[Model, BaseType (typeof (NSObject))]
	public interface AFPhotoEditorControllerDelegate {

		[Export ("photoEditor:finishedWithImage:")]
		void FinishedWithImage (AFPhotoEditorController editor, UIImage image);

		[Export ("photoEditorCanceled:")]
		void  PhotoEditorCanceled(AFPhotoEditorController editor);
	}

	[BaseType (typeof (UIViewController))]
	public interface AFPhotoEditorController {

		[Static, Export ("setAPIKey:secret:")]
		void SetAPIKey (string apiKey, string secret);

		[Static, Export ("setPremiumAddOns")]
		void SetPremiumAddOns (AFPhotoEditorPremiumAddOn premiumAddOns);

		[Export ("initWithImage:")]
		IntPtr Constructor (UIImage image);

		[Export ("delegate", ArgumentSemantic.Assign)]
		AFPhotoEditorControllerDelegate Delegate { get; set; }

		[Export ("session", ArgumentSemantic.Retain)]
		AFPhotoEditorSession Session { get; }

		[Static, Export ("versionString")]
		string VersionString { get; }
	}

	[Category, BaseType (typeof (AFPhotoEditorController))]
	public interface InAppPurchase {

		[Static, Export ("inAppPurchaseManager")]
		AFInAppPurchaseManager InAppPurchaseManager { get; }
	}

	[BaseType (typeof (NSObject))]
	public interface AFPhotoEditorProduct {

		[Export ("productName", ArgumentSemantic.Copy)]
		string ProductName { get; }

		[Export ("productDescription", ArgumentSemantic.Copy)]
		string ProductDescription { get; }

		[Export ("internalProductIdentifier", ArgumentSemantic.Copy)]
		string InternalProductIdentifier { get; }
		/*
		[Field ("kAFPhotoEditorEffectsIAPEnabledKey", "__Internal")]
		NSString AFPhotoEditorEffectsIAPEnabledKey { get; }*/
	}

	[Model, BaseType (typeof (NSObject))]
	public interface AFInAppPurchaseManagerDelegate {

		[Export ("inAppPurchaseManager:productIdentifierForProduct:")]
		string ProductIdentifierForProduct (AFInAppPurchaseManager manager, AFPhotoEditorProduct product);
	}

	[Model, BaseType (typeof (NSObject))]
	public interface AFInAppPurchaseManager {

		[Export ("delegate", ArgumentSemantic.Assign)]
		AFInAppPurchaseManagerDelegate Delegate { get; set; }

		[Export ("observingTransactions")]
		bool ObservingTransactions { [Bind ("isObservingTransactions")] get; }

		[Export ("startObservingTransactions")]
		void StartObservingTransactions ();

		[Export ("stopObservingTransactions")]
		void StopObservingTransactions ();
	}

	[BaseType (typeof (NSObject))]
	public interface AFOpenGLManager {

		[Static, Export ("setPurgeGPUMemoryWhenPossible")]
		void SetPurgeGPUMemoryWhenPossible ( bool purgeGPUMemory);

		[Static, Export ("beginOpenGLLoad")]
		void BeginOpenGLLoad ();

		[Static, Export ("requestOpenGLDataPurge")]
		void RequestOpenGLDataPurge ();

		[Static, Export ("cancelOpenGLDataPurgeRequest")]
		void CancelOpenGLDataPurgeRequest ();
	}

	public delegate void ImageResultDelegate( UIImage image);

	[BaseType (typeof (NSObject))]
	public interface AFPhotoEditorContext {

		[Export ("session", ArgumentSemantic.Assign)]
		AFPhotoEditorSession Session { get; }

		[Export ("size", ArgumentSemantic.Assign)]
		SizeF Size { get; }

		[Export ("canceled")]
		bool Canceled { [Bind ("isCanceled")] get; }

		[Export ("modified")]
		bool Modified { [Bind ("isModified")] get; }

		[Export ("hasBegunRendering")]
		bool HasBegunRendering { get; }

		[Export ("render:")]
		void Render (ImageResultDelegate completion);

		[Export ("cancelRendering")]
		void CancelRendering ();

		[Notification, Field ("AFPhotoEditorSessionCancelledNotification", "__Internal")]
		NSString AFPhotoEditorSessionCancelledNotification { get; }
	}

	[BaseType (typeof (NSObject))]
	public interface AFPhotoEditorSession {

		[Export ("open")]
		bool Open { [Bind ("isOpen")] get; }

		[Export ("cancelled")]
		bool Cancelled { [Bind ("isCancelled")] get; }

		[Export ("modified")]
		bool Modified { [Bind ("isModified")] get; }

		[Export ("createContextWithImage:")]
		AFPhotoEditorContext CreateContextWithImage (UIImage image);

		[Export ("createContextWithImage:maxSize:")]
		AFPhotoEditorContext CreateContextWithImage (UIImage image, SizeF size);

		[Field ("kAFEnhance", "__Internal")]
		NSString AFEnhance { get; }

		[Field ("kAFEffects", "__Internal")]
		NSString AFEffects { get; }

		[Field ("kAFStickers", "__Internal")]
		NSString AFStickers { get; }

		[Field ("kAFOrientation", "__Internal")]
		NSString AFOrientation { get; }

		[Field ("kAFCrop", "__Internal")]
		NSString AFCrop { get; }

		[Field ("kAFAdjustments", "__Internal")]
		NSString AFAdjustments { get; }

		[Field ("kAFSharpness", "__Internal")]
		NSString AFSharpness { get; }

		[Field ("kAFDraw", "__Internal")]
		NSString AFDraw { get; }

		[Field ("kAFText", "__Internal")]
		NSString AFText { get; }

		[Field ("kAFRedeye", "__Internal")]
		NSString AFRedeye { get; }

		[Field ("kAFWhiten", "__Internal")]
		NSString AFWhiten { get; }

		[Field ("kAFBlemish", "__Internal")]
		NSString AFBlemish { get; }

		[Field ("kAFBlur", "__Internal")]
		NSString AFBlur { get; }

		[Field ("kAFMeme", "__Internal")]
		NSString AFMeme { get; }

		[Field ("kAFFrames", "__Internal")]
		NSString AFFrames { get; }

		[Field ("kAFFocus", "__Internal")]
		NSString AFFocus { get; }

		[Field ("kAFSplash", "__Internal")]
		NSString AFSplash { get; }

		[Field ("kAFLeftNavigationTitlePresetCancel", "__Internal")]
		NSString AFLeftNavigationTitlePresetCancel { get; }

		[Field ("kAFLeftNavigationTitlePresetBack", "__Internal")]
		NSString AFLeftNavigationTitlePresetBack { get; }

		[Field ("kAFLeftNavigationTitlePresetExit", "__Internal")]
		NSString AFLeftNavigationTitlePresetExit { get; }

		[Field ("kAFRightNavigationTitlePresetDone", "__Internal")]
		NSString AFRightNavigationTitlePresetDone { get; }

		[Field ("kAFRightNavigationTitlePresetSave", "__Internal")]
		NSString AFRightNavigationTitlePresetSave { get; }

		[Field ("kAFRightNavigationTitlePresetNext", "__Internal")]
		NSString AFRightNavigationTitlePresetNext { get; }

		[Field ("kAFRightNavigationTitlePresetSend", "__Internal")]
		NSString AFRightNavigationTitlePresetSend { get; }

		[Field ("kAFCropPresetName", "__Internal")]
		NSString AFCropPresetName { get; }

		[Field ("kAFCropPresetWidth", "__Internal")]
		NSString AFCropPresetWidth { get; }

		[Field ("kAFCropPresetHeight", "__Internal")]
		NSString AFCropPresetHeight { get; }
	}

	[BaseType (typeof (NSObject))]
	public interface AFPhotoEditorCustomization {

	}

	[Category, BaseType (typeof (AFPhotoEditorCustomization))]
	public interface PCNSupport {

		[Static, Export ("usePCNStagingEnvironment:")]
		void UsePCNStagingEnvironment (bool usePCNStagingEnvironment);
	}

	[Category, BaseType (typeof (AFPhotoEditorCustomization))]
	public interface IPadOrientation {

		[Static, Export ("supportedIpadOrientations")]
		NSObject [] SupportedIpadOrientations { get; set; }
	}

	[Category, BaseType (typeof (AFPhotoEditorCustomization))]
	public interface Appearance {

		[Static, Export ("setIconImage:forTool:")]
		void SetIconImage (UIImage image, string tool);

		[Static, Export ("setNavBarImage")]
		void SetNavBarImage (UIImage navBarImage);

		[Static, Export ("setStatusBarStyle")]
		void SetStatusBarStyle (UIStatusBarStyle statusBarStyle);
	}

	[Category, BaseType (typeof (AFPhotoEditorCustomization))]
	public interface Imaging {

		[Static, Export ("purgeGPUMemoryWhenPossible:")]
		void PurgeGPUMemoryWhenPossible (bool purgeGPUMemory);

		/*
		[Static, Export ("purgeGPUMemoryWhenPossible")]
		bool PurgeGPUMemoryWhenPossible { get; set; }
		*/
	}

	[Category, BaseType (typeof (AFPhotoEditorCustomization))]
	public interface NavigationBarButtons {

		[Static, Export ("leftNavigationBarButtonTitle")]
		string LeftNavigationBarButtonTitle { get; set; }

		[Static, Export ("rightNavigationBarButtonTitle")]
		string RightNavigationBarButtonTitle { get; set; }
	}

	[Category, BaseType (typeof (AFPhotoEditorCustomization))]
	public interface ToolSettings {

		[Static, Export ("toolOrder")]
		NSString [] ToolOrder { get; set; }

		[Static, Export ("cropToolCustomEnabled")]
		bool CropToolCustomEnabled { get; set; }

		[Static, Export ("cropToolOriginalEnabled")]
		bool CropToolOriginalEnabled { get; set; }

		[Static, Export ("cropToolInvertEnabled")]
		bool CropToolInvertEnabled { get; set; }

		[Static, Export ("cropToolPresets")]
		NSObject [] CropToolPresets { get; set; }
	}

	[Category, BaseType (typeof (AFPhotoEditorCustomization))]
	public interface Localization {

		[Static, Export ("disableLocalization:")]
		void DisableLocalization (bool disableLocalization);
	}
}