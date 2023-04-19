using System.Collections;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
     /// <summary>
     /// Spawns a barrel at the mouse pointer after 1 second
     /// </summary>
     public GameObject BarrelPrefab;
     
     public void SpawnBarrel()
     {
          StartCoroutine(SpawnBarrelWithDelay());
     }

     IEnumerator SpawnBarrelWithDelay()
     {
          yield return new WaitForSeconds(1f);
          Instantiate(BarrelPrefab, Hunter.Utility.GetMousePositionOnGroundPlane(), Quaternion.identity);
     }

     /// <summary>
     /// Sets the fire rate to 0.1 seconds
     /// </summary>
     public void SetFireRate()
     {
          WeaponsManager.Instance.fireRate = 0.1f;
     }
}
