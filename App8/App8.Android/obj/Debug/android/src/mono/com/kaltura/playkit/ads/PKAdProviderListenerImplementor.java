package mono.com.kaltura.playkit.ads;


public class PKAdProviderListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kaltura.playkit.ads.PKAdProviderListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onAdLoadingFinished:()V:GetOnAdLoadingFinishedHandler:Com.Kaltura.Playkit.Ads.IPKAdProviderListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Kaltura.Playkit.Ads.IPKAdProviderListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PKAdProviderListenerImplementor.class, __md_methods);
	}


	public PKAdProviderListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PKAdProviderListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kaltura.Playkit.Ads.IPKAdProviderListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onAdLoadingFinished ()
	{
		n_onAdLoadingFinished ();
	}

	private native void n_onAdLoadingFinished ();

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
