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

    public void OnDefendMessage()
    {
        string[] defendMessages =
        {
           "Yes! I didn't feel a thing!",
           "Hehe, it tickles!",
           "I feel invincible!",
           "Nice try, Mr. Plant!",
           "I put that equipment to good use!"
        };
        string outputMessage = defendMessages[Random.Range(0, defendMessages.Length)];
        NewThought(outputMessage);
    }

    public void OnBossMessage()
    {
        string[] bossMessages =
        {
           "Wow, he's huge!",
           "Ok, now here's a real challenge!",
           "Uh oh, now I've done it...",
           "Ok, I wasn't expecting this!",
           "Time to give it all I've got."
        };
        string outputMessage = bossMessages[Random.Range(0, bossMessages.Length)];
        NewThought(outputMessage);
    }

    public void OnBuffAttackMessage()
    {
        string[] buffMessages =
        {
           "That one felt powerful!",
           "This'll pack a punch!",
           "I feel strong!",
           "Take this, thorned beast!",
           "Let's deal some damage!"
        };
        string outputMessage = buffMessages[Random.Range(0, buffMessages.Length)];
        NewThought(outputMessage);
    }

    public void OnNetUseMessage()
    {
        string[] netMessages =
        {
           "Feeling trapped, fiend?",
           "Looks like you're stuck there!",
           "You look good with that net on!",
           "What's the matter, can't move?",
           "Good luck attacking me now!"
        };
        string outputMessage = netMessages[Random.Range(0, netMessages.Length)];
        NewThought(outputMessage);
    }

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