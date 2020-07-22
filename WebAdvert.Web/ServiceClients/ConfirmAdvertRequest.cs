using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertApi.Models;

namespace AdvertApi.ServiceClients
{
    public class ConfirmAdvertRequest
    {
        public string Id { get; set; }
        public string FilePath { get; set; }
        public AdvertStatus Status { get; set; }
    }
}
