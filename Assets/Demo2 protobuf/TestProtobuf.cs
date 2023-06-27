using ProtoBuf;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestProtobuf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        User user = new User();
        //user.ID = 123;
        //user.Username = "holyshit";
        //user.Password = "123456";
        //user.level = 190;
        //user._UserType = User.UserType.Master;

        ////FileStream fs = File.Create(Application.dataPath + "/user.bin");
        ////print(Application.dataPath + "/user.bin");
        ////Serializer.Serialize<User>(fs, user);
        ////fs.Close();
        //using (FileStream fs = File.Create(Application.dataPath + "/user.bin"))
        //{
        //    Serializer.Serialize<User>(fs, user);
        //}
        user = null;
        using (var fs = File.OpenRead(Application.dataPath + "/user.bin")) 
         {
            user = Serializer.Deserialize<User>(fs);
         }
        print(user.ID);
        print(user.Username);
        print(user.Password);
        print(user.level);
        print(user._UserType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
