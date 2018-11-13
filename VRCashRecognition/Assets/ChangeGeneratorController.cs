using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGeneratorController : MonoBehaviour {
    public static ChangeGeneratorController Instance;
    public GameObject CashPrefab;

    // Use this for initialization
    void Start () {
        Instance = this;

    }
	
    public void GenerateChange(int amountOfCashToGenerate)
    {
        int cashNeeded = amountOfCashToGenerate;
        var amounts = new int[] { 1, 5, 10, 20 };
        int cnt = 0;
        while (cashNeeded > 0)
        {
            var cash = Instantiate(CashPrefab);
            int amt = amounts[(int)(Random.value * amounts.Length)];
            cash.GetComponentInChildren<Currency>().Amount = amt;
            cash.transform.position = this.transform.position;
            //cash.transform.Rotate(new Vector3(0, 1, 0), -15 * cnt);
            cashNeeded -= amt;
            cnt++;
        }
    }

	
}
