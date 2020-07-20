using UTEHY.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTEHY.Model.Entities;
using UTEHY.Model.ViewModel;
using UTEHY.Infrastructure.Interfaces;

namespace UTEHY.Service.Implementation
{
    public class CommandService : ICommandService
    {
        private IRepositoryBase<Command, string> _commandRepository;
        public CommandService(IRepositoryBase<Command,string> commandRepository)
        {
            _commandRepository = commandRepository;
        }
        public List<CommandViewModel> GetAll()
        {
            var result = _commandRepository.FindAll().Select(x => new CommandViewModel()
            {
                CommandId = x.CommandId,
                Name = x.Name
            });
            return result.ToList();
        }

    }
}
