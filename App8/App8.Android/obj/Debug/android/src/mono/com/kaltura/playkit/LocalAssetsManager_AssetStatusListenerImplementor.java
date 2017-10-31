package mono.com.kaltura.playkit;


public class LocalAssetsManager_AssetStatusListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kaltura.playkit.LocalAssetsManager.AssetStatusListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStatus:(Ljava/lang/String;JJZ)V:GetOnStatus_Ljava_lang_String_JJZHandler:Com.Kaltura.Playkit.LocalAssetsManager/IAssetStatusListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Kaltura.Playkit.LocalAssetsManager+IAssetStatusListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LocalAssetsManager_AssetStatusListenerImplementor.class, __md_methods);
	}


	public LocalAssetsManager_AssetStatusListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LocalAssetsManager_AssetStatusListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kaltura.Playkit.LocalAssetsManager+IAssetStatusListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onStatus (java.lang.String p0, long p1, long p2, boolean p3)
	{
		n_onStatus (p0, p1, p2, p3);
	}

	private native void n_onStatus (java.lang.String p0, long p1, long p2, boolean p3);

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
