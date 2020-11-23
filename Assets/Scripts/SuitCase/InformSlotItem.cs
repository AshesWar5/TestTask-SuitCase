using UnityEngine;

public class InformSlotItem : MonoBehaviour // Скрипт сообщает слоту, что у него имеется предмет
{
    private void Start()
    {
        GetComponentInParent<Slots>().ItemtoSlot = gameObject;
    }
}