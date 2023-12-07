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

    // 캐릭터 이동
    private void Move()
    {
        // 오른쪽 이동
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1f, 0, 0) * Time.deltaTime * speed;
        }

        // 왼쪽 이동
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1f, 0, 0) * Time.deltaTime * speed;
        }

        // 위쪽 이동
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1f, 0) * Time.deltaTime * speed;
        }

        // 아래쪽 이동
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1f, 0) * Time.deltaTime * speed;
        }

        // 마우스 방향 바라보기
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
