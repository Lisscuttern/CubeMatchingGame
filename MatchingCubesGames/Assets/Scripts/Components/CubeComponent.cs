using UnityEngine;

public class CubeComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private EColor _eColor;
    [SerializeField] private Player m_player;

    #endregion

    public EColor GetColor()
    {
        return _eColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            CubeComponent cubeComponent = other.GetComponent<CubeComponent>();
            if (cubeComponent.GetColor() == EColor.RED)
            {
                if (GetColor() == cubeComponent.GetColor())
                {
                    if (m_player.RedCubes.Contains(this.gameObject) && !m_player.RedCubes.Contains(other.gameObject))
                    {
                        m_player.RedCubes.Add(other.gameObject);
                    }
                    
                    if (!m_player.RedCubes.Contains(this.gameObject) && m_player.RedCubes.Contains(other.gameObject))
                    {
                        m_player.RedCubes.Add(this.gameObject);
                    }

                    if (!m_player.RedCubes.Contains(this.gameObject) && !m_player.RedCubes.Contains(other.gameObject))
                    {
                        m_player.RedCubes.Add(this.gameObject);
                        m_player.RedCubes.Add(other.gameObject);
                    }
                }
            }
            if (cubeComponent.GetColor() == EColor.BLUE)
            {
                if (GetColor() == cubeComponent.GetColor())
                {
                    if (m_player.BlueCubes.Contains(this.gameObject) && !m_player.BlueCubes.Contains(other.gameObject))
                    {
                        m_player.BlueCubes.Add(other.gameObject);
                    }
                    
                    if (!m_player.BlueCubes.Contains(this.gameObject) && m_player.BlueCubes.Contains(other.gameObject))
                    {
                        m_player.BlueCubes.Add(this.gameObject);
                    }

                    if (!m_player.BlueCubes.Contains(this.gameObject) && !m_player.BlueCubes.Contains(other.gameObject))
                    {
                        m_player.BlueCubes.Add(this.gameObject);
                        m_player.BlueCubes.Add(other.gameObject);
                    }
                }
            }
            if (cubeComponent.GetColor() == EColor.GREEN)
            {
                if (GetColor() == cubeComponent.GetColor())
                {
                    if (m_player.GreenCubes.Contains(this.gameObject) && !m_player.GreenCubes.Contains(other.gameObject))
                    {
                        m_player.GreenCubes.Add(other.gameObject);
                    }
                    
                    if (!m_player.GreenCubes.Contains(this.gameObject) && m_player.GreenCubes.Contains(other.gameObject))
                    {
                        m_player.GreenCubes.Add(this.gameObject);
                    }

                    if (!m_player.GreenCubes.Contains(this.gameObject) && !m_player.GreenCubes.Contains(other.gameObject))
                    {
                        m_player.GreenCubes.Add(this.gameObject);
                        m_player.GreenCubes.Add(other.gameObject);
                    }
                }
            }
            if (cubeComponent.GetColor() == EColor.YELLOW)
            {
                if (GetColor() == cubeComponent.GetColor())
                {
                    if (m_player.YellowCubes.Contains(this.gameObject) && !m_player.YellowCubes.Contains(other.gameObject))
                    {
                        m_player.YellowCubes.Add(other.gameObject);
                    }
                    
                    if (!m_player.YellowCubes.Contains(this.gameObject) && m_player.YellowCubes.Contains(other.gameObject))
                    {
                        m_player.YellowCubes.Add(this.gameObject);
                    }

                    if (!m_player.YellowCubes.Contains(this.gameObject) && !m_player.YellowCubes.Contains(other.gameObject))
                    {
                        m_player.YellowCubes.Add(this.gameObject);
                        m_player.YellowCubes.Add(other.gameObject);
                    }
                }
            }
        }
    }
}