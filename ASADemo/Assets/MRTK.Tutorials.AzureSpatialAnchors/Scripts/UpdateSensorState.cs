// Copyright (c) Takahiro Miyaura. All rights reserved.
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

using System;
using Microsoft.Azure.SpatialAnchors;
using UnityEngine;

public class UpdateSensorState : MonoBehaviour
{
    public enum Sensor
    {
        GeoLocation,
        Wifi,
        Bluetooth
    }

    [Range(500f, 60000f)]
    public float Interval = 1000f;

    public AnchorModuleScript AnchorModule;
    public Sensor SensorType;
    public Material Icon;

    public Color AvailableColor = Color.green;
    public Color DisabledCapabilityColor = Color.red;
    public Color MissingProviderColor = Color.yellow;
    public Color NoDataColor = Color.black;
    public Color UserDisabledColor = Color.gray;

    private float timer = 0f;
    private PlatformLocationProvider locationProvider;

    // Start is called before the first frame update
    void Start()
    {
        if (Icon == null)
        {
            return;
        }
        Icon.color = MissingProviderColor;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > Interval)
        {
            timer = 0f;
        }
        try
        {
            if (Icon == null)
            {
                return;
            }
            if (AnchorModule?.LocationProvider == null)
            {
                Icon.color = MissingProviderColor;
                return;
            }

            locationProvider = AnchorModule.LocationProvider;

            switch (SensorType)
            {
                case Sensor.GeoLocation:
                    //Debug.Log($"GeoLocationStatus={GeoLocationStatus}");
                    UpdateColor(GeoLocationStatus);
                    break;
                case Sensor.Wifi:
                    //Debug.Log($"WifiStatus={WifiStatus}");
                    UpdateColor(WifiStatus);
                    break;
                case Sensor.Bluetooth:
                    //Debug.Log($"BluetoothStatus={BluetoothStatus}");
                    UpdateColor(BluetoothStatus);
                    break;
            }

        }
        catch (Exception e)
        {
            Debug.Log($"{e.GetType().Name}:{e.Message}");
            Debug.Log("ここにｷﾀ━━━━(ﾟ∀ﾟ)━━━━!!");
        }
    }

    private void UpdateColor(SensorStatus status)
    {
        switch (status)
        {
            case SensorStatus.Available:
                Icon.color = AvailableColor;
                break;
            case SensorStatus.DisabledCapability:
                Icon.color = DisabledCapabilityColor;
                break;
            case SensorStatus.MissingSensorFingerprintProvider:
                Icon.color = MissingProviderColor;
                break;
            case SensorStatus.NoData:
                Icon.color = NoDataColor;
                break;
            case SensorStatus.UserDisabled:
                Icon.color = UserDisabledColor;
                break;
        }
    }


    public SensorStatus GeoLocationStatus
    {
        get
        {
            if (!AppController.AppSettings.useGeoLocation)
            {
                return SensorStatus.UserDisabled;
            }
            if (!locationProvider.Sensors.GeoLocationEnabled)
            {
                return SensorStatus.DisabledCapability;
            }
            switch (locationProvider.GeoLocationStatus)
            {
                case GeoLocationStatusResult.Available:
                    return SensorStatus.Available;
                case GeoLocationStatusResult.DisabledCapability:
                    return SensorStatus.DisabledCapability;
                case GeoLocationStatusResult.MissingSensorFingerprintProvider:
                    return SensorStatus.MissingSensorFingerprintProvider;
                case GeoLocationStatusResult.NoGPSData:
                    return SensorStatus.NoData;
                default:
                    return SensorStatus.MissingSensorFingerprintProvider;
            }
        }
    }

    public SensorStatus WifiStatus
    {
        get
        {
            if (!AppController.AppSettings.useWifi)
            {
                return SensorStatus.UserDisabled;
            }
            if (!locationProvider.Sensors.WifiEnabled)
            {
                return SensorStatus.DisabledCapability;
            }
            switch (locationProvider.WifiStatus)
            {
                case WifiStatusResult.Available:
                    return SensorStatus.Available;
                case WifiStatusResult.DisabledCapability:
                    return SensorStatus.DisabledCapability;
                case WifiStatusResult.MissingSensorFingerprintProvider:
                    return SensorStatus.MissingSensorFingerprintProvider;
                case WifiStatusResult.NoAccessPointsFound:
                    return SensorStatus.NoData;
                default:
                    return SensorStatus.MissingSensorFingerprintProvider;
            }
        }
    }

    public SensorStatus BluetoothStatus
    {
        get
        {
            if (!AppController.AppSettings.useBluetooth)
            {
                return SensorStatus.UserDisabled;
            }
            if (!locationProvider.Sensors.BluetoothEnabled)
            {
                return SensorStatus.DisabledCapability;
            }
            switch (locationProvider.BluetoothStatus)
            {
                case BluetoothStatusResult.Available:
                    return SensorStatus.Available;
                case BluetoothStatusResult.DisabledCapability:
                    return SensorStatus.DisabledCapability;
                case BluetoothStatusResult.MissingSensorFingerprintProvider:
                    return SensorStatus.MissingSensorFingerprintProvider;
                case BluetoothStatusResult.NoBeaconsFound:
                    return SensorStatus.NoData;
                default:
                    return SensorStatus.MissingSensorFingerprintProvider;
            }
        }
    }


}