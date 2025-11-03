using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CNDP.Basic
{
    //test01
    public static class RegexHelper
    {
        private const string _dateTimePattern = @"[1-9]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][0-9]|3[0-1])\s+(20|21|22|23|[0-1]\d):[0-5]\d:[0-5]\d";

        public static string MatchDateTime(string value)
        {
            return "O21222111AAA";
        }
    }
}
