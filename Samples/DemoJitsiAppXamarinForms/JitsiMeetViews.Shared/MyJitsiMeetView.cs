using JitsiXamarinBinding;
using System;
using System.Collections.Generic;
using System.Text;

namespace JitsiMeetViews.Shared
{
    public class MyJitsiMeetView: JitsiMeetView
    {

    }
    public class JitsiMeetViewPage : JitsiMeetView
    {
        JitsiMeetConferenceOptions _viewOptions;
        Action<JitsiMeetConferenceOptionsBuilder> _builder;
        public JitsiMeetViewPage(Action<JitsiMeetConferenceOptionsBuilder> builder)
        {
            _builder = builder;
        }
        public JitsiMeetConferenceOptions ViewOptions
        {
            get
            {
                if (_viewOptions == null)
                {
                    _viewOptions = JitsiMeetConferenceOptions.FromBuilder(_builder);
                }
                return _viewOptions;

            }
        }

        public void Join()
        {
            Join(ViewOptions);
        }
    }
}
