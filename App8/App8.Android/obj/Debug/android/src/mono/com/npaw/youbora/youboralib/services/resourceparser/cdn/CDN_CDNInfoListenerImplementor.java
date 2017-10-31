package mono.com.npaw.youbora.youboralib.services.resourceparser.cdn;


public class CDN_CDNInfoListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.npaw.youbora.youboralib.services.resourceparser.cdn.CDN.CDNInfoListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getCDNCode:(Ljava/util/Map;Ljava/lang/String;)Ljava/lang/String;:GetGetCDNCode_Ljava_util_Map_Ljava_lang_String_Handler:Com.Npaw.Youbora.Youboralib.Services.Resourceparser.Cdn.CDN/ICDNInfoListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Npaw.Youbora.Youboralib.Services.Resourceparser.Cdn.CDN+ICDNInfoListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CDN_CDNInfoListenerImplementor.class, __md_methods);
	}


	public CDN_CDNInfoListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CDN_CDNInfoListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Npaw.Youbora.Youboralib.Services.Resourceparser.Cdn.CDN+ICDNInfoListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public java.lang.String getCDNCode (java.util.Map p0, java.lang.String p1)
	{
		return n_getCDNCode (p0, p1);
	}

	private native java.lang.String n_getCDNCode (java.util.Map p0, java.lang.String p1);

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
