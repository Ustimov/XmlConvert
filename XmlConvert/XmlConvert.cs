/*
 *  Created by Artem Ustimov (art@ustimov.org) on 22/10/2016.
 */

using System;
using System.IO;
using System.Xml.Serialization;

namespace Ustimov.Org.XmlConvert
{
    public static class XmlConvert
    {
        public static string SerializeObject<T>(T obj,
                                                string defaultNamespace = null,
                                                XmlSerializerNamespaces namespaces = null,
                                                Type[] knownTypes = null)
        {
            var xmlSerializer = new XmlSerializer(typeof(T), null, knownTypes, null, defaultNamespace);

            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, obj, namespaces);
                return stringWriter.ToString();
            }
        }

        public static T DeserializeObject<T>(string xml,
                                             string defaultNamespace = null,
                                             Type[] knownTypes = null)
        {
            var xmlSerializer = new XmlSerializer(typeof(T), null, knownTypes, null, defaultNamespace);

            using (var stringReader = new StringReader(xml))
            {
                return (T)xmlSerializer.Deserialize(stringReader);
            }
        }
    }
}
