using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlNumber : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI number;
    // Start is called before the first frame update
   public void AddOne()
   {
     number.text=((int.Parse(number.text))+1).ToString();
   }

   public void RemoveOne()
   {
        number.text=((int.Parse(number.text))-1).ToString();
   }
}
