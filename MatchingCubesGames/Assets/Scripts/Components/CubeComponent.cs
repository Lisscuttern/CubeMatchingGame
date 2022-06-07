using UnityEngine;

public class CubeComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private EColor _eColor;

    #endregion

    public EColor GetColor()
    {
        return _eColor;
    }
    
}
