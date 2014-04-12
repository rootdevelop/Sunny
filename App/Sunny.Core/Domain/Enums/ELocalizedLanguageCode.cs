using System.Xml.Serialization;

namespace Sunny.Core.Domain.Enums
{
    public enum ELocalizedLanguageCode
    {
        [XmlEnum(Name = "en_US")]
        // ReSharper disable once InconsistentNaming
        enUS = 0,
    }
}
