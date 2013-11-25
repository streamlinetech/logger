using System.Runtime.Serialization;

namespace Streamline.Logger.Models
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