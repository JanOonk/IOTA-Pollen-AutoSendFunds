﻿using System;
using System.Collections.Generic;
using RestSharp;
using SharedLib.Interfaces;
using SharedLib.Models;

namespace SharedLib.Services
{
    public class AddressService : IAddressService
    {
        private readonly ICrudRepo<Address> _addressRepo;
        readonly RestClient _dashboardClient;

        public AddressService(ICrudRepo<Address> addressRepo)
        {
            if (addressRepo == null) throw new ArgumentException("Argument addressRepo can not be null!");

            _addressRepo = addressRepo;
            _dashboardClient = null;
        }

        public AddressService(ICrudRepo<Address> addressRepo, string dashboardUrl) : this(addressRepo)
        {
            if (dashboardUrl == null) throw new ArgumentException("Argument dashboardUrl can not be null");

            _dashboardClient = new RestClient(dashboardUrl);
        }

        public HashSet<Address> GetAll(bool verifyIfReceiveAddressesExist = false)
        {
            HashSet<Address> receiveAddresses = _addressRepo.GetAll();

            if (verifyIfReceiveAddressesExist)
            {
                foreach (Address address in receiveAddresses)
                {
                    address.IsVerified = AddressExist(address.AddressValue);
                }
            }

            return receiveAddresses;
        }

        public bool Add(Address address)
        {
            return _addressRepo.Add(address);
        }

        public bool Delete(string addressValue)
        {
            return _addressRepo.Delete(addressValue);
        }

        public bool Contains(string addressValue)
        {
            return _addressRepo.Contains(addressValue);
        }

        public bool AddressExist(string addressValue)
        {
            if (_dashboardClient == null) throw new ArgumentException("DashboardUrl is not set, can not verify address");

            string url = $"/api/address/{addressValue}";
            var request = new RestRequest(url, DataFormat.Json);

            //check if address really exist using the GoShimmer Dashboard
            IRestResponse response = _dashboardClient.Get(request);
            return response.IsSuccessful;
        }
    }
}
