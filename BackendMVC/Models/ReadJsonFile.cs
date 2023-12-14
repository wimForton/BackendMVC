using System.Text.Json;

namespace BackendMVC.Models
{
    public static class ReadJsonFile
    {

        public static void load(string url = "")
        {

            string fileName = "midiData/maestro-v3.0.0.json";
            string jsonString = File.ReadAllText(fileName);
            MidiDataObject midiDataObject = JsonSerializer.Deserialize<MidiDataObject>(jsonString)!;


            Console.WriteLine($"versie: {midiDataObject.versie}");
            Console.WriteLine($"Composers: {midiDataObject.canonicalComposer.Count}");

            for (int i = 0; i < 20; i++)//midiDataObject.midiFilename.Count
            {
                Console.WriteLine($"canonicalComposer {i + 1}: {midiDataObject.canonicalComposer[i]}");
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"canonicalTitle {i + 1}: {midiDataObject.canonicalTitle[i]}");
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"split {i + 1}: {midiDataObject.split[i]}");
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"Composer {i + 1}: {midiDataObject.year[i]}");
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"midiFilename {i + 1}: {midiDataObject.midiFilename[i]}");
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"audioFilename {i + 1}: {midiDataObject.audioFilename[i]}");
            }
            Console.WriteLine();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"duration {i + 1}: {midiDataObject.duration[i]}");
            }

        }
    }

    public class MidiDataObject
    {

        public string? versie { get; set; }
        public Dictionary<int, string> canonicalComposer { get; set; }
        public Dictionary<int, string> canonicalTitle { get; set; }
        public Dictionary<int, string> split { get; set; }
        public Dictionary<int, int> year { get; set; }
        public Dictionary<int, string> midiFilename { get; set; }
        public Dictionary<int, string> audioFilename { get; set; }
        public Dictionary<int, float> duration { get; set; }

        public MidiDataObject()
        {
            versie = null;
            canonicalComposer = new Dictionary<int, string>();
            canonicalTitle = new Dictionary<int, string>();
            split = new Dictionary<int, string>();
            year = new Dictionary<int, int>();
            midiFilename = new Dictionary<int, string>();
            audioFilename = new Dictionary<int, string>();
            duration = new Dictionary<int, float>();
        }
    }
}
