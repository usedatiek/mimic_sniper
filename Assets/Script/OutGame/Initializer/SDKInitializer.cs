using com.adjust.sdk;
using UnityEngine;

public class SDKInitializer : MonoBehaviour
{
    [SerializeField] private string adjustAppToken;

    private const int tokenCharacterCount = 12;

    private void Awake()
    {
        MaxSdk.InitializeSdk();

        if (adjustAppToken.Length == tokenCharacterCount)
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
