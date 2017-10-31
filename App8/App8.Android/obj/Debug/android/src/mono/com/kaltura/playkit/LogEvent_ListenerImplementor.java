package mono.com.kaltura.playkit;


public class LogEvent_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kaltura.playkit.LogEvent.Listener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLogEvent:(Ljava/lang/String;)V:GetOnLogEvent_Ljava_lang_String_Handler:Com.Kaltura.Playkit.LogEvent/IListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Kaltura.Playkit.LogEvent+IListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LogEvent_ListenerImplementor.class, __md_methods);
	}


	public LogEvent_ListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LogEvent_ListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kaltura.Playkit.LogEvent+IListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onLogEvent (java.lang.String p0)
	{
		n_onLogEvent (p0);
	}

	private native void n_onLogEvent (java.lang.String p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
