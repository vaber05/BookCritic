using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCriticsApplication.Modules.BookModules.Commands;

public class RemoveBook : IRequest<bool>
{
    public int BookId { get; set; }
}
