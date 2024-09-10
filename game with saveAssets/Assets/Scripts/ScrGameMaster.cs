using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


using System.IO;

using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;
using JetBrains.Annotations;


public class ScrGameMaster : MonoBehaviour
{
    public GameObject PreviousItemInteracted = null;//var object interacted previously    
    public GameObject ItemHoldingNow; //var item holding now

    string filePath = Path.Combine(Application.streamingAssetsPath, "savegame.xml");


    //var key 1 = ClassGhostKey
    //var key 2

    //public List<GameObject> itemList;
    public Transform slv_player;
    public GameObject slv_smallbox;
    public GameObject slv_bigbox;
    public GameObject slv_ball;
    public GameObject slv_caixa_instrumental;



    // GameMaster will be holding flags
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {



            SaveGame slv_save_game = new SaveGame();

            slv_save_game.slv_pos_x = slv_player.position.x;
            slv_save_game.slv_pos_y = slv_player.position.y;
            slv_save_game.slv_pos_z = slv_player.position.z;


            slv_save_game.slv_smallbox_visible = slv_smallbox.GetComponent<MeshRenderer>().enabled;
            slv_save_game.slv_bigbox_visible = slv_bigbox.GetComponent<MeshRenderer>().enabled;
            slv_save_game.slv_smallbox_visible = slv_ball.GetComponent<MeshRenderer>().enabled;
            slv_save_game.slv_caixa_instrumental_visible = slv_caixa_instrumental.GetComponent<MeshRenderer>().enabled;






            print("p");//SAVE CALL GOES HERE
            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath);

                print(Directory.CreateDirectory(Application.streamingAssetsPath));
            }
            //if(!File.Exists(filePath)) 
            {
                
                XmlSerializer serializer = new XmlSerializer (typeof(SaveGame));
                StreamWriter streamWriter = new StreamWriter( filePath );
                serializer.Serialize( streamWriter.BaseStream , slv_save_game );
                streamWriter.Close();

                print("saved");
            }
           

        }
        else if(Input.GetKeyDown(KeyCode.L)) 
        {
            print("l");


            XmlSerializer serializer = new XmlSerializer(typeof(SaveGame));
            StreamReader reader = new StreamReader(filePath);
            SaveGame slv_saved_game = (SaveGame)serializer.Deserialize(reader.BaseStream);

            slv_player.position = new Vector3(slv_saved_game.slv_pos_x, slv_saved_game.slv_pos_y, slv_saved_game.slv_pos_z);


            slv_smallbox.GetComponent<MeshRenderer>().enabled = slv_saved_game.slv_smallbox_visible;
            slv_bigbox.GetComponent<MeshRenderer>().enabled = slv_saved_game.slv_bigbox_visible;
            slv_ball.GetComponent<MeshRenderer>().enabled = slv_saved_game.slv_smallbox_visible;
            slv_caixa_instrumental.GetComponent<MeshRenderer>().enabled = slv_saved_game.slv_caixa_instrumental_visible;


            slv_smallbox.GetComponent<Collider>().enabled = slv_saved_game.slv_smallbox_visible;
            slv_bigbox.GetComponent<Collider>().enabled = slv_saved_game.slv_bigbox_visible;
            slv_ball.GetComponent<Collider>().enabled = slv_saved_game.slv_smallbox_visible;
            slv_caixa_instrumental.GetComponent<Collider>().enabled = slv_saved_game.slv_caixa_instrumental_visible;

            reader.Close();

            
        }


    }

    public void MeshTurnOff(GameObject ItemToTurnOff)
    {
        
        
        
        ItemToTurnOff.GetComponent<MeshRenderer>().enabled = false;
        ItemToTurnOff.GetComponent<Collider>().enabled = false;


        ItemHoldingNow = ItemToTurnOff;

        //if(PreviousItemInteracted!=null&& PreviousItemInteracted!= ItemHoldingNow) PreviousItemInteracted.GetComponent<MeshRenderer>().enabled = true;
        PreviousItemInteracted = ItemToTurnOff;
        

    }



}





/*using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;
using JetBrains.Annotations;

public class Xml : MonoBehaviour
{

    string filePath = Path.Combine(Application.streamingAssetsPath, "usuarios.xml");

    public TextMeshProUGUI login;
    public TextMeshProUGUI senha;

    public void gravar()
    {
        //string filePath = Path.Combine(Application.streamingAssetsPath,"usuarios.xml");
        
        List<Usuario> lista = new List<Usuario>();

        Usuario usuario = new Usuario();
        usuario.login = login.text;
        usuario.senha = senha.text;

        print(usuario.login);

        lista.Add(usuario);

        if(!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);

            print(Directory.CreateDirectory(Application.streamingAssetsPath));
        }
        if(!File.Exists(filePath)) 
        {
            XmlSerializer serializer = new XmlSerializer (typeof(List<Usuario>));
            StreamWriter streamWriter = new StreamWriter( filePath );
            serializer.Serialize( streamWriter.BaseStream , lista );
            streamWriter.Close();
        }
        else
        {

            XmlSerializer serializer = new XmlSerializer (typeof(List<Usuario>));
            StreamReader reader = new StreamReader( filePath );
            List<Usuario> listaDeserializada = (List<Usuario>)serializer.Deserialize( reader.BaseStream );
            reader.Close();
            
            foreach (Usuario item in listaDeserializada) 
            {
                if(usuario.login == item.login) 
                {
                    print("ousuario " + usuario.login + " ja possui cadastro");
                    return; //encerra o metodo 'gravar' 
                }
            }
            listaDeserializada.Add(usuario);

            StreamWriter writer= new StreamWriter( filePath );
            serializer.Serialize(writer.BaseStream, listaDeserializada );
            writer.Close(); 
                        
        }

    }

    public void excluir()
    {
        File.Delete(filePath);
    }

    public void read()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Usuario>));
        StreamReader reader = new StreamReader( filePath );
        List<Usuario> usuario = (List<Usuario>)serializer.Deserialize( reader.BaseStream );
        reader.Close();

        foreach (Usuario item in usuario ) 
        {
            print (item.login);
        }
    }




   
}
*/