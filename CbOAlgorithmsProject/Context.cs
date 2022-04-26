using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace CbOAlgorithms
{
    public class NonExistentObjectException : Exception
    {
        public NonExistentObjectException(string message)
            : base(message)
        {
        }
    }

    public class Context
    {
        private static readonly Random Rnd = new Random();

        public Context(string filePath)
        {
            G = new List<string>();
            M = new List<string>();
            Table = new List<List<bool>>();
            var ext = filePath.Substring(filePath.LastIndexOf('.') + 1);
            switch (ext)
            {
                case "xlsx":
                case "xls":
                {
                    Application excel = null;
                    Workbook workbook = null;

                    try
                    {
                        excel = new Application();
                        workbook = excel.Workbooks.Open(filePath);
                        var sheet = (Worksheet) workbook.Sheets[1];
                        sheet.Columns.ClearFormats();
                        sheet.Rows.ClearFormats();

                        var rowCount = sheet.UsedRange.Rows.Count;
                        var colCount = sheet.UsedRange.Columns.Count;
                        if (rowCount < 2 || colCount < 2) throw new Exception("Bad format!");

                        foreach (var obj in (object[,]) sheet.Range[sheet.Cells[2, 1], sheet.Cells[rowCount, 1]].Value)
                            G.Add(obj.ToString());

                        foreach (var attr in (object[,]) sheet.Range[sheet.Cells[1, 2], sheet.Cells[1, colCount]].Value)
                            M.Add(attr.ToString());

                        if (G.Contains("")) throw new Exception("In column of objects the cell is empty");
                        if (M.Contains("")) throw new Exception("In row of sign the ell is empty");

                        var arrData = (object[,]) sheet.Range[sheet.Cells[2, 2], sheet.Cells[rowCount, colCount]].Value;
                        for (var i = 1; i < rowCount; i++)
                        {
                            Table.Add(new List<bool>());
                            for (var j = 1; j < colCount; j++)
                            {
                                Table[i - 1].Add(arrData[i, j] != null);
                            }
                        }

                        workbook.Close(false);
                        excel.Quit();
                    }
                    catch (Exception)
                    {
                        workbook?.Close(false);
                        excel?.Quit();
                        throw new Exception("Incorrect file format!");
                    }

                    break;
                }
                case "csv":
                    break;
            }
        }

        public Context(int objCount, int attrCount)
        {
            G = new List<string>();
            M = new List<string>();
            Table = new List<List<bool>>();

            for (var i = 0; i < objCount; i++) G.Add((i + 1).ToString());
            for (var i = 0; i < attrCount; i++) M.Add(NumToLettersConvertor(i));
            for (var i = 0; i < objCount; i++)
            {
                Table.Add(new List<bool>());
                for (var j = 0; j < attrCount; j++) Table[i].Add(false);
            }
        }

        public List<string> G { get; set; }
        public List<string> M { get; set; }
        public List<List<bool>> Table { get; set; }


        private string NumToLettersConvertor(int number)
        {
            var result = "";
            result = char.ConvertFromUtf32(97 + number % 26) + result;
            number /= 26;

            while (number > 0)
            {
                result = char.ConvertFromUtf32(97 + number % 26 - 1) + result;
                number /= 26;
            }

            return result;
        }

       /// <summary>
       /// Нахождение признаков
       /// </summary>
       /// <param name="objects"></param>
        public List<string> GaluaOperatorUp(List<string> objects)
        {
            if (!objects.Any())
            {
                return M;
            }
            var attributes = new List<string>();
            var objAttr = (from obj in objects
                select G.IndexOf(obj)
                into index
                select Table[index]
                into flags
                select M.Where((t, i) => flags[i]).ToList()).ToList();
            var attrIntersec = new List<string>();
            if (objAttr.Count <= 0) return attrIntersec;
            {
                attrIntersec.AddRange(objAttr[0]);
                for (var i = 1; i < objAttr.Count; i++) attrIntersec = attrIntersec.Intersect(objAttr[i]).ToList();
            }
            return attrIntersec;
        }

        /// <summary>
        /// Нахождение объектов
        /// </summary>
        /// <param name="attributes"></param>
        public List<string> GaluaOperatorFromObjectToSign(List<string> attributes)
        {
            var objIntersec = new List<string>();
            if (attributes.Contains(null))
            {
                return objIntersec;
            }
            var listAttributes = (from attr in attributes
                select M.IndexOf(attr)
                into index
                select Table.Select(it => it[index]).ToList()
                into flags
                select G.Where((t, i) => flags[i]).ToList()).ToList();

            if (listAttributes.Count <= 0) return objIntersec;
            {
                objIntersec.AddRange(listAttributes[0]);
                for (var i = 1; i < listAttributes.Count; i++)
                    objIntersec = objIntersec.Intersect(listAttributes[i]).ToList();
            }
            return objIntersec;
        }


        public static Context RandomContext(int objectCount, int attributeCount, double threshold = 0.5)
        {
            var result = new Context(objectCount, attributeCount);
            foreach (var str in result.Table)
            {
                for (var j = 0; j < str.Count; j++)
                {
                    if (Rnd.NextDouble() < threshold) str[j] = false;
                    else str[j] = true;
                }
            }

            return result;
        }
    }
}