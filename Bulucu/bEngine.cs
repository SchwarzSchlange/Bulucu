using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Bulucu
{
    static class bEngine
    {
        public static float FindSimilarity(bText a,bText b)
        {
            float percent = 0;

            //Lenght Check
            int lengtDiff = a.Lenght - b.Lenght;

            float lengtOran = 0f;

            if(lengtDiff == 0)
            {
                lengtOran = 1f;
            }
            else if(lengtDiff < 0)
            {
                lengtOran = 1f / lengtDiff;
            }
            else if(lengtDiff > 0 )
            {
                lengtOran = 1f / lengtDiff;
            }


            //Char Check 
            float limit = 0;
            float totalFound = 0;
            
            if (a.Lenght > b.Lenght) { limit = b.Lenght; }else if(b.Lenght > a.Lenght) { limit = a.Lenght; } else { limit = a.Lenght; }
            for(int i = 0;i < limit;i++)
            {
                if (a.Value[i] == b.Value[i])
                {
                    totalFound++;
                }
                else
                {
                    if (totalFound != 0) { totalFound--; }
                }
            }


            percent = 100*((lengtOran) + (totalFound/limit))/2;


            return percent;
        }

        public static bResponse FindHighestData(bText a)
        {
            if(LoadedData.Count == 0) { return null; }
            List<bResponse> ORANLAR = new List<bResponse>();
            foreach(string data in LoadedData)
            {
                if (data[0] != a.Value[0]) { continue; }
                bText bData = new bText(data);
                float takenOran = FindSimilarity(bData,a);
                ORANLAR.Add(new bResponse { Rate = takenOran,Compered=bData});
            }


            ORANLAR.Sort((x, y) => x.Rate.CompareTo(y.Rate));

            if(ORANLAR.Count == 0) { return null; }
            ORANLAR.Last().Found = ORANLAR.Count;
            return ORANLAR.Last();
        }

        public static List<bResponse> FindData(bText a)
        {
            if(a.Value == null || a.Value == "") { return null; }
            if (LoadedData.Count == 0) { return null; }
            List<bResponse> ORANLAR = new List<bResponse>();
            foreach (string data in LoadedData)
            {
                if (data[0] != a.Value[0]) { continue; }
                bText bData = new bText(data);
                float takenOran = FindSimilarity(bData, a);
                ORANLAR.Add(new bResponse { Rate = takenOran, Compered = bData });
            }


            ORANLAR.Sort((x, y) => x.Rate.CompareTo(y.Rate));

            if (ORANLAR.Count == 0) { return null; }
            return ORANLAR;
        }

        public static List<string> LoadedData = new List<string>();
        public static void LoadData(string path)
        {
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    LoadedData.Add(line);
                }
            }
        }

        public class bResponse
        {
            public float Rate { get; set; }
            public bText Compered { get; set; }
            public int Found { get; set; }
        };
    }

    
}
