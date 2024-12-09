using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public string triggerName = "";
    public GameObject[] foodItems;
    public GameObject[] cookedFoodItems;

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
                    PickUpItem(0, "breadSlice");
                }
                else if (triggerName == "Tomatoes")
                {
                    PickUpItem(1, "tomato");
                }
                else if (triggerName == "Steak")
                {
                    PickUpItem(2, "steak");
                }
                isHolding = true;
            }
            else if (triggerName == "Stove")
            {
                if (heldItemName == "breadSlice")
                {
                    stove.MakeBurger();
                    isHolding = false;
                    placeHeldItem();
                }
                else if (heldItemName == "tomato")
                {
                    stove.MakeSoda();
                    isHolding = false;
                    placeHeldItem();
                }
                else
                {
                    if (stove.cookedFood == "burger")
                    {
                        print("food was cooked");
                        PickUpItem(3, "burger");
                        stove.CleanStove();
                    }
                    else if (stove.cookedFood == "tomatoSoda")
                    {
                        print("making soda");
                        PickUpItem(4, "tomatoSoda");
                        stove.CleanStove();
                    }
                }

            }
            else if (triggerName == "Recievers")
            {
                if (heldItemName == "burger")
                {
                    placeHeldItem();
                    cookedFoodItems[0].SetActive(true);
                    isHolding = false;
                }
                if (heldItemName == "tomatoSoda")
                {
                    print("calling tomato soda");
                    placeHeldItem();
                    cookedFoodItems[1].SetActive(true);
                    isHolding = false;
                }
            }
        }
    }

    private void PickUpItem(int foodNumber, string itemName)
    {
        heldItem = Instantiate(foodItems[foodNumber], transform, false);
        heldItem.transform.localPosition = new Vector3(0, 2, 2);
        heldItem.transform.localScale = new Vector3(10, 10, 10);
        heldItemName = itemName;
    }

    private void placeHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
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
