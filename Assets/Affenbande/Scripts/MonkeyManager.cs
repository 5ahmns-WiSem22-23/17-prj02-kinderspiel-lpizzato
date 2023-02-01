using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonkeyManager : MonoBehaviour
{
    [SerializeField] List<GameObject> monkeys = new List<GameObject>();

    public Button btn;

    public GameObject[] turnText;

    int random;
    int a = 1;
    public int color1, color2, color3, color4;

    [SerializeField] float animationTime;
    [SerializeField] float buttonTime;

    [SerializeField] Vector3 finalPos1, finalPos2, finalPos3, finalPos4;

    string tagColor;

	void Start()
	{
        btn.onClick.AddListener(TaskOnClick);
        LeanTween.scale(turnText[0], new Vector3(0.6f, 0.6f, 0), 1f).setDelay(1f);
        LeanTween.scale(turnText[0], new Vector3(0, 0, 0), 0.5f).setDelay(3f);
    }

    public void TaskOnClick()
	{
        a++;
        Turn();

        if (IsInvoking("ReEnableButton"))
            return;

        btn.interactable = false;

        Invoke("ReEnableButton", buttonTime);

        random = Random.Range(0, monkeys.Count);

        tagColor = monkeys[random].tag;
        switch (tagColor)
        {
            case "Color1":
                color1++;
                GetAMonkey(finalPos1, color1);
                break;
            case "Color2":
                color2++;
                GetAMonkey(finalPos2, color2);
                break;
            case "Color3":
                color3++;
                GetAMonkey(finalPos3, color3);
                break;
            case "Color4":
                color4++;
                GetAMonkey(finalPos4, color4);
                break;
        }
    }

     void ReEnableButton()
    {
        btn.interactable = true;
    }

    void GetAMonkey(Vector3 position, int count)
    {
        GameObject color = monkeys[random];
        monkeys.RemoveAt(random);
        LeanTween.scale(color, new Vector3(0.25f, 0.25f, 0), animationTime);
        LeanTween.move(color, CountPosition(count, position), animationTime).setDelay(3f);
        LeanTween.scale(color, new Vector3(0.13f, 0.13f, 0), animationTime).setDelay(3f);
    }

    Vector3 CountPosition(int count, Vector3 pos)
    {
        switch (count)
        {
            case 1:
                break;
            case 2:
                pos.x += 1.79f;
                break;
            case 3:
                pos.x += 3.57f;
                break;
            case 4:
                pos.y -= 1.635f;
                break;
            case 5:
                pos.y -= 1.635f;
                pos.x += 1.79f;
                break;
            case 6:
                pos.y -= 1.635f;
                pos.x += 3.57f;
                break;
        }

        return pos;
    }

    void Turn()
    {
        switch (a)
        {
            case 1:
                LeanTween.scale(turnText[0], new Vector3(0.6f, 0.6f, 0), 1f).setDelay(6f);
                LeanTween.scale(turnText[0], new Vector3(0, 0, 0), 0.5f).setDelay(8f);
                break;
            case 2:
                LeanTween.scale(turnText[1], new Vector3(0.6f, 0.6f, 0), 1f).setDelay(6f);
                LeanTween.scale(turnText[1], new Vector3(0, 0, 0), 0.5f).setDelay(8f);
                break;
            case 3:
                LeanTween.scale(turnText[2], new Vector3(0.6f, 0.6f, 0), 1f).setDelay(6f);
                LeanTween.scale(turnText[2], new Vector3(0, 0, 0), 0.5f).setDelay(8f);
                break;
            case 4:
                LeanTween.scale(turnText[3], new Vector3(0.6f, 0.6f, 0), 1f).setDelay(6f);
                LeanTween.scale(turnText[3], new Vector3(0, 0, 0), 0.5f).setDelay(8f);
                a = 0;
                break;
        }

        if ((color1 ^ color2 ^ color3 ^ color4) == 6)
        {
            a = 5;
            btn.interactable = false;
        }
    }
}