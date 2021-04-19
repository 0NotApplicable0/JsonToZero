using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonToZero
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Starting App!");

            var fileDialog = new OpenFileDialog
            {
                Multiselect = true,
                Title = "Open Json Files",
            };

            using (fileDialog)
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in fileDialog.FileNames)
                    {
                        var serializer = new JsonSerializer();

                        using (var sr = new StreamReader(file))
                        {
                            var parsedJson = JObject.Parse(sr.ReadToEnd());
                            if (parsedJson.ContainsKey("cooldown"))
                            {
                                var cooldown = parsedJson["cooldown"];
                                cooldown.Replace(0);
                                sr.Close();

                                var jsonText = JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
                                File.WriteAllText(file, jsonText);
                            }
                        }
                    }
                }
            }
        }
    }
}