using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using JitsiXamarinBinding;
using UIKit;

namespace DemoJitsiAppXamarinForms.iOS
{
    public class JitsiMeetViewPage : JitsiMeetView
    {

        public static CGRect MyFrame => UIScreen.MainScreen.Bounds;
        public JitsiMeetViewPage() : base()
        {
            Join(JitsiMeetConferenceOptions.FromBuilder(builder =>
            {
                builder.ServerURL = new NSUrl("meet.jit.si");
                builder.Room = "testRom";
                builder.WelcomePageEnabled = true;               
            }));
            Delegate = new MeetingDelegate();
        }
    }

    public class MeetingDelegate : JitsiMeetViewDelegate
    {
        [Export("conferenceTerminated:")]
        public override void ConferenceTerminated(NSDictionary data)
        {
            // Do something
        }
    }
}