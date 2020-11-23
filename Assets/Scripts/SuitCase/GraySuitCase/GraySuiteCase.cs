using System.Collections.Generic;

using UnityEngine;

public class GraySuiteCase : BehaviourSaitCases
{
    private List<GameObject> items = new List<GameObject>();

    private ChangeSlotGraySuitCase ChangeSlot;
    public List<GameObject> Items
    {
        get
        {
            return items;
        }
        private set
        {

        }
    }


    private void Start()
    {
        ChangeSlot = GetComponent<ChangeSlotGraySuitCase>();
    }
    public override void AddItem(GameObject item) // Метод добавляет Item(ы) в лист, которые нахохятся в слотах
    {
        for (int b = 0; b <= items.Count; b++)
        {
            if (b >= items.Count)
            {
                items.Add(item);
            }
            if (items[b].gameObject.name == item.name)
            {
                break;
            }
        }
    }

    public void GoButton()
    {
        StartCoroutine(ChangeSlot.AnimSaitCase());
    }
}