using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SlotMaker;

public class GetAssetBundlesHash : MonoBehaviour
{
	public string baseUrl;
	public string platformName;

	private bool isUpdated = true;
	private AssetBundleLoadAsset operation = null;

	[ContextMenu("Request AssetBundle")]
    void Request()
    {
        isUpdated = false;
        operation = new AssetBundleLoadManifestForTest(platformName, baseUrl);
    }

    void Update()
    {
		if (!isUpdated && !operation.Update())
		{
			isUpdated = true;
		}
    }

    public class AssetBundleLoadManifestForTest : AssetBundleLoadAsset
    {
        protected UnityWebRequest www = null;
        private string baseUrl = "";

        public AssetBundleLoadManifestForTest(string platformName, string baseUrl) : base(platformName, "AssetBundleManifest", typeof(AssetBundleManifest))
        {
        	this.baseUrl = baseUrl;
        }

        public override bool Update()
        {
            if (www == null)
            {
                www = UnityWebRequestAssetBundle.GetAssetBundle(Path.Combine(baseUrl, bundleName), 0);
                www.SendWebRequest();
            }

            if (www.error != null)
            {
                Debug.LogError(string.Format("[AssetBundleManager] Failed downloading bundle AssetBundleManifest from {0}: {1}", www.url, www.error));
                return false;
            }

            if (request == null)
            {
                if (www.isDone)
                {
                    DownloadHandlerAssetBundle downloadHandler = (DownloadHandlerAssetBundle)www.downloadHandler;
                    request = downloadHandler.assetBundle.LoadAssetAsync(assetName, type);
                    return true;
                }
            }
            else
            {
                if (request.isDone)
                {
                    AssetBundleManifest manifest = GetAsset<AssetBundleManifest>();
                    isDone = true;

                    DownloadHandlerAssetBundle downloadHandler = (DownloadHandlerAssetBundle)www.downloadHandler;
                    downloadHandler.assetBundle.Unload(false);

                    www.Dispose();

                    if (ApplicationSettings.LogBundle())
                        Debug.Log("[AssetBundleManager] Loaded AssetBundleManifest");

                    StringBuilder sb = new StringBuilder();
                    var assetBundles = manifest.GetAllAssetBundles();
                    foreach(string bundleName in assetBundles)
                    {
                    	if (!bundleName.Contains("lang"))
                    	{
                    		sb.AppendFormat("{0}: {1}\n", bundleName, manifest.GetAssetBundleHash(bundleName));
                    	}
                    }

                	Debug.Log(sb.ToString());

                    return false;
                }
            }

            return true;
        }
    }
}
