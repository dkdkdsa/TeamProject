using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSetter : MonoBehaviour
{

    [SerializeField] private Texture2D cursorTexture;

    private void Awake()
    {

        Cursor.SetCursor(cursorTexture, Vector2.down, CursorMode.Auto);

    }


}
