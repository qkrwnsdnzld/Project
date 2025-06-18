using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform target; // 플레이어
    public Vector3 offset = new Vector3(0, 10, 0); // 위에서 보는 거리

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;
    }
}