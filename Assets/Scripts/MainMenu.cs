/*
MIT License

Copyright (c) 2019 Tom Skarning

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    public GameObject blackFadeGO;
    public RawImage blackFade;
    public RawImage mainMenuBG;
    private Vector2 mainMenuBGOrigSize;
    private float imageSizeChange = 0.05f;

    // Start is called before the first frame update
    void Start() {
        blackFadeGO.SetActive(true);
        blackFade.CrossFadeAlpha(0, 5f, true);
        mainMenuBGOrigSize = mainMenuBG.rectTransform.sizeDelta;

        
    }

    // Update is called once per frame
    void Update() {
        //imageScaler(mainMenuBG);

        if (Input.GetKeyDown(KeyCode.Return)) {
            startGame();
        } if (Input.GetKeyDown(KeyCode.Escape)) {
            quitGame();
        }
    }

    void startGame() {
        Application.LoadLevel("Game");
    }

    void quitGame() {
        Application.Quit();
    }

    void imageScaler(RawImage image) {
        /*var i = 0;
        var up = true;
        var down = false;

        if (i <= 20) {
            mainMenuBG.rectTransform.sizeDelta = new Vector2(mainMenuBGOrigSize + imageSizeChange, mainMenuBGOrigSize + imageSizeChange);
            i++;
        } else {
            i--;
        }*/
    }
}
