using UnityEngine;
using UnityEngine.UI;

public class MonkeyManager : MonoBehaviour
{
	[SerializeField] GameObject[] monkeys;
	[SerializeField] Button btn;
	int random;
    [SerializeField] Text turnText;
    [SerializeField] float animationTime;

	void Start()
	{
        btn.onClick.AddListener(TaskOnClick);
	}

    // animate monkey in the middle
    // move it to spielbrett from it's color
    // sprites: spielbrett, monkey, button
    // button only activated when playing
    // two players one after each other? how?
    // reihenfolge wohin es gehen soll beim ziehen: position immer + 2 oder so
    // don't take monkey twice -> if number already chosen, don't choose again

    public void TaskOnClick()
	{
        random = Random.Range(0, monkeys.Length);

        if (monkeys[random].CompareTag("Color1"))
        {
            GetAMonkey(new Vector3(-4, 2, 0));

			// Debug.Log("random: " + random + ", Color1");
        }
        else if (monkeys[random].CompareTag("Color2"))
        {
            GetAMonkey(new Vector3(-4, -2, 0));

            // Debug.Log("random: " + random + ", Color2");
        }
        else if (monkeys[random].CompareTag("Color3"))
        {
            GetAMonkey(new Vector3(4, 2, 0));

            // Debug.Log("random: " + random + ", Color3");
        }
        else if (monkeys[random].CompareTag("Color4"))
        {
            GetAMonkey(new Vector3(-4, 2, 0));

            // Debug.Log("random: " + random + ", Color4");
        }
	}

    void GetAMonkey(Vector3 position)
    {
        GameObject color = monkeys[random].gameObject;
        // color.SetActive(true);
        LeanTween.scale(color, new Vector3(0.2f, 0.2f, 0), animationTime);
        LeanTween.move(color, position, animationTime).setDelay(4f);
        LeanTween.scale(color, new Vector3(0.13f, 0.13f, 0), 2f).setDelay(4f);
    }
}