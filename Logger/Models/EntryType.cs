using System.Runtime.Serialization;

namespace Logger.Models
{
    [DataContract]
    public enum EntryType
    {
        [EnumMember]
        Information = 0,

        [EnumMember]
        Warning,

        [EnumMember]
        Error
    }
}