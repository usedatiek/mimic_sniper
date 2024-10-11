//#define USE_SECRET_CONFIG
using System.Reflection;
using UnityEngine;

public class AdKeys : MonoBehaviour
{
    public virtual string MaxSdkKey { get => null; }
    public virtual string MaxInterstitialAdUnitId { get => null; }
    public virtual string MaxRewardedAdUnitId { get => null; }
    public virtual string MaxBannerAdUnitId { get => null; }
    public virtual string AdjustAppToken { get => null; }

    // リフレクションで派生型を探してきてインスタンスを返す
    public static AdKeys Instantiate()
    {
#if USE_SECRET_CONFIG
			var secretConfig = InstantiateDerivative<Kayac.HcAd.Secret.SecretConfig>();
			var ret = new AdKeysManual(
				secretConfig.maxSdkKey,
				secretConfig.maxInterstitialAdUnitId,
				secretConfig.maxRewardedAdUnitId,
				secretConfig.maxBannerAdUnitId,
            )
#else
        var ret = InstantiateDerivative<AdKeys>();
#endif
        return ret;
    }

    static BaseType InstantiateDerivative<BaseType>() where BaseType : class
    {
        var baseType = typeof(BaseType);
        var asm = Assembly.GetExecutingAssembly();
        var types = asm.GetTypes();
        System.Type foundType = null;
        foreach (var type in types)
        {
            if ((type != baseType) && (type != typeof(AdKeysManual)) && baseType.IsAssignableFrom(type))
            {
                foundType = type;
                break;
            }
        }
        if (foundType == null)
        {
            foundType = baseType;
            Debug.LogError(typeof(BaseType).Name + " の派生クラスが見当たりません。");
        }
        var instance = System.Activator.CreateInstance(foundType) as BaseType;
        return instance;
    }
}

// ほぼSecretConfigアダプタ
class AdKeysManual : AdKeys
{
    public override string MaxSdkKey { get => maxSdkKey; }
    public override string MaxInterstitialAdUnitId { get => maxInterstitialAdUnitId; }
    public override string MaxRewardedAdUnitId { get => maxRewardedAdUnitId; }
    public override string MaxBannerAdUnitId { get => maxBannerAdUnitId; }
    public override string AdjustAppToken { get => null; }

    public AdKeysManual(
        string maxSdkKey,
        string maxInterstitialAdUnitId,
        string maxRewardedAdUnitId,
        string maxBannerAdUnitId)
    {
        this.maxSdkKey = maxSdkKey;
        this.maxInterstitialAdUnitId = maxInterstitialAdUnitId;
        this.maxRewardedAdUnitId = maxRewardedAdUnitId;
        this.maxBannerAdUnitId = maxBannerAdUnitId;
    }
    // non public --------
    string maxSdkKey;
    string maxInterstitialAdUnitId;
    string maxRewardedAdUnitId;
    string maxBannerAdUnitId;
}