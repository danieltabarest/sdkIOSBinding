using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using Android.Widget;
using Android.App;
using Com.Kaltura.Playkit;
using Com.Kaltura.Playkit.Api;
using Com.Kaltura.Playkit.Drm;
using Com.Kaltura.Playkit.Player;
using Com.Google.Android.Exoplayer.Audio;
using Com.Google.Android.Exoplayer;
using Com.Google.Android.Exoplayer.Text;
using Android.Views;
using Com.Kaltura.Playkit.Plugins.Ads;
using Com.Google.Android.Exoplayer.Util;
using Com.Google.Android.Exoplayer.Drm;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Android.Drm;
using System.Text;
using System.Runtime.Serialization;
using Com.Kaltura.Playkit.Plugins.Playback;
using Org.Json;
using Android.Content;

[assembly: Xamarin.Forms.ExportRenderer(typeof(App8.OpenTokView), typeof(App8.Droid.OpenTokViewRendererold))]
namespace App8.Droid
{
    public class OpenTokViewRendererold : Xamarin.Forms.Platform.Android.ViewRenderer, 
        Com.Kaltura.Playkit.Plugins.SamplePlugin.IFactory,
        Com.Kaltura.Playkit.IPKEvent,
        Com.Kaltura.Playkit.IPKEventListener,

        MvxVideoPlayer.IListener,
            MvxVideoPlayer.ICaptionListener,
            MvxVideoPlayer.ID3MetadataListener,
            AudioCapabilitiesReceiver.IListener

    {
        private PlayerView player;
        private PlayerState playerState;

        private Formatter formatter;
        private StringBuilder formatBuilder;
        private MvxVideoPlayer _player;
        private bool _playerNeedsPrepare;
        private SurfaceView _surfaceView;
        private long _playerPosition;
        private FrameLayout adPlayerContainer;
        private Activity _activity;
        private App8.OpenTokView _openTokView;
        private FrameLayout _mainFrameLayout = null;
        //private Session _session;
        private string adUrl2 = "http://dpndczlul8yjf.cloudfront.net/creatives/assets/79dba610-b5ee-448b-8e6b-531b3d3ebd54/5fe7eb54-0296-4688-af06-9526007054a4.mp4";
        //private string adkaltura = "https://www.kaltura.com/index.php/extwidget/preview/partner_id/2329001/uiconf_id/40636441/entry_id/1_y5jygqla/embed/auto?&flashvars[streamerType]=auto";
        protected Handler _handler = new Handler();
        private RelativeLayout _layout;
        protected Com.Google.Android.Exoplayer.IExoPlayer mediaPlayer;
        private String playerUrl = "http://player-as.ott.kaltura.com/225/v2.48.9_viacom_v0.31_v0.4.1_viacom_proxy_v0.4.12/mwEmbed//mwEmbedFrame.php"; // "http://player-as.ott.kaltura.com/225/v2.48.6_viacom_v0.31_v0.4.1_viacom_proxy_v0.4.7/mwEmbed/mwEmbedFrame.php"
        private Android.Views.View _placeholder = null;
        private Android.Views.View _mainVideoView = null;
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
            _activity = this.Context as Activity;
            //_openTokView = e.NewElement as OpenTokView;
            _mainFrameLayout = new FrameLayout(Context);
            _placeholder = new Android.Views.View(Context)
            {
                Background = new ColorDrawable(Xamarin.Forms.Color.Transparent.ToAndroid()),
                LayoutParameters = new LayoutParams(
                    ViewGroup.LayoutParams.MatchParent,
                    ViewGroup.LayoutParams.MatchParent),
            };
            var videoView = new VideoView(Context)
            {
                Background = new ColorDrawable(Xamarin.Forms.Color.Transparent.ToAndroid()),
                Visibility = ViewStates.Gone,
                LayoutParameters = new LayoutParams(
                        ViewGroup.LayoutParams.MatchParent,
                        ViewGroup.LayoutParams.MatchParent),
            };

            _mediaController = new MediaController(this.Context, true);
            adPlayerContainer = new FrameLayout(this.Context);

            _layout = new RelativeLayout(this.Context);
            _layout.SetMinimumHeight(Resources.DisplayMetrics.HeightPixels);

            //SetNativeControl(_layout);
            SessionConnect();

            _mainFrameLayout.AddView(_surfaceView);

            SetNativeControl(_mainFrameLayout);
        }


        private void SessionConnect()
        {
            try
            {

                getPlayer();
            }
            catch (Exception ec)
            {

            }

        }
        private MediaController _mediaController;
        //private KPPlayerConfig config = null;

        private MvxVideoPlayer.IRendererBuilder GetRendererBuilder()
        {
            var userAgent = ExoPlayerUtil.GetUserAgent(this.Context, "ExoPlayerDemo");
            //var url = adUrl2;
            var url = @"http://cdnapi.kaltura.com/p/2329001/sp/232900100/playManifest/entryId/1_y5jygqla/flavorId/1_6yn79qj9/format/url/protocol/http/a.mp4"; //config.VideoURL;
            var url2 = @"http://cdnapi.kaltura.com/p/831271/sp/83127100/playManifest/entryId/1_ng282arr/flavorId/1_ng282arr/format/url/protocol/http/a.mp4"; //config.VideoURL;
            var urlnova = @"http://cdnbakmi.kaltura.com/p/1971581/sp/197158100/playManifest/entryId/1_5fwa7f5d/flavorId/1_ss9ma9st/format/url/protocol/http/a.mp4";

            //return new DashRendererBuilder(this.Context, userAgent, url,
            //          new WidevineTestMediaDrmCallback(config.VideoURL));

            return new MvxExtractorRendererBuilder(this.Context, userAgent, Android.Net.Uri.Parse(urlnova));
            /* switch (Item.Type)
             {
                 case MvxVideoItem.ContentType.Hls:
                     Log.Debug(Tag, $"Trying to play as HLS video: {url}");
                     return new MvxHlsRendererBuilder(this.Context, userAgent, url);
                 case MvxVideoItem.ContentType.Other:return new MvxHlsRendererBuilder(this.Context, userAgent, url);
                     Log.Debug(Tag, $"Trying to play as non-HLS video: {url}");
                     return new MvxExtractorRendererBuilder(this, userAgent, Uri.Parse(url));
                 default:
                     throw new IllegalStateException("Unsupported type: " + Item.Type);
             }*/
        }
        private void configurePlugins(PKPluginConfigs config)
        {
              JSONObject jsonObject = new JSONObject();
              config.SetPluginConfig("Sample", jsonObject);
              addIMAPluginConfig(config);

        }

        private void addIMAPluginConfig(PKPluginConfigs config)
        {
            String adTagUrl = "https://pubads.g.doubleclick.net/gampad/ads?sz=640x480&iu=/124319096/external/ad_rule_samples&ciu_szs=300x250&ad_rule=1&impl=s&gdfp_req=1&env=vp&output=vmap&unviewed_position_start=1&cust_params=deployment%3Ddevsite%26sample_ar%3Dpremidpostoptimizedpodbumper&cmsid=496&vid=short_onecue&correlator=";
            //"https://pubads.g.doubleclick.net/gampad/ads?sz=640x480&iu=/124319096/external/single_ad_samples&ciu_szs=300x250&impl=s&gdfp_req=1&env=vp&output=vast&unviewed_position_start=1&cust_params=deployment%3Ddevsite%26sample_ct%3Dskippablelinear&correlator=";
            //"https://pubads.g.doubleclick.net/gampad/ads?sz=640x480&iu=/3274935/preroll&impl=s&gdfp_req=1&env=vp&output=xml_vast2&unviewed_position_start=1&url=[referrer_url]&description_url=[description_url]&correlator=[timestamp]";
            //"https://pubads.g.doubleclick.net/gampad/ads?sz=640x480&iu=/124319096/external/ad_rule_samples&ciu_szs=300x250&ad_rule=1&impl=s&gdfp_req=1&env=vp&output=vmap&unviewed_position_start=1&cust_params=deployment%3Ddevsite%26sample_ar%3Dpremidpostpod&cmsid=496&vid=short_onecue&correlator=";
            List<String> videoMimeTypes = new List<string>();
            //videoMimeTypes.add(MimeTypes.APPLICATION_MP4);
            //videoMimeTypes.add(MimeTypes.APPLICATION_M3U8);
            //Map<Double, String> tagTimesMap = new HashMap<>();
            //tagTimesMap.put(2.0,"ADTAG");

            /*IMAConfig adsConfig = new IMAConfig().setAdTagURL(adTagUrl);
            config.setPluginConfig(IMAPlugin.factory.getName(), adsConfig.toJSONObject());*/

        }

        private void startSimpleOvpMediaLoading()
        {
            
            /*
            new KalturaOvpMediaProvider()
                    .setSessionProvider(new SimpleOvpSessionProvider("https://cdnapisec.kaltura.com", 2222401, null))
                    .setEntryId("1_f93tepsn")
                    .load(completion);*/
        }

        private void getPlayer()
        {

            try
            {
                PKMediaConfig mediaConfig = new PKMediaConfig();

                
                var value= new PKMediaSource().SetUrl(@"https://pubads.g.doubleclick.net/gampad/ads?sz=640x480&iu=/124319096/external/ad_rule_samples&ciu_szs=300x250&ad_rule=1&impl=s&gdfp_req=1&env=vp&output=vmap&unviewed_position_start=1&cust_params=deployment%3Ddevsite%26sample_ar%3Dpremidpostoptimizedpodbumper&cmsid=496&vid=short_onecue&correlator=").SetId("preroll-ad-1");
                var list = new List<PKMediaSource>();
                list.Add(value);
                var s = new PKMediaEntry().SetSources(list);
                mediaConfig.SetMediaEntry(s);

                var playercontroller = new Com.Kaltura.Playkit.Player.PlayerController(this.Context);
                var PKPluginConfigs = new PKPluginConfigs();


                _surfaceView = new SurfaceView(this.Context);
                _surfaceView.SetMinimumHeight(Resources.DisplayMetrics.HeightPixels);

                configurePlugins(PKPluginConfigs);

                var mplayer = PlayKitManager.LoadPlayer(this.Context, PKPluginConfigs);
                //KalturaPlaybackRequestAdapter.Install(mplayer, "myApp");
                // in case app developer wants to give customized referrer instead the default referrer in the playmanifest
                mplayer.Prepare(mediaConfig);

                mplayer.Play();
                //_layout.AddView(mplayer.View);
            }
            catch (Exception ex)
            {
                throw;
            }
            #region old
            //player = new PlayerView(_activity)
            //if (Player == null)
            //{

            //if (config == null)
            //{
            //    config = getConfig("1_y5jygqla");
            //}

            //config = new KPPlayerConfig("http://cdnapi.kaltura.com", "26698911", "1831271").SetEntryId("1_o426d3i4");
            //config = new KPPlayerConfig("http://kgit.html5video.org/tags/v2.49/mwEmbedFrame.php", "31638861", "1831271").SetEntryId("1_ng282arr");
            //config = new KPPlayerConfig("cdnapi.kaltura.com", "31638861", "1831271").SetEntryId("1_ng282arr");
            //config.AddConfig("closedCaptions.plugin", "true");
            //config.AddConfig("sourceSelector.plugin", "true");
            //config.AddConfig("sourceSelector.displayMode", "bitrate");
            //config.AddConfig("audioSelector.plugin", "true");
            //config.AddConfig("closedCaptions.showEmbeddedCaptions", "true");


            /* config = new KPPlayerConfig("http://cdnapi.kaltura.com", "40636441", "2329001").SetEntryId("1_y5jygqla");
             config.AutoPlay = true;
             config.AddConfig("autoPlay", "true");
             config.AddConfig("tag", "kpplayerconfig");
             config.AddConfig("debugKalturaPlayer", "true");
             config.AddConfig("topBarContainer.hover", "true");
             config.AddConfig("controlBarContainer.hover", "true");
             config.AddConfig("controlBarContainer.plugin", "true");
             config.AddConfig("topBarContainer.plugin", "true");
             config.AddConfig("largePlayBtn.plugin", "true");

             String adTagUrl = "http://pubads.g.doubleclick.net/gampad/ads?sz=640x480&iu=%2F3510761%2FadRulesSampleTags&ciu_szs=160x600%2C300x250%2C728x90&cust_params=adrule%3Dpremidpostwithpod&impl=s&gdfp_req=1&env=vp&ad_rule=1&vid=12345&cmsid=3601&output=xml_vast2&unviewed_position_start=1&url=[referrer_url]&correlator=[timestamp]";
             config.AddConfig("doubleClick.adTagUrl", adTagUrl);
             config.AddConfig("doubleClick.plugin", "true");

             */


            /*if (_player == null)
                {
                    _player = new MvxVideoPlayer(GetRendererBuilder());
                    _player.AddListener(this);
                    _player.SetCaptionListener(this);
                    _player.SetMetadataListener(this);
                    _player.SeekTo(_playerPosition);
                    _playerNeedsPrepare = true;
                    _mediaController.SetMediaPlayer(_player.PlayerControl);
                    _mediaController.Enabled = true;
                }
                if (_playerNeedsPrepare)
                {
                    _player.Prepare();
                    _playerNeedsPrepare = false;
                }

                _surfaceView = new SurfaceView(this.Context);
                _surfaceView.SetMinimumHeight(Resources.DisplayMetrics.HeightPixels);

                _player.Surface = _surfaceView.Holder.Surface;

                RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(320, 240);
                layoutParams.AddRule(LayoutRules.AlignParentBottom, (int)LayoutRules.True);
                layoutParams.AddRule(LayoutRules.AlignParentRight, (int)LayoutRules.True);
                //_layout.AddView(_player.Surface.Show, layoutParams);
                
                //_player.doa();

                try
                {
                    _mediaController.Show(0);
                }
                catch (Exception ex)
                {
                    // This try-catch seems nasty, but is necessary, since MediaController doesn't null-check before calling CanPause() on a private field.
                    // That can lead to a crash if events come too early.
                    //MvxTrace.Warning($"ShowControls was ignored. MediaController threw NullPointerException: {ex.Message}.");
                }
                /*
                _mediaController.SetMediaPlayer*/
            //_audioCapabilitiesReceiver = new AudioCapabilitiesReceiver(this.Context, this)
            //  _audioCapabilitiesReceiver.Register(); ;
            //_mediaController.SetAnchorView(root);

            //var layer = new KControlsView(this.Context);
            //Com.Kaltura.Playersdk.Drm.DeviceUuidFactory deviceuuidfactory = new Com.Kaltura.Playersdk.Drm.DeviceUuidFactory(this.Context);
            //var resutl= Com.Kaltura.Playersdk.Drm.WidevineDrmClient.IsSupported(this.Context);
            //var resutls = Com.Kaltura.Playersdk.Players.KMediaFormat.WvmWidevine;

            //try
            //{
            //    mPlayer = new KWVCPlayer(_activity);

            //}
            //catch (Exception ex)
            //{

            //}
            //if (resutl == true)
            //{
            //    mPlayer = new KWVCPlayer(this.Context);
            //}
            //_player.PlayWhenReady = true;

            //mPlayer.SetPrepareWithConfigurationMode();
            // mPlayer.AttachSurfaceViewToPlayer();
            //mPlayer.Play();


            //if (adList.size() > 0)
            //{
            //    Boolean prepareWithConfigurationMode = true; // false to load surface automatically
            //    //mPlayer.SetPrepareWithConfigurationModeOff(prepareWithConfigurationMode);
            //mPlayer.initWithConfiguration(config);
            //mPlayer.addEventListener(this);

            //RelativeLayout.LayoutParams layoutParams = new RelativeLayout.LayoutParams(Resources.DisplayMetrics.WidthPixels, Resources.DisplayMetrics.HeightPixels);
            //_layout.AddView(_subscriber.View, layoutParams);

            //}

            //return mPlayer;*/
        }


        /*  public KPPlayerConfig getConfig(String mediaID)
          {
              //KPPlayerConfig config = new KPPlayerConfig(playerUrl, "32626752", "");
              KPPlayerConfig config = new KPPlayerConfig(playerUrl, "40636441", "2329001");
              config.SetEntryId(mediaID);
              config.AddConfig("topBarContainer.hover", "true");
              config.AddConfig("autoPlay", "true");
              config.AddConfig("controlBarContainer.plugin", "true");
              config.AddConfig("durationLabel.prefix", " ");
              config.AddConfig("largePlayBtn.plugin", "true");
              //config.addConfig("mediaProxy.mediaPlayFrom", String.valueOf("100"));
              config.AddConfig("scrubber.sliderPreview", "false");
              //config.addConfig("largePlayBtn","false");
              //config.addConfig("debugKalturaPlayer", "true");
              config.AddConfig("EmbedPlayer.HidePosterOnStart", "true");
              config.AddConfig("watermark.plugin", "true");
              config.AddConfig("watermark.img", "https://voot-kaltura.s3.amazonaws.com/voot-watermark.png");
              config.AddConfig("watermark.title", "Viacom18");
              config.AddConfig("watermark.cssClass", "topRight");
              config.AddConfig("controlBarContainer.hover", "true");
              config.AddConfig("controlBarContainer.plugin", "true");
              config.AddConfig("kidsPlayer.plugin", "true,");
              config.AddConfig("nextBtnComponent.plugin", "true");
              config.AddConfig("prevBtnComponent.plugin", "true");
              config.AddConfig("liveCore.disableLiveCheck", "true");
              //        config.addConfig("tvpapiGetLicensedLinks.plugin", "true");
              config.AddConfig("TVPAPIBaseUrl", "http://tvpapi-as.ott.kaltura.com/v3_4/gateways/jsonpostgw.aspx?m=");
              config.AddProxyData(KProxyData.NewBuilder().SetMediaId(mediaID)
                      .SetIMediaId(mediaID)
                      .SetMediaType("0")
                      .SetPicSize(640, 360)
                      .SetWithDynamic(false)
                      .SetDomainId(0)
                      .SetUserProtection("tvpapi_225", "11111", "aa5e1b6c96988d68")
                      .SetSiteGuid("")
                      .SetPlatform("Cellular")
                      .SetLocale("", "", "Unknown", "")
                      .AddProxyConfigFilter("dash Main")
                      .Build());
              return config;
          }*/
        #endregion

        public void OpenURL(string p0)
        {
        }

        public void SwitchToLive()
        {
        }

        public void OnStateChanged(bool playWhenReady, int playbackState)
        {
            if (playbackState != Com.Google.Android.Exoplayer.ExoPlayer.StateEnded)
            {
                return;
            }

            if (ShallFinishActivityOnPlaybackStateEnd())
            {
                // Finish();
            }
            else
            {
                ShowControls();
            }
        }
        /// <summary>
        /// Determines, wether this Activity will be finished when playback has sucessfully ended.
        /// If true, Activity will be finished on playback end.
        /// If false, the controls will be shown.
        /// </summary>
        protected virtual bool ShallFinishActivityOnPlaybackStateEnd()
        {
            return false;
        }
        private void ShowControls()
        {
            try
            {
                _mediaController.Show(0);
            }
            catch (Exception ex)
            {
                // This try-catch seems nasty, but is necessary, since MediaController doesn't null-check before calling CanPause() on a private field.
                // That can lead to a crash if events come too early.
                //MvxTrace.Warning($"ShowControls was ignored. MediaController threw NullPointerException: {ex.Message}.");
            }
        }

        public void OnError(Java.Lang.Exception e)
        {
            var exception = e as UnsupportedDrmException;
            if (exception != null)
            {
                // TODO
                // Special case DRM failures.
                var msg = ExoPlayerUtil.SdkInt < 18
                    ? "drm_error_not_supported"
                    : exception.Reason == UnsupportedDrmException.ReasonUnsupportedScheme
                        ? "drm_error_unsupported_scheme"
                        : "drm_error_unknown";
                //Toast.MakeText(ApplicationContext, msg, ToastLength.Long).Show();
            }
            _playerNeedsPrepare = true;
            ShowControls();
        }
        private View _shutterView;

        public string Name => throw new NotImplementedException();

        public void OnVideoSizeChanged(int width, int height, int unappliedRotationDegrees, float pixelWidthHeightRatio)
        {
            //_shutterView.Visibility = ViewStates.Gone;
            //_videoFrame.SetAspectRatio(height == 0 ? 1 : (width * pixelWidthAspectRatio) / height);
        }

        public void OnCues(IList<Cue> cues)
        {
            throw new NotImplementedException();
        }

        public void OnId3Metadata(object metadata)
        {
            throw new NotImplementedException();
        }

        public void OnAudioCapabilitiesChanged(AudioCapabilities p0)
        {
            throw new NotImplementedException();
        }

        public void HandleHtml5LibCall(string p0, int p1, string p2)
        {
            throw new NotImplementedException();
        }


        public void PlayerStateChanged(int p0)
        {
            throw new NotImplementedException();
        }

        public void OnError(DrmErrorEvent p0)
        {
            throw new NotImplementedException();
        }

        public void OnEvent(DrmEvent p0)
        {
            throw new NotImplementedException();
        }

        public PKPlugin NewInstance()
        {
            throw new NotImplementedException();
        }

        public void WarmUp(Context p0)
        {
            throw new NotImplementedException();
        }

        public Java.Lang.Enum EventType()
        {
            throw new NotImplementedException();
        }

        public void OnEvent(IPKEvent p0)
        {
            throw new NotImplementedException();
        }
    }


}



