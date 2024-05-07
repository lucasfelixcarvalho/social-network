﻿using Application.InputModels;
using Application.OutputModels;
using Domain.Entities;
using Domain.Repositories;
using Infra.Auth;

namespace Application.Services;

public class AccountService(IAuthService authService, IAccountRepository repository) : IAccountService
{
    private readonly IAuthService _authService = authService;
    private readonly IAccountRepository _repository = repository;

    public ResultOutputModel<AccountDetailsOutputModel?> GetById(int id)
    {
        Account? account = _repository.GetById(id);

        if (account is null)
        {
            return ResultOutputModel<AccountDetailsOutputModel?>.Failure("Not Found");
        }

        return ResultOutputModel<AccountDetailsOutputModel?>.Success(AccountDetailsOutputModel.FromEntity(account));
    }

    public ResultOutputModel<int> Insert(CreateAccountInputModel model)
    {
        string hashedPassword = _authService.ComputeHash(model.password);
        Account account = new(model.fullname, hashedPassword, model.email, model.birth_date, model.phone_number, model.role);
        _repository.Insert(account);
        return ResultOutputModel<int>.Success(account.Id);
    }

    public ResultOutputModel<LoginOutputModel?> Login(LoginInputModel model)
    {
        string receivedPasswordHashed = _authService.ComputeHash(model.password);

        Account? account = _repository.GetByLoginAndHash(model.email, receivedPasswordHashed);

        if (account is null)
        {
            return ResultOutputModel<LoginOutputModel?>.Failure("Error");
        }

        string token = _authService.GenerateToken(account.Email, account.Role);
        return ResultOutputModel<LoginOutputModel?>.Success(new LoginOutputModel(token));
    }

    public ResultOutputModel Update(int id, UpdateAccountInputModel model)
    {
        Account? account = _repository.GetById(id);

        if (account is null)
        {
            return ResultOutputModel.Failure("Not Found");
        }

        account.Update(model.fullname, model.phone_number);
        _repository.Update(account);
        return ResultOutputModel.Success();
    }

    public ResultOutputModel UpdatePassword(int id, UpdatePasswordInputModel model)
    {
        Account? account = _repository.GetById(id);

        if (account is null)
        {
            return ResultOutputModel.Failure("Not Found");
        }

        string receivedPasswordHashed = _authService.ComputeHash(model.new_password);
        account.UpdatePassword(receivedPasswordHashed);
        _repository.Update(account);
        return ResultOutputModel.Success();
    }
}
