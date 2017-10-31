package mono.com.npaw.youbora.youboralib.com;


public class Communication_ExtraOperationsListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.npaw.youbora.youboralib.com.Communication.ExtraOperationsListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onExtraOperations:(Ljava/util/Map;)V:GetOnExtraOperations_Ljava_util_Map_Handler:Com.Npaw.Youbora.Youboralib.Com.Communication/IExtraOperationsListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Npaw.Youbora.Youboralib.Com.Communication+IExtraOperationsListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Communication_ExtraOperationsListenerImplementor.class, __md_methods);
	}


	public Communication_ExtraOperationsListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Communication_ExtraOperationsListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Npaw.Youbora.Youboralib.Com.Communication+IExtraOperationsListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onExtraOperations (java.util.Map p0)
	{
		n_onExtraOperations (p0);
	}

	private native void n_onExtraOperations (java.util.Map p0);

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
