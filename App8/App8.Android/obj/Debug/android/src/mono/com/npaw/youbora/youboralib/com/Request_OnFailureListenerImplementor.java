package mono.com.npaw.youbora.youboralib.com;


public class Request_OnFailureListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.npaw.youbora.youboralib.com.Request.OnFailureListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailure:(Ljava/net/HttpURLConnection;)V:GetOnFailure_Ljava_net_HttpURLConnection_Handler:Com.Npaw.Youbora.Youboralib.Com.Request/IOnFailureListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Npaw.Youbora.Youboralib.Com.Request+IOnFailureListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Request_OnFailureListenerImplementor.class, __md_methods);
	}


	public Request_OnFailureListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Request_OnFailureListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Npaw.Youbora.Youboralib.Com.Request+IOnFailureListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFailure (java.net.HttpURLConnection p0)
	{
		n_onFailure (p0);
	}

	private native void n_onFailure (java.net.HttpURLConnection p0);

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
