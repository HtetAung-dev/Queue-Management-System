using System;
using System.Collections;
using qms.Models;

namespace qms.common.CommonFunctions;

public class TokenFunctions
{
    /// Token Generate Function
    #region GenerateToken
    public String GenerateToken(String token)
    {
        String ret = "";
        String temp = "";
        int number = 0;

        if (!String.IsNullOrEmpty(token))
        {
            number = int.Parse(token);
            number += 1;
            temp = number.ToString();
            if (temp.Length == 1)
            {
                ret = "000" + temp;
            }
            else if (temp.Length == 2)
            {
                ret = "00" + temp;
            }
            else if (temp.Length == 3)
            {
                ret = "0" + temp;
            }
            else
            {
                ret = temp;
            }

            return ret;
        }
        else
        {
            ret = "0001";
            return ret;
        }

    }
    #endregion GenerateToken
}