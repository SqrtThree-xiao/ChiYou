using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour {

    Vector2 pos;
	// Use this for initialization
	void Start () {
        pos = gameObject.GetComponent<RectTransform>().position;

        RectTransform rect = gameObject.GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        //pos = new Vector2(pos.x + 15f * Time.deltaTime, pos.y);
        //gameObject.GetComponent<RectTransform>().position = pos;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("开始：" + collision.transform.name);
        var Vect3 = collision.transform.localScale;
        Vect3 += new Vector3(0.5f, 0.5f, 0.5f);
        collision.transform.localScale = Vector3.Lerp(collision.transform.localScale, Vect3, 0.3f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("结束：" + collision.transform.name);
        var Vect3 = collision.transform.localScale;
        Vect3 -= new Vector3(0.5f, 0.5f, 0.5f);
        collision.transform.localScale = Vector3.Lerp(collision.transform.localScale, Vect3, 0.3f);
    }
}
