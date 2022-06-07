using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region SerializFields

    [SerializeField] private GameSettings m_gameSettings;
    [SerializeField] private Rigidbody m_rb;
     

    #endregion
    #region Private Fields

    private float lastMousePos;
    private float moveFactor;
    private float swerveAmount;

    #endregion
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
        Movement();
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
    private void Movement()
    {
        m_rb.velocity = Vector3.forward * m_gameSettings.MoveSpeed;
            
        swerveAmount = m_gameSettings.SwerveSpeed * moveFactor * Time.deltaTime;
        swerveAmount = Mathf.Clamp(swerveAmount, -m_gameSettings.MaxSwerveAmount, m_gameSettings.MaxSwerveAmount);
        transform.Translate(swerveAmount,0,0);
    }
}
