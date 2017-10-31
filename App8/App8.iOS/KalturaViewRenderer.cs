using System;
using System.Drawing;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;
using CoreGraphics;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Net;
using LibKalturaSDK;
using ObjCRuntime;
using iAd;
using App8.iOS;
using KalturaSDK;
using SharpieSDK;
//using SharpieSDK;


[assembly: Xamarin.Forms.ExportRenderer(typeof(App8.OpenTokView), typeof(App8.iOS.OpenTokViewRenderer))]
namespace App8.iOS
{
    public class OpenTokViewRenderer : Xamarin.Forms.Platform.iOS.ViewRenderer
    {
        //OTSession _session;
        PlayerDelegate _PlayerDelegate;

        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            var width = (float)UIScreen.MainScreen.Bounds.Size.Width;
            var height = (float)UIScreen.MainScreen.Bounds.Size.Height - 20;
            var view = new UIView(new RectangleF(0, 0, width, height));
            this.SetNativeControl(view);
            DoPublish();
            //DoConnect();
        }



        private const int PARTNER_ID = 2329001; //enter your partner id
        private const string ADMIN_SECRET = "9f8eb696e3957ec81e8a2ac8ec6eed00"; //enter your admin secret
        private const string SERVICE_URL = "http://www.kaltura.com/";
        private const string USER_ID = "testUser";
        private const int BLOCK_SIZE = 16;
        private const string FIELD_EXPIRY = "_e";
        private const string FIELD_USER = "_u";
        private const string FIELD_TYPE = "_t";
        private const int RANDOM_SIZE = 16;

        //protected KalturaClient client;
        //protected KalturaClientConfiguration clientConfiguration = new KalturaClientConfiguration();
        //protected KalturaRequestConfiguration requestConfiguration = new KalturaRequestConfiguration();
        private static int code = 0;
        protected string id;

        public KPController _player;
        public void DoPublish()
        {
            try
            {


                

            // for hls stream use: "https://clips.vorwaerts-gmbh.de/big_buck_bunny.mp4"
            //var url = URL(fileURLWithPath: Bundle(for: type(of: self)).path(forResource: "big_buck_bunny_short", ofType: "mp4")!)
                string url = "http://cdnsecakmi.kaltura.com/s/p/1296091/sp/129609100/serveFlavor/entryId/1_4e1pfi47/v/11/flavorId/1_wsalqgxi/forceproxy/true/name/a.mp4?aeauth=1507329152_05539ac3997aee00f5542c1afd8c1629";
                
                //var source2 = new MediaSource("111121");
                //var source = new MediaSource("test", new NSUrl(url), "", null, MediaFormat.Mp4);
                //var mediasource = new MediaSource[1];
                //mediasource[0] = source;
                //var entry = new MediaEntry("test", mediasource, 5000);
                var entry = new MediaEntry("test", null, 5000);

                //var mediaConfig = new MediaConfig(entry,0);

            }
            catch (Exception EX)
            {
                //var _kpplayerconfig = new LibKalturaSDK.KPPlayerConfig_();
            }
        }

        /*public void DoPublish()
        {
            try
            {

                var _playerDelegate = new PlayerDelegate(this);

                if (_player == null)
                {
                    var _PlayerConfig = new PlayerConfig(this);
                    _PlayerConfig.ConstructorserverURL("http://cdnapi.kaltura.com", "40636441", "2329001");
                    var _kpplayerconfig = new KPPlayerConfig("http://cdnapi.kaltura.com", "40636441", "2329001");
                    // Video Entry
                    _kpplayerconfig.EntryId = @"1_o426d3i4";

                    // Setting this property will cache the html pages in the limit size
                    _kpplayerconfig.CacheSize = 100; // MB

                    _player = new KPController();
                }
            }
            catch (Exception EX)
            {
                //var _kpplayerconfig = new LibKalturaSDK.KPPlayerConfig_();
            }
        }*/

        #region old
        private void DoConnect()
        {

            try
            {
                //LibKalturaSDK.Client.Instance.PlayMovieFromUrl("http://cdnbakmi.kaltura.com/p/243342/sp/24334200/playManifest/entryId/1_sf5ovm7u/flavorId/1_jl7y56al/format/url/protocol/http/a.mp4");

                var client = new KalturaClient();
                string url = "http://www.kaltura.com//api_v3/service/media/action/list";
                KalturaWidget kalturaWidget = new KalturaWidget();
                var _kalturaPlayableEntry = new KalturaPlayableEntry();
                var asr = new KalturaDeliveryProfileVodPackagerPlayServer();
                KalturaMediaEntry _kalturamediaentry = new KalturaMediaEntry();
                _kalturamediaentry.SetCreatedAtFromString("2329001");
                var vie = _kalturamediaentry.Views;
                KalturaBulkDownloadJobData kalturaBulkDownloadJobData = new KalturaBulkDownloadJobData();
                client.DownloadProgressDelegate = kalturaBulkDownloadJobData;
                client.BaseEntry.GetWithEntryId("1_jlsg7an3");

                KalturaUserService _KalturaUserService = new KalturaUserService();
                _KalturaUserService.LoginWithPartnerId(PARTNER_ID, USER_ID, ADMIN_SECRET);
                //_KalturaUserService.GetByLoginIdWithLoginId("2329001");
                //kalturaWidget.SetPartnerIdFromString("2329001");
                KalturaFlavorAsset kalturaFlavorAsset = new KalturaFlavorAsset();
                kalturaWidget.EntryId = "1_jlsg7an3";
                //requestConfiguration.Ks = this.GenerateSessionV2(PARTNER_ID, ADMIN_SECRET, USER_ID, 2, 86400, "");
                id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);

                KalturaConfiguration kalturaConfiguration = new KalturaConfiguration();
                kalturaConfiguration.ServiceUrl = "http://www.kaltura.com/";
                client.Config = kalturaConfiguration;

                client.StartMultiRequest();
                // test();
                //var result = client.FlavorAsset.GetUrlWithId("1_jlsg7an3");
                //var multiRequestResults = client.DoMultiRequest;

                //var downloadUrl = multiRequestResults[1];

            }
            catch (Exception ex)
            {

            }

            /*
                        InvokeOnMainThread(() =>
                        {
                            var subView = new RectangleF(0, 0, 1, 1); ;
                            subView.Frame = new RectangleF(0, 0, 1, 1);

                            this.AddSubview(subView);
                            subView.TranslatesAutoresizingMaskIntoConstraints = false;
                            this.AddConstraints(new NSLayoutConstraint[] {
                                    NSLayoutConstraint.Create(subView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 0),
                                    NSLayoutConstraint.Create(subView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, 0),
                                    NSLayoutConstraint.Create(subView, NSLayoutAttribute.Leading, NSLayoutRelation.Equal, this, NSLayoutAttribute.Leading, 1, 0),
                                    NSLayoutConstraint.Create(subView, NSLayoutAttribute.Trailing, NSLayoutRelation.Equal, this, NSLayoutAttribute.Trailing, 1, 0)
                                });
                            this.BringSubviewToFront(subView);

                        });*/
        }

        private KalturaMediaEntry entry;

        public void test()
        {
            // Setup a pager and search to use
            KalturaMediaEntryFilter KalturaMediaEntryFilter = new KalturaMediaEntryFilter();
            KalturaMediaEntryFilter.OrderBy = KalturaMediaEntryOrderBy.CREATED_AT_ASC;
            KalturaMediaEntryFilter.MediaTypeEqual = KalturaMediaType.VIDEO;

            KalturaFilterPager pager = new KalturaFilterPager();
            pager.PageSize = 1;
            pager.PageIndex = 1;
            bufferRead = new byte[BUFFER_SIZE];
            requestData = new StringBuilder(System.String.Empty);
            Console.WriteLine("List videos, get the first one...");
            //MediaService.List(KalturaMediaEntryFilter, pager)
            //    .SetCompletion(new OnCompletedHandler<ListResponse<KalturaMediaEntry>>(OnEntriesListComplete))
            //Execute(client);
        }

        public void Execute(KalturaClient client = null)
        {

            //if (this.client == null)
            //{
            //    this.Build(client);
            //}

            //string url = "http://www.kaltura.com//api_v3/service/media/action/list";
            string url = "http://cdnsecakmi.kaltura.com/s/p/1296091/sp/129609100/serveFlavor/entryId/1_4e1pfi47/v/11/flavorId/1_wsalqgxi/forceproxy/true/name/a.mp4?aeauth=1507329152_05539ac3997aee00f5542c1afd8c1629";

            // build request
            request = (HttpWebRequest)HttpWebRequest.Create(url);

            request.Method = "POST";

            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Accept = "application/xml";
            request.ContentType = "application/json";

            // Add proxy information if required
            request.BeginGetRequestStream(new AsyncCallback(RequestCallback), this);
        }

        private StringBuilder requestData;
        private byte[] bufferRead;
        private HttpWebRequest request;
        private Stream responseStream;
        // Create Decoder for appropriate enconding type.
        private Decoder streamDecode = Encoding.UTF8.GetDecoder();

        public string Boundary
        {
            get;
            set;
        }
        //public virtual KalturaParams getParameters(bool includeServiceAndAction)
        //{
        //    KalturaParams kparams = new KalturaParams();

        //    if (client != null)
        //        kparams.Add(client.RequestConfiguration.ToParams(false));

        //    kparams.Add(base.ToParams(false));

        //    if (includeServiceAndAction)
        //        kparams.Add("service", service);

        //    return kparams;
        //}

        private void RequestCallback(IAsyncResult result)
        {
            /*KalturaParams parameters = getParameters(false);
            parameters.Add(client.ClientConfiguration.ToParams(false));
            parameters.Add("format", EServiceFormat.RESPONSE_TYPE_XML.GetHashCode());
            parameters.Add("kalsig", Signature(parameters));

            string json = parameters.ToJson();*/

            Stream postStream = request.EndGetRequestStream(result);
            //KalturaPlayerEmbedCodeType.Alloc()
            /*if (getFiles().Count == 0)
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                postStream.Write(byteArray, 0, json.Length);
            }
            else
            {
                byte[] paramsBuffer = BuildMultiPartParamsBuffer(json);
                postStream.Write(paramsBuffer, 0, paramsBuffer.Length);

                SortedList<string, MultiPartFileDescriptor> filesDescriptions = new SortedList<string, MultiPartFileDescriptor>();
                foreach (KeyValuePair<string, Stream> file in getFiles())
                    filesDescriptions.Add(file.Key, BuildMultiPartFileDescriptor(file));

                foreach (KeyValuePair<string, MultiPartFileDescriptor> fileDesc in filesDescriptions)
                {
                    postStream.Write(fileDesc.Value._Header, 0, fileDesc.Value._Header.Length);

                    byte[] buffer = new Byte[checked(Math.Min((uint)1048576, fileDesc.Value._Stream.Length))];
                    int bytesRead = 0;
                    while ((bytesRead = fileDesc.Value._Stream.Read(buffer, 0, buffer.Length)) != 0)
                        postStream.Write(buffer, 0, bytesRead);

                    postStream.Write(fileDesc.Value._Footer, 0, fileDesc.Value._Footer.Length);
                }
            }*/
            postStream.Close();

            request.BeginGetResponse(new AsyncCallback(ResponseCallback), this);
        }

        private void ResponseCallback(IAsyncResult result)
        {
            // Call EndGetResponse, which produces the WebResponse object
            //  that came from the request issued above.
            WebResponse response;
            try
            {
                response = request.EndGetResponse(result);
            }
            catch (WebException e)
            {
                return;
            }

            //  Start reading data from the response stream.
            responseStream = response.GetResponseStream();

            //  Pass rs.BufferRead to BeginRead. Read data into rs.BufferRead
            responseStream.BeginRead(bufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), this);
        }
        const int BUFFER_SIZE = 1024;


        private void ReadCallBack(IAsyncResult result)
        {
            // Read rs.BufferRead to verify that it contains data. 
            int read = responseStream.EndRead(result);
            if (read > 0)
            {
                // Prepare a Char array buffer for converting to Unicode.
                Char[] charBuffer = new Char[BUFFER_SIZE];

                // Convert byte stream to Char array and then to String.
                // len contains the number of characters converted to Unicode.
                int len = streamDecode.GetChars(bufferRead, 0, read, charBuffer, 0);

                // Append the recently read data to the RequestData stringbuilder
                // object contained in RequestState.
                requestData.Append(Encoding.ASCII.GetString(bufferRead, 0, read));

                // Continue reading data until 
                // responseStream.EndRead returns –1.
                responseStream.BeginRead(bufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), this);
            }
            else
            {
                if (requestData.Length > 0)
                {
                    string responseString = requestData.ToString();
                    //this.Log("result (serialized): " + responseString);

                    DateTime endTime = DateTime.Now;


                    /*XmlDocument xml = new XmlDocument();
                    xml.LoadXml(responseString);

                    ValidateXmlResult(xml);
                    XmlElement resultXml = xml["xml"]["result"];

                    OnComplete(Deserialize(resultXml), GetAPIError(resultXml));*/
                }
                // Close down the response stream.
                responseStream.Close();
            }
            return;
        }

        private MultiPartFileDescriptor BuildMultiPartFileDescriptor(KeyValuePair<string, Stream> fileEntry)
        {
            MultiPartFileDescriptor result = new MultiPartFileDescriptor();
            result._Stream = fileEntry.Value;

            // Build header
            StringBuilder sb = new StringBuilder();
            Stream fileStream = fileEntry.Value;
            if (fileStream is FileStream)
            {
                FileStream fs = (FileStream)fileStream;
                sb.Append("Content-Disposition: form-data; name=\"" + fileEntry.Key + "\"; filename=\"" + Path.GetFileName(fs.Name) + "\"" + "\r\n");
            }
            else if (fileStream is MemoryStream)
            {
                sb.Append("Content-Disposition: form-data; name=\"" + fileEntry.Key + "\"; filename=\"Memory-Stream-Upload\"" + "\r\n");
            }
            sb.Append("Content-Type: application/octet-stream" + "\r\n");
            sb.Append("\r\n");
            result._Header = Encoding.UTF8.GetBytes(sb.ToString());

            result._Footer = Encoding.UTF8.GetBytes("\r\n--" + Boundary + "\r\n");

            return result;
        }

        private byte[] BuildMultiPartParamsBuffer(string json)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("--" + Boundary + "\r\n");
            sb.Append("Content-Disposition: form-data; name=\"json\"\r\n");
            sb.Append("\r\n");
            //sb.Append(HttpUtility.UrlDecode(json));
            sb.Append("\r\n--" + Boundary + "\r\n");

            return Encoding.UTF8.GetBytes(sb.ToString());
        }


        private struct MultiPartFileDescriptor
        {
            public Stream _Stream;
            public byte[] _Header;
            public byte[] _Footer;

            public long GetTotalLength()
            {
                return _Stream.Length + _Header.LongLength + _Footer.LongLength;
            }
        }

        public string GenerateSessionV2(int partnerId, string adminSecretForSigning, string userId = "", int type = 2, int expiry = 86400, string privileges = "")
        {
            // build fields array
            Dictionary<string, string> fields = new Dictionary<string, string>();
            string[] privilegesArr = privileges.Split(',');
            foreach (string curPriv in privilegesArr)
            {
                string privilege = curPriv.Trim();
                if (privilege.Length == 0)
                {
                    continue;
                }
                if (privilege.Equals("*"))
                {
                    privilege = "all:*";
                }

                string[] splittedPriv = privilege.Split(':');
                if (splittedPriv.Length > 1)
                {
                    //fields.Add(splittedPriv[0], HttpUtility.UrlEncode(splittedPriv[1], Encoding.UTF8));
                }
                else
                {
                    fields.Add(splittedPriv[0], "");
                }
            }

            long expiryTime = (UnixTimeNow() + expiry);
            fields.Add(FIELD_EXPIRY, expiryTime.ToString());
            fields.Add(FIELD_TYPE, ((int)type).ToString());
            fields.Add(FIELD_USER, userId);

            // build fields string
            byte[] randomBytes = createRandomByteArray(RANDOM_SIZE);
            string fieldsString = string.Join("&", fields.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));
            byte[] fieldsByteArray = Encoding.ASCII.GetBytes(fieldsString);
            int totalLength = randomBytes.Length + fieldsByteArray.Length;

            byte[] fieldsAndRandomBytes = new byte[totalLength];
            Array.Copy(randomBytes, 0, fieldsAndRandomBytes, 0, randomBytes.Length);
            Array.Copy(fieldsByteArray, 0, fieldsAndRandomBytes, randomBytes.Length, fieldsByteArray.Length);

            byte[] infoSignature = signInfoWithSHA1(fieldsAndRandomBytes);
            byte[] input = new byte[infoSignature.Length + fieldsAndRandomBytes.Length];
            Array.Copy(infoSignature, 0, input, 0, infoSignature.Length);
            Array.Copy(fieldsAndRandomBytes, 0, input, infoSignature.Length, fieldsAndRandomBytes.Length);

            // encrypt and encode
            byte[] encryptedFields = aesEncrypt(adminSecretForSigning, input);
            string prefix = "v2|" + partnerId + "|";
            byte[] prefixBytes = Encoding.ASCII.GetBytes(prefix);

            byte[] output = new byte[encryptedFields.Length + prefix.Length];
            Array.Copy(prefixBytes, 0, output, 0, prefix.Length);
            Array.Copy(encryptedFields, 0, output, prefix.Length, encryptedFields.Length);

            string encodedKs = EncodeTo64(output);
            encodedKs = encodedKs.Replace("+", "-");
            encodedKs = encodedKs.Replace("/", "_");
            encodedKs = encodedKs.Replace("\n", "");
            encodedKs = encodedKs.Replace("\r", "");

            return encodedKs;
        }

        private byte[] aesEncrypt(string secretForSigning, byte[] text)
        {
            byte[] hashedKey = signInfoWithSHA1(secretForSigning);
            byte[] keyBytes = new byte[BLOCK_SIZE];
            Array.Copy(hashedKey, 0, keyBytes, 0, BLOCK_SIZE);

            //IV
            byte[] ivBytes = new byte[BLOCK_SIZE];

            // Text
            int textSize = ((text.Length + BLOCK_SIZE - 1) / BLOCK_SIZE) * BLOCK_SIZE;
            byte[] textAsBytes = new byte[textSize];
            Array.Copy(text, 0, textAsBytes, 0, text.Length);

            // Encrypt
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = ivBytes;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.None;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cst = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cst.Write(textAsBytes, 0, textSize);
                        return ms.ToArray();
                    }
                }
            }
        }

        private byte[] signInfoWithSHA1(string text)
        {
            return signInfoWithSHA1(Encoding.ASCII.GetBytes(text));
        }

        private byte[] signInfoWithSHA1(byte[] data)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(data);
        }

        private byte[] createRandomByteArray(int size)
        {
            byte[] b = new byte[size];
            new Random().NextBytes(b);
            return b;
        }

        public long UnixTimeNow()
        {
            TimeSpan _TimeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0));
            return (long)_TimeSpan.TotalSeconds;
        }

        private string EncodeTo64(string toEncode)
        {
            return EncodeTo64(Encoding.ASCII.GetBytes(toEncode));
        }

        private string EncodeTo64(byte[] toEncode)
        {
            string returnValue = System.Convert.ToBase64String(toEncode);
            return returnValue;
        }

    }

    public class Files : SortedList<string, Stream>
    {
        public void Add(Files files)
        {
            foreach (KeyValuePair<string, Stream> item in files)
            {
                this.Add(item.Key, item.Value);
            }
        }
    }
    #endregion


    public class ControllerDelegate : LibKalturaSDK.KPControllerDelegate
    {
        private OpenTokViewRenderer _this;

        public override NSObject CurrentPlaybackTime => throw new NotImplementedException();

        public override NSObject Duration => throw new NotImplementedException();

        public override float Volume { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ControllerDelegate(OpenTokViewRenderer This)
        {
            _this = This;
        }

        public override NSObject Mute()
        {
            throw new NotImplementedException();
        }

        public override void SendKPNotification(NSObject kpNotificationName, NSObject kpParams)
        {
            throw new NotImplementedException();
        }

        public override void SendKPNotification(NSObject kpNotificationName, NSObject kpParams, [BlockProxy(typeof(AdAction))] Action handler)
        {
            throw new NotImplementedException();
        }

        public override void SetMute(NSObject isMute)
        {
            throw new NotImplementedException();
        }
    }
    public class PlayerDelegate : LibKalturaSDK.KPlayerDelegate
    {
        private OpenTokViewRenderer _this;

        public PlayerDelegate(OpenTokViewRenderer This)
        {
            _this = This;
        }

        public override void ContentCompleted(KPlayer currentPlayer)
        {
            _this.DoPublish();
            throw new NotImplementedException();
        }


        public override void Player(KPlayer currentPlayer, NSObject @event, NSObject value)
        {
            throw new NotImplementedException();
        }

        public override void PlayerjsonString(KPlayer currentPlayer, NSObject @event, NSObject jsonString)
        {
            throw new NotImplementedException();
        }
    }

    public class PlayerConfig : LibKalturaSDK.KPPlayerConfig
    {
        private OpenTokViewRenderer _this;

        public PlayerConfig(OpenTokViewRenderer This)
        {
            _this = This;
        }
        public override IntPtr ConstructorserverURL(string serverURL, string uiConfId, string partnerId)
        {
            return base.ConstructorserverURL( serverURL,  uiConfId,  partnerId);
            //this.EntryId = @"1_o426d3i4";

            // Setting this property will cache the html pages in the limit size
            this.CacheSize = 100; // MB
        }

    }

}

