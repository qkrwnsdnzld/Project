using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigid;

    float h;
    float v;
    bool isHorizonMove;

    Vector3 lookDirection = Vector3.right; // 기본 방향: 오른쪽

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        if (h != 0)
            isHorizonMove = true;
        else if (v != 0)
            isHorizonMove = false;

        if (h > 0)
            lookDirection = Vector3.right;
        else if (h < 0)
            lookDirection = Vector3.left;


        if (lookDirection == Vector3.right)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);
    }

    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        Vector2 nextPos = rigid.position + moveVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(nextPos);
    }
}