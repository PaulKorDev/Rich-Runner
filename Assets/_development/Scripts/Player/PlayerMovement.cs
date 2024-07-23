using System.Collections;
using System.Collections.Generic;
using UnityEngine

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerForwardSpeed;
    [SerializeField] private float _playerSlideSpeed;



    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += Vector3.forward * Time.deltaTime * _playerSpeed;
    }
    private void SlideMove()
    {
        if (Input.GetMouseButton(0))
        {

        }
    }
}
