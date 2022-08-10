using System;

namespace qms.common;

public class commondata
{

    public static String GetConnectionStr
    {
        get
        {
            return "server=localhost;database=qmsdb;user=root;password=HtetAung19820;";
        }
    }
    public static Dictionary<String, String> ConstantName
    {
        get
        {
            Dictionary<String, String> ret = new Dictionary<String, String>();
            ret.Add("VehicleNo", "မော်တော်ယာဉ်အမှတ်");
            ret.Add("TokenNo", "တုံကင်နံပါတ်");
            ret.Add("VehicleOwner", "ပိုင်ရှင်အမည်");
            ret.Add("ContactNo", "ဖုန်းနံပါတ်");
            ret.Add("CreatedDate", "ရက်စွဲ");
            ret.Add("counter1", "ကောင်တာ (၁)");
            ret.Add("counter2", "ကောင်တာ (၂)");
            ret.Add("counter3", "ကောင်တာ (၃)");
            ret.Add("counter4", "ကောင်တာ (၄)");
            ret.Add("counter5", "ကောင်တာ (၅)");
            ret.Add("nextToken", "နောက်လာမည့် Token အမှတ်");
            ret.Add("MCDC", "မန္တလေးမြို့တော်စည်ပင်သာယာရေးကော်မတီ");
            return ret;
        }
    }

    public static Dictionary<Int32, String> counters
    {
        get
        {
            Dictionary<int, String> ret = new Dictionary<int, string>();
            ret.Add(1, "counter1");
            ret.Add(2, "counter2");
            ret.Add(3, "counter3");
            ret.Add(4, "counter4");
            ret.Add(5, "counter5");
            return ret;
        }
    }


}