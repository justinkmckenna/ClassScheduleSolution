namespace ClassScheduleApi.Adapters;

public class FileScheduleAdapter
{
    private readonly Dictionary<string, List<ClassInstanceModel>> _models = new Dictionary<string, List<ClassInstanceModel>>();
    public FileScheduleAdapter()
    {
        var file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Schedule", "schedule.json");
        using var stream = new StreamReader(file);
        string json = stream.ReadToEnd();
        var items = JsonSerializer.Deserialize<List<StoredScheduleItem>>(json);
        if (items != null)
        {
            foreach (var item in items)
            {
                if (!_models.ContainsKey(item.id))
                {
                    _models.Add(item.id, new List<ClassInstanceModel>());
                }
                var startDate = DateTime.Parse(item.StartDate);
                var endDate = DateTime.Parse(item.EndDate);
                var newItem = new ClassInstanceModel(DateTime.Parse(item.StartDate), DateTime.Parse(item.EndDate), (endDate - startDate).Days);
                _models[item.id].Add(newItem);
            }
        }
    }

    public ClassListModel GetClassList()
    {
        return new ClassListModel(_models);
    }

    public List<ClassInstanceModel>? GetScheduleForClass(string id)
    {
        if(_models.ContainsKey(id))
        {
            return _models[id];
        } else
        {
            return null;
        }
    }
}

public class StoredScheduleItem
{
    public string id { get; set; } = string.Empty;
    public string title { get; set; } = string.Empty;
    [JsonPropertyName("Start Date")]
    public string StartDate { get; set; }
    [JsonPropertyName("End Date")]
    public string EndDate { get; set; }
}