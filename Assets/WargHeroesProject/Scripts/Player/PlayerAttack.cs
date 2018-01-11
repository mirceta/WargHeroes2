using UnityEngine;
using System.Collections;


public class PlayerAttack : MonoBehaviour
{
    PlayerHealth playerHealth;
    GameObject player;
    // Reference to projectile prefab to shoot
    public GameObject projectile;
    public float power = 100.0f;
    private int coolDownTime = 0;
    private GameObject cube;

    // Sound effect on shooting 
    public AudioClip shootSFX;

   
    // Update is called once per frame
    void Update()
    {
        if(coolDownTime > 0)
        {
            coolDownTime--;
            return;
        }
        if(cube) cube.SetActive(true);
        if (Input.GetButtonDown("Fire1"))
        {
            if (projectile)
            {
                cube = GameObject.FindGameObjectWithTag("Cube");
                cube.SetActive(false);
                coolDownTime = 24;
                GameObject newProjectile = Instantiate(projectile, cube.transform.position + cube.transform.forward, cube.transform.rotation);
                player = GameObject.FindGameObjectWithTag("MainCamera");
                playerHealth = player.GetComponent<PlayerHealth>();

                if (!newProjectile.GetComponent<Rigidbody>())
                {
                    newProjectile.AddComponent<Rigidbody>();
                }

                Vector3 v1 =  150 * transform.forward;
                Vector3 v2 = cube.transform.position - transform.position;

                newProjectile.GetComponent<Rigidbody>().AddForce(-Vector3.Normalize(v2-v1) * power, ForceMode.VelocityChange);
                playerHealth.TakeDamage(50);

                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    {
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX,0.3f);
                    }
                    else
                    {
                        AudioSource.PlayClipAtPoint(shootSFX,newProjectile.transform.position,0.3f);
                    }
                }
                
            }
        }
    }
}
