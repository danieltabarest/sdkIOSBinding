package mono.com.kaltura.playkit;


public class PKEvent_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kaltura.playkit.PKEvent.Listener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onEvent:(Lcom/kaltura/playkit/PKEvent;)V:GetOnEvent_Lcom_kaltura_playkit_PKEvent_Handler:Com.Kaltura.Playkit.IPKEventListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Kaltura.Playkit.IPKEventListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PKEvent_ListenerImplementor.class, __md_methods);
	}


	public PKEvent_ListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PKEvent_ListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kaltura.Playkit.IPKEventListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onEvent (com.kaltura.playkit.PKEvent p0)
	{
		n_onEvent (p0);
	}

	private native void n_onEvent (com.kaltura.playkit.PKEvent p0);

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
