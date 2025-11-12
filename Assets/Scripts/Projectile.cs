using System.Collections;
using UnityEngine;
using UnityEngine.TextCore;

public class Projectile : MonoBehaviour
{
    #region Variables
    private Rigidbody rb;
    [SerializeField] private Weapon c_Weapon;
    public float f_FlightTime;
    private bool b_HasColided;
    public PlayerScores playerScores;

    #endregion
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        c_Weapon = GameObject.Find("Cannon").GetComponent<Weapon>();

        rb.AddForce(c_Weapon.f_FireForce * transform.forward, ForceMode.Impulse);

        StartCoroutine(ProjectileLife());

        playerScores = GameObject.Find("ScoreManager").GetComponent<PlayerScores>();
    }

    void Update()
    {
        f_FlightTime += Time.deltaTime;
    }

    private IEnumerator ProjectileLife()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!b_HasColided)
        {
            b_HasColided = true;
            playerScores.UpdateScore();
            Debug.Log($"Tiempo de vuelo: {f_FlightTime}");
            Debug.Log($"Coordenadas de colision: {collision.transform.position}");
        }
    }
}
