using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ThoughtBubble : MonoBehaviour
{
    public Canvas ThoughtBubbleCanvas;
    public RectTransform ThoughtBubbleRectTransform;
    public TextMeshProUGUI ThoughtText;
    public Transform SpriteOriginPoint;

    [Header("Parameters")]
    [SerializeField] private float _typingSpeed = 0.08f;
    [SerializeField] private float _displayTimer = 3f;

    private Coroutine DisplayLineCoroutine;
    private Coroutine DisplayTimerCoroutine;

    public void Start()
    {
        ThoughtBubbleCanvas.gameObject.SetActive(false);
        AnimateBubble();
    }
    public void NewThought(string message)
    {
        ThoughtBubbleCanvas.gameObject.SetActive(true);
        

        if (DisplayLineCoroutine != null)
        {
            StopCoroutine(DisplayLineCoroutine);
        }

        DisplayLineCoroutine = StartCoroutine(DisplayLine(message));
    }

    public void AnimateBubble()
    {
        SpriteOriginPoint.transform.DOMoveY(0.02f, 0.3f).OnComplete(() => { SpriteOriginPoint.transform.DOScaleY(0.02f, 0.3f); }).SetLoops(-1, LoopType.Yoyo);
    }
    private IEnumerator DisplayLine(string line)
    {
        //remove dialogue text
        ThoughtText.text = "";

        //show each letter one at a time
        foreach(char letter in line.ToCharArray())
        {
            ThoughtText.text += letter;
            yield return new WaitForSeconds(_typingSpeed);
        }
        yield return new WaitForSeconds(_displayTimer);
        ThoughtBubbleCanvas.gameObject.SetActive(false);
    }

    //public void 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            NewThought("bacon bacon :)");
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            NewThought("i need to stop these plants! what cards do i have?");
        }
    }
}