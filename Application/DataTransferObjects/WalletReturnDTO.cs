﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects
{
    public class WalletReturnDTO
    {
        public string Email { get; set; } 
        public long WalletNumber { get; set; }
        public long USDbalance     { get; set; }
        public long NGNbalance { get; set; }

    }
}
