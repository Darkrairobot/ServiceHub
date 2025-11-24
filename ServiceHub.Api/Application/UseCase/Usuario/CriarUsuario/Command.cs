using System.ComponentModel.DataAnnotations;
using MediatR;
using ServiceHub.Api.Domain.Common;
using ServiceHub.Api.Domain.Entities;

namespace ServiceHub.Api.Application.UseCase.Usuario.CriarUsuario;

public record Command(string nome, string email, string telefone, string senha) : IRequest<Result>;