using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public GameObject grenadePrefab; // Префаб гранаты
    public Transform throwPoint; // Точка, откуда будет брошена граната
    public float throwForce = 40f; // Сила броска

    void Update()
    {
        // Проверка нажатия правой кнопки мыши (кнопка 1)
        if (Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }
    }

    // Метод для броска гранаты
    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.VelocityChange);
    }


}