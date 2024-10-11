public class AdKeysSetting : AdKeys
{
    public override string MaxSdkKey => "0_kHnlPJ_S7fcoNWMGiMhM9F6D6uITQZUcybS6MIdZfM7sZbN5a7lXVHkkGmEQULTzM7qbFTWkXs_ZDNHzAXHA";
    public override string AdjustAppToken => "l8b7wjkqf94w";
#if UNITY_IOS
		public override string MaxInterstitialAdUnitId => "";
		public override string MaxRewardedAdUnitId => "";
		public override string MaxBannerAdUnitId => "";
#else
    public override string MaxInterstitialAdUnitId => "";
    public override string MaxRewardedAdUnitId => "";
    public override string MaxBannerAdUnitId => "";
#endif
}
