// Copyright (c) 2020 Satoshi Maemoto
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

public class SettingsMenuView : MonoBehaviour
{
    public Interactable useGeoLocationInteractable;
    public Interactable useWifiInteractable;
    public Interactable useBluetoothInteractable;
    public Interactable visibleSpatialMappingInteractable;
    public Interactable visibleDebugButtonsInteractable;

    public void OnEnable()
    {
        this.useGeoLocationInteractable.CurrentDimension = AppController.AppSettings.useGeoLocation ? 1 : 0;
        this.useWifiInteractable.CurrentDimension = AppController.AppSettings.useWifi ? 1 : 0;
        this.useBluetoothInteractable.CurrentDimension = AppController.AppSettings.useBluetooth ? 1 : 0;
        this.visibleSpatialMappingInteractable.CurrentDimension = AppController.AppSettings.visibleSpatialMapping ? 1 : 0;
        this.visibleDebugButtonsInteractable.CurrentDimension = AppController.AppSettings.visibleDebugButtons ? 1 : 0;
    }

    public void Update()
    {
        AppController.AppSettings.useGeoLocation = (this.useGeoLocationInteractable.CurrentDimension == 1);
        AppController.AppSettings.useWifi = (this.useWifiInteractable.CurrentDimension == 1);
        AppController.AppSettings.useBluetooth = (this.useBluetoothInteractable.CurrentDimension == 1);
        AppController.AppSettings.visibleSpatialMapping = (this.visibleSpatialMappingInteractable.CurrentDimension == 1);
        AppController.AppSettings.visibleDebugButtons = (this.visibleDebugButtonsInteractable.CurrentDimension == 1);
    }

    public void SwitchVisibleState()
    {
        this.gameObject.SetActive(!this.gameObject.activeInHierarchy);
    }
}
