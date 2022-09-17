﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLacSo2022
{
    public class InvalidArgumentException: Exception
    {
        public InvalidArgumentException(string message): base(message) { }
        public InvalidArgumentException(string message, Exception innerException): base(message, innerException) { }
    }
}
