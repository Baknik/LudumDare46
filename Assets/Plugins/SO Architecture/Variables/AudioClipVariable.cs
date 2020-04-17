using UnityEngine;

[CreateAssetMenu(
    fileName = "AudioClipVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Audio Clip",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 5)]
public sealed class AudioClipVariable : BaseVariable<AudioClip>
{
}