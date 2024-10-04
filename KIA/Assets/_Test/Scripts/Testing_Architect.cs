using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TESTING
{

    public class Testing_Architect : MonoBehaviour
    {
        DialogueSystem ds;
        TextArchitect architect;
        public TextArchitect.BuildMethod bm = TextArchitect.BuildMethod.instant;

        string[] Lines = new string[5]{
            "This is a test of the writing", 
            "Testing the dialogue of our characters", 
            "Hello world", 
            "Hola mundo", 
            "KIA pls hire us we are pretty good"
        };

        // Start is called before the first frame update
        void Start()
        {
            ds = DialogueSystem.instance;
            architect = new TextArchitect(ds.dialogueContainer.dialogueText);
            architect.buildMethod = TextArchitect.BuildMethod.fade;
            //architect.speed = 0.5;
        }

        // Update is called once per frame
        void Update()
        {
            if(bm != architect.buildMethod){
                architect.buildMethod = bm;
                architect.Stop();
            }

            if(Input.GetKeyDown(KeyCode.S)){
                architect.Stop();
            }

            string longLine = "Hey guys, did you know that in terms of male human and female Pokémon breeding, Vaporeon is the most compatible Pokémon for humans?";
            if(Input.GetKeyDown(KeyCode.Space)){
                if(architect.isBuilding){
                    if(!architect.hurryUp){
                        architect.hurryUp = true;
                    } else{
                        architect.ForceComplete();
                      }
                } else{
                    architect.Build(longLine);
                    //architect.Build(Lines[Random.Range(0, Lines.Length)]);
                }
            } else if(Input.GetKeyDown(KeyCode.A)){
                architect.Append(longLine);
                //architect.Append(Lines[Random.Range(0, Lines.Length)]);
            }
        }
    }
}