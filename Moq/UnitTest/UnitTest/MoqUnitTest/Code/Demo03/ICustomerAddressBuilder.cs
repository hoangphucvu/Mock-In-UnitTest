namespace MoqUnitTest.Code.Demo03
{
    public interface ICustomerAddressBuilder
    {
        Address From(CustomerToCreateDto customerToCreate);
    }
}