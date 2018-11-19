using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashGenerator : MonoBehaviour {

    public GameObject CashPrefab;

    public List<GameObject> SpawnPoints;

	// Use this for initialization
	void Awake ()
    {
        int cashNeeded = CashMachineController.Instance.targetAmount * 2;
        var amounts = new int[] { 1,5,10,20 };
        int cnt = 0;
        while(cashNeeded > 0)
        {
            var cash = Instantiate(CashPrefab);
            int amt = amounts[(int)(Random.value * amounts.Length)];
            cash.GetComponentInChildren<Currency>().Amount = amt;
            var spawnPointIndex = (cnt + SpawnPoints.Count) % SpawnPoints.Count;
            cash.transform.position = SpawnPoints[spawnPointIndex].transform.position;
            //cash.transform.Rotate(new Vector3(0, 1, 0), -15 * cnt);
            cashNeeded -= amt;
            cnt++;
        }

    }
}
