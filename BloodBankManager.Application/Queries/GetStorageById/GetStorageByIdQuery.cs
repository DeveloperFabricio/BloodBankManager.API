using BloodBankManager.Application.Models.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Application.Queries.GetStorageById
{
    public class GetStorageByIdQuery : IRequest<BloodStorageViewModel>
    {
        public GetStorageByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
