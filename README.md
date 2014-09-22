# Xamarin CI Sample

This is a sample of how to set up automated builds for Xamarin.iOS and Xamarin.Android apps, including running UI tests locally and in TestCloud, and packaging the apps for distribution. The build system used here is [FAKE](https://github.com/fsharp/FAKE).

The TipCalc sample app used here was borrowed with love from [Xamarin's samples](https://github.com/xamarin/xamarin-forms-samples/tree/master/TipCalc/TipCalc). Minor updates were made for testability, but that's it.

The `TeamCityExport.zip` file contains an export of an example TeamCity configuration using this setup.

## Building

To run a build, from the command line do:

`./build.sh {target}`

These are the targets available:

1. `core-build`
  * Builds the shared cross-platform TipCalc project
2. `core-tests`
  * Runs unit tests for the shared TipCalc project and publishes the results to TeamCity
3. `ios-build`
  * Builds the iOS app
4. `ios-adhoc`
  * Builds the iOS app for ad-hoc distribution and publishes the IPA file to TeamCity as an artifact
5. `ios-appstore`
  * Builds the iOS app for app store distribution and publishes the zip file to TeamCity as an artifact
6. `ios-uitests`
  * Runs automated UI tests for the iOS app in a simulator and publishes the results to TeamCity
7. `ios-testcloud`
  * Runs automated UI tests for the iOS app in TestCloud and publishes the results to TeamCity
8. `android-build`
  * Builds the Android app
9. `android-package`
  * Builds the Android app for distribution and publishes the APK file to TeamCity as an artifact
10. `android-uitests`
  * Runs automated UI tests for the Android app in a simulator and publishes the results to TeamCity
11. `android-testcloud`
  * Runs automated UI tests for the Android app in TestCloud and publishes the results to TeamCity