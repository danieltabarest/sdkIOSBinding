package mono.com.kaltura.playkit;


public class PlayerEvent_ListenerImplementor
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.kaltura.playkit.PlayerEvent.Listener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPlayerEvent:(Lcom/kaltura/playkit/Player;Lcom/kaltura/playkit/PlayerEvent$Type;)V:GetOnPlayerEvent_Lcom_kaltura_playkit_Player_Lcom_kaltura_playkit_PlayerEvent_Type_Handler:Com.Kaltura.Playkit.PlayerEvent/IListenerInvoker, BindingJar\n" +
			"";
		mono.android.Runtime.register ("Com.Kaltura.Playkit.PlayerEvent+IListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PlayerEvent_ListenerImplementor.class, __md_methods);
	}


	public PlayerEvent_ListenerImplementor () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PlayerEvent_ListenerImplementor.class)
			mono.android.TypeManager.Activate ("Com.Kaltura.Playkit.PlayerEvent+IListenerImplementor, BindingJar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onPlayerEvent (com.kaltura.playkit.Player p0, com.kaltura.playkit.PlayerEvent.Type p1)
	{
		n_onPlayerEvent (p0, p1);
	}

	private native void n_onPlayerEvent (com.kaltura.playkit.Player p0, com.kaltura.playkit.PlayerEvent.Type p1);

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
