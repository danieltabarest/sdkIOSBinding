package mono.com.kaltura.playkit;


public class LocalAssetsManager_AssetRemovalListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kaltura.playkit.LocalAssetsManager.AssetRemovalListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onRemoved:(Ljava/lang/String;)V:GetOnRemoved_Ljava_lang_String_Handler:Com.Kaltura.Playkit.LocalAssetsManager/IAssetRemovalListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Kaltura.Playkit.LocalAssetsManager+IAssetRemovalListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LocalAssetsManager_AssetRemovalListenerImplementor.class, __md_methods);
	}


	public LocalAssetsManager_AssetRemovalListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LocalAssetsManager_AssetRemovalListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kaltura.Playkit.LocalAssetsManager+IAssetRemovalListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onRemoved (java.lang.String p0)
	{
		n_onRemoved (p0);
	}

	private native void n_onRemoved (java.lang.String p0);

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
