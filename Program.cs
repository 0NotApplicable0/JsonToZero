using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

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
                        using (var jsonTextReader = new JsonTextReader(sr))
                        {
                            var json = serializer.Deserialize<Root>(jsonTextReader);
                            sr.Close();
                            json.cooldown = 0;

                            var jsonData = JsonConvert.SerializeObject(json);  
                            // var path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                            // var fileName = Path.Combine(path, "test.txt");
                            File.WriteAllText(file, jsonData);
                        }
                    }
                }
            }
        }
    }
}