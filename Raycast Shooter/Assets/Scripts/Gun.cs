using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    private float fireRate = 15f;
    private float impactForce = 30f;
    private float nextTimeToFire = 0f;

    [SerializeField] Camera fpsCamera;
    [SerializeField] ParticleSystem gunFlash;
    [SerializeField] ParticleSystem impactEffect;
    
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1") && Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
	}

    private void Shoot()
    {

        gunFlash.Play();

        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)){
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            ParticleSystem impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO.gameObject, .7f);
        }
    }

}
