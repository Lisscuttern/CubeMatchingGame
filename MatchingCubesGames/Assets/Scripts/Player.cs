using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region SerializFields

    [SerializeField] private GameSettings m_gameSettings;
    [SerializeField] private Rigidbody m_rb;
    [SerializeField] private List<GameObject> m_cubes = new List<GameObject>();
    [SerializeField] private PickerComponent m_pickerComponent;

    #endregion
    #region Private Fields

    private float lastMousePos;
    private float moveFactor;
    private float swerveAmount;
    

    #endregion

    #region Public Fields

    [Header("Same Color Cubes")]
    public List<GameObject> RedCubes;
    public List<GameObject> BlueCubes;
    public List<GameObject> YellowCubes;
    public List<GameObject> GreenCubes;
    public int index = 0;

    #endregion
    
    private void FixedUpdate()
    {
        VerticalMovement();
        HorizontalMovement();
    }
    
    void Update()
    {
        MouseInput();
        SameColorCubesControl();
        ClearCubeList();
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

    private void ClearCubeList()
    {
        for (int i = 0; i < m_cubes.Count; i++)
        {
            if (m_cubes[i] == null)
            { 
      
                m_cubes.RemoveAt(i);
                
            }

       
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
    /// This function help for destroy matching cubes
    /// </summary>
    private void SameColorCubesControl()
    {
        if (RedCubes.Count >= 3)
        {
            for (int i = 0; i < RedCubes.Count; i++)
            {
                Destroy(RedCubes[i].gameObject);
                m_pickerComponent.m_cubeHeight--;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                m_pickerComponent.transform.localPosition = new Vector3(m_pickerComponent.transform.localPosition.x,
                    m_pickerComponent.transform.localPosition.y + 1, m_pickerComponent.transform.localPosition.z);
            }
            RedCubes.Clear();
        }
        if (GreenCubes.Count >= 3)
        {
            for (int i = 0; i < RedCubes.Count; i++)
            {
                Destroy(RedCubes[i].gameObject);
                m_pickerComponent.m_cubeHeight--;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                m_pickerComponent.transform.localPosition = new Vector3(m_pickerComponent.transform.localPosition.x,
                    m_pickerComponent.transform.localPosition.y + 1, m_pickerComponent.transform.localPosition.z);
            }
            GreenCubes.Clear();
        }
        if (BlueCubes.Count >= 3)
        {
            for (int i = 0; i < RedCubes.Count; i++)
            {
                Destroy(RedCubes[i].gameObject);
                m_pickerComponent.m_cubeHeight--;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                m_pickerComponent.transform.localPosition = new Vector3(m_pickerComponent.transform.localPosition.x,
                    m_pickerComponent.transform.localPosition.y + 1, m_pickerComponent.transform.localPosition.z);
            }
            BlueCubes.Clear();
        }
        if (YellowCubes.Count >= 3)
        {
            for (int i = 0; i < RedCubes.Count; i++)
            {
                Destroy(RedCubes[i].gameObject);
                m_pickerComponent.m_cubeHeight--;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
                m_pickerComponent.transform.localPosition = new Vector3(m_pickerComponent.transform.localPosition.x,
                    m_pickerComponent.transform.localPosition.y + 1, m_pickerComponent.transform.localPosition.z);
            }
            YellowCubes.Clear();
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
