using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerComponent : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private Player m_playerScript;
    [SerializeField] private List<GameObject> m_cube = new List<GameObject>();
    [SerializeField] private int m_cubeHeight;
    private bool isCollectCube = false;
    
    /// <summary>
    /// This function help for collect cubes 
    /// </summary>
    private void CollectCube()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == CommonTypes.TAG_CUBE)
        {
            isCollectCube = true;
            m_cube.Add(other.gameObject);
            other.transform.parent = m_player.transform;
            m_cubeHeight++;
            other.transform.localPosition = new Vector3(0,-m_cubeHeight,0);
            other.GetComponent<BoxCollider>().enabled = false;
            m_playerScript.Playerpos(1);
            PickerPos();
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == CommonTypes.TAG_CUBE)
        {
            isCollectCube = false;
        }
    }

    private void PickerPos()
    {
        transform.localPosition = new Vector3(0, -m_cubeHeight, 0);
    }

    /// <summary>
    /// This function return height
    /// </summary>
    /// <returns>m_cubeHeight</returns>
    public int GetCubeHeight()
    {
        return m_cubeHeight;
    }

    /// <summary>
    /// This function return isCollectCube
    /// </summary>
    /// <returns>isCollectCube</returns>
    public bool GetCollectCube()
    {
        return isCollectCube;
    }
}
