namespace ClassScheduleApi.Models;

// record is equivelantt to having a class with getters, setters, and a constructor. This saves code.
public record ClassInstanceModel(DateTime startDate, DateTime endDate);

public record ClassListModel(Dictionary<string, List<ClassInstanceModel>> data);  