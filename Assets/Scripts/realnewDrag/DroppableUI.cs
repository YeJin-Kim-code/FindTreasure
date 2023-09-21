using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DroppableUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{
    private Image image;
    private RectTransform rect;



    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = Color.yellow;
    }
     
    public void OnDrop(PointerEventData eventData)
    {
        image.color = Color.white;
    }



    public void OnPointerExit(PointerEventData eventData)
    {
        //���� �巡���ϰ� �ִ� ���(=������)
        if(eventData.pointerDrag!=null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
    }
}
