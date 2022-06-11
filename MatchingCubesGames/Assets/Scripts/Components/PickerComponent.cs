using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PickerComponent : MonoBehaviour
{
    #region SerializFields

    [SerializeField] private GameObject m_player;
    [SerializeField] private Player m_playerScript;
    [SerializeField] private float m_speedUpValue;
    

    #endregion

    #region Public Fields

    public int m_cubeHeight;

    #endregion


    /// <summary>
    /// This function help for collect cube and after this update picker and player positions
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CommonTypes.TAG_CUBE)
        {
            m_playerScript.GetCubeList().Add(other.gameObject);
            other.transform.parent = m_player.transform;
            m_cubeHeight++;
            other.transform.localPosition = new Vector3(0,-m_cubeHeight,0);
            //other.GetComponent<BoxCollider>().enabled = false;
            //m_playerScript.Playerpos(1);
            m_playerScript.transform.position = new Vector3(m_playerScript.transform.position.x,m_playerScript.transform.position.y +1,m_playerScript.transform.position.z);
            PickerPos();
        }

        if (other.gameObject.tag == CommonTypes.TAG_SPEEDUP)
        {
            m_playerScript.speed = m_speedUpValue;
        }

        if (other.gameObject.tag == CommonTypes.TAG_JUMP)
        {
            m_playerScript.transform.DOJump(new Vector3(m_playerScript.transform.position.x, m_playerScript.transform.position.y, 163f),15,1,5f);
        }

        if (other.gameObject.tag == CommonTypes.TAG_RANDOM_GATE)
        {
            for (int i = 0; i < m_playerScript.m_cubes.Count; i++)
            {
                GameObject temp = m_playerScript.m_cubes[i];
               

                int index = Random.Range(0 , m_playerScript.m_cubes.Count);
                
                // m_playerScript.m_cubes[i] = m_playerScript.m_cubes[index];
                // m_playerScript.m_cubes[index] = temp;


                // m_playerScript.m_cubes[i].transform.localPosition = m_playerScript.m_cubes[index].transform.localPosition;
                // m_playerScript.m_cubes[index].transform.localPosition = temp.transform.localPosition;
            }
        }
    }
    
    /// <summary>
    /// This function update picker position
    /// </summary>
    private void PickerPos()
    {
        //transform.localPosition = new Vector3(0, -m_cubeHeight, 0);
        transform.localPosition = new Vector3(0, transform.localPosition.y - 1, 0);
    }
    
}
