using System;
using System.Collections.Generic;

namespace EF
{
    internal class CsvReader
    {
        public CsvReader()
        {

        }
        private IEnumerable<string>[] LoadContent()
        {
            //try
            //{
            //    string str = Environment.CurrentDirectory;
            //    string bompath = str + @"\dependencies\bom.csv";
            //    string partpath = str + @"\dependencies\part.csv";
            //    List<string> paths = new List<string>();
            //    paths.Add(bompath);
            //    paths.Add(partpath);
            //    var allContents = new IEnumerable<string[]>[paths.Count()];
            //    foreach (var (path, index) in paths.Select((value, i) => (value, i)))
            //    {

            //        var rarecontents = File.ReadAllText(path).Split('\n');
            //        var csvdata = from line in rarecontents
            //                      select line.Split(',').ToArray();
            //        int headerrowscsv = paths.Count();
            //        foreach (var rowcsv in csvdata.Skip(headerrowscsv)
            //            .TakeWhile(r => r.Length > 1 && r.Last().Trim().Length > 0))
            //        {
            //            var parentName = rowcsv[0];
            //            var quantity = rowcsv[1];
            //            var componentName = rowcsv[2];
            //        }
            //        allContents[index] = csvdata;
            //    }
            //    return allContents;
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.ToString());
            //}
            return null;
        }
    }
}