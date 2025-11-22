using MediatR;
using ServiceHub.Api.Domain.Common;

namespace ServiceHub.Api.Application.UseCase.Empresa.RemoverEmpresa;

public record Command(string id_empresa) : IRequest<Result>;