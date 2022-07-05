using System;

namespace qms.common;

public class commondata{
    public static Dictionary<String, String> ConstantName
    {
        get
        {
            Dictionary<String, String> ret = new Dictionary<String, String>();
            ret.Add("VehicleNo", "မော်တော်ယာဉ်အမှတ်");
            ret.Add("VehicleOwner", "ပိုင်ရှင်အမည်");
            ret.Add("ContactNo", "ဆက်သွယ်ရန်ဖုန်းနံပါတ်");
            ret.Add("counter1", "ကောင်တာ (၁)");
            ret.Add("counter2", "ကောင်တာ (၂)");
            ret.Add("counter3", "ကောင်တာ (၃)");
            ret.Add("counter4", "ကောင်တာ (၄)");
            ret.Add("counter5", "ကောင်တာ (၅)");
            ret.Add("nextToken", "နောက်လာမည့် Token အမှတ်");
            return ret;
        }
    }
}