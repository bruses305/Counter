using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CounterDataSerializationSurrogate : ISerializationSurrogate
{
    public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
    {
        var ld = (CounterData)obj;
        info.AddValue("volume", ld._volume);
        info.AddValue("intensity", ld._intensity);
        info.AddValue("delay", ld._delay);
        info.AddValue("name", ld._name);
        info.AddValue("groupName", ld._groupName);
        info.AddValue("st", ld.st);
        info.AddValue("ID", ld.ID);
        info.AddValue("IDInMasive", ld.IDInMasive);
        info.AddValue("count", ld._count);
    }

    public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
    {
        var ld = (CounterData)obj;
        ld._volume = (float)info.GetValue("volume", typeof(float));
        ld._intensity = (float)info.GetValue("intensity", typeof(float));
        ld._delay = (float)info.GetValue("delay", typeof(float));
        ld._name = (string)info.GetValue("name", typeof(string));
        ld._groupName = (string)info.GetValue("groupName", typeof(string));
        ld.st = (List<int>)info.GetValue("st", typeof(List<int>));
        ld.ID = (int)info.GetValue("ID", typeof(int));
        ld.IDInMasive = (int)info.GetValue("IDInMasive", typeof(int));
        ld._count = (int)info.GetValue("count", typeof(int));
        obj = ld;
        return obj;
    }
}
