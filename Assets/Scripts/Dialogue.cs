using UnityEngine;

[System.Serializable]
public class Dialogue {
    public string name;
    public BoxChat[] chat;
}

[System.Serializable]
public class BoxChat
{
    public Sprite chatImg;
    [TextArea(3, 10)]
    public string sentences;
}
