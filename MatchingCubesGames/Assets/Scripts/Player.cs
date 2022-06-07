using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region SerializFields

    [SerializeField] private GameSettings m_gameSettings;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private List<GameObject> m_cubes = new List<GameObject>();
    [SerializeField] private List<GameObject> m_targetCubes;

    #endregion
    #region Private Fields

    private float lastMousePos;
    private float moveFactor;
    private float swerveAmount;

    #endregion
    
    private void FixedUpdate()
    {
        VerticalMovement();
        HorizontalMovement();
    }
    
    void Update()
    {
        MouseInput();
        CubesColorControl();
    }

    /// <summary>
    /// This function help for get player finger input
    /// </summary>
    private void MouseInput()
    {
        if(Input.GetMouseButtonDown(0))
        {
            lastMousePos = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactor = Input.mousePosition.x - lastMousePos;
            lastMousePos = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactor = 0f;
        }
    }
    
    /// <summary>
    /// This function help for player horizontal movement
    /// </summary>
    private void HorizontalMovement()
    {
        swerveAmount = m_gameSettings.SwerveSpeed * moveFactor * Time.deltaTime;
        swerveAmount = Mathf.Clamp(swerveAmount, -m_gameSettings.MaxSwerveAmount, m_gameSettings.MaxSwerveAmount);
        transform.Translate(swerveAmount,0,0);
        if (transform.position.x < -m_gameSettings.VerticalMovementBorder)
        {
            transform.position = new Vector3(
                -m_gameSettings.VerticalMovementBorder, 
                transform.position.y, 
                transform.position.z);
        }
        if (transform.position.x > m_gameSettings.VerticalMovementBorder)
        {
            transform.position = new Vector3(
                m_gameSettings.VerticalMovementBorder, 
                transform.position.y, 
                transform.position.z);
        }
    }

    /// <summary>
    /// This function help for player vertical movement
    /// </summary>
    private void VerticalMovement()
    {
        m_rb.velocity = Vector3.forward * m_gameSettings.MoveSpeed;
    }

    
    /// <summary>
    /// This function control cubes color in cubeList
    /// </summary>
    private void CubesColorControl()
    {
        if (m_cubes.Count < 3)
            return;

        int matchCount = 0;
        
        for (int i = 0; i < m_cubes.Count; i++)
        {
            if (m_cubes[i].gameObject.GetComponent<CubeComponent>().GetColor() == m_cubes[i + 1].gameObject.GetComponent<CubeComponent>().GetColor())
            {
                matchCount += 1;
                m_targetCubes.Add(m_cubes[i + 1]);
                m_targetCubes.Add(m_cubes[i]);
            }
        }
    }
    
    /// <summary>
    /// this function help for update player position
    /// </summary>
    /// <param name="height"></param>
    public void Playerpos(int height)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
    }

    /// <summary>
    /// This function return cubes list
    /// </summary>
    /// <returns></returns>
    public List<GameObject> GetCubeList()
    {
        return m_cubes;
    }

}
