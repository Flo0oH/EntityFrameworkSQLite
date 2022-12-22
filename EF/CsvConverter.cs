using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EF
{
    internal class CsvConverter
    {
        private string paths;

        public CsvConverter(string paths)
        {
            this.paths = paths;

        }
        internal IEnumerable<string[]>[] readCsvToStringList(string paths)
        {
            try
            {
                string str = Environment.CurrentDirectory;
                string csvtest = str + @"\dependencies\LGT_2019-08-17.csv";
                string csvtest2 = str + @"\dependencies\initial.csv";
                List<string> allpaths = new List<string>();
                allpaths.Add(csvtest);
                allpaths.Add(csvtest);
                var allContents = new IEnumerable<string[]>[allpaths.Count()];
                foreach (var (path, index) in allpaths.Select((value, i) => (value, i)))
                {
                    var rarecontents = File.ReadAllText(path).Split('\n');
                    var csvdata = from line in rarecontents
                                  select line.Split(',').ToArray();
                    int headerrowscsv = allpaths.Count();
                    foreach (var rowcsv in csvdata.Skip(headerrowscsv)
                        .TakeWhile(r => r.Length > 1 && r.Last().Trim().Length > 0))
                    {
                        var parentName = rowcsv[0];
                        var quantity = rowcsv[1];
                        var componentName = rowcsv[2];
                    }
                    allContents[index] = csvdata;

                }
                return allContents;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}