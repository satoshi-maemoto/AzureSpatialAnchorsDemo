using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoarseRelocalizationConfig", menuName = "Azure Spatial Anchors/CoarseRelocalizationConfiguration")]
public class CoarseRelocalizationSettings : ScriptableObject
{
    [Header("NearDevice Settings")]
    [SerializeField]
    [Tooltip("Maximum distance in meters from the device")]
    private int distanceInMeters = 5;
    public int DistanceInMeters => distanceInMeters;

    [SerializeField]
    [Tooltip("Maximum desired result count")]
    private int maxResultCount = 20;
    public int MaxResultCount => maxResultCount;

    
    [Header("Geo Location")]
    [SerializeField]
    [Tooltip("Set enabled or disabled of Geo Location to use for Coarse Relocalization.")]
    private bool geoLocationEnabled = true;
    public bool GeoLocationEnabled => geoLocationEnabled;

    [Header("wifi")]
    [SerializeField]
    [Tooltip("Set enabled or disabled of Wifi to use for Coarse Relocalization.")]
    private bool wifiEnabled = true;
    public bool WifiEnabled => wifiEnabled;

    [Header("Bluetooth")]
    [SerializeField]
    [Tooltip("Set enabled or disabled of Wifi to use for Coarse Relocalization.")]
    private bool bluetoothEnabled = true;
    public bool BluetoothEnabled => bluetoothEnabled;

    [SerializeField]
    [Tooltip("The BLE Beacon UUIDs to use for Coarse Relocalization.")]
    private string[] knownBeaconProximityUuids = new string[] { };
    public string[] KnownBeaconProximityUuids => knownBeaconProximityUuids;
}
