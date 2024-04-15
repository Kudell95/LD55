using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThoughtBubble : MonoBehaviour
{
    public Canvas ThoughtBubbleCanvas;
    public TextMeshProUGUI ThoughtText;
    // SpriteOriginPoint.transform.DOMoveY(0.5f, 1.5f).OnComplete(()=>{SpriteOriginPoint.transform.DOScaleY(0.9f,0.3f);}).SetLoops(-1,LoopType.Yoyo);
    [Header("Parameters")]
    [SerializeField] private float typingSpeed = 0.08f;
    [SerializeField] private float DisplayTime = 5f;

    private Coroutine DisplayLineCoroutine;
    public void NewThought(string message)
    {
        ThoughtBubbleCanvas.gameObject.SetActive(true);

        if (DisplayLineCoroutine != null)
        {
            StopCoroutine(DisplayLineCoroutine);
        }

        DisplayLineCoroutine = StartCoroutine(DisplayLine(message));

        StartCoroutine(DisplayTimer);
    }

    public void AnimateBubble()
    {

    }

    private IEnumerator DisplayTimer(string line)
    {
        yield return new WaitForSeconds(DisplayTime);
        ThoughtBubbleCanvas.gameObject.SetActive(true);

    }
    private IEnumerator DisplayLine(string line)
    {
        //remove dialogue text
        ThoughtText.text = "";

        //show each letter one at a time
        foreach(char letter in line.ToCharArray())
        {
            ThoughtText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    NewThought("Bacon Bacon :)");
        //}

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    NewThought("I need to stop these plants! What cards do I have?");
        //}
    }
}