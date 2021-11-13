using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private float _apperanceSpeed;
     
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Open()
    {
        StartCoroutine(ShowScreen());
    }

    private IEnumerator ShowScreen()
    {
        while(_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += _apperanceSpeed * Time.deltaTime;
            yield return null;
        }

        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}
