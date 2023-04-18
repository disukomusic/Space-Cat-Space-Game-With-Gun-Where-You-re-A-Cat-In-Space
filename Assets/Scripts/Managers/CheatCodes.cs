using System.Collections;
using UnityEngine;

public class CheatCodes : MonoBehaviour
{
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
}
