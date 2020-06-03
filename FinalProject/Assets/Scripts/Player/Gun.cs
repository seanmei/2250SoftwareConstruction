using UnityEngine;
using System.Collections;

public abstract class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100;

    public ParticleSystem flash;

    public Camera fpsCam;

    static public int bullets = 50 ; //total bullets on your person
    public int maxAmmo = 10; //clip size
    public int currentAmmo;  //ammo left
    public float reloadTIme = 3f;
    public bool isReloading = false;

    public Animator animator;


    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if(currentAmmo <= 0 && bullets >0) 
        {
            StartCoroutine(Reload());
            return;
        }


        if (Input.GetButtonDown("Fire1") && currentAmmo>0)
        {
            Shoot();

        }
    }

    public virtual void Shoot()
    {
  
    }


    protected virtual IEnumerator Reload()
    {
       

        yield return new WaitForSeconds(reloadTIme);

      
    }



}
 