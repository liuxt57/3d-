using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySpace
{
    public class UserGUI : MonoBehaviour
    {     
        private IUserAction action;       
        private GUIStyle buttonStyle;
        private GUIStyle textStyle;
        public CharacterController characterController;
        public int status;

        void Start()
        {
            status = 0;
            action = Director.GetInstance().CurrentSecnController as IUserAction;
        }

        void OnGUI()
        {
            textStyle = new GUIStyle
            {
                fontSize = 40,
                alignment = TextAnchor.MiddleCenter
            };
            
            buttonStyle = new GUIStyle("Button")
            {
                fontSize = 20
            };     
            
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 250, 100, 50), "Priest And Devil", textStyle);
            
            if (GUI.Button(new Rect(Screen.width / 2 - 50, 100, 100, 60), "Restart", buttonStyle))
            {
                status = 0;
                action.Restart();
            }
            if (status != 1 && status != 0)
            {
                //游戏结束
                GUI.Label(new Rect(Screen.width / 2 - 50, 200, 100, 50), "You Lose!", textStyle);

            }
            if (status == 1)
            {
                GUI.Label(new Rect(Screen.width / 2 - 50, 200, 100, 50), "You Win!", textStyle);

            }
        }
        public void SetCharacterCtrl(CharacterController _cc)
        {
            characterController = _cc;
        }

        public void OnMouseDown()
        {
            if (gameObject.name == "boat")
            {
                action.MoveBoat();
            }
            else
            {
                action.CharacterClicked(characterController);
            }
        }
    }
}