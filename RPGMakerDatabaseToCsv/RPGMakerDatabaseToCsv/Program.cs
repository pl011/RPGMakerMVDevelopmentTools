// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using RPGMakerDatabaseToCsv;
using System.Runtime.CompilerServices;

Console.WriteLine("Generating files...");

string dataFolder = "Data";
if (args.Length > 0)
{
    dataFolder = args[0];
}

var skillsData = JsonConvert.DeserializeObject<List<Skills>>(File.ReadAllText(Path.Combine(dataFolder, "Skills.json")));
var mapInfosData = JsonConvert.DeserializeObject<List<MapInfos>>(File.ReadAllText(Path.Combine(dataFolder, "MapInfos.json")));
var classesData = JsonConvert.DeserializeObject<List<Classes>>(File.ReadAllText(Path.Combine(dataFolder, "Classes.json")));

List<SkillsTableData> skillsTableData = new List<SkillsTableData>();
foreach (var result in skillsData)
{
    if (result != null)
    {
        SkillsTableData data = new SkillsTableData();
        data.Id = result.id;
        data.Name = result.name;

        data.ClassesThatLearnThisSkill = classesData.Where(x => x != null && x.learnings.Where(x => x.skillId == data.Id).Any()).Select(x => x.name).ToList();

        skillsTableData.Add(data);
    }
}

using (StreamWriter outputFile = new StreamWriter("SkillsTable.csv"))
{
    outputFile.WriteLine("ID,Name,\"Learnt by classes\"");
    foreach (var tableData in skillsTableData)
    {
        outputFile.Write($"{tableData.Id},{tableData.Name},");
        foreach (var classData in tableData.ClassesThatLearnThisSkill)
        {
            outputFile.Write($"{classData};");
        }
        outputFile.WriteLine();
    }
}

using (StreamWriter outputFile = new StreamWriter("SkillsTable.md"))
{
    outputFile.WriteLine("|ID|Name|Learnt by classes|");
    outputFile.WriteLine("|--|----|-----------------|");
    foreach (var tableData in skillsTableData)
    {
        outputFile.Write($"|{tableData.Id}|{tableData.Name}|");
        foreach (var classData in tableData.ClassesThatLearnThisSkill)
        {
            outputFile.Write($"{classData}; ");
        }
        outputFile.WriteLine("|");
    }
}

using (StreamWriter outputFile = new StreamWriter("MapInfosTable.csv"))
{
    outputFile.WriteLine("\"Map ID\",\"Name\",\"List Order\",\"Parent/linked to ID\"");
    foreach (var result in mapInfosData)
    {
        if (result != null)
        {
            outputFile.WriteLine($"{result.id},{result.name},{result.order},{result.parentId}");
        }
    }
}

using (StreamWriter outputFile = new StreamWriter("MapInfosTable.md"))
{
    outputFile.WriteLine("|Map ID|Name|List Order|Parent/linked to ID|");
    outputFile.WriteLine("|------|----|----------|-------------------|");
    foreach (var result in mapInfosData)
    {
        if (result != null)
        {
            outputFile.WriteLine($"|{result.id}|\"{result.name}\"|{result.order}|{result.parentId}");
        }
    }   
}


Console.WriteLine("Done!");
