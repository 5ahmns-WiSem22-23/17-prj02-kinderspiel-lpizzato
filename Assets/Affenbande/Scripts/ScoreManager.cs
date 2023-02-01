using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] MonkeyManager mm;
    [SerializeField] GameObject winText;
    [SerializeField] GameObject button;

    private void Update()
    {
        Win(ref mm.color1, new Vector3(-607f, 300f, 0));
        Win(ref mm.color2, new Vector3(-607f, -300f, 0));
        Win(ref mm.color3, new Vector3(607f, 300f, 0));
        Win(ref mm.color4, new Vector3(607f, -300f, 0));
    }

    void Win(ref int color, Vector3 pos)
    {
        if (color == 6)
        {
            GameObject win = Instantiate(winText, pos, Quaternion.identity);
            win.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            button.active = false;
            LeanTween.scale(win, new Vector3(0.6f, 0.6f, 0), 2f).setEase(LeanTweenType.easeOutBounce).setDelay(5f);
            color = 0;
        }
    }
}