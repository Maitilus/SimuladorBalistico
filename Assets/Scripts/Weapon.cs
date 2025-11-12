using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    #region Variables
    [Range(50, 500)] public float f_FireForce;
    [Range(-45, 45)] public float f_Ptich;
    [Range(1, 10)] public float f_Mass;

    public Slider s_AngleSlider;
    [SerializeField] private Slider s_ForceSlider;
    public Slider s_MassSlider;

    [SerializeField] private GameObject g_ProjectilePrefab;
    [SerializeField] private Transform t_ProjectileSpawnPoint;

    #endregion


    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.F))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Instantiate(g_ProjectilePrefab, t_ProjectileSpawnPoint.position, t_ProjectileSpawnPoint.rotation);
    }

    #region CannonSliders

    public void SetCannonAngle()
    {
        transform.localRotation = Quaternion.Euler(s_AngleSlider.value + 90, 0, 0);
    }

    public void SetProjectileMass()
    {
        g_ProjectilePrefab.GetComponent<Rigidbody>().mass = s_MassSlider.value;
    }

    public void SetFireingForce()
    {
        f_FireForce = s_ForceSlider.value;
    }

    #endregion
}

