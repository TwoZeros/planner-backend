using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planner.Data.Contract.Repositories;
using Planner.Models;
using Planner.Services.Contract;
using Planner.Services.Contract.Dto;
using Planner.Services.Infrastructure.Mappers;

namespace Planner.Services
{

    public class ClientService : IClientService
    {
        public IClientRepository _repo;

        private readonly IClientDetailMapper _detailMapper;
        private readonly IClientListMapper _listMapper;
        public ClientService(IClientRepository repo, IClientDetailMapper detailMapper, IClientListMapper listMapper)
        {
            _detailMapper = detailMapper;
            _listMapper = listMapper;
            _repo = repo;

        }
        public async Task<ClientDetailDto> GetById(int id)
        {
            var client = await _repo.GetClientInfo(id);
            var clientDto = _detailMapper.Map<Client, ClientDetailDto>(client);

            return clientDto;
        }

        public List<ClientListDto> GetAll()
        {
            var client = _repo.GetListClient();
            return _listMapper.Map<List<Client>, List<ClientListDto>>(client);
        }

        public async Task<string> Delete(int id)
        {
            var employee = await _repo.GetClientInfo(id);
            if (employee != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";

        }
        public async Task AddClient(Client client)
        {
            client.CreatedDate = DateTime.Now;
            _repo.Add(client);
            await _repo.SaveAsync();
        }

        public void PutClient(int id, Client client)
        {
            _repo.PutClient(client);
        }
        public void PutClientPhoto(int id, Client client)
        {
            _repo.PutClientPhoto(client);
        }
        public ClientsByDayDto GetClientsAndDay()
        {
            var dates = _repo.GetDates();

            if (dates.Count == 0)
                return null;

            var datesString = new List<string>();
            var clientscount = new List<int>();

            foreach (var date in dates)
            {
                datesString.Add(date.ToString("d"));
                clientscount.Add(_repo.GetClientCountByDate(date));
            }

            return new ClientsByDayDto { Count = clientscount, Date = datesString };
        }
    }
}
