using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PwF.Template
{
    class JsonStuff {

        public JsonStuff(){
            var character = JsonConvert.DeserializeObject<List<Objects.Character>>("json.file");
            var characterJson = JsonConvert.SerializeObject(character);
        }

    }
}
