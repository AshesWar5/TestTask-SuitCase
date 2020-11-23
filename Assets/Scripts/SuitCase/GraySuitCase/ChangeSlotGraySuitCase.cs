using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

using UnityEngine.UI;

public class ChangeSlotGraySuitCase :  BehaviourSaitCases
{
    [SerializeField] private GameObject resultGood, resultBad, Canvas;
    [SerializeField] private AudioClip goodAudio, errorAudio;
    [SerializeField] private GraphicRaycaster rightGraphycsRaycaster;
    private GraySuiteCase graySuiteCase;
    private Animator animator { get => GetComponent<Animator>(); }
    private AudioSource audioSource { get => GetComponent<AudioSource>(); }

    private void Start()
    {
        graySuiteCase = GetComponent<GraySuiteCase>();

    }



    public override void ChekingSlotsCollision() // Метод для проверки слотов на столкновение
    {
        for (int b = 0; b <= graySuiteCase.Items.Count; b++) // Перебираем List из скрипта GraySutCase
        {
            try
            {
                if (b >= graySuiteCase.Items.Count)
                {
                    if (rightGraphycsRaycaster.enabled == true)
                    {
                        rightGraphycsRaycaster.enabled = false;
                        ChekingSlotsCollision();
                    }
                    else
                    {
                        ChekingSlotsNotCollision();
                    }
                }
                var data = LetRaytoCheck(graySuiteCase.Items[b].transform.position); // Отправляем позицию Item(а) в метод пускания луча для проверки столкновения
                if (data.tag == "Item" && data.gameObject != graySuiteCase.Items[b].gameObject) // если луч попоал в предмет в слоте
                {
                    CreateResultIcon(true, graySuiteCase.Items[b].transform.position); // Создаём иконку столкновения
                    StartAudio(errorAudio);
                    break;
                }
            }
            catch
            {

            }
        }
    }



    

    public override void ChekingSlotsNotCollision() // Метод нужен для создания IconResult, что Item(ы) из скрипта RedSuitCase не столкнулись предметами
    {
        StartAudio(goodAudio);
        for (int b = 0; b <= graySuiteCase.Items.Count; b++) // Перебираем List из скрипта RedSutCase
        {
            CreateResultIcon(false, graySuiteCase.Items[b].transform.position); // Создаём иконку, что столкновения не было
        }
    }



    private void StartAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }



    private GameObject LetRaytoCheck(Vector2 position)
    {
        PointerEventData pointerEvent = new PointerEventData(EventSystem.current);
        List<RaycastResult> resultsRaycast = new List<RaycastResult>();
        pointerEvent.position = position;
        EventSystem.current.RaycastAll(pointerEvent, resultsRaycast);
        if (resultsRaycast.Count > 0)
        {
            print(resultsRaycast[0].gameObject.name);
            return resultsRaycast[0].gameObject;
        }
        return null;
    }


    private void StartAnimator(string nameAnimation, bool value)
    {
        animator.SetBool(nameAnimation, value);
    }


    private void CreateResultIcon(bool Iscollision, Vector2 Iconposition)
    {
        if (!Iscollision)
        {
            Instantiate(resultGood, Iconposition, Canvas);
        }
        else
        {
            Instantiate(resultBad, Iconposition, Canvas);
        }
    }


    private void Instantiate(GameObject spawnObject, Vector2 positionSpawn, GameObject setParentObject)
    {
        GameObject Instance = Instantiate(spawnObject, positionSpawn, Quaternion.identity);
        Instance.transform.SetParent(setParentObject.transform);
    }


    public IEnumerator AnimSaitCase()
    {
        StartAnimator("Close", true);
        yield return new WaitForSeconds(2f);
        StartAnimator("Invisible", true);
        ChekingSlotsCollision(); // Метод для проверки слотов на столкновение с другими предметами
    }
}