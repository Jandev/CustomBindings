using System;
using System.Runtime.Serialization;

namespace CustomBindingFunction
{
    [DataContract]
    public class IncomingNetStandardModel
    {
        [DataMember]
        public Guid Identifier { get; set; }
    }
}
