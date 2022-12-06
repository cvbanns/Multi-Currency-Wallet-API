<<<<<<< HEAD

=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using WalletApp.Abstractions.Repositories;
using WalletApp.Abstractions.Services;
using WalletApp.Models.DTO;
using WalletApp.Utils;

namespace WalletApp.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ITransactionService _transactionService;

        public WalletService(IWalletRepository walletRepository, ITransactionService transactionService)
        {
            _walletRepository = walletRepository;
            _transactionService = transactionService;
        }
        
        public async Task<string> CreateWalletAsync()
        {
            var address = await _walletRepository.CreateWalletAsync();
            return address;
        }

        public async Task<bool> DepositAsync(DepositDto deposit)
        {
            if(deposit.Amount < 1) return false;
            var deposited = await _walletRepository.DepositAsync(deposit);
            return deposited;   
        }

        public async Task<bool> WithdrawAsync(DepositDto withdraw)
        {
            if (withdraw.Amount < 1) return false;
            var withdrawn = await _walletRepository.WithdrawAsync(withdraw);
            return withdrawn;
        }

        public async Task<bool> TransferAsync(TransferDto transfer)
        {
            if (transfer.Amount < 1) return false;
            var transferred = await _walletRepository.TransferAsync(transfer);
            return transferred;
        }


        

    }
}
