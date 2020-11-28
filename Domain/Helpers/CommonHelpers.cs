using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Helpers
{
    public static class CommonHelpers
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}
