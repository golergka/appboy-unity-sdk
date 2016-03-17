This repository contains the wrapper code and binaries for the Unity plugins derived from the Appboy Android, iOS, and Windows SDKs.

## Android Setup

To integrate Appboy into your Android Unity application, complete our <a href="https://documentation.appboy.com/SDK_Integration/Unity/Android">Android Unity integration instructions</a>.

## Plugin Setup

Common Appboy C# code is contained in the `Plugins/Appboy` folder in the SDK. It is not actually neccessary to copy it to the special `Plugins` folder in Unity, since it doesn't contain any native code, but you need all of these files in your project for `AppboyBindings.cs` to compile.

## iOS Setup

1. You need Appboy native iOS files in your project, which are located in `Plugins/iOS` folder in this SDK. [As Unity documentation says](http://docs.unity3d.com/Manual/PluginsForIOS.html), these files need to be placed under `Plugins/iOS` folder. Since you likely have a lot of different plugins in your project, it's a good idea to copy them to `Plugins/iOS/Appboy` instead.

2. Build the xcode project and confirm that Unity has copied the files `AppboyBinding.m`, `AppboyUnityManager.h`, and `AppboyUnityManager.mm` to the "Libraries" directory of your generated project. Note that they will not be included in the XCode project, so you'll need to check for their presence manually. If Unity fails to copy the files automatically, manually copy them from this repo.

If you copied them to `Plugins/iOS/Appboy` folder, as suggested earlier, you will find them in the `Libraries/Plugins/iOS/Appboy` folder in your iOS project.

3. Include AppboyUnityManager.h in your Xcode project (even though the file itself is already in the Libraries directory) by right clicking on Classes and selecting "Add Files to ..."

4. Now, you will need to perform the first three normal integration steps for adding the Appboy SDK to an iOS project. These steps are documented under "Basic SDK Integration," "Add the iOS Libraries," and "Configure the Appboy Library and Framework" in our iOS Integration Instructions at: https://documentation.appboy.com/Advanced_Use_Cases/Manual_iOS_SDK_Integration

<b>Note:</b> As of version 2.3.1, the Appboy iOS SDK has split into two libraries, AppboyKit and AppboyKitWithoutFacebookSupport. More details of the split can found here (https://github.com/Appboy/appboy-ios-sdk and https://github.com/Appboy/appboy-ios-sdk/blob/master/CHANGELOG.md#231). Since the Unity platform provides Facebook support and therefore the AppboyKitWithoutFacebookSupport is the correct SDK to use in your Unity application. 

Next, we'll need to make some modifications to your generated `Classes\AppController.mm`. A version of these modifications is included at the bottom of the integration directions linked to in the previous step, the following are meant to replace those).

1. At the top of the file add the following import statements:
`#import "AppboyKit.h"`
`#import "AppboyUnityManager.h"`

2. In the method `applicationDidFinishLaunchingWithOptions`, add the following code block above the return statement, replacing "YOUR-API-KEY" with your Appboy API key:
```
[Appboy startWithApiKey:@"YOUR-API-KEY"
        inApplication:application
        withLaunchOptions:launchOptions];
[Appboy sharedInstance].slideupDelegate = [AppboyUnityManager sharedInstance];
```

3. If you want to fetch the slide up message from Appboy, add this line to `applicationDidFinishLaunchingWithOptions`:
```
[[AppboyUnityManager sharedInstance] addSlideupListenerWithObjectName:@"Your Unity Game Object Name" callbackMethodName:@"Your Unity Call Back Method Name"];
````

4. Replace @"Your Unity Game Object Name" with the unity object name you want to listen to the slide up message, and also change @"Your Unity Call Back Method Name" to the call back method name that handles the slide up message. Please make sure the call back method is in the unity object you just passed in as the first parameter. 

5. If you want to use push notifications, also add this code to `applicationDidFinishLaunchingWithOptions`:
```
[[UIApplication sharedApplication] registerForRemoteNotificationTypes: 
          (UIRemoteNotificationTypeAlert | 
           UIRemoteNotificationTypeBadge |     
           UIRemoteNotificationTypeSound)];
[[AppboyUnityManager sharedInstance] addPushReceivedListenerWithObjectName:@"Your Unity Game Object Name" callbackMethodName:@"Your Unity Call Back Method Name"];
[[AppboyUnityManager sharedInstance] addPushOpenedListenerWithObjectName:@"Your Unity Game Object Name" callbackMethodName:@"Your Unity Call Back Method Name"];
```

6. This line to `didRegisterForRemoteNotificationsWithDeviceToken`:
```
[[Appboy sharedInstance] registerPushToken:
                [NSString stringWithFormat:@"%@", deviceToken]];
```

7. And this line to `didReceiveRemoteNotification`:
```
[[AppboyUnityManager sharedInstance] registerApplication:application
                didReceiveRemoteNotification:userInfo];
```

8. To help verify the code modifications you made, there is an example modified AppController.mm generated by Unity 4.1.2 in Docs/iOS in this repo.

<b>Note:</b> If you're using push notifications you'll need to follow the standard setup for Apple push which you can find <a href="https://documentation.appboy.com/Enabling_Message_Channels/Push_Notifications/iOS">here in our documentation.</a>

As you make updates to your app from Unity, you should choose the same location to generate the Xcode project each time. Unity will prompt you to replace or append the existing folder. If you choose "Append," you shouldn't have to redo any of your Appboy setup in the future.

## Windows Phone 8 Setup

Once you have placed the plugin DLLs in the proper location in your Unity project, build your Windows Phone 8 application from your Unity project.  You will then have a working Windows Phone 8 XAML application with the required Appboy plugin DLLs referenced from your project.  

You can then follow the normal integration instructions found <a href="https://documentation.appboy.com/SDK_Integration/Windows/Phone8">here</a>, with the following exception:  

<b>Note:</b> Unity does processing and modification of Windows Phone 8 plugin DLLs.  As a result, you must use the DLLs that are output from the Unity build; do not replace a DLL with a different version after you've built from Unity.  In particular, if you are using our UI library, you must modify the references to point at the DLLs unity outputs (not the ones found using Nuget).  If you need to update a DLL version, you can place it in the ```Plugins/WP8``` directory and then use the ones output from Unity.

## Windows Universal Setup

Once you have placed the plugin DLLs in the proper location in your Unity project, build your Windows Store or Phone 8.1 application from your Unity project.  You will then have a working XAML application with the required Appboy plugin DLLs referenced from your project.  

You can then follow the normal integration instructions found <a href="https://documentation.appboy.com/SDK_Integration/Windows/Universal">here</a>.  
