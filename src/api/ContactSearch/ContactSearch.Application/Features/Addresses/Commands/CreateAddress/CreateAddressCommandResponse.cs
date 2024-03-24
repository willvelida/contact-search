using ContactSearch.Application.Responses;

namespace ContactSearch.Application.Features.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommandResponse : BaseResponse
    {
        public CreateAddressCommandResponse() : base()
        {

        }

        public CreateAddressDto Address { get; set; } = default!;
    }
}
