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
using Android.Views;
using Com.Kaltura.Playkit.Plugins.Ads;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using Android.Drm;
using GoogleGson;
using System.Text;
using System.Runtime.Serialization;
using Com.Kaltura.Playkit.Plugins.Playback;
using Org.Json;
using Android.Content;
using Com.Kaltura.Playkit.Plugins;
//using Com.Google.Android.Exoplayer2.Audio;
//using Com.Google.Android.Exoplayer2;
//using Com.Google.Android.Exoplayer2.Text;

[assembly: Xamarin.Forms.ExportRenderer(typeof(App8.OpenTokView), typeof(App8.Droid.OpenTokViewRenderer))]
namespace App8.Droid
{
    public class OpenTokViewRenderer : Xamarin.Forms.Platform.Android.ViewRenderer
    {
        //The url of the source to play
        //private static String SOURCE_URL = "https://cdnapisec.kaltura.com/p/2215841/sp/221584100/playManifest/entryId/1_w9zx2eti/protocol/https/format/applehttp/falvorIds/1_1obpcggb,1_yyuvftfz,1_1xdbzoa6,1_k16ccgto,1_djdf6bk8/a.m3u8";
        private static String SOURCE_URL = "http://cdnsecakmi.kaltura.com/s/p/243342/sp/24334200/serveFlavor/entryId/1_sf5ovm7u/v/1/pv/2/flavorId/1_jl7y56al/forceproxy/true/name/a.mp4?aeauth=1509053566_52ed19cb3753e19770adbe8865ef9efb";
        Com.Kaltura.Playkit.IPlayer player;
        private static String ENTRY_ID = "1_sf5ovm7u";
        private static String MEDIA_SOURCE_ID = "source_id";

        //private Com.Kaltura.Playkit.Player player;
        private PKMediaConfig mediaConfig;
        private Button playPauseButton;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            try
            {
                //Initialize media config object.
                createMediaConfig();

                //Create plugin configurations.
                PKPluginConfigs pluginConfigs = createPluginConfigs();

                //Create instance of the player with plugin configurations.
                player = PlayKitManager.LoadPlayer(this.Context, pluginConfigs);

                //Add player to the view hierarchy.
                addPlayerToView();

                //Add simple play/pause button.
                addPlayPauseButton();

                //Prepare player with media configuration.
                player.Prepare(mediaConfig);

                player.Play();
            }
            catch (Exception EX)
            {

            }
        }


        /**
         * Will create {@link PKMediaConfig} object.
         */
        private void createMediaConfig()
        {
            //First. Create PKMediaConfig object.
            mediaConfig = new PKMediaConfig();

            //Second. Create PKMediaEntry object.
            PKMediaEntry mediaEntry = createMediaEntry();

            //Add it to the mediaConfig.
            mediaConfig.SetMediaEntry(mediaEntry);
        }

        private PKPluginConfigs createPluginConfigs()
        {
            try
            {
                //First register your SamplePlugin.
                PlayKitManager.RegisterPlugins(this.Context, SamplePlugin.Factory);

                //Initialize plugin configuration object.
                PKPluginConfigs pluginConfigs = new PKPluginConfigs();

                //Initialize jsonObject which will hold custom parameters for plugin.

                JsonObject jsonObject = new JsonObject();
                //Add custom values.
                Java.Lang.Number s = (Java.Lang.Number)2000;
                Java.Lang.Boolean t = (Java.Lang.Boolean)true;
                jsonObject.AddProperty("delay", s);
                //jsonObject.AddProperty("value2",t);

                //Set jsonObject to the main pluginConfigs object.
                pluginConfigs.SetPluginConfig(SamplePlugin.Factory.Name, jsonObject);

                //Return created and populated object.
                return pluginConfigs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /**
         * Create {@link PKMediaEntry} with minimum necessary data.
         *
         * @return - the {@link PKMediaEntry} object.
         */
        private PKMediaEntry createMediaEntry()
        {
            //Create media entry.
            PKMediaEntry mediaEntry = new PKMediaEntry();

            //Set id for the entry.
            mediaEntry.SetId(ENTRY_ID);

            //Set media entry type. It could be Live,Vod or Unknown.
            //For now we will use Unknown.
            mediaEntry.SetMediaType(PKMediaEntry.MediaEntryType.Unknown);

            //Create list that contains at least 1 media source.
            //Each media entry can contain a couple of different media sources.
            //All of them represent the same content, the difference is in it format.
            //For example same entry can contain PKMediaSource with dash and another
            // PKMediaSource can be with hls. The player will decide by itself which source is
            // preferred for playback.
            List<PKMediaSource> mediaSources = createMediaSources();

            //Set media sources to the entry.
            mediaEntry.SetSources(mediaSources);

            return mediaEntry;
        }

        /**
         * Create list of {@link PKMediaSource}.
         *
         * @return - the list of sources.
         */
        private List<PKMediaSource> createMediaSources()
        {
            //Init list which will hold the PKMediaSources.
            List<PKMediaSource> mediaSources = new List<PKMediaSource>();

            //Create new PKMediaSource instance.
            PKMediaSource mediaSource = new PKMediaSource();

            //Set the id.
            mediaSource.SetId(MEDIA_SOURCE_ID);

            //Set the content url. In our case it will be link to hls source(.m3u8).
            mediaSource.SetUrl(SOURCE_URL);

            //Set the format of the source. In our case it will be hls.
            mediaSource.SetMediaFormat(PKMediaFormat.Hls);

            //Add media source to the list.
            mediaSources.Add(mediaSource);

            return mediaSources;
        }

        /**
         * Will add player to the view.
         */
        private void addPlayerToView()
        {
            //Get the layout, where the player view will be placed.}
            //_mainFrameLayout = new FrameLayout(Context);
            FrameLayout layout = new FrameLayout(Context);
            //Add player view to the layout.
            layout.AddView(player.View);
            SetNativeControl(layout);
        }

        /**
         * Just add a simple button which will start/pause playback.
         */
        private void addPlayPauseButton()
        {
            //Get reference to the play/pause button.
            /* playPauseButton = (Button)this.findViewById(R.id.play_pause_button);
             //Add clickListener.
             playPauseButton.setOnClickListener(new View.OnClickListener() {
             @Override
             public void onClick(View v)
             {
                 if (player.isPlaying())
                 {
                     //If player is playing, change text of the button and pause.
                     playPauseButton.setText(R.string.play_text);
                     player.pause();
                 }
                 else
                 {
                     //If player is not playing, change text of the button and play.
                     playPauseButton.setText(R.string.pause_text);
                     player.play();
                 }
             }*/
        }
    }

}



