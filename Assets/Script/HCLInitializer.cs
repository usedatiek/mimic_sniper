using com.adjust.sdk;
using UnityEngine;

public class HCLInitializer : MonoBehaviour
{
    private AdKeys adKeys;

    private void Awake()
    {
        adKeys = AdKeys.Instantiate();

        if (string.IsNullOrEmpty(adKeys.MaxSdkKey))
        {
            Debug.LogError("No MaxSDK Key. Iniialization Skipped.");
        }
        else
        {
            MaxSdk.SetSdkKey(adKeys.MaxSdkKey);
            MaxSdk.InitializeSdk();
        }

        if (adKeys.AdjustAppToken.Length == 12)
        {
            AdjustConfig config = new AdjustConfig(adKeys.AdjustAppToken, AdjustEnvironment.Production);
            Adjust.start(config);
        }
        else
        {
            Debug.LogError("No AdjustAppToken. Iniialization Skipped.");
        }
    }
}
