using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    CharacterController playerCC;//角色控制器
    [SerializeField]
    private float speed;

	void Start () {
        playerCC = transform.GetComponent<CharacterController>();//初始化
	}
	
	
	void Update () {
        Move();
	}
    void Move()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerCC.SimpleMove(new Vector3(0, 0, transform.position.z*speed));
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerCC.SimpleMove(new Vector3(0, 0, -transform.position.z * speed));
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerCC.SimpleMove(new Vector3(transform.position.x * speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerCC.SimpleMove(new Vector3(-transform.position.x * speed, 0, 0));
        }





    }



}
