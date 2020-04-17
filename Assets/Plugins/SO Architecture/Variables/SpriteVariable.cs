using UnityEngine;

[CreateAssetMenu(
    fileName = "SpriteVariable.asset",
    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Sprite",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 5)]
public sealed class SpriteVariable : BaseVariable<Sprite>
{
}