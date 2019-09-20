using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTests.Examples
{
    [DataContract(Name = "JSON_SerializingClassName")]
    class SerializedClassExample
    {
        [DataMember(IsRequired = true, Name = "L", Order = 1)]
        string member2;
        [DataMember(EmitDefaultValue = true, IsRequired = true, Name = "L", Order = 1)]
        string member3;
        string member4;

        [OnSerializing()]
        internal void OnSerializingMethod(StreamingContext context)
        {
            member2 = "This value went into the data file during serialization.";
        }

        [OnSerialized()]
        internal void OnSerializedMethod(StreamingContext context)
        {
            member2 = "This value was reset after serialization.";
        }

        [OnDeserializing()]
        internal void OnDeserializingMethod(StreamingContext context)
        {
            member3 = "This value was set during deserialization";
        }

        [OnDeserialized()]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            member4 = "This value was set after deserialization.";
        }
    }
}
