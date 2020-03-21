using System;
using AVFoundation;
using CallKit;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace JitsiXamarinBinding
{
    // @interface JitsiMeetUserInfo : NSObject
    [BaseType (typeof(NSObject))]
	interface JitsiMeetUserInfo
	{
		// @property (copy, nonatomic) NSString * _Nullable displayName;
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable avatar;
		[NullAllowed, Export ("avatar", ArgumentSemantic.Copy)]
		NSUrl Avatar { get; set; }

		// -(instancetype _Nullable)initWithDisplayName:(NSString * _Nullable)displayName andEmail:(NSString * _Nullable)email andAvatar:(NSURL * _Nullable)avatar;
		[Export ("initWithDisplayName:andEmail:andAvatar:")]
		IntPtr Constructor ([NullAllowed] string displayName, [NullAllowed] string email, [NullAllowed] NSUrl avatar);
	}

	// @interface JitsiMeetConferenceOptionsBuilder : NSObject
	[BaseType (typeof(NSObject))]
	interface JitsiMeetConferenceOptionsBuilder
	{
		// @property (copy, nonatomic) NSURL * _Nullable serverURL;
		[NullAllowed, Export ("serverURL", ArgumentSemantic.Copy)]
		NSUrl ServerURL { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable room;
		[NullAllowed, Export ("room")]
		string Room { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable subject;
		[NullAllowed, Export ("subject")]
		string Subject { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable token;
		[NullAllowed, Export ("token")]
		string Token { get; set; }

		// @property (copy, nonatomic) NSDictionary * _Nullable colorScheme;
		[NullAllowed, Export ("colorScheme", ArgumentSemantic.Copy)]
		NSDictionary ColorScheme { get; set; }

		// @property (readonly, nonatomic) NSDictionary * _Nonnull featureFlags;
		[Export ("featureFlags")]
		NSDictionary FeatureFlags { get; }

		// @property (nonatomic) BOOL audioOnly;
		[Export ("audioOnly")]
		bool AudioOnly { get; set; }

		// @property (nonatomic) BOOL audioMuted;
		[Export ("audioMuted")]
		bool AudioMuted { get; set; }

		// @property (nonatomic) BOOL videoMuted;
		[Export ("videoMuted")]
		bool VideoMuted { get; set; }

		// @property (nonatomic) BOOL welcomePageEnabled;
		[Export ("welcomePageEnabled")]
		bool WelcomePageEnabled { get; set; }

		// @property (nonatomic) JitsiMeetUserInfo * _Nullable userInfo;
		[NullAllowed, Export ("userInfo", ArgumentSemantic.Assign)]
		JitsiMeetUserInfo UserInfo { get; set; }

		// -(void)setFeatureFlag:(NSString * _Nonnull)flag withBoolean:(BOOL)value;
		[Export ("setFeatureFlag:withBoolean:")]
		void SetFeatureFlag (string flag, bool value);

		// -(void)setFeatureFlag:(NSString * _Nonnull)flag withValue:(id _Nonnull)value;
		[Export ("setFeatureFlag:withValue:")]
		void SetFeatureFlag (string flag, NSObject value);
	}

	// @interface JitsiMeetConferenceOptions : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface JitsiMeetConferenceOptions
	{
		// @property (readonly, copy, nonatomic) NSURL * _Nullable serverURL;
		[NullAllowed, Export ("serverURL", ArgumentSemantic.Copy)]
		NSUrl ServerURL { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable room;
		[NullAllowed, Export ("room")]
		string Room { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable subject;
		[NullAllowed, Export ("subject")]
		string Subject { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable token;
		[NullAllowed, Export ("token")]
		string Token { get; }

		// @property (copy, nonatomic) NSDictionary * _Nullable colorScheme;
		[NullAllowed, Export ("colorScheme", ArgumentSemantic.Copy)]
		NSDictionary ColorScheme { get; set; }

		// @property (readonly, nonatomic) NSDictionary * _Nonnull featureFlags;
		[Export ("featureFlags")]
		NSDictionary FeatureFlags { get; }

		// @property (readonly, nonatomic) BOOL audioOnly;
		[Export ("audioOnly")]
		bool AudioOnly { get; }

		// @property (readonly, nonatomic) BOOL audioMuted;
		[Export ("audioMuted")]
		bool AudioMuted { get; }

		// @property (readonly, nonatomic) BOOL videoMuted;
		[Export ("videoMuted")]
		bool VideoMuted { get; }

		// @property (readonly, nonatomic) BOOL welcomePageEnabled;
		[Export ("welcomePageEnabled")]
		bool WelcomePageEnabled { get; }

		// @property (nonatomic) JitsiMeetUserInfo * _Nullable userInfo;
		[NullAllowed, Export ("userInfo", ArgumentSemantic.Assign)]
		JitsiMeetUserInfo UserInfo { get; set; }

		// +(instancetype _Nonnull)fromBuilder:(void (^ _Nonnull)(JitsiMeetConferenceOptionsBuilder * _Nonnull))initBlock;
		[Static]
		[Export ("fromBuilder:")]
		JitsiMeetConferenceOptions FromBuilder (Action<JitsiMeetConferenceOptionsBuilder> initBlock);
	}

	// @protocol JitsiMeetViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface JitsiMeetViewDelegate
	{
		// @optional -(void)conferenceJoined:(NSDictionary *)data;
		[Export ("conferenceJoined:")]
		void ConferenceJoined (NSDictionary data);

		// @optional -(void)conferenceTerminated:(NSDictionary *)data;
		[Export ("conferenceTerminated:")]
		void ConferenceTerminated (NSDictionary data);

		// @optional -(void)conferenceWillJoin:(NSDictionary *)data;
		[Export ("conferenceWillJoin:")]
		void ConferenceWillJoin (NSDictionary data);

		// @optional -(void)enterPictureInPicture:(NSDictionary *)data;
		[Export ("enterPictureInPicture:")]
		void EnterPictureInPicture (NSDictionary data);
	}

	// @interface JitsiMeetView : UIView
	[BaseType (typeof(UIView))]
	interface JitsiMeetView
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		JitsiMeetViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<JitsiMeetViewDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)join:(JitsiMeetConferenceOptions * _Nullable)options;
		[Export ("join:")]
		void Join ([NullAllowed] JitsiMeetConferenceOptions options);

		// -(void)leave;
		[Export ("leave")]
		void Leave ();
	}

	// @interface JitsiMeetBaseLogHandler : NSObject
	[BaseType (typeof(NSObject))]
	interface JitsiMeetBaseLogHandler
	{
		// -(void)logVerbose:(NSString *)msg;
		[Export ("logVerbose:")]
		void LogVerbose (string msg);

		// -(void)logDebug:(NSString *)msg;
		[Export ("logDebug:")]
		void LogDebug (string msg);

		// -(void)logInfo:(NSString *)msg;
		[Export ("logInfo:")]
		void LogInfo (string msg);

		// -(void)logWarn:(NSString *)msg;
		[Export ("logWarn:")]
		void LogWarn (string msg);

		// -(void)logError:(NSString *)msg;
		[Export ("logError:")]
		void LogError (string msg);
	}

	// @interface JitsiMeetLogger : NSObject
	[BaseType (typeof(NSObject))]
	interface JitsiMeetLogger
	{
		// +(void)addHandler:(JitsiMeetBaseLogHandler *)handler;
		[Static]
		[Export ("addHandler:")]
		void AddHandler (JitsiMeetBaseLogHandler handler);

		// +(void)removeHandler:(JitsiMeetBaseLogHandler *)handler;
		[Static]
		[Export ("removeHandler:")]
		void RemoveHandler (JitsiMeetBaseLogHandler handler);
	}

	// @interface JitsiMeet : NSObject
	[BaseType (typeof(NSObject))]
	interface JitsiMeet
	{
		// @property (copy, nonatomic) NSString * _Nullable conferenceActivityType;
		[NullAllowed, Export ("conferenceActivityType")]
		string ConferenceActivityType { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable customUrlScheme;
		[NullAllowed, Export ("customUrlScheme")]
		string CustomUrlScheme { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nullable universalLinkDomains;
		[NullAllowed, Export ("universalLinkDomains", ArgumentSemantic.Copy)]
		string[] UniversalLinkDomains { get; set; }

		// @property (nonatomic) JitsiMeetConferenceOptions * _Nullable defaultConferenceOptions;
		[NullAllowed, Export ("defaultConferenceOptions", ArgumentSemantic.Assign)]
		JitsiMeetConferenceOptions DefaultConferenceOptions { get; set; }

		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		JitsiMeet SharedInstance ();

		// -(BOOL)application:(UIApplication * _Nonnull)application didFinishLaunchingWithOptions:(NSDictionary * _Nonnull)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool Application (UIApplication application, NSDictionary launchOptions);

		//TODO- resolve issues with UIUserActivityRestoring
		// -(BOOL)application:(UIApplication * _Nonnull)application continueUserActivity:(NSUserActivity * _Nonnull)userActivity restorationHandler:(void (^ _Nullable)(NSArray<id<UIUserActivityRestoring>> * _Nonnull))restorationHandler;
		//[Export ("application:continueUserActivity:restorationHandler:")]
		//bool Application (UIApplication application, NSUserActivity userActivity, [NullAllowed] Action<NSArray<UIUserActivityRestoring>> restorationHandler);

		// -(BOOL)application:(UIApplication * _Nonnull)app openURL:(NSURL * _Nonnull)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> * _Nonnull)options;
		[Export ("application:openURL:options:")]
		bool Application (UIApplication app, NSUrl url, NSDictionary<NSString, NSObject> options);

		// -(JitsiMeetConferenceOptions * _Nonnull)getInitialConferenceOptions;
		[Export ("getInitialConferenceOptions")]
		//[Verify (MethodToProperty)]
		JitsiMeetConferenceOptions InitialConferenceOptions { get; }
	}
	//// @protocol JMCallKitListener <NSObject>
	//[Protocol, Model]
	//[BaseType (typeof(NSObject))]
	//interface JMCallKitListener
	//{
	//	// @optional -(void)providerDidReset;
	//	[Export ("providerDidReset")]
	//	void ProviderDidReset ();

	//	// @optional -(void)performAnswerCallWithUUID:(NSUUID * _Nonnull)UUID;
	//	[Export ("performAnswerCallWithUUID:")]
	//	void PerformAnswerCallWithUUID (NSUuid UUID);

	//	// @optional -(void)performEndCallWithUUID:(NSUUID * _Nonnull)UUID;
	//	[Export ("performEndCallWithUUID:")]
	//	void PerformEndCallWithUUID (NSUuid UUID);

	//	// @optional -(void)performSetMutedCallWithUUID:(NSUUID * _Nonnull)UUID isMuted:(BOOL)isMuted;
	//	[Export ("performSetMutedCallWithUUID:isMuted:")]
	//	void PerformSetMutedCallWithUUID (NSUuid UUID, bool isMuted);

	//	// @optional -(void)performStartCallWithUUID:(NSUUID * _Nonnull)UUID isVideo:(BOOL)isVideo;
	//	[Export ("performStartCallWithUUID:isVideo:")]
	//	void PerformStartCallWithUUID (NSUuid UUID, bool isVideo);

	//	// @optional -(void)providerDidActivateAudioSessionWithSession:(AVAudioSession * _Nonnull)session;
	//	[Export ("providerDidActivateAudioSessionWithSession:")]
	//	void ProviderDidActivateAudioSessionWithSession (AVAudioSession session);

	//	// @optional -(void)providerDidDeactivateAudioSessionWithSession:(AVAudioSession * _Nonnull)session;
	//	[Export ("providerDidDeactivateAudioSessionWithSession:")]
	//	void ProviderDidDeactivateAudioSessionWithSession (AVAudioSession session);

	//	// @optional -(void)providerTimedOutPerformingActionWithAction:(CXAction * _Nonnull)action;
	//	[Export ("providerTimedOutPerformingActionWithAction:")]
	//	void ProviderTimedOutPerformingActionWithAction (CXAction action);
	//}

	//// @interface JMCallKitProxy : NSObject
	//[BaseType (typeof(NSObject))]
	//[DisableDefaultCtor]
	//interface JMCallKitProxy
	//{
	//	// @property (nonatomic, class) BOOL enabled;
	//	[Static]
	//	[Export ("enabled")]
	//	bool Enabled { get; set; }

	//	// +(void)configureProviderWithLocalizedName:(NSString * _Nonnull)localizedName ringtoneSound:(NSString * _Nullable)ringtoneSound iconTemplateImageData:(NSData * _Nullable)iconTemplateImageData;
	//	[Static]
	//	[Export ("configureProviderWithLocalizedName:ringtoneSound:iconTemplateImageData:")]
	//	void ConfigureProviderWithLocalizedName (string localizedName, [NullAllowed] string ringtoneSound, [NullAllowed] NSData iconTemplateImageData);

	//	// +(BOOL)isProviderConfigured __attribute__((warn_unused_result));
	//	[Static]
	//	[Export ("isProviderConfigured")]
	//	//[Verify (MethodToProperty)]
	//	bool IsProviderConfigured { get; }

	//	// +(void)addListener:(id<JMCallKitListener> _Nonnull)listener;
	//	[Static]
	//	[Export ("addListener:")]
	//	void AddListener (JMCallKitListener listener);

	//	// +(void)removeListener:(id<JMCallKitListener> _Nonnull)listener;
	//	[Static]
	//	[Export ("removeListener:")]
	//	void RemoveListener (JMCallKitListener listener);

	//	// +(BOOL)hasActiveCallForUUID:(NSString * _Nonnull)callUUID __attribute__((warn_unused_result));
	//	[Static]
	//	[Export ("hasActiveCallForUUID:")]
	//	bool HasActiveCallForUUID (string callUUID);

	//	// +(void)reportNewIncomingCallWithUUID:(NSUUID * _Nonnull)UUID handle:(NSString * _Nullable)handle displayName:(NSString * _Nullable)displayName hasVideo:(BOOL)hasVideo completion:(void (^ _Nonnull)(NSError * _Nullable))completion;
	//	[Static]
	//	[Export ("reportNewIncomingCallWithUUID:handle:displayName:hasVideo:completion:")]
	//	void ReportNewIncomingCallWithUUID (NSUuid UUID, [NullAllowed] string handle, [NullAllowed] string displayName, bool hasVideo, Action<NSError> completion);

	//	// +(void)reportCallUpdateWith:(NSUUID * _Nonnull)UUID handle:(NSString * _Nullable)handle displayName:(NSString * _Nullable)displayName hasVideo:(BOOL)hasVideo;
	//	[Static]
	//	[Export ("reportCallUpdateWith:handle:displayName:hasVideo:")]
	//	void ReportCallUpdateWith (NSUuid UUID, [NullAllowed] string handle, [NullAllowed] string displayName, bool hasVideo);

	//	// +(void)reportCallWith:(NSUUID * _Nonnull)UUID endedAt:(NSDate * _Nullable)dateEnded reason:(CXCallEndedReason)endedReason;
	//	[Static]
	//	[Export ("reportCallWith:endedAt:reason:")]
	//	void ReportCallWith (NSUuid UUID, [NullAllowed] NSDate dateEnded, CXCallEndedReason endedReason);

	//	// +(void)reportOutgoingCallWith:(NSUUID * _Nonnull)UUID startedConnectingAt:(NSDate * _Nullable)dateStartedConnecting;
	//	[Static]
	//	[Export ("reportOutgoingCallWith:startedConnectingAt:")]
	//	void ReportOutgoingCallWithStartedConnectingAt (NSUuid UUID, [NullAllowed] NSDate dateStartedConnecting);

	//	// +(void)reportOutgoingCallWith:(NSUUID * _Nonnull)UUID connectedAt:(NSDate * _Nullable)dateConnected;
	//	[Static]
	//	[Export ("reportOutgoingCallWithConnectedAt:connectedAt:")]
	//	void ReportOutgoingCallWith (NSUuid UUID, [NullAllowed] NSDate dateConnected);

	//	// +(void)request:(CXTransaction * _Nonnull)transaction completion:(void (^ _Nonnull)(NSError * _Nullable))completion;
	//	[Static]
	//	[Export ("request:completion:")]
	//	void Request (CXTransaction transaction, Action<NSError> completion);
	//}
}
