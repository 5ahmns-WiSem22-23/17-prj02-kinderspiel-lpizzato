using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonkeyManager : MonoBehaviour
{
	// [SerializeField] GameObject[] monkeys;
    [SerializeField] List<GameObject> monkeys = new List<GameObject>();

    [SerializeField] Button btn;
    [SerializeField] Text turnText;

    int random;
    [SerializeField] int color1, color2, color3, color4;
    [SerializeField] float animationTime;
    [SerializeField] Vector3 finalPos1, finalPos2, finalPos3, finalPos4;

    string tagColor;

	void Start()
	{
        btn.onClick.AddListener(TaskOnClick);
	}

    // button only activated when playing
    // two players one after each other? how?
    // beginning: sprechblasen aus dem wald in der mitte
    // drag & drop monkey -> snap to position
    // menu

    public void TaskOnClick()
	{
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

    void GetAMonkey(Vector3 position, int count)
    {
        GameObject color = monkeys[random];
        monkeys.RemoveAt(random);
        LeanTween.scale(color, new Vector3(0.25f, 0.25f, 0), animationTime);
        LeanTween.move(color, CountPosition(count, position), animationTime).setDelay(4f);
        LeanTween.scale(color, new Vector3(0.13f, 0.13f, 0), animationTime).setDelay(4f);
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
}