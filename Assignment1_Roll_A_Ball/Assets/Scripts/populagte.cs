using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class populagte : MonoBehaviour
{

    public GameObject [] box;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostwait;
    public float spawnLeastWait;
    public int startWait;

    private int _randEnemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        IEnumerable waitSpawner() {
            yield return new WaitForSeconds (startWait);
            while (true)
            {
                _randEnemy = Random.Range(0, 2); 
                Vector3 spawnPosition =  new Vector3(Random.Range(-spawnValues.x, spawnValues.x),1, Random.Range(-spawnValues.z, spawnValues.z));

                Instantiate(box[_randEnemy], spawnPosition + transform.InverseTransformPoint(0, 0, 0), gameObject.transform.rotation);

                yield return new WaitForSeconds(1);
            } 

        }
            
    }
     
}
