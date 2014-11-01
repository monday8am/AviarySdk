using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("AviarySDK.a", LinkTarget.Simulator | LinkTarget.ArmV7, ForceLoad = true, LinkerFlags="-lsqlite3.0")]
