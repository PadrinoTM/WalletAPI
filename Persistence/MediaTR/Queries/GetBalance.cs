using Application.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.MediaTR.Queries
{
    public sealed record GetBalance (ViewBalanceDTO viewBal, bool TrackChanges):
        IRequest<BalanceDTO>
    {
    }
}
