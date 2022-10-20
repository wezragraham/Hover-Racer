using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerTracker : MonoBehaviour
{
    TextMeshProUGUI myText;

    
    GameObject tank;
    // Start is called before the first frame update
    void Start()
    {
        tank = this.gameObject.transform.parent.gameObject;
        myText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (tank.GetComponent<HoverTankController>().go == false)
        {
            myText.text = $"{tank.GetComponent<HoverTankController>().countdown}";
        }
        else if(tank.GetComponent<HoverTankController>().go == true)
        {
            myText.text = "";
        }
        else if (tank.GetComponent<HoverTankController>().finished == true)
        {
            myText.text = $"Finished!!! {tank.GetComponent<HoverTankController>().time}";
        }
    }
}
