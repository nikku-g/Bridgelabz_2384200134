using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

class Program
{
    static void Main()
    {
        string jsonInputPath = "ipl_matches.json";
        string csvInputPath = "ipl_matches.csv";
        string jsonOutputPath = "censored_ipl_matches.json";
        string csvOutputPath = "censored_ipl_matches.csv";

        // Process JSON
        if (File.Exists(jsonInputPath))
        {
            var matches = ReadJson(jsonInputPath);
            var censoredMatches = ApplyCensorship(matches);
            WriteJson(jsonOutputPath, censoredMatches);
        }

        // Process CSV
        if (File.Exists(csvInputPath))
        {
            var matches = ReadCsv(csvInputPath);
            var censoredMatches = ApplyCensorship(matches);
            WriteCsv(csvOutputPath, censoredMatches);
        }
    }

    static List<Match> ReadJson(string path)
    {
        string json = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<List<Match>>(json) ?? new List<Match>();
    }

    static void WriteJson(string path, List<Match> matches)
    {
        string json = JsonConvert.SerializeObject(matches, Formatting.Indented);
        File.WriteAllText(path, json);
    }

    static List<Match> ReadCsv(string path)
    {
        using var reader = new StreamReader(path);
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        return csv.GetRecords<Match>().ToList();
    }

    static void WriteCsv(string path, List<Match> matches)
    {
        using var writer = new StreamWriter(path);
        using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
        csv.WriteRecords(matches);
    }

    static List<Match> ApplyCensorship(List<Match> matches)
    {
        return matches.Select(m => new Match
        {
            MatchId = m.MatchId,
            Team1 = MaskTeamName(m.Team1),
            Team2 = MaskTeamName(m.Team2),
            Winner = MaskTeamName(m.Winner),
            PlayerOfTheMatch = "REDACTED"
        }).ToList();
    }

    static string MaskTeamName(string team)
    {
        if (string.IsNullOrEmpty(team)) return team;
        string[] parts = team.Split(' ');
        return parts.Length > 1 ? string.Join(" ", parts[0], "***") : team;
    }
}

class Match
{
    public int MatchId { get; set; }
    public string Team1 { get; set; }
    public string Team2 { get; set; }
    public string Winner { get; set; }
    public string PlayerOfTheMatch { get; set; }
}
