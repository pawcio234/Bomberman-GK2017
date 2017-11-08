﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameOnClick : MonoBehaviour {

    public void QuitOnClick() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}