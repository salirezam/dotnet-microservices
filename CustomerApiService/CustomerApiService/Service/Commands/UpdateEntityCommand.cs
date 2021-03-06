﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Commands
{
    public class UpdateEntityCommand<T>: IRequest<T>
        where T : class, IEntity
    {
        public T Entity { get; set; }
    }
}
