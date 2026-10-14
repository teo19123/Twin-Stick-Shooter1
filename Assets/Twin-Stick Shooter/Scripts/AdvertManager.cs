using UnityEngine.Advertisements;
using UnityEngine;
using Unity.VisualScripting;

public class AdvertManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField]
    string m_androidGameId = "5171861";
    [SerializeField]
    string m_iosGameId = "5171860";

    public string m_currentGameId = "";
    private bool m_testMode = true;
    public static AdvertManager instance;

    [SerializeField]
    InterstitialAdvert m_interstitialAdvert;
    public void OnInitializationComplete()
    {
        Debug.Log("Advertisements Service Initialized");
    }


    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError("Advertisements Service Failed to Initialize: " + message);
    }

    void Awake()
    {

        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }
#if UNIT_IOS
    m_currentGameId = m_iosGameId;
#else
    m_currentGameId = m_androidGameId;
#endif

    if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(m_currentGameId, m_testMode, this);
        }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

