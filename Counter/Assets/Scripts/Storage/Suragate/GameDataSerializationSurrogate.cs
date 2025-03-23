using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GameDataSerializationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        var ld = (GameData)obj;
        info.AddValue("counterData", ld.counterData);
        info.AddValue("groupName", ld.groupName);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        var ld = (GameData)obj;
        ld.counterData = (List<CounterData>)info.GetValue("counterData", typeof(List<CounterData>));
        ld.groupName = (List<string>)info.GetValue("groupName", typeof(List<string>));
        obj = ld;
        return obj;
    }
}
