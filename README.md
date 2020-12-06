# AzureSpatialAnchorsDemo

Multi platform build-ready project for Azure Spatial Anchors.

* Single project ready to build for UWP devices(HoloLens2 and HoloLens1), Andoroid devices and iOS devices, with platform changing only
* You can use Coarse Relocalization

## How to build
1. Dupliate MRTK.Tutorials.AzureSpatialAnchorsAssets/AzureSpatialAnchors.SDK/Resources/_SpatialAnchorsConfig to SpatialAnchorsConfig
2. Fill credentials  
![image](https://user-images.githubusercontent.com/530182/101269153-e9b93b80-37ae-11eb-8ad9-74d1e472e772.png)
3. Build to any platform.
  
### (Optional) settings for Coarse Relocalization via Bluetooth
3. Dupliate Assets/MRTK.Tutorials.AzureSpatialAnchors/Resources/_CoarseRelocalizationConfig to CoarseRelocalizationConfig
4. Append your beacons uuid  
![image](https://user-images.githubusercontent.com/530182/101269237-32252900-37b0-11eb-8009-9679478806f5.png)

### Known issues
* Building for Android, require modify below code manually  
```
Packages/com.unity.xr.arkit/Assets/Shaders/ARKitLWRPBackground.shader

40: #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
41: #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Color.hlsl"
```
Ref. https://forum.unity.com/threads/ar-foundation-shader-error-when-using-urp.815010/
* **Has'nt worked property Coarse Relocalization via Bluetooth on iOS devices on my environment... Help me...**

## How to Use
1. Adjust settings on Settings panel can use from "Settings" button on the main menu  
![image](https://user-images.githubusercontent.com/530182/101269414-0a36c500-37b2-11eb-9f16-971d79083728.png)
### With out Coarse Relocalization
2-1. Tap the "Save Spatial Anchors" button **without use all sensors**, If you already saved you can skip to 2-2  
Anchor ID will save to local storage, it will used for loading anchor until overwrite  
2-2. Tap the "Load Spatial Anchors" button **without use all sensors**  
Instruction video: https://youtu.be/eP1PYCXmRTg
### With Coarse Relocalization
3-1. Tap the "Save Spatial Anchors" button **with use any sensors**, If you already saved you can skip to 3-2  
3-2. Tap the "Load Spatial Anchors" button **with use any sensors**  
Instruction video: https://youtu.be/ZWn-HiUlDRI

## Notice for OSS
This project has using below project.
* microsoft/MixedRealityLearning  
https://github.com/microsoft/MixedRealityLearning/blob/development/LICENSE
* TakahiroMiyaura/AzureSpatialAnchorsSamplesOnMRTKV2  
https://github.com/TakahiroMiyaura/AzureSpatialAnchorsSamplesOnMRTKV2/blob/master/LICENSE  
Special thanks to Miyaura-san's post https://qiita.com/miyaura/items/f220b87d1df59c1a9ce6
