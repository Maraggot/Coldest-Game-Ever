using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab; // ������ �������
    public Transform throwPoint; // �����, ������ ����� ������� �������
    public float throwForce = 40f; // ���� ������

    void Update()
    {
        // �������� ������� ������ ������ ���� (������ 1)
        if (Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }
    }

    // ����� ��� ������ �������
    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
    }


}