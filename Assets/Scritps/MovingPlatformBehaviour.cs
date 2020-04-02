using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformBehaviour : MonoBehaviour
{
    [SerializeField]
    private Transform _point_A, _point_B;
    private float _speed = 5f;
    private Vector3 _platform_Movement;





    void Start()
    {
        
    }

    void FixedUpdate()
    {

        if (transform.position == _point_A.position)
        {
            _platform_Movement = _point_B.position;
        }
        else if (transform.position == _point_B.position)
        { 
        _platform_Movement = _point_A.position;
        };

        transform.position = Vector3.MoveTowards(transform.position,_platform_Movement,_speed* Time.deltaTime);



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = this.transform;
            Debug.Log("triggered");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent = null;

        }
    }



}
