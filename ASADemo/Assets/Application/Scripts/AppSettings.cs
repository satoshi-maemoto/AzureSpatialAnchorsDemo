// Copyright (c) 2020 Satoshi Maemoto
// Released under the MIT license
// http://opensource.org/licenses/mit-license.php

using UnityEngine;

[CreateAssetMenu(menuName = "App/AppSettings")]
public class AppSettings : ScriptableObject
{
    public bool useGeoLocation = false;
    public bool useWifi = false;
    public bool useBluetooth = false;
    public bool visibleSpatialMapping = true;
    public bool visibleDebugButtons = false;
}
