using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameTxt;
    public TextMeshProUGUI msjTxt;
    public Image chatIMG;
    public Animator anim;

    public GameObject[] menus;

    public static DialogueManager instance;
    private Queue<BoxChat> sentences;
    
    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        sentences = new Queue<BoxChat>();
        menus[0].SetActive(false);
        menus[1].SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue) {
        anim.SetBool("IsOpen", true);
        nameTxt.text = dialogue.name;
        sentences.Clear();

        foreach (BoxChat sentence in dialogue.chat) {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    
    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }
        BoxChat sentence = sentences.Dequeue();

        if (sentence.chatImg != null) {
            chatIMG.gameObject.SetActive(true);
            chatIMG.sprite = sentence.chatImg;
        }
        else {
            chatIMG.gameObject.SetActive(false);
            Debug.Log("No Hay imagen ext");
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence.sentences));        
    }

    private IEnumerator TypeSentence(string sentence) {
        msjTxt.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            msjTxt.text += letter;
            yield return null;
        }
    }

    private void EndDialogue() {
        chatIMG.gameObject.SetActive(false);
        Debug.Log("End of Conversation");
        anim.SetBool("IsOpen", false);
        menus[0].SetActive(false);
        menus[1].SetActive(true);
    }
}
