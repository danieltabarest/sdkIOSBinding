package mono.com.kaltura.playkit.drm;


public class WidevineClassicDrm_EventListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kaltura.playkit.drm.WidevineClassicDrm.EventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onError:(Landroid/drm/DrmErrorEvent;)V:GetOnError_Landroid_drm_DrmErrorEvent_Handler:Com.Kaltura.Playkit.Drm.WidevineClassicDrm/IEventListenerInvoker, BindingJar\n" +
			"n_onEvent:(Landroid/drm/DrmEvent;)V:GetOnEvent_Landroid_drm_DrmEvent_Handler:Com.Kaltura.Playkit.Drm.WidevineClassicDrm/IEventListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Kaltura.Playkit.Drm.WidevineClassicDrm+IEventListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", WidevineClassicDrm_EventListenerImplementor.class, __md_methods);
	}


	public WidevineClassicDrm_EventListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == WidevineClassicDrm_EventListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kaltura.Playkit.Drm.WidevineClassicDrm+IEventListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onError (android.drm.DrmErrorEvent p0)
	{
		n_onError (p0);
	}

	private native void n_onError (android.drm.DrmErrorEvent p0);


	public void onEvent (android.drm.DrmEvent p0)
	{
		n_onEvent (p0);
	}

	private native void n_onEvent (android.drm.DrmEvent p0);

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
