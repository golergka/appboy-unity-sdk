## Integration steps

1.  Add the modified Plugins folder (or copy individual elements from it) into your project.  You can find it here:  https://github.com/Appboy/appboy-unity-sdk/blob/feature/w10/w10plugin/Plugins.zip.
2.  For each Appboy DLL in the main WSA folder, mark it as `Don't process'. (See DontProcess.png)
3.  For the `WindowsUniversalUnityAdapater.dll` in the `WSA` folder, mark the Placeholder to be `Assests/Plugins/WSA/PlaceholderDLLS/WindowsUniversalUnityAdapater.dll`.  (See WindowsUniversalUnityAdapater.png)
4.  For the `Assests/Plugins/WSA/PlaceholderDLLS/WindowsUniversalUnityAdapater.dll` dll, remove the `WSAPlayer` platform and mark it as `Editor`.  (See PlaceholderWindowsUniversalUnityAdapater.png).