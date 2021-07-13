using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using HarmonyLib;
using TaleWorlds.ModuleManager;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace SkinsExtender
{
    [HarmonyPatch(typeof(Module), "CreateProcessedSkinsXMLForNative")]
    public class SkinsExtenderModule
    {
        // Get the xml file path which matches the id in every project.mbproj.
        internal static void Postfix(ref string __result)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(__result);
            List<Tuple<string, string>> list = new List<Tuple<string, string>>();
            foreach (MbObjectXmlInformation mbObjectXmlInformation in XmlResource.MbprojXmls)
            {
                if (mbObjectXmlInformation.Id == "soln_skins_extension")
                {
                    string text = ModuleHelper.GetXmlPathForNative(mbObjectXmlInformation.ModuleName, mbObjectXmlInformation.Name);
                    if (File.Exists(text))
                    {
                        list.Add(Tuple.Create<string, string>(ModuleHelper.GetXmlPathForNative(mbObjectXmlInformation.ModuleName, mbObjectXmlInformation.Name), string.Empty));
                    }
                }
            }
            XmlNode extendedXmlForNative = SkinsExtenderManager.CreateExtendedXmlFile(xmlDocument, list);
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            extendedXmlForNative.WriteTo(xmlTextWriter);
            __result = stringWriter.ToString();
        }
    }
}
