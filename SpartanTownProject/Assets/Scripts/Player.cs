using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // ĳ���� �̵�
    private void Move()
    {
        // ������ �̵�
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * speed;
        }

        // ���� �̵�
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1f, 0, 0) * Time.deltaTime * speed;
        }

        // ���� �̵�
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1f, 0) * Time.deltaTime * speed;
        }

        // �Ʒ��� �̵�
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1f, 0) * Time.deltaTime * speed;
        }

        // ���콺 ���� �ٶ󺸱�
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(mousePos.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
