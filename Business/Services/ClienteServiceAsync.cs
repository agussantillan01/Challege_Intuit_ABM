using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ClienteServiceAsync
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public ClienteServiceAsync(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
        }

    }
}
