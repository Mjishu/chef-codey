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
        for (int i = 0; i < cookedFoods.Length; i++)
        {
            cookedFoods[i].SetActive(false);
        }
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

    public void MakeSoda()
    {
        cookedFoods[1].SetActive(true);
        cookedFood = "tomatoSoda";
    }

    public void CleanStove()
    {
        for (int i = 0; i < cookedFoods.Length; i++)
        {
            cookedFoods[i].SetActive(false);
        }
        cookedFood = "";
    }
}
