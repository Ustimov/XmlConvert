/*
 *  Created by Artem Ustimov (art@ustimov.org) on 22/10/2016.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Ustimov.Org.XmlConvert
{
    public static class XmlConvert
    {
        public static string SerializeObject<T>(T obj,
                                                string defaultNamespace = null,
                                                IDictionary<string, string> namespaces = null,
                                                Type[] knownTypes = null)
        {
            var xmlSerializer = new XmlSerializer(typeof(T), null, knownTypes, null, defaultNamespace);

            var xmlSerializerNamespaces = new XmlSerializerNamespaces();

            if (namespaces != null)
            {
                foreach (var ns in namespaces)
                {
                    xmlSerializerNamespaces.Add(ns.Key, ns.Value);
                }
            }

            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, obj, xmlSerializerNamespaces);
                return stringWriter.ToString();
            }
        }

        public static T DeserializeObject<T>(string xml,
                                             string defaultNamespace = null,
                                             IDictionary<string, string> namespaces = null,
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
