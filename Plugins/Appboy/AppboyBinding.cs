// When developing, you can place #define UNITY_ANDROID or #define UNITY_IOS above this line 
// in order to get correct syntax highlighting in the region you are working on.
using Appboy.Models;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;

/// <summary>
/// These methods can be called by Unity applications using iOS or Android in order to report 
/// events and set user attributes. Please see the Appboy Android JavaDocs for more 
/// detailed guidance on usage (note that only a subset of the functions in the JavaDocs
/// are availabe in the Unity API):
/// http://appboy.github.io/appboy-android-sdk/javadocs/com/appboy/IAppboy.html
/// http://appboy.github.io/appboy-android-sdk/javadocs/index.html
/// </summary>

namespace Appboy {
  public class AppboyBinding : MonoBehaviour {
    public const string Version = "1.2.1";

    public static void LogPurchase(string productId, string currencyCode, decimal price) {
      LogPurchase(productId, currencyCode, price, 1);
    }

    public static void IncrementCustomUserAttribute(string key) {
      IncrementCustomUserAttribute(key, 1);
    }

#if UNITY_IOS
    void Start() {
      Debug.Log("Starting Appboy binding for iOS clients.");
    }
  
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _logCustomEvent(string eventName);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _changeUser(string userId);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _logPurchase(string productId, string currencyCode, string price, int quantity);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserFirstName(string firstName);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserLastName(string lastName);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserPhoneNumber(string phoneNumber);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserAvatarImageURL(string imageURL);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserBio(string bio);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserGender(int gender);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserEmail(string email);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserDateOfBirth(int year, int month, int day);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserCountry(string country);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserHomeCity(string city);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserIsSubscribedToEmails(bool isSubscribedToEmails);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserEmailNotificationSubscriptionType(int emailNotificationSubscriptionType);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setUserPushNotificationSubscriptionType(int pushNotificationSubscriptionType);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setCustomUserAttributeBool(string key, bool val);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setCustomUserAttributeInt(string key, int val);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setCustomUserAttributeFloat(string key, float val);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setCustomUserAttributeString(string key, string val);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setCustomUserAttributeToNow(string key);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setCustomUserAttributeToSecondsFromEpoch(string key, long seconds);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _unsetCustomUserAttribute(string key);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _incrementCustomUserAttribute(string key, int incrementValue);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _setCustomUserAttributeArray(string key, string[] array, int size);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _addToCustomUserAttributeArray(string key, string value);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _removeFromCustomUserAttributeArray(string key, string value);
        
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _submitFeedback(string replyToEmail, string message, bool isReportingABug);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _logInAppMessageClicked(string inAppMessageJSONString);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _logInAppMessageImpression(string inAppMessageJSONString);
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _logInAppMessageButtonClicked(string inAppMessageJSONString, int buttonID);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _logCardImpression(string cardJSONString);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _logCardClicked(string cardJSONString);

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _requestFeedRefresh();

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _requestFeedRefreshFromCache();

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _logFeedDisplayed();

    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _logFeedbackDisplayed();
    
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern void _requestInAppMessage();

    public static void LogCustomEvent(string eventName) {
      _logCustomEvent(eventName);
    }

    public static void LogPurchase(string productId, string currencyCode, decimal price, int quantity) {
      _logPurchase(productId, currencyCode, price.ToString(), quantity);
    }
  
    public static void ChangeUser(string userId) {
      _changeUser(userId);
    }
  
    public static void SetUserFirstName(string firstName) {
      _setUserFirstName(firstName);
    }  
  
    public static void SetUserLastName(string lastName) {
      _setUserLastName(lastName);
    }
 
    public static void SetUserEmail(string email) {
      _setUserEmail(email);
    }

    public static void SetUserBio(string bio) {
      _setUserBio(bio);
    }
 
    public static void SetUserGender(Gender gender) {
      _setUserGender((int)gender);
    }
 
    public static void SetUserDateOfBirth(int year, int month, int day) {
      _setUserDateOfBirth(year, month, day);
    }

    public static void SetUserCountry(string country) {
      _setUserCountry(country);
    }

    public static void SetUserHomeCity(string city) {
      _setUserHomeCity(city);
    }

    public static void SetUserIsSubscribedToEmails(bool isSubscribedToEmails) {
      _setUserIsSubscribedToEmails(isSubscribedToEmails);
    }

    public static void SetUserEmailNotificationSubscriptionType(AppboyNotificationSubscriptionType emailNotificationSubscriptionType) {
      _setUserEmailNotificationSubscriptionType((int)emailNotificationSubscriptionType);
    }

    public static void SetUserPushNotificationSubscriptionType(AppboyNotificationSubscriptionType pushNotificationSubscriptionType) {
      _setUserPushNotificationSubscriptionType((int)pushNotificationSubscriptionType);
    }

    public static void SetUserPhoneNumber(string phoneNumber) {
      _setUserPhoneNumber(phoneNumber);
    }

    public static void SetUserAvatarImageURL(string imageURL) {
      _setUserAvatarImageURL(imageURL);
    }

    public static void SetCustomUserAttribute(string key, bool value) {
      _setCustomUserAttributeBool(key, value);
    }

    public static void SetCustomUserAttribute(string key, int value) {
      _setCustomUserAttributeInt(key, value);
    }

    public static void SetCustomUserAttribute(string key, float value) {
      _setCustomUserAttributeFloat(key, value);
    }

    public static void SetCustomUserAttribute(string key, string value) {
      _setCustomUserAttributeString(key, value);
    }
  
    public static void SetCustomUserAttributeToNow(string key) {
      _setCustomUserAttributeToNow(key);
    }
  
    public static void SetCustomUserAttributeToSecondsFromEpoch(string key, long secondsFromEpoch) {
      _setCustomUserAttributeToSecondsFromEpoch(key, secondsFromEpoch);
    }
  
    public static void UnsetCustomUserAttribute(string key) {
      _unsetCustomUserAttribute(key);
    }

    public static void IncrementCustomUserAttribute(string key, int incrementValue) {
      _incrementCustomUserAttribute(key, incrementValue);
    }

    public static void SetCustomUserAttributeArray(string key, List<string> array, int size) {
      if (array == null) {
        _setCustomUserAttributeArray(key, null, size);
      } else {
        _setCustomUserAttributeArray(key, array.ToArray(), size);
      }
    }

    public static void AddToCustomUserAttributeArray(string key, string value) {
      _addToCustomUserAttributeArray(key, value);
    }

    public static void RemoveFromCustomUserAttributeArray(string key, string value) {
      _removeFromCustomUserAttributeArray(key, value);
    }

    public static void SubmitFeedback(string replyToEmail, string message, bool isReportingABug) {
      _submitFeedback(replyToEmail, message, isReportingABug);
    }

    public static void ClearPushMessage(int notificationId) {

    }
    
    public static void RequestInAppMessage() {
      _requestInAppMessage();
    }

    [System.Obsolete("LogSlideupClicked is deprecated, please use LogInAppMessageClicked instead.")]
    public static void LogSlideupClicked(string slideupJSONString) {
      _logInAppMessageClicked(slideupJSONString);
    }

    [System.Obsolete("LogSlideupImpression is deprecated, please use LogInAppMessageImpression instead.")]
    public static void LogSlideupImpression(string slideupJSONString) {
      _logInAppMessageImpression(slideupJSONString);
    }

    public static void LogInAppMessageClicked(string inAppMessageJSONString) {
      _logInAppMessageClicked(inAppMessageJSONString);
    }

    public static void LogInAppMessageImpression(string inAppMessageJSONString) {
      _logInAppMessageImpression(inAppMessageJSONString);
    }
    
    public static void LogInAppMessageButtonClicked(string inAppMessageJSONString, int buttonID) {
      _logInAppMessageButtonClicked(inAppMessageJSONString, buttonID);
    }

    public static void LogCardImpression(string cardJSONString) {
      _logCardImpression(cardJSONString);
    }

    public static void LogCardClicked(string cardJSONString) {
      _logCardClicked(cardJSONString);
    }

    public static void RequestFeedRefresh() {
      _requestFeedRefresh();
    }
    public static void RequestFeedRefreshFromCache() {
      _requestFeedRefreshFromCache();
    }

    public static void LogFeedDisplayed() {
      _logFeedDisplayed();
    }

    public static void LogFeedbackDisplayed() {
      _logFeedbackDisplayed();
    }

#elif UNITY_ANDROID
    private static AndroidJavaObject appboyUnityActivity;
    private static AndroidJavaObject appboy;
  
    void Start() {
      Debug.Log("Starting Appboy binding for Android clients.");
    }
    
    #region Properties
    public static AndroidJavaObject AppboyUnityActivity {
      get {
        if (appboyUnityActivity == null) {
          using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer")) {
            appboyUnityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
          }
        }
        return appboyUnityActivity;
      }
    }

    public static AndroidJavaObject Appboy {
      get {
        if (appboy == null) {
          using (var appboyClass = new AndroidJavaClass("com.appboy.Appboy")) {
            appboy = appboyClass.CallStatic<AndroidJavaObject>("getInstance", AppboyUnityActivity);
          }
        }
        return appboy;
      }
    }
    #endregion
  
    private static AndroidJavaObject GetCurrentUser() {
      return Appboy.Call<AndroidJavaObject>("getCurrentUser");
    }

    public static void LogCustomEvent(string eventName) {
      Appboy.Call<bool>("logCustomEvent", eventName);
    }

    public static void LogPurchase(string productId, string currencyCode, decimal price, int quantity) {
      var javaPrice = new AndroidJavaObject("java.math.BigDecimal", price.ToString());
      Appboy.Call<bool>("logPurchase", productId, currencyCode, javaPrice, quantity);
    }
 
    public static void ChangeUser(string userId) {
      Appboy.Call<AndroidJavaObject>("changeUser", userId);
    }
  
    public static void SetUserFirstName(string firstName) {
      GetCurrentUser().Call<bool>("setFirstName", firstName);
    }  
  
    public static void SetUserLastName(string lastName) {
      GetCurrentUser().Call<bool>("setLastName", lastName);
    }
 
    public static void SetUserEmail(string email) {
      GetCurrentUser().Call<bool>("setEmail", email);
    }

    public static void SetUserBio(string bio) {
      GetCurrentUser().Call<bool>("setBio", bio);
    }
 
    /// <summary>
    /// Sets the gender field for the current user.
    /// </summary>
    /// <param name='gender'>
    /// The gender of the user. Should be either 'M', 'F', 'MALE', or 'FEMALE'.
    /// </param>
    public static void SetUserGender(Gender gender) {
      using (var genderClass = new AndroidJavaClass("com.appboy.enums.Gender")) {
        switch (gender) {
          case Gender.Male:
            GetCurrentUser().Call<bool>("setGender", genderClass.GetStatic<AndroidJavaObject>("MALE"));
            break;
          case Gender.Female:
            GetCurrentUser().Call<bool>("setGender", genderClass.GetStatic<AndroidJavaObject>("FEMALE"));
            break;
          default:
            Debug.Log("Unknown gender received: " + gender);
            break;
        }
      }
    }

    /// <summary>
    /// Sets the date of birth for the current user.
    /// </summary>
    /// <param name='year'>
    /// Ordinal for the year of birth in the Gregorian calendar.
    /// </param>
    /// <param name='month'>
    /// Ordinal for the month of the year with January = 1 and December = 12.
    /// </param>
    /// <param name='day'>
    /// Ordinal for the day of the month.
    /// </param>
    public static void SetUserDateOfBirth(int year, int month, int day) {
      using (var monthClass = new AndroidJavaClass("com.appboy.enums.Month")) {
        AndroidJavaObject monthObject;
        switch (month) {
          case 1:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("JANUARY");
            break;
          case 2:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("FEBRUARY");
            break;
          case 3:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("MARCH");
            break;
          case 4:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("APRIL");
            break;
          case 5:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("MAY");
            break;
          case 6:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("JUNE");
            break;
          case 7:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("JULY");
            break;
          case 8:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("AUGUST");
            break;
          case 9:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("SEPTEMBER");
            break;
          case 10:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("OCTOBER");
            break;
          case 11:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("NOVEMBER");
            break;
          case 12:
            monthObject = monthClass.GetStatic<AndroidJavaObject>("DECEMBER");
            break;
          default:
            Debug.Log("Month must be in range from 1-12");
            return;
        }
        GetCurrentUser().Call<bool>("setDateOfBirth", year, monthObject, day);
      }
    }

    public static void SetUserCountry(string country) {
      GetCurrentUser().Call<bool>("setCountry", country);
    }

    public static void SetUserHomeCity(string city) {
      GetCurrentUser().Call<bool>("setHomeCity", city);
    }

    public static void SetUserIsSubscribedToEmails(bool isSubscribedToEmails) {
      GetCurrentUser().Call<bool>("setIsSubscribedToEmails", isSubscribedToEmails);
    }

    public static void SetUserEmailNotificationSubscriptionType(AppboyNotificationSubscriptionType emailNotificationSubscriptionType) {
      using (var notificationTypeClass = new AndroidJavaClass("com.appboy.enums.NotificationSubscriptionType")) {
        switch (emailNotificationSubscriptionType) {
          case AppboyNotificationSubscriptionType.OPTED_IN:
            GetCurrentUser().Call<bool>("setEmailNotificationSubscriptionType", notificationTypeClass.GetStatic<AndroidJavaObject>("OPTED_IN"));
            break;
          case AppboyNotificationSubscriptionType.SUBSCRIBED:
            GetCurrentUser().Call<bool>("setEmailNotificationSubscriptionType", notificationTypeClass.GetStatic<AndroidJavaObject>("SUBSCRIBED"));
            break;
          case AppboyNotificationSubscriptionType.UNSUBSCRIBED:
            GetCurrentUser().Call<bool>("setEmailNotificationSubscriptionType", notificationTypeClass.GetStatic<AndroidJavaObject>("UNSUBSCRIBED"));
            break;
          default:
            Debug.Log("Unknown notification subscription type received: " + emailNotificationSubscriptionType);
            break;
        }
      }
    }

    public static void SetUserPushNotificationSubscriptionType(AppboyNotificationSubscriptionType pushNotificationSubscriptionType) {
      using (var notificationTypeClass = new AndroidJavaClass("com.appboy.enums.NotificationSubscriptionType")) {
        switch (pushNotificationSubscriptionType) {
          case AppboyNotificationSubscriptionType.OPTED_IN:
            GetCurrentUser().Call<bool>("setPushNotificationSubscriptionType", notificationTypeClass.GetStatic<AndroidJavaObject>("OPTED_IN"));
            break;
          case AppboyNotificationSubscriptionType.SUBSCRIBED:
            GetCurrentUser().Call<bool>("setPushNotificationSubscriptionType", notificationTypeClass.GetStatic<AndroidJavaObject>("SUBSCRIBED"));
            break;
          case AppboyNotificationSubscriptionType.UNSUBSCRIBED:
            GetCurrentUser().Call<bool>("setPushNotificationSubscriptionType", notificationTypeClass.GetStatic<AndroidJavaObject>("UNSUBSCRIBED"));
            break;
          default:
            Debug.Log("Unknown notification subscription type received: " + pushNotificationSubscriptionType);
            break;
        }
      }
    }

    public static void SetUserPhoneNumber(string phoneNumber) {
      GetCurrentUser().Call<bool>("setPhoneNumber", phoneNumber);
    }

    public static void SetUserAvatarImageURL(string imageURL) {
      GetCurrentUser().Call<bool>("setAvatarImageUrl", imageURL);
    }

    public static void SetCustomUserAttribute(string key, bool value) {
      GetCurrentUser().Call<bool>("setCustomUserAttribute", key, value);
    }

    public static void SetCustomUserAttribute(string key, int value) {
      GetCurrentUser().Call<bool>("setCustomUserAttribute", key, value);
    }

    public static void SetCustomUserAttribute(string key, float value) {
      GetCurrentUser().Call<bool>("setCustomUserAttribute", key, value);
    }

    public static void SetCustomUserAttribute(string key, string value) {
      GetCurrentUser().Call<bool>("setCustomUserAttribute", key, value);
    }
  
    public static void SetCustomUserAttributeToNow(string key) {
      GetCurrentUser().Call<bool>("setCustomUserAttributeToNow", key);
    }
  
    public static void SetCustomUserAttributeToSecondsFromEpoch(string key, long secondsFromEpoch) {
      GetCurrentUser().Call<bool>("setCustomUserAttributeToSecondsFromEpoch", key, secondsFromEpoch);
    }
  
    public static void UnsetCustomUserAttribute(string key) {
      GetCurrentUser().Call<bool>("unsetCustomUserAttribute", key);
    }

    public static void IncrementCustomUserAttribute(string key, int incrementValue) {
      GetCurrentUser().Call<bool>("incrementCustomUserAttribute", key, incrementValue);
    }

    public static void SetCustomUserAttributeArray(string key, List<string> array, int size) {
      if (array == null) {
        GetCurrentUser().Call<bool>("setCustomAttributeArray", key, null);
      } else {
        GetCurrentUser().Call<bool>("setCustomAttributeArray", key, array.ToArray());
      }
    }
    
    public static void AddToCustomUserAttributeArray(string key, string value) {
      GetCurrentUser().Call<bool>("addToCustomAttributeArray", key, value);
    }
    
    public static void RemoveFromCustomUserAttributeArray(string key, string value) {
      GetCurrentUser().Call<bool>("removeFromCustomAttributeArray", key, value);
    }
    
    public static void SubmitFeedback(string replyToEmail, string message, bool isReportingABug) {
      object[] args = new object[] { replyToEmail, message, isReportingABug };
      Appboy.Call<bool>("submitFeedback", args);
    }
        
    public static void ClearPushMessage(int notificationId) {
      AppboyUnityActivity.Call("clearNotification", new object[] { notificationId });
    }

    public static void RequestSlideup() {
      Appboy.Call("requestInAppMessageRefresh");
    }

    public static void RequestInAppMessage() {
      Appboy.Call("requestInAppMessageRefresh");
    }

    public static void RequestFeedRefresh() {
      Appboy.Call("requestFeedRefresh");
    }

    public static void RequestFeedRefreshFromCache() {
      Appboy.Call("requestFeedRefreshFromCache");
    }

    public static void LogInAppMessageClicked(string inAppMessageJSONString) {
      AppboyUnityActivity.Call("logInAppMessageClick", new object[] { inAppMessageJSONString });
    }

    public static void LogInAppMessageImpression(string inAppMessageJSONString) {
      AppboyUnityActivity.Call("logInAppMessageImpression", new object[] { inAppMessageJSONString });
    }
    
    public static void LogInAppMessageButtonClicked(string inAppMessageJSONString, int buttonID) {
      AppboyUnityActivity.Call("logInAppMessageButtonClick", new object[] { inAppMessageJSONString, buttonID });
    }

    [System.Obsolete("LogSlideupClicked is deprecated, please use LogInAppMessageClicked instead.")]
    public static void LogSlideupClicked(string slideupJSONString) {
      AppboyUnityActivity.Call("logInAppMessageClick", new object[] { slideupJSONString });
    }

    [System.Obsolete("LogSlideupImpression is deprecated, please use LogInAppMessageImpression instead.")]
    public static void LogSlideupImpression(string slideupJSONString) {
      AppboyUnityActivity.Call("logInAppMessageImpression", new object[] { slideupJSONString });
    }

    public static void LogFeedDisplayed() {
      Appboy.Call<bool>("logFeedDisplayed");
    }

    public static void LogFeedbackDisplayed() {
      Appboy.Call<bool>("logFeedbackDisplayed");
    }
    
#elif UNITY_METRO
    void Start() {
      Debug.Log("Starting Appboy binding for Windows Metro clients.");
    }

    public static void LogCustomEvent(string eventName) {
      WindowsUniversalUnityAdapter.AppboyAdapter.LogCustomEvent(eventName);
    }

    public static void LogPurchase(string productId, string currencyCode, decimal price, int quantity) {
      WindowsUniversalUnityAdapter.AppboyAdapter.LogPurchase(productId, currencyCode, price, quantity);
    }

    public static void ChangeUser(string userId) {
      WindowsUniversalUnityAdapter.AppboyAdapter.ChangeUser(userId);
    }

    public static void SetUserFirstName(string firstName) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserFirstName(firstName);
    }

    public static void SetUserLastName(string lastName) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserLastName(lastName);
    }

    public static void SetUserEmail(string email) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserEmail(email);
    }

    public static void SetUserBio(string bio) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserBio(bio);
    }

    public static void SetUserGender(Gender gender) {
      if (gender == Gender.Female) {
        WindowsUniversalUnityAdapter.AppboyAdapter.SetUserGender("FEMALE");

      } else {
        WindowsUniversalUnityAdapter.AppboyAdapter.SetUserGender("MALE");
      }
    }

    public static void SetUserDateOfBirth(int year, int month, int day) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserDateOfBirth(year, month, day);
    }

    public static void SetUserCountry(string country) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserCountry(country);
    }

    public static void SetUserHomeCity(string city) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserHomeCity(city);
    }

    public static void SetUserIsSubscribedToEmails(bool isSubscribedToEmails) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserIsSubscribedToEmails(isSubscribedToEmails);
    }

    public static void SetUserEmailNotificationSubscriptionType(AppboyNotificationSubscriptionType emailNotificationSubscriptionType) {
      if (emailNotificationSubscriptionType == AppboyNotificationSubscriptionType.OPTED_IN) {
        WindowsUniversalUnityAdapter.AppboyAdapter.SetUserPushNotificationSubscriptionType("OPTED_IN");
      } else if (emailNotificationSubscriptionType == AppboyNotificationSubscriptionType.SUBSCRIBED) {
        WindowsUniversalUnityAdapter.AppboyAdapter.SetUserPushNotificationSubscriptionType("SUBSCRIBED");
      } else {
        WindowsUniversalUnityAdapter.AppboyAdapter.SetUserPushNotificationSubscriptionType("UNSUBSCRIBED");
      }
    }

    public static void SetUserPushNotificationSubscriptionType(AppboyNotificationSubscriptionType pushNotificationSubscriptionType) {
      if (pushNotificationSubscriptionType == AppboyNotificationSubscriptionType.OPTED_IN) {
        WindowsUniversalUnityAdapter.AppboyAdapter.SetUserPushNotificationSubscriptionType("OPTED_IN");
      } else if (pushNotificationSubscriptionType == AppboyNotificationSubscriptionType.SUBSCRIBED) {
        WindowsUniversalUnityAdapter.AppboyAdapter.SetUserPushNotificationSubscriptionType("SUBSCRIBED");
      } else {
        WindowsUniversalUnityAdapter.AppboyAdapter.SetUserPushNotificationSubscriptionType("UNSUBSCRIBED");
      }
    }

    public static void SetUserPhoneNumber(string phoneNumber) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserPhoneNumber(phoneNumber);
    }

    public static void SetUserAvatarImageURL(string imageURL) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetUserAvatarImageURL(imageURL);
    }

    public static void SetCustomUserAttribute(string key, bool value) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetCustomUserAttribute(key, value);
    }

    public static void SetCustomUserAttribute(string key, int value) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetCustomUserAttribute(key, value);
    }

    public static void SetCustomUserAttribute(string key, float value) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetCustomUserAttribute(key, value);
    }

    public static void SetCustomUserAttribute(string key, string value) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetCustomUserAttribute(key, value);
    }

    public static void SetCustomUserAttributeToNow(string key) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetCustomUserAttributeToNow(key);
    }

    public static void SetCustomUserAttributeToSecondsFromEpoch(string key, long secondsFromEpoch) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetCustomUserAttributeToSecondsFromEpoch(key, secondsFromEpoch);
    }

    public static void UnsetCustomUserAttribute(string key) {
      WindowsUniversalUnityAdapter.AppboyAdapter.UnsetCustomUserAttribute(key);
    }

    public static void IncrementCustomUserAttribute(string key, int incrementValue) {
      WindowsUniversalUnityAdapter.AppboyAdapter.IncrementCustomUserAttribute(key, incrementValue);
    }

    public static void SetCustomUserAttributeArray(string key, List<string> array, int size) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SetCustomUserAttributeArray(key, array, size);
    }

    public static void AddToCustomUserAttributeArray(string key, string value) {
      WindowsUniversalUnityAdapter.AppboyAdapter.AddToCustomUserAttributeArray(key, value);
    }

    public static void RemoveFromCustomUserAttributeArray(string key, string value) {
      WindowsUniversalUnityAdapter.AppboyAdapter.RemoveFromCustomUserAttributeArray(key, value);
    }

    public static void SubmitFeedback(string replyToEmail, string message, bool isReportingABug) {
      WindowsUniversalUnityAdapter.AppboyAdapter.SubmitFeedback(replyToEmail, message, isReportingABug);
    }

    public static void ClearPushMessage(int notificationId) {
      WindowsUniversalUnityAdapter.AppboyAdapter.ClearPushMessage(notificationId);
    }

    public static void RequestSlideup() {
      WindowsUniversalUnityAdapter.AppboyAdapter.RequestSlideup();
    }

    public static void RequestFeedRefresh() {
      WindowsUniversalUnityAdapter.AppboyAdapter.RequestFeedRefresh();
    }

    public static void RequestFeedRefreshFromCache() {
      WindowsUniversalUnityAdapter.AppboyAdapter.RequestFeedRefreshFromCache();
    }

    public static void LogSlideupClicked(string slideupJSONString) {
      WindowsUniversalUnityAdapter.AppboyAdapter.LogSlideupClicked(slideupJSONString);
    }

    public static void LogSlideupImpression(string slideupJSONString) {
      WindowsUniversalUnityAdapter.AppboyAdapter.LogSlideupImpression(slideupJSONString);
    }

    public static void LogFeedDisplayed() {
      WindowsUniversalUnityAdapter.AppboyAdapter.LogFeedDisplayed();
    }

    public static void LogFeedbackDisplayed() {
      WindowsUniversalUnityAdapter.AppboyAdapter.LogFeedbackDisplayed();
    }

#elif UNITY_WP8
    void Start() {
      Debug.Log("Starting Appboy binding for Windows Phone8 clients.");
    }

    public static void LogCustomEvent(string eventName) {
      WindowsPhone8UnityAdapter.AppboyAdapter.LogCustomEvent(eventName);
    }

    public static void LogPurchase(string productId, string currencyCode, decimal price, int quantity) {
      WindowsPhone8UnityAdapter.AppboyAdapter.LogPurchase(productId, currencyCode, price, quantity);
    }

    public static void ChangeUser(string userId) {
      WindowsPhone8UnityAdapter.AppboyAdapter.ChangeUser(userId);
    }

    public static void SetUserFirstName(string firstName) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserFirstName(firstName);
    }

    public static void SetUserLastName(string lastName) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserLastName(lastName);
    }

    public static void SetUserEmail(string email) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserEmail(email);
    }

    public static void SetUserBio(string bio) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserBio(bio);
    }

    public static void SetUserGender(Gender gender) {
      if (gender == Gender.Female) {
        WindowsPhone8UnityAdapter.AppboyAdapter.SetUserGender("FEMALE");
      } else {
        WindowsPhone8UnityAdapter.AppboyAdapter.SetUserGender("MALE");
      }
    }

    public static void SetUserDateOfBirth(int year, int month, int day) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserDateOfBirth(year, month, day);
    }

    public static void SetUserCountry(string country) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserCountry(country);
    }

    public static void SetUserHomeCity(string city) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserHomeCity(city);
    }

    public static void SetUserIsSubscribedToEmails(bool isSubscribedToEmails) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserIsSubscribedToEmails(isSubscribedToEmails);
    }

    public static void SetUserEmailNotificationSubscriptionType(AppboyNotificationSubscriptionType emailNotificationSubscriptionType) {
      if (emailNotificationSubscriptionType == AppboyNotificationSubscriptionType.OPTED_IN) {
        WindowsPhone8UnityAdapter.AppboyAdapter.SetUserEmailNotificationSubscriptionType("OPTED_IN");
      } else if (emailNotificationSubscriptionType == AppboyNotificationSubscriptionType.SUBSCRIBED) {
        WindowsPhone8UnityAdapter.AppboyAdapter.SetUserEmailNotificationSubscriptionType("SUBSCRIBED");
      } else {
        WindowsPhone8UnityAdapter.AppboyAdapter.SetUserEmailNotificationSubscriptionType("UNSUBSCRIBED");
      }
    }

    public static void SetUserPushNotificationSubscriptionType(AppboyNotificationSubscriptionType pushNotificationSubscriptionType) {
      if (pushNotificationSubscriptionType == AppboyNotificationSubscriptionType.OPTED_IN) {
        WindowsPhone8UnityAdapter.AppboyAdapter.SetUserPushNotificationSubscriptionType("OPTED_IN");
      } else if (pushNotificationSubscriptionType == AppboyNotificationSubscriptionType.SUBSCRIBED) {
        WindowsPhone8UnityAdapter.AppboyAdapter.SetUserPushNotificationSubscriptionType("SUBSCRIBED");
      } else {
        WindowsPhone8UnityAdapter.AppboyAdapter.SetUserPushNotificationSubscriptionType("UNSUBSCRIBED");
      }
    }

    public static void SetUserPhoneNumber(string phoneNumber) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserPhoneNumber(phoneNumber);
    }

    public static void SetUserAvatarImageURL(string imageURL) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetUserAvatarImageURL(imageURL);
    }

    public static void SetCustomUserAttribute(string key, bool value) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetCustomUserAttribute(key, value);
    }

    public static void SetCustomUserAttribute(string key, int value) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetCustomUserAttribute(key, value);
    }

    public static void SetCustomUserAttribute(string key, float value) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetCustomUserAttribute(key, value);
    }

    public static void SetCustomUserAttribute(string key, string value) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetCustomUserAttribute(key, value);
    }

    public static void SetCustomUserAttributeToNow(string key) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetCustomUserAttributeToNow(key);
    }

    public static void SetCustomUserAttributeToSecondsFromEpoch(string key, long secondsFromEpoch) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetCustomUserAttributeToSecondsFromEpoch(key, secondsFromEpoch);
    }

    public static void UnsetCustomUserAttribute(string key) {
      WindowsPhone8UnityAdapter.AppboyAdapter.UnsetCustomUserAttribute(key);
    }

    public static void IncrementCustomUserAttribute(string key, int incrementValue) {
      WindowsPhone8UnityAdapter.AppboyAdapter.IncrementCustomUserAttribute(key, incrementValue);
    }

    public static void SetCustomUserAttributeArray(string key, List<string> array, int size) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SetCustomUserAttributeArray(key, array, size);
    }

    public static void AddToCustomUserAttributeArray(string key, string value) {
      WindowsPhone8UnityAdapter.AppboyAdapter.AddToCustomUserAttributeArray(key, value);
    }

    public static void RemoveFromCustomUserAttributeArray(string key, string value) {
      WindowsPhone8UnityAdapter.AppboyAdapter.RemoveFromCustomUserAttributeArray(key, value);
    }

    public static void SubmitFeedback(string replyToEmail, string message, bool isReportingABug) {
      WindowsPhone8UnityAdapter.AppboyAdapter.SubmitFeedback(replyToEmail, message, isReportingABug);
    }

    public static void ClearPushMessage(int notificationId) {
      WindowsPhone8UnityAdapter.AppboyAdapter.ClearPushMessage(notificationId);
    }

    public static void RequestSlideup() {
      WindowsPhone8UnityAdapter.AppboyAdapter.RequestSlideup();
    }

    public static void RequestFeedRefresh() {
      WindowsPhone8UnityAdapter.AppboyAdapter.RequestFeedRefresh();
    }

    public static void RequestFeedRefreshFromCache() {
      WindowsPhone8UnityAdapter.AppboyAdapter.RequestFeedRefreshFromCache();
    }

    public static void LogSlideupClicked(string slideupJSONString) {
      WindowsPhone8UnityAdapter.AppboyAdapter.LogSlideupClicked(slideupJSONString);
    }

    public static void LogSlideupImpression(string slideupJSONString) {
      WindowsPhone8UnityAdapter.AppboyAdapter.LogSlideupImpression(slideupJSONString);
    }

    public static void LogFeedDisplayed() {
      WindowsPhone8UnityAdapter.AppboyAdapter.LogFeedDisplayed();
    }

    public static void LogFeedbackDisplayed() {
      WindowsPhone8UnityAdapter.AppboyAdapter.LogFeedbackDisplayed();
    }

#else


    // Empty implementations of the API, in case the application is being compiled for a platform other than iOS or Android.
    void Start() {
      Debug.Log("Starting no-op Appboy binding for non iOS/Android clients.");
    }

    public static void LogCustomEvent(string eventName) {
    }

    public static void LogPurchase(string productId, string currencyCode, decimal price, int quantity) {
    }

    public static void ChangeUser(string userId) {
    }

    public static void SetUserFirstName(string firstName) {
    }

    public static void SetUserLastName(string lastName) {
    }

    public static void SetUserEmail(string email) {
    }

    public static void SetUserBio(string bio) {
    }

    public static void SetUserGender(Gender gender) {
    }

    public static void SetUserDateOfBirth(int year, int month, int day) {
    }

    public static void SetUserCountry(string country) {
    }

    public static void SetUserHomeCity(string city) {
    }

    public static void SetUserIsSubscribedToEmails(bool isSubscribedToEmails) {
    }

    public static void SetUserEmailNotificationSubscriptionType(AppboyNotificationSubscriptionType emailNotificationSubscriptionType) {
    }

    public static void SetUserPushNotificationSubscriptionType(AppboyNotificationSubscriptionType pushNotificationSubscriptionType) {
    }

    public static void SetUserPhoneNumber(string phoneNumber) {
    }

    public static void SetUserAvatarImageURL(string imageURL) {
    }

    public static void SetCustomUserAttribute(string key, bool value) {
    }

    public static void SetCustomUserAttribute(string key, int value) {
    }

    public static void SetCustomUserAttribute(string key, float value) {
    }

    public static void SetCustomUserAttribute(string key, string value) {
    }

    public static void SetCustomUserAttributeToNow(string key) {
    }

    public static void SetCustomUserAttributeToSecondsFromEpoch(string key, long secondsFromEpoch) {
    }

    public static void UnsetCustomUserAttribute(string key) {
    }

    public static void IncrementCustomUserAttribute(string key, int incrementValue) {
    }

    public static void SetCustomUserAttributeArray(string key, List<string> array, int size) {
    }

    public static void AddToCustomUserAttributeArray(string key, string value) {
    }

    public static void RemoveFromCustomUserAttributeArray(string key, string value) {
    }

    public static void SubmitFeedback(string replyToEmail, string message, bool isReportingABug) {
    }

    public static void ClearPushMessage(int notificationId) {
    }

    public static void RequestSlideup() {
    }
        
    public static void RequestInAppMessage() {
    }

    public static void RequestFeedRefresh() {
    }

    public static void RequestFeedRefreshFromCache() {
    }

    public static void LogSlideupClicked(string slideupJSONString) {
    }

    public static void LogSlideupImpression(string slideupJSONString) {
    }

    public static void LogInAppMessageClicked(string inAppMessageJSONString) {
    }

    public static void LogInAppMessageImpression(string inAppMessageJSONString) {
    }

    public static void LogFeedDisplayed() {
    }

    public static void LogFeedbackDisplayed() {
    }
#endif
  }
}
