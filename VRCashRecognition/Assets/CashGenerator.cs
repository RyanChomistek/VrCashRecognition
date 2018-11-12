using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashGenerator : MonoBehaviour {

    public GameObject CashPrefab;

	// Use this for initialization
	void Start ()
    {
        int cashNeeded = CashMachineController.Instance.targetAmount;
        var amounts = new int[] { 1,5,10,20 };
        while(cashNeeded > 0)
        {
            var cash = Instantiate(CashPrefab);
            int amt = amounts[(int)(Random.value * amounts.Length)];
            cash.GetComponentInChildren<Currency>().Amount = amt;
            cash.transform.position = this.transform.position;
            cashNeeded -= amt;
        }

    }
}
