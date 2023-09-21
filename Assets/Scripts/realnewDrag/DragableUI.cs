using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private Transform previousParent;
    private RectTransform rect;
    private CanvasGroup canvasGroup;



    // Start is called before the first frame update

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

     public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;//�巡�� ������ �ҼӵǾ��ִ� �θ� transform�� ��������

        //���� �巡������ ui�� ȭ���� �ֻ�ܿ� ��µǵ��� �ϱ�����
        transform.SetParent(canvas);//�θ� ������Ʈ�� canvas�� ����
        transform.SetAsLastSibling(); //���� �տ� ���̵��� ������ �ڽ����� ����

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;
        }

        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }   
}
