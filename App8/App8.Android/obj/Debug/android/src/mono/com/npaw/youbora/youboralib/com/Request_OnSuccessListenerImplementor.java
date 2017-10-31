package mono.com.npaw.youbora.youboralib.com;


public class Request_OnSuccessListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.npaw.youbora.youboralib.com.Request.OnSuccessListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSuccess:(Ljava/lang/String;Ljava/net/HttpURLConnection;)V:GetOnSuccess_Ljava_lang_String_Ljava_net_HttpURLConnection_Handler:Com.Npaw.Youbora.Youboralib.Com.Request/IOnSuccessListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Npaw.Youbora.Youboralib.Com.Request+IOnSuccessListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Request_OnSuccessListenerImplementor.class, __md_methods);
	}


	public Request_OnSuccessListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Request_OnSuccessListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Npaw.Youbora.Youboralib.Com.Request+IOnSuccessListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onSuccess (java.lang.String p0, java.net.HttpURLConnection p1)
	{
		n_onSuccess (p0, p1);
	}

	private native void n_onSuccess (java.lang.String p0, java.net.HttpURLConnection p1);

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
