using FluentValidation.Results;
using System.Collections.Generic;

namespace UltimatR
{
    public interface ICommandSet<TDto> : ICommandSet where TDto : Dto
    {
        public new IEnumerable<DtoCommand<TDto>> Commands { get; }
    }

    public interface ICommandSet : IDataIO
    {
        public IEnumerable<ICommand> Commands { get; }

        public ValidationResult Result { get; set; }
    }
}