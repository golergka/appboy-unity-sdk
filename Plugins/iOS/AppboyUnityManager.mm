#import "AppboyUnityManager.h"
#import "AppboyKit.h"
#import "ABKFeedbackViewControllerModalContext.h"
#import "ABKFeedViewControllerModalContext.h"
#import "ABKCard.h"

@interface ABKCard(proxy)
- (NSMutableDictionary *) proxyForJson;
@end

@interface ABKInAppMessage(proxy)
- (NSMutableDictionary *) proxyForJson;
@end

@implementation AppboyUnityManager

+ (AppboyUnityManager*)sharedInstance {
	static AppboyUnityManager *sharedInstance = nil;
  
	if(!sharedInstance)
		sharedInstance = [[AppboyUnityManager alloc] init];
  
	return sharedInstance;
}

- (void) showFeedbackForm {
  ABKFeedbackViewControllerModalContext *feedbackViewController = [[ABKFeedbackViewControllerModalContext alloc] init];
  [UnityGetGLViewController() presentViewController:feedbackViewController animated:YES completion:nil];
}

- (void) showStreamView {
  ABKFeedViewControllerModalContext *feedViewController = [[ABKFeedViewControllerModalContext alloc] init];
  [UnityGetGLViewController() presentViewController:feedViewController animated:YES completion:nil];
}

- (void) logCustomEvent:(NSString *)eventName {
  [[Appboy sharedInstance] logCustomEvent:eventName];
}

- (void) changeUser:(NSString *)userId {
  [[Appboy sharedInstance] changeUser:userId];
}

- (void) logPurchase:(NSString *)productId inCurrency:(NSString *)currencyCode 
             atPrice:(NSString *)price withQuantity:(NSUInteger)quantity {
  [[Appboy sharedInstance] logPurchase:productId 
                            inCurrency:currencyCode 
                               atPrice:[NSDecimalNumber decimalNumberWithString:price] 
                          withQuantity:quantity];
}

- (void) setUserFirstName:(NSString *)firstName {
  [Appboy sharedInstance].user.firstName = firstName;
}

- (void) setUserLastName:(NSString *)lastName {
  [Appboy sharedInstance].user.lastName = lastName;
}

- (void) setUserPhoneNumber:(NSString *)number {
  [Appboy sharedInstance].user.phone = number;
}

- (void) setUserAvatarImageURL:(NSString *)imageURL {
  [Appboy sharedInstance].user.avatarImageURL = imageURL;
}

- (void) setUserEmail:(NSString *)email {
  [Appboy sharedInstance].user.email = email;
}

- (void) setUserBio:(NSString *)bio {
  [Appboy sharedInstance].user.bio = bio;
}

- (void) setUserGender:(NSInteger)gender {
  [[Appboy sharedInstance].user setGender:(ABKUserGenderType)gender];
}

- (void) setUserDateOfBirthToYear:(NSInteger)year Month:(NSInteger)month andDay:(NSInteger)day {
  NSDateComponents *comps = [[NSDateComponents alloc] init];
  [comps setDay:day];
  [comps setMonth:month];
  [comps setYear:year];
  NSCalendar *gregorian = [[NSCalendar alloc]
                           initWithCalendarIdentifier:NSGregorianCalendar];
  NSDate *date = [gregorian dateFromComponents:comps];
  [Appboy sharedInstance].user.dateOfBirth = date;
}

- (void) setUserCountry:(NSString *)country {
  [Appboy sharedInstance].user.country = country;
}

- (void) setUserHomeCity:(NSString *)city {
  [Appboy sharedInstance].user.homeCity = city;
}

- (void) setUserIsSubscribedToEmails:(BOOL)subscribedToEmail {
  [[Appboy sharedInstance].user setIsSubscribedToEmails:subscribedToEmail];
}

- (void) setUserEmailNotificationSubscriptionType:(NSInteger)emailNotificationSubscriptionType {
  [[Appboy sharedInstance].user setEmailNotificationSubscriptionType:(ABKNotificationSubscriptionType)emailNotificationSubscriptionType];
}

- (void) setUserPushNotificationSubscriptionType:(NSInteger)pushNotificationSubscriptionType {
  [[Appboy sharedInstance].user setPushNotificationSubscriptionType:(ABKNotificationSubscriptionType)pushNotificationSubscriptionType];
}

- (void) setUserCustomAttributeWithKey:(NSString *)key andBOOLValue:(BOOL)value {
  [[Appboy sharedInstance].user setCustomAttributeWithKey:key andBOOLValue:value];
}

- (void) setUserCustomAttributeWithKey:(NSString *)key andIntegerValue:(NSInteger)value {
  [[Appboy sharedInstance].user setCustomAttributeWithKey:key andIntegerValue:value];
}

- (void) setUserCustomAttributeWithKey:(NSString *)key andDoubleValue:(double)value {
  [[Appboy sharedInstance].user setCustomAttributeWithKey:key andDoubleValue:value];
}

- (void) setUserCustomAttributeWithKey:(NSString *)key andStringValue:(NSString *)value {
  [[Appboy sharedInstance].user setCustomAttributeWithKey:key andStringValue:value];
}

- (void) setUserCustomAttributeToNowWithKey:(NSString *)key {
  [[Appboy sharedInstance].user setCustomAttributeWithKey:key andDateValue:[NSDate date]];
}

- (void) setUserCustomAttributeWithKey:(NSString *)key toDateAsSecondsFromEpoch:(NSTimeInterval)seconds {
  [[Appboy sharedInstance].user setCustomAttributeWithKey:key andDateValue:[NSDate dateWithTimeIntervalSince1970:seconds]];
}

- (void) unsetUserCustomAttributeWithKey:(NSString *)key {
  [[Appboy sharedInstance].user unsetCustomAttributeWithKey:key];
}

- (void) incrementCustomUserAttributeWithKey:(NSString *)key by:(NSInteger)incrementValue {
  [[Appboy sharedInstance].user incrementCustomUserAttribute:key by:incrementValue];
}

- (void) setCustomAttributeArrayWithKey:(NSString *)key array:(NSArray *)valueArray {
  [[Appboy sharedInstance].user setCustomAttributeArrayWithKey:key array:valueArray];
}

- (void) addToCustomAttributeArrayWithKey:(NSString *)key value:(NSString *)value {
  [[Appboy sharedInstance].user addToCustomAttributeArrayWithKey:key value:value];
}

- (void) removeFromCustomAttributeArrayWithKey:(NSString *)key value:(NSString *)value {
  [[Appboy sharedInstance].user removeFromCustomAttributeArrayWithKey:key value:value];
}

- (BOOL) submitFeedback:(NSString *)replyToEmail message:(NSString *)message isReportingABug:(BOOL)isReportingABug {
  return [[Appboy sharedInstance] submitFeedback:replyToEmail message:message isReportingABug:isReportingABug];
}

// ABKInAppMessageDelegate methods
- (BOOL) onInAppMessageReceived:(ABKInAppMessage *)inAppMessage {
  if (self.unityInAppMessageGameObjectName == nil) {
    NSLog(@"Not sending a Unity message in response to an in-app message being received because "
          "no message receiver was defined. To implement custom behavior in response to a in-app"
          "message being received, you must register a GameObject and method name with Appboy "
          "by calling [[AppboyUnityManager sharedInstance] addInAppMessageListenerWithObjectName: callbackMethodName:].");
    return NO;
  }
  if (self.unityInAppMessageCallbackFunctionName == nil) {
    NSLog(@"Not sending a Unity message in response to a in-app message being received because "
          "no method name was defined for the %@. To implement custom behavior in response to a in-app "
          "message being received, you must register a GameObject and method name with Appboy "
          "[[AppboyUnityManager sharedInstance] addInAppMessageListenerWithObjectName: callbackMethodName:].",
          self.unityInAppMessageGameObjectName);
    return NO;
  }
  NSLog(@"Sending an in-app message to %@:%@.", self.unityInAppMessageGameObjectName, self.unityInAppMessageCallbackFunctionName);
  
  NSData *inAppMessageData = [inAppMessage serializeToData];
  NSString *dataString = [[NSString alloc] initWithData:inAppMessageData encoding:NSUTF8StringEncoding];
  NSLog(@"dataString is %@.", dataString);
  UnitySendMessage([self.unityInAppMessageGameObjectName cStringUsingEncoding:NSUTF8StringEncoding],
                   [self.unityInAppMessageCallbackFunctionName cStringUsingEncoding:NSUTF8StringEncoding],
                   [dataString cStringUsingEncoding:NSUTF8StringEncoding]);
  return YES;
}

// Internal methods for communications between Appboy and Unity
- (void) addInAppMessageListenerWithObjectName:(NSString *)gameObject callbackMethodName:(NSString *)callbackMethod {
  self.unityInAppMessageGameObjectName = gameObject;
  self.unityInAppMessageCallbackFunctionName = callbackMethod;
}

- (void) addFeedListenerWithObjectName:(NSString *)gameObject callbackMethodName:(NSString *)callbackMethod {
  self.unityFeedGameObjectName = gameObject;
  self.unityFeedCallbackFunctionName = callbackMethod;
}

- (void) addPushReceivedListenerWithObjectName:(NSString *)gameObject callbackMethodName:(NSString *)callbackMethod {
  self.unityPushReceivedGameObjectName = gameObject;
  self.unityPushReceivedCallbackFunctionName = callbackMethod;
}

- (void) addPushOpenedListenerWithObjectName:(NSString *)gameObject callbackMethodName:(NSString *)callbackMethod {
  self.unityPushOpenedGameObjectName = gameObject;
  self.unityPushOpenedCallbackFunctionName = callbackMethod;
}

// Push related  methods
- (void) registerApplication:(UIApplication *)application didReceiveRemoteNotification:(NSDictionary *)notification {
  [[Appboy sharedInstance] registerApplication:application didReceiveRemoteNotification:notification];
  
  // generate a new dictionary that rearrange the notification elements
  NSMutableDictionary *aps = [NSMutableDictionary dictionaryWithDictionary:[notification objectForKey:@"aps"]];
  
  // check if the object for key alert is a string; if it is, then convert it to a dictionary
  id alert = [aps objectForKey:@"alert"];
  if ([alert isKindOfClass:[NSString class]]) {
    NSDictionary *alertDictionary = [NSDictionary dictionaryWithObject:alert forKey:@"body"];
    [aps setObject:alertDictionary forKey:@"alert"];
  }
  
  // move all other dictionarys other than aps in payload to key extra in aps dictionary
  NSMutableDictionary *extraDictionary = [NSMutableDictionary dictionaryWithDictionary:notification];
  [extraDictionary removeObjectForKey:@"aps"];
  if ([extraDictionary count] > 0) {
    [aps setObject:extraDictionary forKey:@"extra"];
  }
  
  if ([NSJSONSerialization isValidJSONObject:aps]) {
    NSError *pushParsingError = nil;
    NSData *data = [NSJSONSerialization dataWithJSONObject:aps options:0 error:&pushParsingError];
    
    if (pushParsingError == nil) {
      NSString *dataString = [[NSString alloc] initWithData:data encoding:NSUTF8StringEncoding];
      
      if (application.applicationState == UIApplicationStateActive) {
        if (self.unityPushReceivedGameObjectName == nil) {
          NSLog(@"Not sending a Unity message in response to a push notification being received because "
                "no message receiver was defined. To implement custom behavior in response to a push "
                "notification being received, you must register a GameObject and method name with Appboy "
                "by calling [AppboyUnityManager sharedInstance] addPushReceivedListenerWithObjectName: callbackMethodName].");
          return;
        }
        if (self.unityPushReceivedCallbackFunctionName == nil) {
          NSLog(@"Not sending a Unity message in response to a push notification being received because "
                "no method name was defined for the %@. To implement custom behavior in response to a push "
                "notification being received, you must register a GameObject and method name with Appboy "
                "by calling [AppboyUnityManager sharedInstance] addPushReceivedListenerWithObjectName: callbackMethodName].",
                self.unityPushReceivedGameObjectName);
          return;
        }
        NSLog(@"Sending a notification received message to %@:%@.", self.unityPushReceivedGameObjectName, self.unityPushReceivedCallbackFunctionName);
        
        UnitySendMessage([self.unityPushReceivedGameObjectName cStringUsingEncoding:NSUTF8StringEncoding],
                         [self.unityPushReceivedCallbackFunctionName cStringUsingEncoding:NSUTF8StringEncoding],
                         [dataString cStringUsingEncoding:NSUTF8StringEncoding]);
      } else {
        if (self.unityPushOpenedGameObjectName == nil) {
          NSLog(@"Not sending a Unity message in response to a push notification being opened because "
                "no message receiver was defined. To implement custom behavior in response to a push "
                "notification being opened, you must register a GameObject and method name with Appboy "
                "by calling [AppboyUnityManager sharedInstance] addPushOpenedListenerWithObjectName: callbackMethodName].");
          return;
        }
        if (self.unityPushOpenedCallbackFunctionName == nil) {
          NSLog(@"Not sending a Unity message in response to a push notification being opened because "
                "no method name was defined for the %@. To implement custom behavior in response to a push "
                "notification being opened, you must register a GameObject and method name with Appboy "
                "[AppboyUnityManager sharedInstance] addPushOpenedListenerWithObjectName: callbackMethodName].",
                self.unityPushOpenedGameObjectName);
          return;
        }
        NSLog(@"Sending a notification opened message to %@:%@.", self.unityPushOpenedGameObjectName, self.unityPushOpenedCallbackFunctionName);
        
        UnitySendMessage([self.unityPushOpenedGameObjectName cStringUsingEncoding:NSUTF8StringEncoding],
                         [self.unityPushOpenedCallbackFunctionName cStringUsingEncoding:NSUTF8StringEncoding],
                         [dataString cStringUsingEncoding:NSUTF8StringEncoding]);
      }
    }
  }
}

- (void) logInAppMessageClicked:(NSString *)inAppMessageJSONString {
  ABKInAppMessage *inAppMessage = [[ABKInAppMessage alloc] init];
  [self getInAppMessageFromString:inAppMessageJSONString withInAppMessage:inAppMessage];
  [inAppMessage logInAppMessageClicked];
}

- (void) logInAppMessageButtonClicked:(NSString *)inAppMessageJSONString withButtonID:(NSInteger)buttonID {
  ABKInAppMessageImmersive *inAppMessageImmersive = [[ABKInAppMessageImmersive alloc] init];
  [self getInAppMessageFromString:inAppMessageJSONString withInAppMessage:inAppMessageImmersive];
  [inAppMessageImmersive logInAppMessageClickedWithButtonID:buttonID];
}

- (void) logInAppMessageImpression:(NSString *)inAppMessageJSONString {
  ABKInAppMessage *inAppMessage = [[ABKInAppMessage alloc] init];
  [self getInAppMessageFromString:inAppMessageJSONString withInAppMessage:inAppMessage];
  [inAppMessage logInAppMessageImpression];
}

- (void) getInAppMessageFromString:(NSString *)inAppMessageJSONString withInAppMessage:(ABKInAppMessage *)inAppMessage {
  NSData *inAppMessageData = [inAppMessageJSONString dataUsingEncoding:NSUTF8StringEncoding];
  NSError *e = nil;
  id deserializedInAppMessageDict = [NSJSONSerialization JSONObjectWithData:inAppMessageData options:NSJSONReadingMutableContainers error:&e];
  [inAppMessage setValuesForKeysWithDictionary:deserializedInAppMessageDict];
}

- (void) logCardImpression:(NSString *)cardJSONString {
  NSData *cardData = [cardJSONString dataUsingEncoding:NSUTF8StringEncoding];
  NSError *e = nil;
  id deserializedCardDict = [NSJSONSerialization JSONObjectWithData:cardData options:NSJSONReadingMutableContainers error:&e];
  ABKCard *card = [ABKCard deserializeCardFromDictionary:deserializedCardDict];
  [card logCardImpression];
}

- (void) logCardClicked:(NSString *)cardJSONString {
  NSData *cardData = [cardJSONString dataUsingEncoding:NSUTF8StringEncoding];
  NSError *e = nil;
  id deserializedCardDict = [NSJSONSerialization JSONObjectWithData:cardData options:NSJSONReadingMutableContainers error:&e];
  ABKCard *card = [ABKCard deserializeCardFromDictionary:deserializedCardDict];
  [card logCardClicked];
}

- (void) requestFeedRefresh {
  [[NSNotificationCenter defaultCenter] addObserver:self
                                           selector:@selector(requestFeedFromCache:)
                                               name:ABKFeedUpdatedNotification
                                             object:nil];
  [[Appboy sharedInstance] requestFeedRefresh];
}

- (void) requestFeedFromCache:(NSNotification *)notification {
  BOOL fromOfflineStorage = YES;
  if (notification != nil) {
    [[NSNotificationCenter defaultCenter] removeObserver:self name:ABKFeedUpdatedNotification object:nil];
    fromOfflineStorage = NO;
  }
  if (self.unityFeedGameObjectName == nil) {
    NSLog(@"Not sending a Unity message in response to a feed cards requrest because "
          "no message receiver was defined. To implement custom behavior in response to a feed"
          "being received, you must register a GameObject and method name with Appboy "
          "by calling [[AppboyUnityManager sharedInstance] addFeedListenerWithObjectName: callbackMethodName:].");
  }
  if (self.unityFeedCallbackFunctionName == nil) {
    NSLog(@"Not sending a Unity message in response to a feed cards request because "
          "no method name was defined for the %@. To implement custom behavior in response to a feed "
          "being received, you must register a GameObject and method name with Appboy "
          "[[AppboyUnityManager sharedInstance] addFeedListenerWithObjectName: callbackMethodName:].",
          self.unityFeedGameObjectName);
  }
  NSLog(@"Sending cards to %@:%@.", self.unityFeedGameObjectName, self.unityFeedCallbackFunctionName);
  
  // Parse cards to
  NSMutableArray *cardsDictionaryArray = [NSMutableArray arrayWithCapacity:1];
  NSArray *cards = [[Appboy sharedInstance].feedController getCardsInCategories:ABKCardCategoryAll];
  for (ABKCard *card in cards) {

    NSMutableDictionary *cardDictionary = [card proxyForJson];
    [cardsDictionaryArray addObject:cardDictionary];
  }
  
  NSTimeInterval timestamp = [[Appboy sharedInstance].feedController.lastUpdate timeIntervalSince1970];
  NSDictionary *feedDictionary = @{@"mFeedCards" : cardsDictionaryArray,
                                   @"mTimestamp" : [NSNumber numberWithDouble:timestamp],
                                   @"mFromOfflineStorage" : [NSNumber numberWithBool:fromOfflineStorage]};
  NSError *error;
  NSString *feedString;
  NSData *feedData = [NSJSONSerialization dataWithJSONObject:feedDictionary
                                                     options:0
                                                       error:&error];
  if (!feedData) {
    NSLog(@"Got an error %@ when parsing Appboy feed to json data.", error);
  } else {
    feedString = [[NSString alloc] initWithData:feedData encoding:NSUTF8StringEncoding];
  }
  if (feedString != nil) {
    NSLog(@"the message that's going to pass to Unity is: \n %@", feedString);
    UnitySendMessage([self.unityFeedGameObjectName cStringUsingEncoding:NSUTF8StringEncoding],
                     [self.unityFeedCallbackFunctionName cStringUsingEncoding:NSUTF8StringEncoding],
                     [feedString cStringUsingEncoding:NSUTF8StringEncoding]);
  }
}

- (void) logFeedDisplayed {
  [[Appboy sharedInstance] logFeedDisplayed];
}

- (void) logFeedbackDisplayed {
  [[Appboy sharedInstance] logFeedbackDisplayed];
}

- (void) requestInAppMessageRefresh {
  [[Appboy sharedInstance] requestInAppMessageRefresh];
}

@end
