﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvertApi.ServiceClients
{
    public interface IAdvertApiClient
    {
        Task<AdvertResponse> CreateAsync(CreateAdvertModel model);
        Task<bool> ConfirmAsync(ConfirmAdvertRequest model);
        //Task<List<Advertisement>> GetAllAsync();
        //Task<Advertisement> GetAsync(string advertId);
    }
}