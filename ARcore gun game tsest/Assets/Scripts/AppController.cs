using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.Examples.Common;

public class AppController : MonoBehaviour
{
    public Camera FirstPersonCamera;
    public GameObject prefab;
    private bool mIsQuitting = false;
    private const float mModelRotation = 180.0f;
    public bool planebuild = false;
    public GameObject canvas;
    // Use this for initialization

    void Start()
    {
        OnCheckDevice();
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateApplicationLifecycle();

        Touch touch;
        if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
        {
            return;
        }
        if (planebuild == false)
        {
            TrackableHit hit;
            TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon | TrackableHitFlags.PlaneWithinBounds;
            if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
            {
                if ((hit.Trackable is DetectedPlane) && Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position, hit.Pose.rotation * Vector3.up) < 0)
                {
                    Debug.Log("射線擊中了DetectedPlane的背面！");
                }
                else
                {

                    var PlaneObject = Instantiate(prefab, hit.Pose.position, hit.Pose.rotation);
                    PlaneObject.name = "PlanePOS";
                    PlaneObject.transform.Rotate(0, mModelRotation, 0, Space.Self);
                    var anchor = hit.Trackable.CreateAnchor(hit.Pose);
                    PlaneObject.transform.parent = anchor.transform;
                    planebuild = true;
                    canvas.SetActive(true);
                   
                }
            }
        }
      
    }
   


    private void OnCheckDevice()
    {
        if (Session.Status == SessionStatus.ErrorSessionConfigurationNotSupported)
        {
            ShowAndroidToastMessage("ARCore在本機上不受支持或配置錯誤！");
            Invoke("DoQuit", 0.5f);
        }
        else if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
        {
            ShowAndroidToastMessage("AR應用的運行需要使用攝影鏡頭，現無法獲取到攝影鏡頭授權訊息，'請允許使用攝影鏡頭");
            Invoke("DoQuit", 0.5f);
        }
        else if (Session.Status.IsError())
        {
            ShowAndroidToastMessage("ARCore運行時出現錯誤，請重新啟動！");
            Invoke("DoQuit", 0.5f);
        }
    }
    private void UpdateApplicationLifecycle()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            const int lostTrackingSleepTimeout = 15;
            Screen.sleepTimeout = lostTrackingSleepTimeout;
        }
        else
        {
            Screen.sleepTimeout = SleepTimeout.NeverSleep;
        }

        if (mIsQuitting)
        {
            return;
        }
    }
    /// <summary>
    /// 退出程式
    /// </summary>
    private void DoQuit()
    {
        Application.Quit();
    }
    /// <summary>
    /// 跳出訊息提示
    /// </summary>
    /// <param name="message">要跳出的訊息</param>
    private void ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
                toastObject.Call("show");
            }));
        }
    }

    
}
