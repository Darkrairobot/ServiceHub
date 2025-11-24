using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Usuario.RealizarLogin;

public record Command(string email, string senha) : IRequest<Result<Response>>;