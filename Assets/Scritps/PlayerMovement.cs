using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController _characterController;
    [SerializeField]
    private float _moveSpeed, _jumpHeigth,_yMovement;
    [SerializeField]
    private float _gravity;
    private bool _doubleJump = false;
    private bool _hasJumped;
    private Vector3 movement;




    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame

        

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput , 0, 0) ;
         movement = direction * _moveSpeed;

        if (_characterController.isGrounded)
        {
            _hasJumped = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                _yMovement = _jumpHeigth;
                _doubleJump = true;
                _hasJumped = true;

            }

        }
        else
        {

            
            if (Input.GetKeyDown(KeyCode.Space) )
            {
                if (_doubleJump)
                {
                   // _yMovement = 0;
                    _yMovement = _jumpHeigth;
                    _doubleJump = false;
                    _hasJumped = true;
                }
                else
                {
                    if (!_hasJumped)
                    {
                       // _yMovement = 0;
                        _yMovement = _jumpHeigth;
                        _doubleJump = true;
                        _hasJumped = true;
                    }

                }
                

            }
            _yMovement -= _gravity;
            
        }

        movement.y = _yMovement;

        _characterController.Move(movement * Time.deltaTime);

        if (_characterController.transform.position.y < -6)
        {
            _characterController.transform.position = new Vector3(2, 3, transform.position.z);
        }

    }
    private void FixedUpdate()
    {
        
    }
}
