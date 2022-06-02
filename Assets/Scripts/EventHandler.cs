using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.IO;

public class EventHandler : MonoBehaviour
{
    public TextMeshProUGUI chatbox;
    public TextMeshProUGUI speakerbox;
    public TextMeshProUGUI ch_1;
    public TextMeshProUGUI ch_2;
    public GameObject choice_list;
    public GameObject[] Buttons;
    public GameObject[] npcs;
    public GameObject[] npcs_locations;
    public GameObject text_box;
    public TextAsset Scene_1;
    public GameObject T_End;
    string[] read_act, read_opt;
    int c_lines = 0;
    int o_lines = 0;
    public Rt other;
    bool opt_on = false;
    // Start is called before the first frame update

    public void Show__Npc(string name)
    {
        foreach (GameObject item in npcs)
        {
            if (item.name == name)
            {
                item.SetActive(true);
                item.transform.position=npcs_locations[0].transform.position;
                break;
            }
        }
    }
   
    public void Flip_Abt()
    {
        Buttons[0].SetActive(true);
        Buttons[1].SetActive(true);
        Buttons[2].SetActive(false);
        Buttons[3].SetActive(false);
    }

    public void Flip_Bbt()
    {
        Buttons[0].SetActive(false);
        Buttons[1].SetActive(false);
        Buttons[2].SetActive(true);
        Buttons[3].SetActive(true);
    }

    public void TypeChat()
    {

        if (read_act[c_lines][0] == '%' )
        {
            T_End.SetActive(true);
            return;
        }

        if (other.Cr() == false)
        {
            string[] full_txt;
            if (opt_on)
            {              
                if (o_lines>=read_opt.Length)
                {
                    opt_on = false;
                    o_lines = 0;                   
                    return;
                }
                else
                {
                    full_txt = read_opt[o_lines].Split(':');                  
                }
            }
            else
            { 
              full_txt = read_act[c_lines].Split(':');             
            }
            
            string temp = full_txt[0];
            if (full_txt[0][0] == '/')
            {
                speakerbox.SetText(" ");
                Buttons[0].GetComponent<Button>().interactable = false;
                Buttons[1].GetComponent<Button>().interactable = false;
                Choices(temp);
                return;
            }
            else if (full_txt[0][0]=='>')
            {
                c_lines++;
                Show__Npc(read_act[c_lines].Trim());
                c_lines++;
                TypeChat();
                return;
            }
            speakerbox.SetText(full_txt[0].Trim());           
            chatbox.SetText(full_txt[1]);          
            Show__Npc(full_txt[0].Trim());
            other.Reveal();
            if(opt_on)
            {
                o_lines++;
            }
            else
            {
                c_lines++;
            }
        }
        else
        {
            Flip_Abt();
            //c_lines++;
            other.CR_running = false;
        }       
    }

    public void Previous_Txt()
    {
        if(c_lines>=2)
        {
            c_lines-=2;
           TypeChat();
        }
    }
    void Choices (string temp)
    {
        chatbox.SetText(" ");
        if (read_act[c_lines][0] == '/' && read_act[c_lines][1] == 'c')
        {
            choice_list.SetActive(true);
            c_lines++;                        
                if (read_act[c_lines][0] == '1')
                {
                    c_lines++;
                    ch_1.SetText(read_act[c_lines]);
                    c_lines++;
                }
                if (read_act[c_lines][0] == '2')
                {                    
                    c_lines++;
                    ch_2.SetText(read_act[c_lines]);
                    c_lines+=2;                 
                }
                opt_on = true; ;          
        }
            return;
    }

    public void Opt_A(int c)
    {
        choice_list.SetActive(false);    
            if(c==1)
            {
                if (read_act[c_lines][0] == '1')
                {                   
                    c_lines++;
                    read_opt = read_act[c_lines].Split('`');
                    c_lines++;                       
                }
            }
            if (c==2)
            {
                while (read_act[c_lines][0] != '2')
                {                
                    c_lines++;
                }
                if (read_act[c_lines][0] == '2')
                {
                    c_lines++;
                    read_opt = read_act[c_lines].Split('`');
                }
            }

            while (read_act[c_lines][0]!='*')
            {
                c_lines++;
            }
            c_lines++;
            TypeChat();
            Buttons[0].GetComponent<Button>().interactable = true;
            Buttons[1].GetComponent<Button>().interactable = true;
    }

    void Start()
    {
        choice_list.SetActive(false);
        read_act = Scene_1.text.Split('\n');    
        Flip_Bbt();
        TypeChat();       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(!choice_list.activeSelf)
            {
                if (other.Cr())
                {
                    Buttons[3].GetComponent<Button>().onClick.Invoke();
                }
                else
                {
                    Buttons[0].GetComponent<Button>().onClick.Invoke();
                }
            }
            
          
        }
        //Debug.Log(other.Cr());
    }
}
