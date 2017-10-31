package mono.com.npaw.youbora.youboralib.utils;


public class Timer_TimerEventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.npaw.youbora.youboralib.utils.Timer.TimerEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTimerEvent:(J)V:GetOnTimerEvent_JHandler:Com.Npaw.Youbora.Youboralib.Utils.Timer/ITimerEventListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Npaw.Youbora.Youboralib.Utils.Timer+ITimerEventListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Timer_TimerEventListenerImplementor.class, __md_methods);
	}


	public Timer_TimerEventListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Timer_TimerEventListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Npaw.Youbora.Youboralib.Utils.Timer+ITimerEventListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onTimerEvent (long p0)
	{
		n_onTimerEvent (p0);
	}

	private native void n_onTimerEvent (long p0);

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
