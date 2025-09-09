using System.Text.Json.Serialization;

namespace MunicipalApplication.Models
{
    public class Issue
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime DateReported { get; set; } = DateTime.Now;
        public string Location { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [JsonIgnore]
        public LinkedList<string> ImagePaths { get; set; } = new LinkedList<string>();

        public string[] ImagePathsSerialized
        {
            get
            {
                var array = new string[ImagePaths.Count];
                int i = 0;
                foreach (var path in ImagePaths)
                {
                    array[i++] = path;
                    return array;
                }
            }
            set
            {
                ImagePaths = new LinkedList<string>(value);
                if (ImagePaths == null) return;
                foreach (var paths in value) ImagePaths.AddLast(paths);
            }
        }
    }
}
