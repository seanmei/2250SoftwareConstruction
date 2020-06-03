using System.Collections;
using UnityEngine;

public class Gun1 : Gun
{

    void OnEnable()
	{
        isReloading = false;
        animator.SetBool("Reloading", false);
	}
 
    public override void Shoot()
    {
        flash.Play();

        currentAmmo--; 
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //checks if in range of weapon
        {    //checks if should shoot array
            Debug.Log(hit.transform.name);
            Enemy enemy = hit.transform.GetComponent<Enemy>(); //gets enemy 
            if (enemy != null)//checks if hit 
            {
                enemy.TakeDamage(damage); //removes enemy 
            }
        }
    }

    protected override IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloadng...");

        animator.SetBool("Reload", true);

        yield return new WaitForSeconds(reloadTIme -.25f);

     

        if (bullets >= maxAmmo) 
        {
            bullets -= maxAmmo;
            currentAmmo = maxAmmo;
        }
        if (bullets < maxAmmo)
        {
            Debug.Log("low");
            currentAmmo = bullets;
            bullets = 0;
        }

        currentAmmo = maxAmmo;
        isReloading = false;
        animator.SetBool("Reload", false);
        yield return new WaitForSeconds(.25f);

    }



}
 