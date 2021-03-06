_BlinkCard_ Xamarin SDK
======================

Enhance your Xamarin cross-platform apps with an AI-driven mobile credit card scanning software.

Please note that, for maximum performance and full access to all features, it’s best to go with one of our native SDKs (for [iOS](https://github.com/BlinkCard/blinkcard-ios) or [Android](https://github.com/BlinkCard/blinkcard-android)).

Below you can try out our sample app, read the integration guides for both Android and iOS and study advanced topics ⬇️


# Integration into Xamarin Forms project

Steps for integrating BlinkCard into your Xamarin Forms project:

1. In both your `Core`, `Droid` and `iOS` projects, add `BlinkCard.Forms` NuGet package as a reference.
2. In your `Droid` project, update your `MainActivity.cs` in a following way:
    - update your `MainActivity` class so that it implements `Microblink.Forms.Droid.IMicroblinkScannerAndroidHostActivity`. This interface specifies 2 properties and 1 method that you must implement:
        - `HostActivity` property must return reference to current host activity.
        - `ScanActivityRequestCode` property must return integer that will be used as request code for Android's `StartActivityForResult` invocation
        - `ScanningStarted` method will be called just before scanning starts. It will receive currently used `MicroblinkScannerImplementation` as a parameter. You should save a reference to this object because you will need it later in your implementation of `OnActivityResult`
    - override `Activity's` method `OnActivityResult` and pass its parameters to reference of `MicroblinkScannerImplementation`
3. Your `iOS` project does not need any modifications.
4. In your `Core` project, obtain a reference to `IMicroblinkScannerFactory` using a `DependencyService`
5. Use a factory to create an instance of `IMicroblinkScanner`.
6. Use the dependency service to create recognizer you wish to use
7. Subscribe to `Messages.ScanningDoneMessage` that will inform you whether the scanning has completed or was cancelled by end user
8. Using on or more of recognizer objects obtained in step 6., create an instance `IRecognizerCollection` using `IRecognizerCollectionFactory` obtained via `DependencyService`
9. Create a settings object for desired UI overlay
10. Start scanning by invoking method `Scan` on instance of `IMicroblinkScanner`

## Xamarin Forms sample app

Xamarin Forms sample app is available [here](Samples/Forms).

# Integration into native Android project

In your native Android project, add reference to `BlinkCard.Android.Binding` NuGet package and follow the integration instructions for [BlinkCard Android SDK](https://github.com/BlinkCard/blinkcard-android).

## Native Android sample app

Native Android sample app is available [here](Samples/Android).

# Integration into native iOS project

In your native iOS project, add reference to `BlinkCard.iOS.Binding` NuGet package and follow the integration instructions for [BlinkCard iOS SDK](https://github.com/BlinkCard/blinkcard-ios).

## Native iOS sample app

Native iOS sample app is available [here](Samples/iOS).

# Integration via Binding projects

If you do not wish to use BlinkCard NuGet packages, you can directly reference binding projects in your solutions. Just make sure that following conditions are met:

- all large binary files have been checked out
    - to ensure that all files have been checked out, please make sure that you have installed [Git Large File Storage](https://git-lfs.github.com/) and that you have fetched all LFS files with `git lfs pull` command.
- your solution has referenced all dependencies of the project that you are referencing

# Directory and files summary

* `Binding` - Xamarin [iOS](https://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/) and [Android](https://developer.xamarin.com/guides/android/advanced_topics/binding-a-java-library/) Binding Libraries and Xamarin Forms project from which all mentioned NuGet packages were built
* `Samples` - [Xamarin.iOS](Samples/iOS), [Xamarin.Android](Samples/Android) and [Xamarin.Forms](Samples/Forms) sample applications


# Advanced topics

## Updating native binding libraries

### Android

1. Download latest AAR from [Android SDK repository](https://github.com/BlinkCard/blinkcard-android/blob/master/LibBlinkCard.aar)
2. Replace `Binding/Android/Jars/LibBlindCard.aar` with latest AAR
3. Open `Binding/Forms/BlinkCard.Forms/BlinkCard.Forms.sln` solution
4. If needed, update `Transforms/Metadata.xml` in `AndroidBinding` project.
5. Right-click the `AndroidBinding` project, select `Options`, under `NuGet Package` section select `Metadata`
6. Update `Version` on tab `General`
7. Update `Release notes` on tab `Details`
8. Rebuild the `AndroidBinding` project

### iOS

1. Download latest [BlinkCard.framework](https://github.com/BlinkCard/blinkcard-ios/tree/master/BlinkCard.framework) from [iOS SDK repository](https://github.com/BlinkCard/blinkcard-ios)
2. Replace `Binding/iOS/BlinkCard.framework` with latest versions
3. Generate new `ApiDefinitions.cs` and `StructsAndEnums.cs` with latest version of [Objective Sharpie](https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/binding/objective-sharpie/get-started), but **DO NOT OVERWRITE existing `ApiDefiniton.cs` and `Structs.cs`**
    - you can generate new `ApiDefinitions.cs` and `StructsAndEnums.cs` with following command (replace `iphoneos14.4` with latest SDK you have on your Mac):

    ```
    cd Binding/iOS
    sharpie bind -sdk iphoneos11.4 MicroBlink.framework/Headers/MicroBlink.h -scope MicroBlink.framework/Headers -namespace Microblink -c -F .
    ```
4. Manually merge new structures from generated `StructsAndEnums.cs` into existing `Structs.cs` while fixing compile errors
    - `sharpie` generates enums with underlying types such as `nuint` or `nint` which are not supported by latest version of C# - you must replace those with `uint` or `int` types.
5. Manually merge new API classes from generated `ApiDefinitions.cs` into existing `ApiDefinition.cs`
    - note that diff between those two files may be quite large, as `ApiDefinition.cs` has been manually edited to ensure correct compilation and correct exposure of all native SDK features. Focus only on adding new recognizers and parsers. Usually it shuold not be necessary to add other classes.
6. Open `Binding/Forms/BlinkCard.Forms/BlinkCard.Forms.sln` solution
7. Right-click the `iOSBinding` project, select `Options`, under `NuGet Package` section select `Metadata`
8. Update `Version` on tab `General`
9. Update `Release notes` on tab `Details`
10. Rebuild the `iOSBinding` project and fix any compile errors that may have been introduced in steps 4. and 5.

## Updating Xamarin Forms core and platform implementations

1. Ensure that **both Android and iOS** native binding libraries have been updated as explained above
2. Open `Binding/Forms/BlinkCard.Forms/BlinkCard.Forms.sln` solution
3. Right-click the `BlinkCard.Forms.Core` project, select `Options`, under `NuGet Package` section select `Metadata`
4. Update `Version` on tab `General`
5. Update `Release notes` on tab `Details`
6. Do the same for `BlinkCard.Forms.Android`, `BlinkCard.Forms.iOS` and `BlinkCard.Forms.NuGet` projects
7. in `BlinkCard.Forms.Core` add interfaces for new functionality (e.g. new recognizer)
8. add implementation for those interfaces in `BlinkCard.Forms.Android` and `BlinkCard.Forms.iOS` projects
9. rebuild both `BlinkCard.Forms.Core`, `BlinkCard.Forms.Android` and `BlinkCard.Forms.iOS` projects

## Creating updated NuGet packages

1. Ensure that all projects have been updated as described above
    - this includes Android and iOS native binding libraries **and** Xamarin Forms core and platform implementations libraries
2. Open `Binding/Forms/BlinkCard.Forms/BlinkCard.Forms.sln` solution
3. Make sure `Release` build type is selected in `Visual Studio`
4. Right-click on `BlinkCard.Forms.NuGet` project and select `Create NuGet package`
    - all projects will be built and their respective NuGet packages will be created in their `bin/Release` folder
5. Upload packages to [NuGet](https://www.nuget.org/)
