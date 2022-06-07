using UnityEngine;

[CreateAssetMenu(menuName = "Default/GameSettings", fileName = "GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    [Header("Colors")]
    public Color BlueColor;
    public Color RedColor;
    public Color YellowColor;
    public Color GreenColor;

    [Header("Player")]
    public float SwerveSpeed;
    public float MaxSwerveAmount;
    public float MoveSpeed;
    public float VerticalMovementBorder;
    
    
    public Color GetColorByEColor(EColor eColor)
    {
        switch (eColor)
        {
            case EColor.BLUE:
                return BlueColor;
            case EColor.YELLOW:
                return YellowColor;
            case EColor.RED:
                return RedColor;
            case EColor.GREEN:
                return GreenColor;
                                   
        }

        return Color.white;
    }
}
