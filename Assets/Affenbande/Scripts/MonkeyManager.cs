using UnityEngine;
using UnityEngine.UI;

public class MonkeyManager : MonoBehaviour
{
	[SerializeField] GameObject[] monkeys;
	[SerializeField] Button btn;
	int random;

	void Start()
	{
		random = Random.Range(0, monkeys.Length);
        btn.onClick.AddListener(TaskOnClick);
	}

    public void TaskOnClick()
	{
        if (monkeys[random].CompareTag("Color1"))
        {
			Debug.Log("random: " + random + ", Color1");
        }
        else if (monkeys[random].CompareTag("Color2"))
        {
            Debug.Log("random: " + random + ", Color2");
        }
        else if (monkeys[random].CompareTag("Color3"))
        {
            Debug.Log("random: " + random + ", Color3");
        }
        else if (monkeys[random].CompareTag("Color4"))
        {
            Debug.Log("random: " + random + ", Color4");
        }
	}
}