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
