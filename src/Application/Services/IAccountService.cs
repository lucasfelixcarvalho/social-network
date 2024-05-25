using Application.InputModels;
using Application.OutputModels;

namespace Application.Services;

public interface IAccountService
{
    ResultOutputModel<int> Insert(CreateAccountInputModel model);
    ResultOutputModel UpdatePassword(int id, UpdatePasswordInputModel model);
    ResultOutputModel Update(int id, UpdateAccountInputModel model);
    ResultOutputModel<LoginOutputModel?> Login(LoginInputModel model);
    ResultOutputModel<AccountDetailsOutputModel?> GetById(int id);
}
