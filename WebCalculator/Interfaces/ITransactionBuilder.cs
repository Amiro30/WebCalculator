﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebCalculator.Models;

namespace WebCalculator.Interfaces
{
    public interface ITransactionBuilder
    {
        Operation TransactionCreate(Operation data);
    }
}
