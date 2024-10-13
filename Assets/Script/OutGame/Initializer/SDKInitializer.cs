using com.adjust.sdk;
using UnityEngine;

public class SDKInitializer : MonoBehaviour
{
    [SerializeField] private string adjustAppToken;

    private void Awake()
    {
        MaxSdk.InitializeSdk();

        if (adjustAppToken.Length == 12)
        {
            AdjustConfig config = new AdjustConfig(adjustAppToken, AdjustEnvironment.Production);
            Adjust.start(config);
        }
        else
        {
            Debug.LogError("No AdjustAppToken. Iniialization Skipped.");
        }
    }
}
