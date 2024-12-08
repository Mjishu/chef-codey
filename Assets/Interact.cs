using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";
    public GameObject[] foodItems;

    public GameObject heldItem;
    public string heldItemName;

    public Stove stove;

    private bool isHolding = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!isHolding)
            {
                if (triggerName == "Bread")
                {
                    heldItem = Instantiate(foodItems[0], transform, false);
                    heldItem.transform.localPosition = new Vector3(0, 2, 2);
                    heldItem.transform.localScale = new Vector3(10, 10, 10);
                    heldItemName = "breadSlice";
                }
                else if (triggerName == "Tomatoes")
                {
                    heldItem = Instantiate(foodItems[1], transform, false);
                    heldItem.transform.localPosition = new Vector3(0, 2, 2);
                    heldItem.transform.localScale = new Vector3(10, 10, 10);
                    heldItemName = "tomato";
                }
                else if (triggerName == "Steak")
                {
                    heldItem = Instantiate(foodItems[2], transform, false);
                    heldItem.transform.localPosition = new Vector3(0, 2, 2);
                    heldItem.transform.localScale = new Vector3(10, 10, 10);
                    heldItemName = "steak";
                }
                isHolding = true;
            }
            else if (triggerName == "Stove")
            {
                if (heldItemName == "breadSlice")
                {
                    stove.MakeBurger();
                    isHolding = false;
                    Destroy(heldItem);
                    heldItemName = "";
                }
                else
                {
                    print("else was called");
                    if (stove.cookedFood == "burger")
                    {
                        print("food was cooked");
                        heldItem = Instantiate(foodItems[3], transform, false);
                        heldItem.transform.localPosition = new Vector3(0, 2, 2);
                        heldItem.transform.localScale = new Vector3(10, 10, 10);
                        heldItemName = "burger";
                        stove.CleanStove();
                    }
                }

            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
    }

    void OnTriggerExit(Collider other)
    {
        triggerName = "";
    }
}
