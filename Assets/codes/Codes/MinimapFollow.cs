using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    public Transform target; // �÷��̾�
    public Vector3 offset = new Vector3(0, 10, 0); // ������ ���� �Ÿ�

    void LateUpdate()
    {
        if (target != null)
            transform.position = target.position + offset;
    }
}