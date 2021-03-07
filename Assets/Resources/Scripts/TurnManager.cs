using BattleTrinity.Interface;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleTrinity
{
    public class TurnManager : MonoBehaviour
    {
        private GameManager GameManager;

        public List<string> Actors;
        public int SelectedIndex;
        public IActor SelectedActor;

        public TURN_STATE state = TURN_STATE.TurnStart;

        public void SetSelectedActor(string name)
        {
            SelectedIndex = Actors.FindIndex(x => x == name);
            SelectedActor = GameObject.Find(Actors[SelectedIndex]).GetComponent<IActor>();
            GameManager.CameraManager.CenterTarget(SelectedActor.GameObject);
        }

        //Awake is called when the script instance is being loaded
        private void Awake()
        {
            //External components
            GameManager = (GameManager)GameObject.Find("GameManager").GetComponent("GameManager");

            Actors.Add("knight-01");
            Actors.Add("knight-02");
            Actors.Add("knight-03");
            SelectedIndex = 0;
        }

        // Start is called before the first frame update
        void Start()
        {
            SelectedActor = GameObject.Find(Actors[SelectedIndex]).GetComponent<IActor>();
        }

        // Update is called once per frame
        void Update()
        {
            switch (state)
            {
                case TURN_STATE.TurnStart:
                    CheckTurnStart();
                    break;
                case TURN_STATE.SelectTarget:
                    CheckSelectTarget();
                    break;
                case TURN_STATE.ChooseDirection:
                    CheckChooseDirection();
                    break;
                case TURN_STATE.MeasureDistance:
                    CheckMeasureDistance();
                    break;
                case TURN_STATE.Resolve:
                    CheckResolve();
                    break;
                case TURN_STATE.TurnEnd:
                    CheckTurnEnd();
                    break;
            }

           



        }

        private void CheckTurnStart()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SelectedIndex = (SelectedIndex < Actors.Count - 1) ? SelectedIndex + 1 : 0;
                SelectedActor = GameObject.Find(Actors[SelectedIndex]).GetComponent<IActor>();
                GameManager.CameraManager.CenterTarget(SelectedActor.GameObject);
            }
        }

        private void CheckSelectTarget()
        {
        }

        private void CheckChooseDirection()
        {
        }

        private void CheckMeasureDistance()
        {
        }

        private void CheckResolve()
        {
        }

        private void CheckTurnEnd()
        {
        }



    }
}