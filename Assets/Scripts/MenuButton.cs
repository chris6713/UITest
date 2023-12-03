using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    Image flash;
    [SerializeField]
    GameObject popup1;
    [SerializeField]
    GameObject popup2;
    
    // Start is called before the first frame update
    void Start()
    {
        flash.color = new Color(1, 1, 1, 0);
        popup1.SetActive(false);
        popup2.SetActive(false);
    }

    Sequence popup1goup_enter;
    Sequence popup2goup_enter;
    Sequence flashbutton_enter;
    Sequence popup1goup_exit;
    Sequence popup2goup_exit;
    Sequence flashbutton_exit;

    // this basically just flashes the button and folds out more menus at the top of the button - Chris
    public void OnPointerEnter(PointerEventData eventData)
    {
        DOTween.Kill(popup1goup_enter);
        DOTween.Kill(popup2goup_enter);
        DOTween.Kill(flashbutton_enter);

        flashbutton_enter = DOTween.Sequence();
        flashbutton_enter.Append(flash.DOColor(new Color(1, 1, 1, 1), 0.2f).SetEase(Ease.OutFlash));
        flashbutton_enter.Append(flash.DOColor(new Color(0.5f, 1f, 0.8f, 0.1f), 0.05f));

        popup1goup_enter = DOTween.Sequence();
        popup1goup_enter.AppendCallback(() => { popup1.SetActive(true); popup1.transform.localPosition = new Vector3(0, 76, 0); });
        popup1goup_enter.Append(popup1.transform.DOBlendableLocalMoveBy(new Vector3(0, 139, 0), 0.2f));

        popup2goup_enter = DOTween.Sequence();
        popup2goup_enter.AppendCallback(() => { popup2.SetActive(true); popup2.transform.localPosition = new Vector3(0, 76, 0); });
        popup2goup_enter.Append(popup2.transform.DOBlendableLocalMoveBy(new Vector3(0, 70, 0), 0.2f));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DOTween.Kill(popup1goup_exit);
        DOTween.Kill(popup2goup_exit);
        DOTween.Kill(flashbutton_exit);

        flashbutton_exit = DOTween.Sequence();
        flashbutton_exit.Append(flash.DOColor(new Color(0, 0, 0, 0), 0.2f).SetEase(Ease.OutElastic));

        popup1.SetActive(false);
        popup2.SetActive(false);
    }
}
