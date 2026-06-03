using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace TK_ParkServer
{
    static class MarketInterfaceLog
    {
        private const int MaxLogCount = 1000;
        private static readonly object syncRoot = new object();
        private static readonly List<MarketInterfaceLogEntry> entries = new List<MarketInterfaceLogEntry>();
        private static readonly System.Timers.Timer saveTimer = new System.Timers.Timer(600000);
        private static bool unsavedLogs;
        private static string activeLogFilePath;

        static MarketInterfaceLog()
        {
            saveTimer.AutoReset = true;
            saveTimer.Elapsed += saveTimer_Elapsed;
        }

        public static void Load()
        {
            lock (syncRoot)
            {
                entries.Clear();
                activeLogFilePath = GetLatestLogFilePath();

                if (!string.IsNullOrEmpty(activeLogFilePath))
                {
                    foreach (MarketInterfaceLogEntry entry in ReadLogFile(activeLogFilePath).Take(MaxLogCount))
                    {
                        entries.Add(entry);
                    }

                    TrimEntries();
                }

                unsavedLogs = false;
            }

            saveTimer.Start();
        }

        public static void Add(string description)
        {
            lock (syncRoot)
            {
                entries.Add(new MarketInterfaceLogEntry(DateTime.Now, description));
                if (TrimEntries())
                {
                    activeLogFilePath = null;
                }

                unsavedLogs = true;
            }
        }

        public static List<string> GetDisplayEntries()
        {
            lock (syncRoot)
            {
                return entries.Select(entry => entry.ToDisplayString()).ToList();
            }
        }

        public static void Save()
        {
            List<MarketInterfaceLogEntry> snapshot;
            string logFilePath;

            lock (syncRoot)
            {
                if (!unsavedLogs || entries.Count == 0)
                {
                    return;
                }

                snapshot = entries.ToList();
                logFilePath = activeLogFilePath;
                unsavedLogs = false;
            }

            try
            {
                Directory.CreateDirectory(GetLogFolderPath());

                if (string.IsNullOrEmpty(logFilePath))
                {
                    logFilePath = GetLogFilePath(snapshot.First().Timestamp);
                }

                File.WriteAllLines(logFilePath, CreateCsvLines(snapshot).ToArray(), Encoding.UTF8);

                lock (syncRoot)
                {
                    activeLogFilePath = logFilePath;
                }
            }
            catch
            {
                lock (syncRoot)
                {
                    unsavedLogs = true;
                }
            }
        }

        public static void Stop()
        {
            saveTimer.Stop();
            Save();
        }

        private static void saveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Save();
        }

        private static string GetLatestLogFilePath()
        {
            string logFolderPath = GetLogFolderPath();
            if (!Directory.Exists(logFolderPath))
            {
                return null;
            }

            return Directory.GetFiles(logFolderPath, "MarketLog_*.csv")
                .OrderByDescending(File.GetLastWriteTime)
                .FirstOrDefault();
        }

        private static bool TrimEntries()
        {
            bool trimmed = false;
            DateTime oldestAllowedTimestamp = DateTime.Now.AddMonths(-1);

            while (entries.Count > 0 && entries[0].Timestamp < oldestAllowedTimestamp)
            {
                entries.RemoveAt(0);
                trimmed = true;
            }

            while (entries.Count > MaxLogCount)
            {
                entries.RemoveAt(0);
                trimmed = true;
            }

            return trimmed;
        }

        private static string GetLogFolderPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        }

        private static string GetLogFilePath(DateTime firstTimestamp)
        {
            string fileName = string.Format(
                "MarketLog_{0}.csv",
                firstTimestamp.ToString("yyMMdd_HHmmss", CultureInfo.InvariantCulture));

            return Path.Combine(GetLogFolderPath(), fileName);
        }

        private static IEnumerable<string> CreateCsvLines(IEnumerable<MarketInterfaceLogEntry> logEntries)
        {
            yield return "Timestamp,Description";

            foreach (MarketInterfaceLogEntry entry in logEntries)
            {
                yield return EscapeCsv(entry.Timestamp.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)) + "," +
                    EscapeCsv(entry.Description);
            }
        }

        private static IEnumerable<MarketInterfaceLogEntry> ReadLogFile(string filePath)
        {
            foreach (string line in File.ReadAllLines(filePath, Encoding.UTF8).Skip(1))
            {
                string[] values = SplitCsvLine(line);
                if (values.Length < 2)
                {
                    continue;
                }

                DateTime timestamp;
                if (!DateTime.TryParseExact(values[0], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out timestamp))
                {
                    continue;
                }

                yield return new MarketInterfaceLogEntry(timestamp, values[1]);
            }
        }

        private static string EscapeCsv(string value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\r") || value.Contains("\n"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }

            return value;
        }

        private static string[] SplitCsvLine(string line)
        {
            List<string> values = new List<string>();
            StringBuilder value = new StringBuilder();
            bool quoted = false;

            for (int i = 0; i < line.Length; i++)
            {
                char character = line[i];
                if (quoted)
                {
                    if (character == '"' && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        value.Append('"');
                        i++;
                    }
                    else if (character == '"')
                    {
                        quoted = false;
                    }
                    else
                    {
                        value.Append(character);
                    }
                }
                else if (character == ',')
                {
                    values.Add(value.ToString());
                    value.Length = 0;
                }
                else if (character == '"')
                {
                    quoted = true;
                }
                else
                {
                    value.Append(character);
                }
            }

            values.Add(value.ToString());
            return values.ToArray();
        }

        private sealed class MarketInterfaceLogEntry
        {
            public MarketInterfaceLogEntry(DateTime timestamp, string description)
            {
                Timestamp = timestamp;
                Description = description;
            }

            public DateTime Timestamp { get; private set; }
            public string Description { get; private set; }

            public string ToDisplayString()
            {
                return Timestamp.ToString("MM.dd HH:mm:ss", CultureInfo.InvariantCulture) + " " + Description;
            }
        }
    }
}
