using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
namespace Watermelon
{
    public class Banner : MonoBehaviour
    {
#if UNITY_ANDROID
      [SerializeField]  private string _adUnitId;

#endif

        BannerView _bannerView;

        /// <summary>
        /// Creates a 320x50 banner view at top of the screen.
        /// </summary>
        ///
        private void OnEnable()
        {
            SceneManager.activeSceneChanged += SceneChanged;
        }
        private void OnDisable()
        {
            SceneManager.activeSceneChanged -= SceneChanged;
        }
        void SceneChanged(Scene scene,Scene scene1)
        {
            CreateBannerView();
            LoadAd();
        }
        public void CreateBannerView()
        {
            Debug.Log("Creating banner view");

            // If we already have a banner, destroy the old one.
            //if (_bannerView != null)
            //{
            //    DestroyAd();
            //}

            // Create a 320x50 banner at top of the screen
            _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);
        }
        void Start()
        {
           
            // Initialize the Google Mobile Ads SDK.
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                // This callback is called once the MobileAds SDK is initialized.
            });
            LoadAd();
        }
        public void LoadAd()
        {
            // create an instance of a banner view first.
            if (_bannerView == null)
            {
                CreateBannerView();
            }

            // create our request used to load the ad.
            var adRequest = new AdRequest();

            // send the request to load the ad.
            Debug.Log("Loading banner ad.");
            _bannerView.LoadAd(adRequest);
        }
        public void DestroyAd()
        {
            if (_bannerView != null)
            {
                Debug.Log("Destroying banner view.");
                _bannerView.Destroy();
                _bannerView = null;
            }
        }
    }
}
