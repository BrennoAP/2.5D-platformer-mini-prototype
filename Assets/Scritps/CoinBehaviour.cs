using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{

    private GameObject _player;
    private UiManager  _Uimanager;


    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _Uimanager = GameObject.Find("Canvas").GetComponent<UiManager>();
        if (_Uimanager == null)
        {
            Debug.LogError("Manager is Null");
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colidiu " + other);

        if (other.tag == "Player")
        {
            
           _Uimanager.SetScore();

        }
        
        GameObject.Destroy(this.gameObject);

    }

    



}
