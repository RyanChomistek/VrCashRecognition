using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalletController : MonoBehaviour {
    public GameObject MoneySpot;
    public GameObject CashPrefab;
    int[] amounts = new int[] { 1, 5, 10, 20 };

    public List<int> MoneyInWallet;

    // Use this for initialization
    void Start () {
        /*
        int cashNeeded = CashMachineController.Instance.targetAmount;
        MoneyInWallet = new List<int>();
        while (cashNeeded > 0)
        {
            int amt = amounts[(int)(Random.value * amounts.Length)];
            cashNeeded -= amt;
            MoneyInWallet.Add(amt);
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerExit(Collider other)
    {
        /*
        var cash = Instantiate(CashPrefab);
        int amt = MoneyInWallet[0];
        MoneyInWallet.RemoveAt(0);
        cash.GetComponentInChildren<Currency>().Amount = amt;
        cash.transform.SetParent(MoneySpot.transform);
        cash.transform.localPosition = Vector3.zero;
        cash.transform.localRotation = Quaternion.identity;
        */
    }
}
