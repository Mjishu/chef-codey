using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public GameObject[] cookedFoods;
    public string cookedFood = "";
    // Start is called before the first frame update
    void Start()
    {
        cookedFoods[0].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MakeBurger()
    {
        cookedFoods[0].SetActive(true);
        cookedFood = "burger";
    }

    public void CleanStove()
    {
        cookedFoods[0].SetActive(false);
        cookedFood = "";
    }
}
