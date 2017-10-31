package mono.com.kaltura.playkit;


public class LocalAssetsManager_AssetRegistrationListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kaltura.playkit.LocalAssetsManager.AssetRegistrationListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFailed:(Ljava/lang/String;Ljava/lang/Exception;)V:GetOnFailed_Ljava_lang_String_Ljava_lang_Exception_Handler:Com.Kaltura.Playkit.LocalAssetsManager/IAssetRegistrationListenerInvoker, BindingJar\n" +
			"n_onRegistered:(Ljava/lang/String;)V:GetOnRegistered_Ljava_lang_String_Handler:Com.Kaltura.Playkit.LocalAssetsManager/IAssetRegistrationListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Kaltura.Playkit.LocalAssetsManager+IAssetRegistrationListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LocalAssetsManager_AssetRegistrationListenerImplementor.class, __md_methods);
	}


	public LocalAssetsManager_AssetRegistrationListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LocalAssetsManager_AssetRegistrationListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kaltura.Playkit.LocalAssetsManager+IAssetRegistrationListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onFailed (java.lang.String p0, java.lang.Exception p1)
	{
		n_onFailed (p0, p1);
	}

	private native void n_onFailed (java.lang.String p0, java.lang.Exception p1);


	public void onRegistered (java.lang.String p0)
	{
		n_onRegistered (p0);
	}

	private native void n_onRegistered (java.lang.String p0);

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
