# JitsiMeet.Xamarin.IOS
A xamarin ios wrapper library of JitsiMeetIOS SDK

Reference the entire JitsiMeetXamarin Binding Library Project in your Xamarin IOS app or build the JitsiMeetXamarin project (-configuration: release )
and add the dll as a .Net Library in your Xamarin IOS app

The sample project is a simple Xamarin IOS single page app. I referenced the dll gotten from the build outupt of the JitsMeetXamarin  (Binding Library)
A JitsMeetView is created in the ViewController class and added to the view hierrachy. Remember to add the JitsiXamarinBinding namespace.
All classes binding interfaces are in the JitsiXamarinBinding namespace 

Remeber to follow all prerequisites per the JitsiMeetIOS SDK documentation --https://github.com/jitsi/jitsi-meet/blob/master/ios/README.md
e.g. disable bitcode, add microphone and camera permissions etc.

