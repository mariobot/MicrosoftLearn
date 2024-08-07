﻿using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorProducts.Server.Repository
{
    public interface ITransactionRepository
    {
        Task AddTransaction(Transaction transaction);
        List<Transaction> GetAllTransactions();
    }
}
