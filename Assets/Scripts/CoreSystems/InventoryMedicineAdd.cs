using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryMedicineAdd : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI myMedicine;

    [SerializeField]
    CoreBoolean handler;

    public void AddMedToInv()
    {
        string[] my_text = myMedicine.text.Split("\n");
        handler.AddToInventory(my_text[0]);
    }
    public void RemoveMedFromInv()
    {
        string[] my_text = myMedicine.text.Split("\n");
        handler.RemoveToInventory(my_text[0]);
    }
    // Start is called before the first frame update
    void Start()
    {
        handler = GameObject.FindGameObjectWithTag("Core").GetComponent<CoreBoolean>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
