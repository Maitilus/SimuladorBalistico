using System.Collections;
using UnityEngine;
using UnityEngine.TextCore;

public class Projectile : MonoBehaviour
{
    #region Variables
    private Rigidbody rb;
    [SerializeField] private Weapon c_Weapon;
    private float f_FlightTime;
    private bool b_HasColided;

    #endregion
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        c_Weapon = GameObject.Find("Cannon").GetComponent<Weapon>();

        rb.AddForce(c_Weapon.f_FireForce * transform.forward, ForceMode.Impulse);

        StartCoroutine(ProjectileLife());
    }

    void Update()
    {
        f_FlightTime += Time.deltaTime;
    }

    private IEnumerator ProjectileLife()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!b_HasColided)
        {
            b_HasColided = true;
            Debug.Log($"Tiempo de vuelo: {f_FlightTime}");
            Debug.Log($"Coordenadas de colision: {collision.transform.position}");
        }
    }
}
