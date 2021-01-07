using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TripleDes.Dto;

namespace TripleDes
{
    public static  class BranchCode
    {

        public static string  GetBranchName(string code)

           
        {
            
            var wrd = Directory.GetParent(".").Parent.Parent + "/code/branch.json";
           

                using (StreamReader r = new StreamReader(wrd))
                {
                    string value = r.ReadToEnd();
                  
                    var allCode = JsonConvert.DeserializeObject<List<BranchDto>>(value);

                var  bankBranch= allCode.Where(x =>x.BranchCode == code ).FirstOrDefault();
                return bankBranch.BranchName;
                }

          


        } 
    }
}
