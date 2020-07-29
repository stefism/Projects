using AutoMapper;
using AutoMapper.QueryableExtensions;
using PetStore.Data;
using PetStore.Models;
using PetStore.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PetStore.Services
{
    public class ClientService
    {
        private readonly PetStoreDbContext dbContext;
        private readonly IMapper mapper;

        public ClientService(PetStoreDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddClient(AddClientViewModel clientToAdd)
        {
            Client client = mapper.Map<Client>(clientToAdd);

            var hashedPassword = ComputeSha256Hash(client.Password);
            client.Password = hashedPassword;
            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
        }

        public ICollection<GetAllClientViewModel> GetAllClients()
        {
            var allClients = dbContext.Clients
                .ProjectTo<GetAllClientViewModel>(mapper.ConfigurationProvider).ToList();

            return allClients;
        }

        private static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
