using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletController : MonoBehaviour {
    public GameObject MoneySpot;
    public GameObject CashPrefab;
    int[] amounts = new int[] { 1, 5, 10, 20 };

    // Use this for initialization
    void Start () {
        int cashNeeded = CashMachineController.Instance.targetAmount;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerExit(Collider other)
    {
        
        var cash = Instantiate(CashPrefab);
        int amt = amounts[(int)(Random.value * amounts.Length)];
        cash.GetComponentInChildren<Currency>().Amount = amt;
        cash.transform.position = this.transform.position;
        
        //Debug.Log("exit " + other.name);
    }
}
