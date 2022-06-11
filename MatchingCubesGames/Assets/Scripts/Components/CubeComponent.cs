using System;
using UnityEngine;

public class CubeComponent : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private EColor _eColor;
    [SerializeField] private Player m_player;
    [SerializeField] private PickerComponent m_pickerComponent;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private TrailRenderer m_trailRenderer;
    #endregion

    private void Start()
    {
        gameSettings.GetColorByEColor(_eColor);
    }

    public EColor GetColor()
    {
        return _eColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CommonTypes.TAG_CUBE)
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
            if (other.gameObject.GetComponent<CubeComponent>().GetColor() == EColor.BLUE)
            {
                if (GetColor() == other.gameObject.GetComponent<CubeComponent>().GetColor())
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

        if (other.gameObject.tag == CommonTypes.TAG_TRAP)
        {
            m_player.transform.position =
                (new Vector3(m_player.transform.position.x, m_player.transform.position.y - 1, m_player.transform.position.z));

            transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
            m_pickerComponent.transform.localPosition = new Vector3(
                m_pickerComponent.transform.localPosition.x,
                m_pickerComponent.transform.localPosition.y + 1, 
                m_pickerComponent.transform.localPosition.z);
            m_pickerComponent.m_cubeHeight--;
            Destroy(gameObject);
            other.GetComponent<BoxCollider>().enabled = false;
        }

        if (other.gameObject.tag == CommonTypes.TAG_GROUND)
        {
            m_trailRenderer.emitting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == CommonTypes.TAG_GROUND)
        {
            m_trailRenderer.emitting = false;
        }
    }
}