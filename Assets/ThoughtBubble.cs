using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ThoughtBubble : MonoBehaviour
{
	public static ThoughtBubble Instance;
	public Canvas ThoughtBubbleCanvas;
	public RectTransform ThoughtBubbleRectTransform;
	public TextMeshProUGUI ThoughtText;
	public Transform SpriteOriginPoint;

	[Header("Parameters")]
	[SerializeField] private float _typingSpeed = 0.06f;
	[SerializeField] private float _displayTimer = 3f;

	private Coroutine DisplayLineCoroutine;
	
	private void Awake() {
		if(Instance == null)
			Instance = this;
		else
			Destroy(this);
			
			
		ThoughtBubbleCanvas.gameObject.SetActive(false);
		AnimateBubble();
	}

	public void Start()
	{
		
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
		SpriteOriginPoint.transform.DOLocalMoveY(0.02f, 0.3f).OnComplete(() => { SpriteOriginPoint.transform.DOScaleY(0.02f, 0.3f); }).SetLoops(-1, LoopType.Yoyo);
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
		   "Wow, he's huge! Look's like a plant boss!",
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
		   "I feel strong... and handsome too!",
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

	public void OnPlayerClickMessage()
	{
		string[] playerClickMessages =
		{
		   "Please don't click me...",
		   "Come on, stay focused!",
		   "Can't you see I'm busy here?",
		   "Seriously? Now's not the time, dude.",
		   "Quite curious, aren't you?"
		};
		string outputMessage = playerClickMessages[Random.Range(0, playerClickMessages.Length)];
		NewThought(outputMessage);
	}

	public void OnStartPlayerMessage()
	{
		string[] playerStartMessages =
		{
		   "These plants have got to go!",
		   "Time to summon some tools!",
		   "And I thought I retired from summoning...",
		   "It's about time I dusted off the ol' book!",
		   "I'll show you what it really means to garden!"
		};
		string outputMessage = playerStartMessages[Random.Range(0, playerStartMessages.Length)];
		NewThought(outputMessage);
	}

    public void OnPlayerHitMessage()
    {
        string[] playerHitMessages =
        {
           "Ouch, that hurt!",
           "Ooh! I felt that one!",
           "Grr! The flesh is weak but the soul continues on!",
           "Darn! You'll pay for that!",
           "I must.. *Argh*.. go on..."
        };
        string outputMessage = playerHitMessages[Random.Range(0, playerHitMessages.Length)];
        NewThought(outputMessage);
    }

    public void OnLegendaryAttackMessage()
    {
        string[] legendaryAttackMessages =
        {
           "65cc's of mechanical power!",
           "Oh... heck yeah! My favourite tool.",
           "This is going to hurt you.. A LOT!",
           "Aha.. HA HA HA HA HA HA",
           "Now this is gardening! Brr! Vroom!"
        };
        string outputMessage = legendaryAttackMessages[Random.Range(0, legendaryAttackMessages.Length)];
        NewThought(outputMessage);
    }

    public void OnFinalBossMessage()
    {
        string[] finalBossMessages =
        {
           "He looks tough, time to finish this!",
           "Oh boy, this job might be beyond the scope of a gardener...", // wanted this to be more likely to pop up.
           "This job might be beyond the scope of a gardener...",
           "Oh boy, this job might be beyond the scope of a gardener...",
           "Time to end this, right here and now!",
           "Come on then, if you think you're tough enough!",
           "I'll show you what it really means to garden!"
        };
        string outputMessage = finalBossMessages[Random.Range(0, finalBossMessages.Length)];
        NewThought(outputMessage);
    }

    public void OnMissMessage()
    {
        string[] missMessages =
        {
           "Whoops, must be my old fingers!",
           "I missed? I am really out of practice.",
           "Did I mention I was retired?",
           "Uhh... That was a warning shot!",
           "Ok, ok.. maybe we can negotiate?",
           "I don't know what you expected from an old man..."
        };
        string outputMessage = missMessages[Random.Range(0, missMessages.Length)];
        NewThought(outputMessage);
    }

    public void OnNoManaMessage()
    {
        string[] noManaMessages =
        {
           "I don't have enough mana!",
           "I'm all out of mana for that one...", 
           "In my old age, mana is a virtue.",
           "Why didn't I buy the 'no mana required' compendium?",
           "Look, I'm old. Mana is akin to mojo these days...",
           "Ok, ok.. maybe we can negotiate?"
        };
        string outputMessage = noManaMessages[Random.Range(0, noManaMessages.Length)];
        NewThought(outputMessage);
    }
}