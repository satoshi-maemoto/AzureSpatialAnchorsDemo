// Copyright (c) 2020 Satoshi Maemoto
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using System.Collections;
using System.IO;
using UnityEngine;

public class AppController : MonoBehaviour
{
    [SerializeField]
    public AppSettings appSettings;
    public static AppSettings AppSettings { get; private set; }

    private string settingsFilePath = string.Empty;

    public AnchorModuleScript AnchorModule;
    public MessageBar MessageBar;
    public GameObject debugButtons;

    private void Awake()
    {
        this.settingsFilePath = $"{Application.persistentDataPath}{Path.DirectorySeparatorChar}Settings.json";
        AppController.AppSettings = this.appSettings;
        this.LoadSettings();
    }

    private void Start()
    {
        this.AnchorModule.OnASAAnchorLocated += () =>
        {
            this.MessageBar.ShowMessage("Anchor located.");
        };
        this.AnchorModule.OnCreateAnchorSucceeded += () =>
        {
            this.MessageBar.ShowMessage("Anchor created.");
        };

        this.StartCoroutine(this.Process());
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            this.SaveSettings();
        }
    }

    private void LoadSettings()
    {
        if (File.Exists(this.settingsFilePath))
        {
            var json = File.ReadAllText(this.settingsFilePath);
            JsonUtility.FromJsonOverwrite(json, AppController.AppSettings);
            Debug.Log($"Settings loaded from {this.settingsFilePath}");
        }
    }

    private void SaveSettings()
    {
        string json = JsonUtility.ToJson(AppController.AppSettings);
        File.WriteAllText(this.settingsFilePath, json);
        Debug.Log($"Settings saved to {this.settingsFilePath}");
    }

    private IEnumerator Process()
    {
        this.SetSpatialMappingVisible();
        this.SetDebugButtonsVisible();
        var spatialMappingState = AppController.AppSettings.visibleSpatialMapping;
        var debugButtonsState = AppController.AppSettings.visibleDebugButtons;
        while (true)
        {
            if (spatialMappingState != AppController.AppSettings.visibleSpatialMapping)
            {
                this.SetSpatialMappingVisible();
            }
            spatialMappingState = AppController.AppSettings.visibleSpatialMapping;

            if (debugButtonsState != AppController.AppSettings.visibleDebugButtons)
            {
                this.SetDebugButtonsVisible();
            }
            debugButtonsState = AppController.AppSettings.visibleDebugButtons;

            yield return true;
        }
    }
    public async void CreateAzureAnchor()
    {
        await this.AnchorModule.RestartSession(AppSettings.useGeoLocation || AppSettings.useWifi || AppSettings.useBluetooth);
        this.AnchorModule.CreateAzureAnchor(this.AnchorModule.gameObject);
    }

    public async void FindAzureAnchor()
    {
        await this.AnchorModule.RestartSession(AppSettings.useGeoLocation || AppSettings.useWifi || AppSettings.useBluetooth);
        if (!AppSettings.useGeoLocation && !AppSettings.useWifi && !AppSettings.useBluetooth)
        {
            Debug.Log($"Find Azure Anchor without Coarse Relocalization");
            this.AnchorModule.GetAzureAnchorIdFromDisk();
            this.AnchorModule.FindAzureAnchor();
        }
        else
        {
            Debug.Log($"Find Azure Anchor with Coarse Relocalization");
            this.AnchorModule.FindAzureAnchorForCoarseRelocalization();
        }
    }

    public async void UnlockAnchor()
    {
        await this.AnchorModule.StopAzureSessionAsync();
        this.AnchorModule.RemoveLocalAnchor(this.AnchorModule.gameObject);
    }

    private void SetSpatialMappingVisible()
    {
#if UNITY_WSA
        var observer = (CoreServices.SpatialAwarenessSystem as IMixedRealityDataProviderAccess).GetDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();
        observer.DisplayOption = AppController.AppSettings.visibleSpatialMapping ? SpatialAwarenessMeshDisplayOptions.Visible : SpatialAwarenessMeshDisplayOptions.Occlusion;
#endif
    }

    private void SetDebugButtonsVisible()
    {
        this.debugButtons.SetActive(AppController.AppSettings.visibleDebugButtons);
    }
}
